using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Mime;
using InterceptionPoC.Common;
using InterceptionPoC.Services;
using Microsoft.Practices.Unity.InterceptionExtension;
using System.Web.Script.Serialization;

namespace InterceptionPoC.Interceptor
{
    class LoggingInterceptionBehavior : IInterceptionBehavior
    {
        ILogService Logger;

        public LoggingInterceptionBehavior(ILogService logger)
        {
            Logger = logger;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            bool loggingAttribute = Attribute.IsDefined(input.MethodBase, typeof(LoggingAttribute));
            if (loggingAttribute)
            {
                PreProcess(input);
            }

            // Invoke the next behavior in the chain.
            var result = getNext()(input, getNext);

            if (loggingAttribute)
            {
                PostProcess(input, result);
            }


            return result;
        }

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public bool WillExecute
        {
            get { return true; }
        }


        private void PreProcess(IMethodInvocation input)
        {
            string message = string.Format("[{0}.{1}] {2} start: ", input.MethodBase.ReflectedType.Namespace, input.MethodBase.ReflectedType.Name, input.MethodBase.Name);
            LoggingAttribute attributeInfo = (LoggingAttribute)Attribute.GetCustomAttributes(input.MethodBase, typeof(LoggingAttribute)).SingleOrDefault();
            if (attributeInfo != null && attributeInfo.LogParameters)
            {
                message += GetParametersText(input.Arguments);
            }
            WriteLog(message);

        }

        private void PostProcessException(IMethodInvocation input, IMethodReturn result)
        {
            AddExceptionData(input, result.Exception);
            string message = string.Format("[{0}.{1}] {2} [Exception]: {3}",
                input.MethodBase.ReflectedType.Namespace, input.MethodBase.ReflectedType.Name, input.MethodBase.Name,
                result.Exception);
            WriteLog(message);

        }

        private void PostProcess(IMethodInvocation input, IMethodReturn result)
        {
            if (result.Exception != null)
            {
                PostProcessException(input, result);
            }
            else
            {
                string message = string.Format("[{0}.{1}] {2} finish: ", input.MethodBase.ReflectedType.Namespace, input.MethodBase.ReflectedType.Name, input.MethodBase.Name);
                bool loggingAttribute = Attribute.IsDefined(input.MethodBase, typeof(LoggingAttribute));
                if (loggingAttribute)
                {
                    LoggingAttribute attributeInfo = (LoggingAttribute)Attribute.GetCustomAttributes(input.MethodBase, typeof(LoggingAttribute)).SingleOrDefault();
                    if (attributeInfo != null && attributeInfo.LogParametersAfterExecution)
                    {
                        message += "Parameters: " + GetParametersText(input.Arguments);
                    }

                    if (result.ReturnValue != null && attributeInfo != null && attributeInfo.LogReturnValue)
                    {
                        string returnValueContent = string.Empty;
                        if (result.ReturnValue.GetType().IsSerializable)
                        {
                            returnValueContent = new JavaScriptSerializer().Serialize(result.ReturnValue);
                        }
                        else
                        {
                            returnValueContent = returnValueContent.ToString();
                        }
                        message += " ReturnValue: " + returnValueContent;
                    }
                }

                WriteLog(message);
            }
        }

        private void WriteLog(string message)
        {
            Logger.Log(message);
        }

        private string GetParametersText(IParameterCollection parameterCollection)
        {
            if (parameterCollection.GetType().IsSerializable)
            {
                return new JavaScriptSerializer().Serialize(parameterCollection);
            }

            List<string> textList = new List<string>();
            for (int i = 0; i < parameterCollection.Count; i++)
            {
                textList.Add(parameterCollection.GetParameterInfo(i).Name + " = " + parameterCollection[i]);
            }
            return string.Join(", ", textList);
        }

        private void AddExceptionData(IMethodInvocation input, Exception exception)
        {
            for (int i = 0; i < input.Inputs.Count; i++)
            {
                exception.Data.Add(input.Inputs.GetParameterInfo(i).Name, input.Inputs[i]);
            }
        }

    }
}
