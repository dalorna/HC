using EWT.Nuget.Contract.Manager;
using KWT.HC.API.Model;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace KWT.HC.API.Manager.Contract
{
    public interface ILogoManager : IManager<LogoModel, int>
    {
        Task<LogoModel> UploadLogoFile(IFormFile formFile, string name);
        Task<LogoModel> UpdateLogoFile(IFormFile formFile, int logoId, string name);
        Task<bool> DeleteLogo(int logoId);
    }
}
