using EWT.Nuget.Contract.Manager;
using KWT.HC.API.Accessor.Contract;
using KWT.HC.API.Manager.Contract;
using KWT.HC.API.Model;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KWT.HC.API.Manager
{
    public class LogoManager : ManagerBase<LogoModel, ILogoAccessor, int>, ILogoManager
    {
        public LogoManager(ILogoAccessor accessor) : base(accessor)
        {
        }

        public async Task<LogoModel> UploadLogoFile(IFormFile formFile, string name)
        {
            return await accessor.UploadLogoFile(formFile, name);
        }

        public async Task<LogoModel> UpdateLogoFile(IFormFile formFile, int logoId, string name)
        {
            return await accessor.UpdateLogoFile(formFile, logoId, name);
        }

        public async Task<bool> DeleteLogo(int logoId)
        {
            return await accessor.DeleteLogo(logoId);
        }
    }
}
