using primenumberapi.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace primenumberapi.Objects
{

    public class PrimeNumberResponse
        : BaseResponse
    {

        public PrimeNumberResponse()
            : base()
        {
            Numbers = new List<int>();
        }

        public List<int> Numbers {get; set;}

        public void PageResults(int pageNumber, int numberPerPage)
        {

            try
            {

                int startIndex = GetPagingStartIndex(pageNumber, numberPerPage);

                List<int> pagedNumbers = new List<int>();

                for(int i = startIndex; i < (numberPerPage + startIndex); i++ )
                {

                    // If we hit the end of the results, we can break from the loop
                    if( i > Numbers.Count -1 )
                    {
                        break;
                    }

                    pagedNumbers.Add(Numbers[i]);
                }

                Numbers = pagedNumbers;

            }
            catch(Exception ex)
            {
                // TOOD: 
            }

        }

        protected internal int GetPagingStartIndex(int pageNumber, int numberPerPage)
        {
            return (pageNumber - 1) * numberPerPage;
        }

    }

}
