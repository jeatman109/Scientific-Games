using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeAndDeath.DateData
{
    public class Person
    {
        public int BirthDate = 0;
        public int DeathDate = 0;

        public Person(int birth, int death)
        {
            BirthDate = birth;
            DeathDate = death;
        }
    }
}
