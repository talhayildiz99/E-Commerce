using E_Commerce.Cargo.DataAccessLayer.Abstract;
using E_Commerce.Cargo.DataAccessLayer.Concrete;
using E_Commerce.Cargo.DataAccessLayer.Repositories;
using E_Commerce.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Cargo.DataAccessLayer.EntityFramework
{
    public class EfCargoCustomerDal : GenericRepository<CargoCustomer>, ICargoCustomerDal
    {
        private readonly CargoContext _cargoContext;
        public EfCargoCustomerDal(CargoContext context, CargoContext cargoContext) : base(context)
        {
            _cargoContext = cargoContext;
        }
        public CargoCustomer GetCargoCustomerById(string id)
        {
            var values = _cargoContext.CargoCustomers.Where(x => x.UserCustomerId == id).FirstOrDefault();
            return values;
        }
    }
}
