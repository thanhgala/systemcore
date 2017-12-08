using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SystemCore.Utilities.DTO
{
    public class PageResult<T> : PageResultBase where T:class
    {
        public PageResult()
        {
            Results = new List<T>();
        }

        public IList<T> Results { get; set; }
    }
}
