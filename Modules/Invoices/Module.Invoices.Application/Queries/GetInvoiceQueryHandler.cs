using FluentValidation;
using Mapster;
using MediatR;
using Module.Invoices.Domain.Services.Dtos;
using Module.Invoices.Domain.Services.Queries;
using Module.Invoices.Domain.Stores;

namespace Module.Invoices.Application.Queries
{
    public class GetInvoiceQueryValidator : AbstractValidator<GetInvoiceQuery>
    {
        public GetInvoiceQueryValidator() 
        {
            RuleFor(x => x.Id).NotNull().NotEmpty();
        }
    }

    public class GetInvoiceQueryHandler : IRequestHandler<GetInvoiceQuery, InvoiceDto?>
    {
        private readonly IInvoiceStore _invoiceStore;

        public GetInvoiceQueryHandler(IInvoiceStore orderStore)
        {
            _invoiceStore = orderStore;
        }

        public async Task<InvoiceDto?> Handle(GetInvoiceQuery request, CancellationToken cancellationToken)
        {
            var order = await _invoiceStore.GetByIdAsync(request.Id);
            return order?.Adapt<InvoiceDto?>();
        }
    }

}
