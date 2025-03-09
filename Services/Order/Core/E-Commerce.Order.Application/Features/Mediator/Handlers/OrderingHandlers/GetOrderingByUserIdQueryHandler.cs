﻿using E_Commerce.Order.Application.Features.Mediator.Queries.OrderingQueries;
using E_Commerce.Order.Application.Features.Mediator.Results.OrderingResults;
using E_Commerce.Order.Application.Interfaces;
using E_Commerce.Order.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class GetOrderingByUserIdQueryHandler : IRequestHandler<GetOrderingByUserIdQuery, List<GetOrderingByUserIdQueryResult>>
    {
        private readonly IOrderingRepository _orderingRepository;

        public GetOrderingByUserIdQueryHandler(IOrderingRepository orderingRepository)
        {
            _orderingRepository = orderingRepository;
        }

        public async Task<List<GetOrderingByUserIdQueryResult>> Handle(GetOrderingByUserIdQuery request, CancellationToken cancellationToken)
        {
            var values = _orderingRepository.GetOrderingsByUserId(request.Id);
            return values.Select(x => new GetOrderingByUserIdQueryResult
            {
                OrderDate = x.OrderDate,
                OrderingID = x.OrderingID,
                TotalPrice = x.TotalPrice,
                UserID = x.UserID
            }).ToList();
        }
    }
}
