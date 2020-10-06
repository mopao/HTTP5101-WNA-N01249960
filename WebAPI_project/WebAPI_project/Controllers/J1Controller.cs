using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI_project.Controllers
{
    public class J1Controller : ApiController
    {
        /// <summary>
        /// the total of calories of the placed order
        /// <example> GET http://localhost/api/J1/Menu/1/2/3/2  -> 957 </example>
        /// </summary>
        /// <param name="burger">  burger choice number</param>
        /// <param name="drink">drink choice number</param>
        /// <param name="side">side choice number</param>
        /// <param name="dessert">dessert choice number</param>
        /// <returns> the order's total calories</returns>
        [Route("api/J1/Menu/{burger}/{drink}/{side}/{dessert}")]
        [HttpGet]
        public String Menu( int burger, int drink, int side, int dessert)
        {
            // represents the ordered array of calories for the three burger choices from choice 1 to 3
            int[] burgerCaloriesArray = { 461,431,420 };
            // represents the ordered array of calories for the three drink choices from choice 1 to 3
            int[] drinkCaloriesArray = { 130, 160, 118};
            // represents the ordered array of calories for the three side choices from choice 1 to 3
            int[] sideCaloriesArray = { 100, 57, 70 };
            // represents the ordered array of calories for the three dessert choices from choice 1 to 3
            int[] dessertCaloriesArray = { 167, 266, 75 };
            // represents the total calories of the placed order
            int totalCalories = 0;

            // if the burger choice is valid. if so, add it calories to the total calories
            if(burger>0 && burger < 4)
            {
                totalCalories += burgerCaloriesArray[burger - 1];
            }
            // if the drink choice is valid. if so, add it calories to the total calories
            if (drink > 0 && drink < 4)
            {
                totalCalories += drinkCaloriesArray[drink - 1];
            }
            // if the side choice is valid. if so, add it calories to the total calories
            if (side > 0 && side < 4)
            {
                totalCalories += sideCaloriesArray[side - 1];
            }
            // if the dessert choice is valid. if so, add it calories to the total calories
            if (dessert > 0 && dessert < 4)
            {
                totalCalories += dessertCaloriesArray[dessert - 1];
            }



            return "Your total calories count is "+totalCalories;
        }
    }
}
