using KWT.HC.API.Accessor.Contract;
using KWT.HC.API.Model;
using EWT.Nuget.Contract.Mapper;
using EWT.Nuget.Contract.Repository;
using EWT.Nuget.Contract.Accessor;
using KWT.HC.API.Entity;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace KWT.HC.API.Accessor
{
    public class LogoAccessor : AccessorBase<LogoModel, Logo, IRepository<Logo, int>, int>, ILogoAccessor
    {
        public LogoAccessor(IRepository<Logo, int> repository, IMapper<LogoModel, Logo, int> mapper) : base(repository, mapper)
        {
        }

        public async Task<LogoModel> UploadLogoFile(IFormFile formFile, string name)
        {
            byte[] file;
            using (var stream = formFile.OpenReadStream())
            {
                using (var reader = new BinaryReader(stream))
                {
                    file = reader.ReadBytes((int)stream.Length);
                }
            }

            var base64String = Convert.ToBase64String(file);


            var e = new Logo()
            {
                Name = name,
                LogoFile = base64String
            };
            var logo = await _repository.Context.Set<Logo>().AddAsync(e);
            await _repository.Context.SaveChangesAsync();

            return _mapper.ToModel(logo.Entity);
        }

        public async Task<LogoModel> UpdateLogoFile(IFormFile formFile, int logoId, string name)
        {
            byte[] file;
            using (var stream = formFile.OpenReadStream())
            {
                using (var reader = new BinaryReader(stream))
                {
                    file = reader.ReadBytes((int)stream.Length);
                }
            }

            var base64String = Convert.ToBase64String(file);


            var e = new Logo()
            {
                Id = logoId,
                Name = name,
                LogoFile = base64String
            };
            var logo = _repository.Context.Set<Logo>().Update(e);
            await _repository.Context.SaveChangesAsync();

            return _mapper.ToModel(logo.Entity);
        }

        public async Task<bool> DeleteLogo(int logoId)
        {

            var logo = await _repository.Context.Set<Logo>().FindAsync(logoId);
            if (logo != null)
            {
                _repository.Context.Set<Logo>().Remove(logo);
                var changes = _repository.Context.SaveChanges();
                return changes == 1;
            }
            return false;
        }
    }
}
