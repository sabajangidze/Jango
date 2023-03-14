using Admin.Application.CustomersAggregate.Commands;
using Admin.Application.Models;
using Admin.Domain.Entities;
using Jango.IntegrationEvent;
using MassTransit;
using MediatR;
using Newtonsoft.Json;

namespace Admin.API;

public class Consumer : IConsumer<CustomerEvent>
{
    private readonly ISender _sender;

    public Consumer(ISender sender)
    {
        _sender = sender;
    }

    public async Task Consume(ConsumeContext<CustomerEvent> context)
    {
        var jsonMessage = JsonConvert.SerializeObject(context.Message);
        Console.Out.WriteLine(context.Message.FirstName);

        AddCustomerCommand addCustomerCommand = new AddCustomerCommand
            (
                context.Message.FirstName,
                context.Message.LastName,
                context.Message.Email,
                context.Message.Phone,
                context.Message.Street,
                context.Message.City
            );

        await _sender.Send(addCustomerCommand);
    }
}
