using Cookaracha.Application.Abstractions;
using Cookaracha.Application.DTO;

namespace Cookaracha.Infrastructure.DAL.Queries;

public sealed record GetProducts(int PageNumber, int PageSize) : IQuery<IEnumerable<ProductDto>>;