using Admin.Application.CustomersAggregate.Commands;
using MassTransit;
using MediatR;
using Newtonsoft.Json;

namespace Admin.API
{
    public class Consumer : IConsumer<AddCustomerCommand>
    {
        private readonly ISender _sender;

        public Consumer(ISender sender)
        {
            _sender = sender;
        }

        public async Task Consume(ConsumeContext<AddCustomerCommand> context)
        {
            var jsonMessage = JsonConvert.SerializeObject(context.Message);

            await _sender.Send(jsonMessage);
        }
    }
}
