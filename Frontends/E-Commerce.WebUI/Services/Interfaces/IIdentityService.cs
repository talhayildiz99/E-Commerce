using E_Commerce.DtoLayer.IdentityDtos.LoginDtos;

namespace E_Commerce.WebUI.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<bool> SignIn(SignInDto signInDto);
    }
}
