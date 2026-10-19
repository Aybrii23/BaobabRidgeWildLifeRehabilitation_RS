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

        // Existing 7-parameter constructor
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

        // Backwards-compatible 8-parameter constructor
        // The fourth parameter is kept for callers that pass an extra string (e.g. notes). It's ignored here.
        public Animal(string animalID, string name, string species, string unused, int age, int recoveryScore, string healthStatus, string houselocation)
            : this(animalID, name, species, age, recoveryScore, healthStatus, houselocation)
        {
            // unused parameter intentionally not stored to preserve original class shape
        }

        public override string ToString()
        {
           return $"Animal ID: {AnimalID}, Name: {Name}, Species: {Species}, Age: {Age}, Recovery Score: {RecoveryScore}, Health Status: {HealthStatus}, House Location: {HouseLocation}";
        }

    }
}
