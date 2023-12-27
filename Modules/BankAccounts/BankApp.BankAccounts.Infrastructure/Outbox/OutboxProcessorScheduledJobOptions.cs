using Microsoft.Extensions.Options;
using Quartz;

namespace BankApp.BankAccounts.Infrastructure.Outbox;

public class OutboxProcessorScheduledJobOptions : IConfigureOptions<QuartzOptions>
{
    public void Configure(QuartzOptions options)
    {
        var jobKey = JobKey.Create("BankAccount" + nameof(OutboxProcessor));
        options.AddJob<OutboxProcessor>(builder => builder.WithIdentity(jobKey)).AddTrigger(trigger =>
            trigger.ForJob(jobKey).WithSimpleSchedule(schedule => schedule.WithIntervalInSeconds(5).RepeatForever()));
    }
}