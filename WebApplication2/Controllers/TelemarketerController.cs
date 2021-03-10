using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication2.Controllers
{
    /*Here at the Concerned Citizens of Commerce (CCC), we have noted that telemarketers like to use
seven-digit phone numbers where the last four digits have three properties.Looking just at the last
four digits, these properties are:
• the first of these four digits is an 8 or 9;
• the last digit is an 8 or 9;
• the second and third digits are the same.
For example, if the last four digits of the telephone number are 8229, 8338, or 9008, these are
telemarketer numbers.
Write a program to decide if a telephone number is a telemarketer number or not, based on the
last four digits. If the number is not a telemarketer number, we should answer the phone, and
otherwise, we should ignore it.
Input Specification
The input will be 4 lines where each line contains exactly one digit in the range from 0 to 9.
Output Specification
Output either ignore if the number matches the pattern for a telemarketer number; otherwise,
output answer.*/

    /// J1 PROBLEM
    /// 
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
