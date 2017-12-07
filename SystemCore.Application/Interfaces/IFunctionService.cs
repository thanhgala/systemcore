using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SystemCore.Application.ViewModels.System;

namespace SystemCore.Application.Interfaces
{
    public interface IFunctionService : IDisposable
    {
        Task<List<FunctionViewModel>> GetAll();

        List<FunctionViewModel> GetAllByPermission(Guid userId);
    }
}