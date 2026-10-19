using System;
using System.Collections.Generic;
using System.Text;

namespace BaobabRidgeWildlifeRehabilitation_RS.BusinessLayer
{
    public class Animal
    {
        public string AnimalID { get; set; }
        public string Name { get; set; }

        public string Species { get; set; } 
        public int Age { get; set; }
        public int RecoveryScore { get; set; }
        public string HealthStatus { get; set; }
        public string HouseLocation { get; set; }
         
         public Animal() { }
        
        public Animal(string animalID, string name, string species, int age, int recoveryScore, string healthStatus, string houselocation)
        {
            AnimalID = animalID;
            Name = name;
            Species = species;
            Age = age;
            RecoveryScore = recoveryScore;
            HealthStatus = healthStatus;
            HouseLocation = houselocation;
        }
         public void CalculateStatusandHousing()
         {
           switch (RecoveryScore)
             {
                 case >= 0 and <= 19:
                     HealthStatus = "Critical";
                     HouseLocation = "Intensive Care Unit";
                     break;
                 case >= 20 and <= 39:
                     HealthStatus = "Serious";
                     HouseLocation = "High-Dependency Ward";
                     break;
                 case >= 40 and <= 59:
                     HealthStatus = "Stable";
                     HouseLocation = "Recovery Ward";
                     break;
                 case >= 60 and <= 79:
                     HealthStatus = "Recovering";
                     HouseLocation = "Outdoor Enclosure";
                     break;
                 case >= 80 and <= 100:
                     HealthStatus = "Release-Ready";
                     HouseLocation = "Pre-Release Camp";
                     break;
                 default:
                     HealthStatus = "UNKNOWN";
                     HouseLocation= "UNKNOWN"; 
                     break;
             }
         }
        public override string ToString()
        {
           return $"Animal ID: {AnimalID}, Name: {Name}, Species: {Species}, Age: {Age}, Recovery Score: {RecoveryScore}, Health Status: {HealthStatus}, House Location: {HouseLocation}";
        }

    }
}
