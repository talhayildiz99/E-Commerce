using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Cargo.EntityLayer.Concrete
{
    public class CargoDetail
    {
        public int CargoDetailID { get; set; }
        public string SenderCustomer{ get; set; }
        public string RecieverCustomer { get; set; }
        public int Barcode { get; set; }
        public int CargoCompanyID { get; set; }
        public CargoCompany CargoCompany { get; set; }
    }
}
