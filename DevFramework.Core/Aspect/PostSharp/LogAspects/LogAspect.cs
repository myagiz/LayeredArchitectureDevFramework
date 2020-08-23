using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.CrossCuttingCorners.Logging;
using DevFramework.Core.CrossCuttingCorners.Logging.Log4Net;
using PostSharp.Aspects;
using PostSharp.Extensibility;

namespace DevFramework.Core.Aspect.PostSharp.LogAspects
{
    [Serializable]
    [MulticastAttributeUsage(MulticastTargets.Method,TargetExternalMemberAttributes = MulticastAttributes.Instance)]
    public class LogAspect:OnMethodBoundaryAspect
    {
        private Type _loggerType;
        private LoggerService _loggerService;

        public LogAspect(Type loggerType)
        {
            _loggerType = loggerType;
        }

        public override void RuntimeInitialize(MethodBase method)
        {
            if (_loggerType.BaseType!=typeof(LoggerService))
            {
                throw new Exception("Wrong Logger Type");
            }

            _loggerService = (LoggerService) Activator.CreateInstance(_loggerType);
            
            base.RuntimeInitialize(method);
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            if (!_loggerService.IsInfoEnabled)
            {
                return;
            }

            try
            {
                var LogParameters = args.Method.GetParameters().Select((t, i) => new LogParameter
                {
                    Name = t.Name,
                    Type = t.ParameterType.Name,
                    Value = args.Arguments.GetArgument(i)
                }).ToList();

                var logdetail = new LogDetail
                {
                    FullName = args.Method.DeclaringType == null ? null : args.Method.DeclaringType.Name,
                    MethodName = args.Method.Name,
                    Parameters = LogParameters
                };
                _loggerService.Info(logdetail);
            }
            catch (Exception )
            {
                
            }
        }
    }
}
