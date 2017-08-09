using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeAndDeath.DateData
{
    /// <summary>
    /// DateDataCalculator: Calculates the years with the most people alive given a list of people with dates of birth and death.
    /// </summary>
    public class DateDataCalculator
    {
        #region Public Methods
        /// <summary>
        /// Finds the years with most living people based on data provided
        /// </summary>
        /// <param name="people"></param>
        /// <param name="minYear"></param>
        /// <param name="maxYear"></param>
        /// <returns></returns>
        public IEnumerable<int> GetYearsWithMostLivingPeople(IEnumerable<Person> people, int minYear, int maxYear)
        {
            //initialize some values to track progress
            List<int> bestYears = new List<int>();
            int maxPeopleAlive = 0;
            int currentPeopleAlive = 0;
            int currentYear = 0;

            //create a dictionary
            var changeInPopulationDict = CreateChangeInPopulationDictionary(minYear, maxYear);

            //iterate through each person.  
            //Add one to the matching dictionary key for their birth year and subtract one to the matching dictionary key for their death year
            foreach (Person person in people)
            {
                changeInPopulationDict[person.BirthDate] += 1;
                changeInPopulationDict[person.DeathDate] -= 1;
            }

            //iterate through each dictionary key pair
            //determine if the running total of living people is greater than or equal to the currentPeopleAlive value
            //clear the list of best years and start over or add to it respectively 
            foreach (KeyValuePair<int, int> entry in changeInPopulationDict)
            {
                currentYear = entry.Key;
                currentPeopleAlive += entry.Value;

                if (currentPeopleAlive > maxPeopleAlive)
                {
                    bestYears.Clear();
                    maxPeopleAlive = currentPeopleAlive;
                    bestYears.Add(currentYear);
                }
                else if (currentPeopleAlive == maxPeopleAlive)
                {
                    bestYears.Add(currentYear);
                }
            }

            Console.WriteLine("Most people alive at once = " + maxPeopleAlive);

            return bestYears;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Creates a dictionary with the key value set to years provided.
        /// Sets all paired values to 0.
        /// </summary>
        /// <param name="minYear"></param>
        /// <param name="maxYear"></param>
        private Dictionary<int, int> CreateChangeInPopulationDictionary(int minYear, int maxYear)
        {
            var changeInPopulation = new Dictionary<int, int>();
            for (int i = minYear; i <= maxYear; i++)
                 changeInPopulation.Add(i, 0);

            return changeInPopulation;
        }
        #endregion
    }

}
