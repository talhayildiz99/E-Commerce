using E_Commerce.DtoLayer.IdentityDtos.UserDtos;

namespace E_Commerce.WebUI.Services.UserIdentityServices
{
    public interface IUserIdentityService
    {
        Task<List<ResultUserDto>> GetAllUserListAsync();
    }
}
