using E_Commerce.Cargo.BusinessLayer.Abstract;
using E_Commerce.Cargo.DtoLayer.Dtos.CargoCompanyDtos;
using E_Commerce.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using E_Commerce.Cargo.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomersController : ControllerBase
    {
        private readonly ICargoCustomerService _cargoCustomerService;

        public CargoCustomersController(ICargoCustomerService cargoCustomerService)
        {
            _cargoCustomerService = cargoCustomerService;
        }

        [HttpGet]
        public IActionResult CargoCustomerList()
        {
            var values = _cargoCustomerService.TGetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoCustomerById(int id)
        {
            var values = _cargoCustomerService.TGetById(id);
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCargoCustomer(CreateCargoCustomerDto createCargoCustomerDto)
        {
            CargoCustomer cargoCustomer = new CargoCustomer()
            {
                Address = createCargoCustomerDto.Address,
                City = createCargoCustomerDto.City,
                District = createCargoCustomerDto.District,
                Name = createCargoCustomerDto.Name,
                Surname=createCargoCustomerDto.Surname,
                Email = createCargoCustomerDto.Email,
                Phone = createCargoCustomerDto.Phone
            };
            _cargoCustomerService.TInsert(cargoCustomer);
            return Ok("Kargo müşteri ekleme işlemi başarıyla oluşturuldu");
        }

        [HttpDelete]
        public IActionResult RemoveCargoCustomer(int id)
        {
            _cargoCustomerService.TDelete(id);
            return Ok("Kargo müşteri silme işlemi başarıyla silindi");
        }

        [HttpPut]
        public IActionResult UpdateCargoCustomer(UpdateCargoCustomerDto updateCargoCustomerDto)
        {
            CargoCustomer cargoCustomer = new CargoCustomer()
            {
                Address= updateCargoCustomerDto.Address,
                CargoCustomerID = updateCargoCustomerDto.CargoCustomerID,
                City = updateCargoCustomerDto.City,
                District= updateCargoCustomerDto.District,
                Email = updateCargoCustomerDto.Email,
                Phone= updateCargoCustomerDto.Phone,
                Name = updateCargoCustomerDto.Name,
                Surname=updateCargoCustomerDto.Surname
            };
            _cargoCustomerService.TUpdate(cargoCustomer);
            return Ok("Kargo müşteri güncelleme işlemi başarıyla güncellendi");
        }
    }
}
