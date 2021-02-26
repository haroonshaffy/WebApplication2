using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication2.Controllers
{
    /// <summary>
    /// Checks if the number is from a telemarketer or not and tells the user to either answer 
    /// or ignore the call
    /// </summary>
    /// <param name="num1"> The first of the last four digits</param>
    /// <param name="num2"> The second of the last four digits</param>
    /// <param name="num3"> The third of the last four digits</param>
    /// <param name="num4"> The last digit</param>
    /// <example> GET api/Telemarketer/FourDigits/9/6/6/8 -> Ignore</example>
    /// <example> GET api/Telemarketer/FourDigits/5/6/6/8 -> Answer</example>
    /// <returns> Either Ignore or Answer based on if the call is from a 
    /// telemarketer or not</returns>
    public class TelemarketerController : ApiController
    {
        [HttpGet]
        [Route("api/Telemarketer/FourDigits/{num1}/{num2}/{num3}/{num4}")]
        
        public string FourDigits(int num1, int num2, int num3, int num4)
        {
            if((num1 == 8 || num1 == 9) && (num4 == 8 || num4 ==9) && (num2 == num3))
            {
                return "Ignore";
            }
            else
            {
                return "Answer";
            }
        }
    }
}
