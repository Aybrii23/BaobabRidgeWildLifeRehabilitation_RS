using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace BaobabRidgeWildlifeRehabilitation_RS
{
    public class AnimalRepo
    {
        private readonly string filePath = "animals.txt";

        public List<Animal> GetAllAnimalsFromFile()
        {
            List<Animal> animals = new List<Animal>();
            if (!File.Exists(filePath))
            {
               MessageBox.Show($"File not found: {filePath}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return animals;
            }///////-----

            ////-----
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length == 7)
                    {
                        string animalID = parts[0];
                        string name = parts[1];
                        string species = parts[2];
                        int age = int.Parse(parts[3]);
                        int recoveryScore = int.Parse(parts[4]);
                        string healthStatus = parts[5];
                        string houseLocation = parts[6];
                        Animal animal = new Animal(animalID, name, species, "", age, recoveryScore, healthStatus, houseLocation);
                        animals.Add(animal);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error reading animal file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            return animals;
        }
    }
}
