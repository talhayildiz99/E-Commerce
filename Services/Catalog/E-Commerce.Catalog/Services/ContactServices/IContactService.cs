using E_Commerce.Catalog.Dtos.ContactDtos;

namespace E_Commerce.Catalog.Services.ContactServices
{
    public interface IContactService
    {
        Task<List<ResultContactDto>> GetAllContactAsync();
        Task CreateContactAsync(CreateContactDto contactDto);
        Task UpdateContactAsync(UpdateContactDto contactDto);
        Task DeleteContactAsync(string id);
        Task<GetByIdContactDto> GetByIdContactAsync(string id);

    }
}
