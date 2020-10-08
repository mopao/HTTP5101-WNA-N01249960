using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI_project.Controllers
{
    public class J3Controller : ApiController
    {
        /// <summary>
        /// calculate how much time is needed to type certain a word
        /// </summary>
        /// <example>GET: api/J3/WordTapingTimeOut/abba -> 12</example>
        /// <param name="word">represents the word for which the taping time is calculated </param>
        /// <returns>the taping time of the word</returns>
        
        [Route("api/J3/WordTapingTimeOut/{word}")]
        [HttpGet]
        public String WordTapingTimeOut(String word)
        {
            int maxWordLength = 20; // represents the maximum length we calculate the taping time for
            int pressTime = 1;     // represents time for one press
            int pauseTime = 2; // represents the pause time between two presses.
            // representation of the phone keyboard from button 2 to 9 as an array
            String[] arrayPhoneKeyboard = { "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };
            int tapingTime = 0; // represents the taping time 
            int index = 0;      // represents the first index of the word we calculate the taping time for
            String exitWord = "halt"; // represents the exit word
            string result = "";  // represents the result to return

            // we only calculate taping time for word different than 'halt' and with at most 20 length 
            if (word != exitWord || word.Length>maxWordLength)
            {
                // as long as we still have letter to calculate taping time for 
                while (index < word.Length)
                {
                    int i = 0;
                    // for the current letter word[index] in  word we find in which string it belong to in arrayPhoneKeyboard
                    while (arrayPhoneKeyboard[i].IndexOf(word[index]) == -1 && i < arrayPhoneKeyboard.Length)
                    {
                        i += 1;
                    }
                    // check if the string was found 
                    if (i < arrayPhoneKeyboard.Length)
                    {
                        // we calculate the taping time of the current letter word[index]
                        // arrayPhoneKeyboard[i].IndexOf(word[index]) + 1 represents the number of presses for the curent letter
                        tapingTime += (arrayPhoneKeyboard[i].IndexOf(word[index]) + 1)*pressTime;
                        // as long as the next letter word[index+1] is in the same string which represents
                        // the case where we need to press the same button for the next letter                        
                        while (index + 1 < word.Length && arrayPhoneKeyboard[i].IndexOf(word[index+1])!=-1)
                        {
                            tapingTime += pauseTime;// we add the pause time 
                            tapingTime += (arrayPhoneKeyboard[i].IndexOf(word[index]) + 1) * pressTime;// we add  the press time of the next letter 
                            index += 1;// we make the next letter the current letter
                            

                        }
                    }
                    index += 1;

                }

            }
            // update the result with the taping time 
            if (tapingTime > 0)
            {
                result += tapingTime;
            }

            return result;

            
        }
    }
}
