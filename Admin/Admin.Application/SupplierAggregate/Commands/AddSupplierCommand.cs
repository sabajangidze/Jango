﻿using Admin.Application.ProductAggregate.Commands;
using MediatR;

namespace Admin.Application.SupplierAggregate.Commands;

public record AddSupplierCommand(
    string CompanyName,
    string Country,
    string City,
    string Street,
    string Phone,
    IEnumerable<AddProductCommand> Products) : IRequest<Unit>;
