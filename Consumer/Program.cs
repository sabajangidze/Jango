using MassTransit;
using Newtonsoft.Json;
using Web.Application.Models;

var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
{
    cfg.ReceiveEndpoint("customer-created-event", e =>
    {
        e.Consumer<CustomerCreatedConsumer>();
    });

});

await busControl.StartAsync(new CancellationToken());

try
{
    Console.WriteLine("Press enter to exit");

    await Task.Run(() => Console.ReadLine());
}
finally
{
    await busControl.StopAsync();
}

class CustomerCreatedConsumer : IConsumer<CustomerDTO>
{
    public async Task Consume(ConsumeContext<CustomerDTO> context)
    {
        var jsonMessage = JsonConvert.SerializeObject(context.Message);
        Console.WriteLine($"ConsumerCreated message: {jsonMessage}");
    }
}


