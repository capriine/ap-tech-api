using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace primenumberapi.Controllers
{ 

    public abstract class BaseController
        : ControllerBase
    {

        protected void HandleExceptions(
            Objects.IResponse response,
            Exception ex)
        {
            response.IsSuccess = false;
            response.ErrorMessage = ex.Message;
        }
        
    }

}
