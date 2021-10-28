using EWT.Nuget.Contract.Manager;
using KWT.HC.API.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KWT.HC.API.Manager.Contract
{
    public interface IGraphOptionManager : IManager<GraphOptionModel, int>
    {
        Task<List<GraphOptionModel>> GetOptionsByType(string optionType);
    }
}
