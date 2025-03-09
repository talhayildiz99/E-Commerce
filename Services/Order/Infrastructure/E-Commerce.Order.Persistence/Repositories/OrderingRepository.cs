using E_Commerce.Order.Application.Interfaces;
using E_Commerce.Order.Domain.Entities;
using E_Commerce.Order.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Order.Persistence.Repositories
{
    public class OrderingRepository : IOrderingRepository
    {
        private readonly OrderContext _orderContext;

        public OrderingRepository(OrderContext orderContext)
        {
            _orderContext = orderContext;
        }

        public List<Ordering> GetOrderingsByUserId(string id)
        {
            var values = _orderContext.Orderings.Where(x => x.UserID==id).ToList();
            return values;
        }
    }
}
