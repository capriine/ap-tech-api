using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace primenumberapi.Objects
{
    public interface IResponse
    {

        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }

    }

}
