using FluentValidation;
using Mapster;
using MediatR;
using Module.Invoices.Domain.Models;
using Module.Invoices.Domain.Services.Commands;
using Module.Invoices.Domain.Services.Queries;
using Module.Invoices.Domain.Stores;

namespace Module.Invoices.Application.Commands
{
    public class GetInvoiceQueryValidator : AbstractValidator<AddInvoiceCommand>
    {
        public GetInvoiceQueryValidator()
        {
        }
    }

    public class AddInvoiceCommandHandler : IRequestHandler<AddInvoiceCommand, Invoice>
    {
        private readonly IInvoiceStore _invoiceStore;
        private readonly IMediator _mediator;

        public AddInvoiceCommandHandler(IInvoiceStore invoiceStore, IMediator mediator)
        {
            _invoiceStore = invoiceStore;
            _mediator = mediator;   
        }

        public async Task<Invoice> Handle(AddInvoiceCommand request, CancellationToken cancellationToken)
        {
            await Task.Delay(6000, cancellationToken);

            var invoice = request.Adapt<Invoice>();
            var iv = await _mediator.Send(new GetInvoiceQuery { Id = invoice.Id }, cancellationToken);

            if (iv != null)
                await _invoiceStore.AddAsync(invoice);

            Console.WriteLine("AddInvoiceCommand, Invoice Id: {0}, end time: {1}", invoice.Id, DateTime.UtcNow);
            return invoice;
        }
    }
}
