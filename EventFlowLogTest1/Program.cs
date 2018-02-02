using Microsoft.Diagnostics.EventFlow;
using Microsoft.Diagnostics.EventFlow.Inputs;
using Microsoft.Extensions.Logging;
using System;

namespace EventFlowLogTest1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var diagnosticPipeline = DiagnosticPipelineFactory.CreatePipeline("eventFlowConfig.json"))
            {
                //System.Diagnostics.Trace.TraceWarning("dsalkjfdlakdsølkj");
                var loggerFactory = new LoggerFactory()
                //.AddConsole(minLevel: Microsoft.Extensions.Logging.LogLevel.Trace)
                //.AddDebug()
                .AddEventFlow(diagnosticPipeline);

                var logger = new Logger<Program>(loggerFactory);

                using (logger.BeginScope("SomeScope"))
                {
                    logger.LogDebug("Log debug!");
                    logger.LogInformation("Log information");
                    logger.LogError("Log errrrrrr");
                }
            }
        }
    }
}
