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

        public static (string HealthStatus, string HousingUnit) ClassifyAnimal(int recoveryScore)
        {
            // Classification mapping based on Recovery Score (0 - 100)
            if (recoveryScore >= 0 && recoveryScore <= 20)
                return ("Critical", "Intensive Care Unit");
            if (recoveryScore <= 50)
                return ("Serious", "High-Dependency Ward");
            if (recoveryScore <= 75)
                return ("Recovering", "Outdoor Enclosure");
            if (recoveryScore <= 100)
                return ("Release-Ready", "Pre-Release Camp");

            return ("Unknown", "Unassigned");
        }


        public override string ToString()
        {
           return $"Animal ID: {AnimalID}, Name: {Name}, Species: {Species}, Age: {Age}, Recovery Score: {RecoveryScore}, Health Status: {HealthStatus}, House Location: {HouseLocation}";
        }

    }
}
