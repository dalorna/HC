using KWT.HC.API.Accessor.Contract;
using KWT.HC.API.Model;
using EWT.Nuget.Contract.Mapper;
using EWT.Nuget.Contract.Repository;
using System.Threading.Tasks;
using EWT.Nuget.Contract.Accessor;
using KWT.HC.API.Entity;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace KWT.HC.API.Accessor
{
    public class TurbineAccessor : AccessorBase<TurbineModel, Turbine, IRepository<Turbine, int>, int>, ITurbineAccessor
    {
        public TurbineAccessor(IRepository<Turbine, int> repository, IMapper<TurbineModel, Turbine, int> mapper) : base(repository, mapper)
        {
        }

        public async Task<bool> DeleteById(int Id)
        {
            var turbine = await _repository.Context.Set<Turbine>().FindAsync(Id);
            if (turbine != null)
            {
                _repository.Context.Set<Turbine>().Remove(turbine);
                var changes = _repository.Context.SaveChanges();
                return changes == 1;

            }
            return false;
        }

        public async Task<List<TurbineModel>> GetTurbinesByScheduleId(int scheduleId)
        {
            var modelList = new List<TurbineModel>();
            var sd = await _repository.Context.Set<ScheduleTurbine>().Where(w => w.ScheduleId == scheduleId).ToListAsync();
            if (sd != null && sd.Count > 0)
            {
                var st = await _repository.Context.Set<Turbine>().Where(w => sd.Select(s => s.TurbineId).Contains(w.Id)).ToListAsync();
                st.ForEach(e => modelList.Add(_mapper.ToModel(e)));
            }
            return modelList;
        }
    }
}
