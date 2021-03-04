using FrameworkWorkShop.Core.CrossCuttingConcerns.Logging;
using FrameworkWorkShop.Core.CrossCuttingConcerns.Logging.Log4Net;
using PostSharp.Aspects;
using PostSharp.Extensibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkWorkShop.Core.Aspects.PostSharp.LogAspects
{
    [Serializable]
    [MulticastAttributeUsage(MulticastTargets.Method,TargetExternalMemberAttributes =MulticastAttributes.Instance)]
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
            if (_loggerType.BaseType != typeof(LoggerService))
            {
                throw new Exception("Wrong logger type");
            }
            _loggerService = (LoggerService)Activator.CreateInstance(_loggerType);
            base.RuntimeInitialize(method);
        }

        public override void OnEntry(MethodExecutionArgs args) 
        {
            if (!_loggerService.IsInfoEnabled) return;

            try
            {
                var logParamters = args.Method.GetParameters().Select((type, iterator) => new LogParameter
                {
                    Name = type.Name,
                    Type = type.ParameterType.Name,
                    Value = args.Arguments.GetArgument(iterator)
                }).ToList();

                var logDetail = new LogDetail
                {
                    FullName = args.Method.DeclaringType is null ? null : args.Method.DeclaringType.Name,
                    MethodName = args.Method.Name,
                    Parameters = logParamters
                };

                _loggerService.InFo(logDetail);
            }
            catch (Exception ex)
            {
            }

        }
    }
}
