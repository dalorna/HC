using EWT.Nuget.Contract.Manager;
using KWT.HC.API.Accessor.Contract;
using KWT.HC.API.Manager.Contract;
using KWT.HC.API.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KWT.HC.API.Manager
{
    public class GraphOptionManager : ManagerBase<GraphOptionModel, IGraphOptionAccessor, int>, IGraphOptionManager
    {
        public GraphOptionManager(IGraphOptionAccessor accessor) : base(accessor)
        {
        }

        public async Task<List<GraphOptionModel>> GetOptionsByType(string optionType)
        {
            return await accessor.GetOptionsByType(optionType);
        }
    }
}
