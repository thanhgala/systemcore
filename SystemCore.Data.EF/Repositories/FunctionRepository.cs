using System;
using System.Collections.Generic;
using System.Text;
using SystemCore.Data.Entities;
using SystemCore.Data.IRepositories;

namespace SystemCore.Data.EF.Repositories
{
    public class FunctionRepository : EFRepository<Function, string>, IFunctionRepository
    {
        public FunctionRepository(AppDbContext context) : base(context)
        {
        }
    }
}
