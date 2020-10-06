using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI_project.Controllers
{
    public class J2Controller : ApiController
    {
        /// <summary>
        /// determines how many ways we can roll the value of 10.
        /// </summary>
        /// <example> GET api/J2/DiceGame/6/8  -> 5 </example>
        /// <param name="m">he number of sides on the first die</param>
        /// <param name="n">he number of sides on the second die</param>
        /// <returns>number of ways we can roll the value of 10.</returns>
        [Route("api/J2/DiceGame/{m}/{n}")]
        [HttpGet]
        public String DiceGame(int m,int n)
        {
            int nberOfWays = 0;// represents the number of ways we can roll 10 with the two dices
            int diceSum = 10; // represents the sum 10
            int subM=m;
            int subN=n;
            //if the first dice has more than 10 sides we just consider sides from 1 to 9
            if (m >= 10)
            {
                subM = diceSum - 1;
            }
            //if the second dice  has more than 10 sides we just consider sides from  to 
            if (n >= 10)
            {
                subN = diceSum - 1;
            }

            if (subM + subN >= diceSum)
            {
                nberOfWays = subM + subN - diceSum+ 1;// calculate the number of way to roll 10
            }

            return " There are "+nberOfWays+" total ways to get the sum "+diceSum;

        }
    }
}
