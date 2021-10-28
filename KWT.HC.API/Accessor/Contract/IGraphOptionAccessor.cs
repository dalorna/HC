using EWT.Nuget.Contract.Accessor;
using KWT.HC.API.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KWT.HC.API.Accessor.Contract
{
    public interface IGraphOptionAccessor : IAccessor<GraphOptionModel, int>
    {
        Task<List<GraphOptionModel>> GetOptionsByType(string optionType);
    }
}
