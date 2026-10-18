using System;
using System.Collections.Generic;
using System.Text;

namespace BaobabRidgeWildlifeRehabilitation_RS.BusinessLayer
{
    internal class Animal
    {
        public string AnimalID { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public int Age { get; set; }
        public int RecoveryScore { get; set; }
        public string HealthStatus { get; private set; }
        public string HousingUnit { get; private set; }

        public Animal() //Constructor
        {

        }
      
    }
}
