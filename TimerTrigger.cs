using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CCIT.StoredProc
{
    public static class TimerTrigger
    {
        [FunctionName("TimerTrigger")]
        public static void Run([TimerTrigger("0 */5 * * * *")]TimerInfo myTimer, TraceWriter log)
        {
            var configuration = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .AddJsonFile("appsettings.json", true)
                .Build();
            var conString = configuration.GetConnectionString("MyDbConnStr");

            log.Info(conString);
            using(var connection = new SqlConnection(conString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.spCustomer";
            }
            log.Info($"C# Timer trigger function executed at: {DateTime.Now}");
        }
    }
}
