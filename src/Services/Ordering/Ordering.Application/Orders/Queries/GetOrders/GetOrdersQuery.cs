﻿using BuildingBlocks.Pagination;

namespace Ordering.Application.Orders.Queries.GetOrders;

public record GetOrdersQuery(PaginationRequest PaginationRequest): IQuery<GetOrdersResult>;
public record GetOrdersResult(PaginatedResult<OrderDTO> PaginatedResult);