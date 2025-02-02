using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DtoLayer.CatalogDtos.VendorDtos
{
    public class UpdateVendorDto
    {
        public string VendorId { get; set; }
        public string VendorName { get; set; }
        public string ImageUrl { get; set; }
    }
}
