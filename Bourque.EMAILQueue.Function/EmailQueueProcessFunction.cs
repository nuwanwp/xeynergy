using System;
using Bourque.EMAILQueue.EntityFramework.Context;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Bourque.EMAILQueue.Function
{
    public class EmailQueueProcessFunction
    {
        private readonly ILogger _logger;
        private readonly EmailQueueDbContext _emailQueueDbContext;

        public EmailQueueProcessFunction(EmailQueueDbContext emailQueueDbContext, ILogger<EmailQueueProcessFunction> logger)
        {
            _logger = logger;
            _emailQueueDbContext = emailQueueDbContext;
        }

        [FunctionName("EmailQueueProcessFunction")]
        public void Run([TimerTrigger("*/2 * * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation("Hello");
        }
    }
}
