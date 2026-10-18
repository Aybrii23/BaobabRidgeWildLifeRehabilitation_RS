using System;
using System.Collections.Generic;
using System.Text;

namespace BaobabRidgeWildlifeRehabilitation_RS
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
        public Animal(string animalID, string name, string species, string gender, int age, int recoveryScore, string healthStatus, string houselocation)
        {
            AnimalID = animalID;
            Name = name;
            Species = species;
            Age = age;
            RecoveryScore = recoveryScore;
            HealthStatus = healthStatus;
            HouseLocation = houselocation;
        }
        public override string ToString()
        {
           return $"Animal ID: {AnimalID}, Name: {Name}, Species: {Species}, Age: {Age}, Recovery Score: {RecoveryScore}, Health Status: {HealthStatus}, House Location: {HouseLocation}";
        }

    }
}
