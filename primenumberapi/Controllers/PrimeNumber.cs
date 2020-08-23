using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using primenumberapi.Filters;

namespace primenumberapi.Controllers
{

    [Route("primenumber")]
    [ApiController]
    public class PrimeNumber 
        : BaseController
    {

        // GET api/<PrimeNumber>/5
        [SecurityFilter]
        [HttpGet("{maxValue}/{pageNumber}/{numberPerPage}")]
        public Objects.PrimeNumberResponse Get(
            int maxValue, 
            int pageNumber, 
            int numberPerPage
        )
        {

            Objects.PrimeNumberResponse retVal = null;

            try
            {

                retVal = new Objects.PrimeNumberResponse();

                ValidateInputs(maxValue, pageNumber, numberPerPage);

                // 2 is the lowest prime number, start there
                // Loop 2 to maxvalue, inclusive
                for (int i = 2; i <= maxValue; i++) // Number to check
                {

                    bool isPrime = true;

                    // We only need to check as far as half the value of the number we're checking. It can't be divibsle by higher than that
                    for (int j = 2; j <= i/2; j++) // Number to check against
                    {
                        if (i % j == 0)
                        {
                            isPrime = false;
                            break;
                        }
                    }

                    if (isPrime)
                    {
                        retVal.Numbers.Add(i);
                    }

                }

                retVal.PageResults(pageNumber, numberPerPage);

            }
            catch (Exception ex)
            {
                HandleExceptions(
                    retVal, 
                    ex);
            }

            return retVal;

        }

        private void ValidateInputs(
            int maxValue,
            int pageNumber,
            int numberPerPage
        )
        {

            if (maxValue < 2)
            {
                throw new Exception("maxValue must be at least 2");
            }

            if (pageNumber < 1)
            {
                throw new Exception("pageNumber must be at least 1");
            }

            if (numberPerPage < 1)
            {
                throw new Exception("numberPerPage must be at least 1");
            }

        }

    }

}
