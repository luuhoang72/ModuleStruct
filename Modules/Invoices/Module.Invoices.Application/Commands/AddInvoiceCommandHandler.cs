using FluentValidation;
using Mapster;
using MediatR;
using Module.Invoices.Domain.Models;
using Module.Invoices.Domain.Services.Commands;
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

        public AddInvoiceCommandHandler(IInvoiceStore invoiceStore)
        {
            _invoiceStore = invoiceStore;
        }

        public async Task<Invoice> Handle(AddInvoiceCommand request, CancellationToken cancellationToken)
        {
            var Invoice = request.Adapt<Invoice>();
            Invoice.Id = Guid.NewGuid().ToString();

            await _invoiceStore.AddAsync(Invoice);

            return Invoice;
        }
    }
}
