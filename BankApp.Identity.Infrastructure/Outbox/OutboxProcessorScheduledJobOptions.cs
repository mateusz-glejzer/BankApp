using Microsoft.Extensions.Options;
using Quartz;

namespace BankApp.Identity.Infrastructure.Outbox;

public class OutboxProcessorScheduledJobOptions : IConfigureOptions<QuartzOptions>
{
    public void Configure(QuartzOptions options)
    {
        //TODO add instance Id
        var jobKey = JobKey.Create("Identity" + nameof(OutboxProcessor));
        options.AddJob<OutboxProcessor>(builder => builder.WithIdentity(jobKey)).AddTrigger(trigger =>
            trigger.ForJob(jobKey).WithSimpleSchedule(schedule => schedule.WithIntervalInSeconds(5).RepeatForever()));
    }
}