using System;
using System.Collections.Generic;
using System.Text;

namespace SystemCore.Data.Interfaces
{
    public interface IHasSoftDelete
    {
        bool IDeleted { set; get; }
    }
}
