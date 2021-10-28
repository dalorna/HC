using KWT.HC.API.Accessor.Contract;
using KWT.HC.API.Model;
using EWT.Nuget.Contract.Mapper;
using EWT.Nuget.Contract.Repository;
using EWT.Nuget.Contract.Accessor;
using KWT.HC.API.Entity;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace KWT.HC.API.Accessor
{
    public class GraphOptionAccessor : AccessorBase<GraphOptionModel, GraphOption, IRepository<GraphOption, int>, int>, IGraphOptionAccessor
    {
        public GraphOptionAccessor(IRepository<GraphOption, int> repository, IMapper<GraphOptionModel, GraphOption, int> mapper) : base(repository, mapper)
        {
        }


        public async Task<List<GraphOptionModel>> GetOptionsByType(string optionType)
        {
            var modelList = new List<GraphOptionModel>();
            var options = await _repository.Context.Set<GraphOption>().Where(w => w.OptionType == optionType).ToListAsync();
            if (options != null && options.Count > 0)
            {
                options.ForEach(e => modelList.Add(_mapper.ToModel(e)));
            }
            return modelList;
        }
    }
}
