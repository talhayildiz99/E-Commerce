﻿using E_Commerce.Order.Application.Features.CQRS.Results.AddressResults;
using E_Commerce.Order.Application.Interfaces;
using E_Commerce.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressQueryHandler
    {
        private readonly IRepository<Address> _repository;

        public GetAddressQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetAddressQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x=> new GetAddressQueryResult
            {
                AddressID = x.AddressID,
                City = x.City,
                Detail = x.Detail1,
                District = x.District,
                UserID = x.UserID
            }).ToList();
        }
    }
}
