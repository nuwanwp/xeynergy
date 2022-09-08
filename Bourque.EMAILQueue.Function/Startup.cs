using Bourque.EMAILQueue.EntityFramework.Context;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Bourque.EMAILQueue.Function.Startup))]
namespace Bourque.EMAILQueue.Function
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddDbContext<EmailQueueDbContext>();
        }
    }
}
