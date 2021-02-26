using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication2.Controllers
{
    /// <summary>
    /// Tells us how many parking slots were filled on both days
    /// </summary>
    /// <param name="parkingSpots">Number of parking spots</param>
    /// <param name="yspots"> Parking spots occuppied and unoccupied on the previous day</param>
    /// <param name="tspots"> Parking spots occuppied and unoccupied today</param>
    /// <example> GET api/OccupyParking/Parking/5/CCUCU/CUUCU -> 2 parking spots were occupied both yesterday and today</example>
    /// <example> GET api/OccupyParking/Parking/5/CUCUC/CCCCC -> 3 parking spots were occupied both yesterday and today</example>
    /// <returns> The number of parking spots which were occupied on both the days</returns>
    public class OccupyParkingController : ApiController
    {
        [HttpGet]
        [Route("api/OccupyParking/Parking/{parkingSpots}/{yspots}/{tspots}")]
        public string Parking(int parkingSpots, string yspots, string tspots)
        {
            string output = "";
            int counter = 0;
            

            string YUpper = yspots.ToUpper();
            string TUpper = tspots.ToUpper();

            char[] Ychars = YUpper.ToCharArray();
            char[] Tchars = TUpper.ToCharArray();
            
            for(int i=0; i<parkingSpots; i++)
            {
                if (Ychars[i] == Tchars[i] && Ychars[i] == 'C')
                {
                    counter = counter + 1;

                }
            }
            output = counter + " parking spots were occupied both yesterday and today";
            return output;
        }
    }
}
