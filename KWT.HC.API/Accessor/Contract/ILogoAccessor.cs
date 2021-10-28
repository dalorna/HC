using EWT.Nuget.Contract.Accessor;
using KWT.HC.API.Model;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace KWT.HC.API.Accessor.Contract
{
    public interface ILogoAccessor : IAccessor<LogoModel, int>
    {
        Task<LogoModel> UploadLogoFile(IFormFile formFile, string name);
        Task<LogoModel> UpdateLogoFile(IFormFile formFile, int logoId, string name);
        Task<bool> DeleteLogo(int logoId);
    }
}
