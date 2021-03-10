using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication2.Controllers
{
    /* Problem Description -
   
    //You decide to go for a very long drive on a very straight road. Along this road are five cities. As
    //you travel, you record the distance between each pair of consecutive cities.
    //You would like to calculate a distance table that indicates the distance between any two of the cities
    //you have encountered.

    */

    /* Pseudo Code -
     
    1) We need to create an array that stores the distance between consecutive cities
    2) We need to create an array that stores the final output
    3) All inputs need to be positive integers and should be less than 1000
    4) We need to ensure invalid input is handled properly
    5) Once input is verified, we need to create two for loop for the row and column elements
    6) Now we need to check for each condition
        a) When the value in the row position and column position are the same
        b) When the value in row position is less than the column position
        c) When the value in the column position is less than the value in the row position
    7) Return the array as the output
    */

    public class DistanceController : ApiController
    {
        /// J3 PROBLEM
        /// 
        /// <summary>
        /// In this problem, we're taking the distance between consecutive cities as the input from the user,
        /// storing them in an array and providing the distance between any 2 cities mentioned in the final array
        /// </summary>
        /// 
        /// <param name="city1">Distance of City1 from Starting Point</param>
        /// <param name="city2">Distance between city2 and City1</param>
        /// <param name="city3">Distance between City3 and City2</param>
        /// <param name="city4">Distance between City4 and City3.</param>
        /// 
        ///<example>
        ///
        ///GET api/Distance/DistancePerCity/3/10/12/5 -> 
        ///     Output - [[0,3,13,25,30],[3,0,10,22,27],[13,10,0,12,17],[25,22,12,0,5],[30,27,17,5,0]]
        ///
        ///GET api/Distance/DistancePerCity/45/100/62/365 -> 
        ///     Output - [[0,45,145,207,572],[45,0,100,162,527],[145,100,0,62,427],[207,162,62,0,365],[572,527,427,365,0]]
        ///
        ///GET api/Distance/DistancePerCity/55/570/1200/750 -> 
        ///     Output - null
        ///     
        ///GET api/Distance/DistancePerCity/3/-10/12/5 -> 
        ///     Output - null
        ///     
        ///</example>
        /// 
        /// <returns>
        /// 
        /// 1) An output of 5 lines, with the ith line (1 ≤ i ≤ 5) containing the distance from city i to
        ///    cities 1, 2, ... 5 in order, separated by a comma.
        /// 2) Returns null if an invalid input is provided 
        ///
        /// </returns>

        [HttpGet]
        [Route("api/Distance/DistancePerCity/{city1}/{city2}/{city3}/{city4}")]
        public int[,] DistancePerCity(int city1, int city2, int city3, int city4)
        {
            int[] InterCityDistance = new int[] { 0, city1, city2, city3, city4 };
            int[,] DistanceFromStart = new int[5, 5];
            bool verify = true;
            int totaldistance = 0;


            for (int i = 0; i < 5; i++)
            {
                if (InterCityDistance[i] < 0 || InterCityDistance[i] >= 1000)
                {
                    verify = false;
                    DistanceFromStart = null;
                }
            }

            if (verify == true)
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (i == j)
                        {
                            DistanceFromStart[i, j] = 0;
                        }
                        else if (i < j)
                        {
                            for (int k = i + 1; k <= j; k++)
                            {
                                totaldistance = totaldistance + InterCityDistance[k];
                            }
                            DistanceFromStart[i, j] = totaldistance;
                            totaldistance = 0;
                        }
                        else
                        {
                            DistanceFromStart[i, j] = DistanceFromStart[j, i];
                        }
                    }
                }
            }
            return DistanceFromStart;
        }
    }
}