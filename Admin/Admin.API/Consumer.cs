using Admin.Application.Models;
using Admin.Domain.Entities;
using MassTransit;
using Newtonsoft.Json;

namespace Admin.API;

public class Consumer : IConsumer<CustomerDTO>
{
    private readonly ILogger<Consumer> logger;

    public Consumer(ILogger<Consumer> logger)
    {
        this.logger = logger;
    }

    public async Task Consume(ConsumeContext<CustomerDTO> context)
    {
        await Console.Out.WriteLineAsync(context.Message.FirstName);
        logger.LogInformation($"Got new message {context.Message.FirstName}");
    }
}
