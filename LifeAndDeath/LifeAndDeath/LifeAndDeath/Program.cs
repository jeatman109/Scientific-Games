using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using LifeAndDeath.DateData;


namespace LifeAndDeath
{
    /// <summary>
    /// Tests the DateDataCalculator
    /// </summary>
    class Program
    {
  
        /// <summary>
        /// Lowest date to be used in the date data container
        /// </summary>
        private static int _minDate = 1900;
        
        /// <summary>
        /// Highest date to be used in the date data container
        /// </summary>
        private static int _maxDate = 2000;

        static void Main(string[] args)
        {
            //create a list of people with the test dates provided from the text file
            var people = CreatePersonListFromFile(@"data.txt");

            //Instantiate the date data container and get the best years with test data
            DateDataCalculator dataCalculator = new DateDataCalculator();
            var bestYears = dataCalculator.GetYearsWithMostLivingPeople(people, _minDate, _maxDate);

            //output the result
            foreach (int year in bestYears)
                Console.WriteLine(year);

            Console.ReadKey();
        }

        /// <summary>
        /// Creates a list of the Person class given the name of a comma delimited .txt file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        static IEnumerable<Person> CreatePersonListFromFile(string fileName)
        {
            var sr = new StreamReader(fileName);
            var fullList = sr.ReadToEnd();
            var entries = fullList.Split('\n');
            var people = entries.Select(s => ParsePerson(s));
            sr.Close();

            return people;
        }

        /// <summary>
        /// Converts a string with comma seperation into the birth and death year of a person
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static Person ParsePerson(string str)
        {
            var items = str.Split(',');
            return new Person(int.Parse(items[0]), int.Parse(items[1]));
        }
    }
}
