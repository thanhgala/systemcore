using System;
using System.Collections.Generic;
using System.Text;
using SystemCore.Data.Enums;

namespace SystemCore.Data.Interfaces
{
    public interface ISwitchable
    {
        Status Status { set; get; }
    }
}
