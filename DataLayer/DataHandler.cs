using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.IO;

namespace BaobabRidgeWildlifeRehabilitation_RS.DataLayer
{
     class DataHandler
    {
        public DataHandler() //Constructor
        {
        }

        public void AddAnimal(Animal a)
        {
            string filePath = "animals.txt"; //Linking the file path to the text file

            try
            {
                string name = a.Name;
                string species = a.Species;
                int ageText = a.Age;
                int scoreText = a.RecoveryScore;
                string id = a.AnimalID;
                //All these strings are used to validate the input data before writing to the file

                if (string.IsNullOrEmpty(id))
                {
                    MessageBox.Show("ID is required.", "Validation Error");
                    return;
                }

                if (!id.StartsWith("WR-"))
                {
                    MessageBox.Show("ID must start with 'WR-'.", "Validation Error");
                    return;
                }

                if (id.Contains("|"))
                {
                    MessageBox.Show("ID must not contain '|'.", "Validation Error");
                    return;
                }

                int score;
                if (int.TryParse(scoreText.ToString(), out score))
                {
                    if (score < 0 || score > 100)
                    {
                        MessageBox.Show("Score must be between 0 and 100.", "Validation Error");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Score must be a whole number.", "Validation Error");
                    return;
                }

                int age;
                if (int.TryParse(ageText.ToString(), out age))
                {
                    if (age < 0 || age > 100)
                    {
                        MessageBox.Show("Age must be a number between 0 and 100", "Validation Error");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Age must be a whole number.", "Validation Error");
                    return;
                }

                // read remaining properties from the passed-in Animal
                string healthStatus = a.HealthStatus;
                string houseLocation = a.HouseLocation;

                Animal newAnimal = new Animal(id, name, species, age, score, healthStatus, houseLocation);

                using (StreamWriter writer = new StreamWriter(filePath, append: true))
                {
                    writer.WriteLine($"{newAnimal.AnimalID}|{newAnimal.Name}|{newAnimal.Species}|{newAnimal.Age}|{newAnimal.RecoveryScore}|{newAnimal.HealthStatus}|{newAnimal.HouseLocation}");
                }
                // After writing to the file, show a success message and clear the input fields

                MessageBox.Show("Animal added successfully!", "Success");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error writing to file: " + ex.Message, "Error");
            }
        }

        public void DeleteAnimal(string animalID) //Retreive data from the ID input box to delete the animal from the file
        {
            string filePath = "animals.txt";
            try
            {
                if (!File.Exists(filePath))
                {
                    MessageBox.Show("Animal data file not found.", "Error");
                    return;
                }
                //Checking if the file exists 

                List<string> lines = new List<string>(File.ReadAllLines(filePath));
                bool animalFound = false;
                for (int i = 0; i < lines.Count; i++)
                {
                    string[] parts = lines[i].Split('|');
                    if (parts.Length > 0 && parts[0] == animalID)
                    {
                        lines.RemoveAt(i);
                        animalFound = true;
                        break;
                    }
                }
                if (animalFound == true)
                {
                    File.WriteAllLines(filePath, lines);
                    MessageBox.Show("Animal deleted successfully!", "Success");
                    //Rewriting the entire File after the Id'd animal has been removed
                }
                else
                {
                    MessageBox.Show("Animal ID not found.", "Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting animal: " + ex.Message, "Error");
            }
        }


        public void Summary()
        {
            // string filePath = "animals.txt"; Removed since AnimalRepo handles the file path now!
            try
            {
                // Get the current list of animals from the current 
                AnimalRepo repo = new AnimalRepo();
                List<Animal> animals = repo.GetAllAnimalsFromFile();
                if (animals == null)
                {
                    MessageBox.Show("No animals found in the file.", "Error");
                    return;
                }

                int totalAnimals = animals.Count;
                double avgAge = 0.00;
                double avgScore = 0.00;

                if (totalAnimals > 0)
                {
                    avgAge = animals.Average(a => a.Age);
                    avgScore = animals.Average(a => (double)a.RecoveryScore);
                }

                // Count animals per status, ensuring all 5 statuses are accounted for
                int criticalCount = animals.Count(a => a.HealthStatus.Equals("Critical", StringComparison.OrdinalIgnoreCase));
                int seriousCount = animals.Count(a => a.HealthStatus.Equals("Serious", StringComparison.OrdinalIgnoreCase));
                int stableCount = animals.Count(a => a.HealthStatus.Equals("Stable", StringComparison.OrdinalIgnoreCase));
                int recoveringCount = animals.Count(a => a.HealthStatus.Equals("Recovering", StringComparison.OrdinalIgnoreCase));
                int releaseReadyCount = animals.Count(a => a.HealthStatus.Equals("Release-Ready", StringComparison.OrdinalIgnoreCase));

                // Format strings for averages ("N/A" if empty, otherwise 2 decimal places using full stop)
                string avgAgeStr = totalAnimals > 0 ? avgAge.ToString("0.00", CultureInfo.InvariantCulture) : "N/A";
                string avgScoreStr = totalAnimals > 0 ? avgScore.ToString("0.00", CultureInfo.InvariantCulture) : "N/A";

                // Build the exact file layout required by the brief
                string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

                StringBuilder reportContent = new StringBuilder();
                reportContent.AppendLine("BAOBAB RIDGE WILDLIFE REHABILITATION CENTRE");
                reportContent.AppendLine("ANIMAL SUMMARY REPORT");
                reportContent.AppendLine($"Generated: {timestamp}");
                reportContent.AppendLine("----------------------------------------");
                reportContent.AppendLine($"Total animals: {totalAnimals}");
                reportContent.AppendLine($"Average age (years): {avgAgeStr}");
                reportContent.AppendLine($"Average recovery score: {avgScoreStr}");
                reportContent.AppendLine("----------------------------------------");
                reportContent.AppendLine("Animals per status:");
                reportContent.AppendLine($" Critical: {criticalCount}");
                reportContent.AppendLine($" Serious: {seriousCount}");
                reportContent.AppendLine($" Stable: {stableCount}");
                reportContent.AppendLine($" Recovering: {recoveringCount}");
                reportContent.AppendLine($" Release-Ready: {releaseReadyCount}");

                // Save to summary.txt in the same folder as the .exe (overwriting each time)
                File.WriteAllText("summary.txt", reportContent.ToString(), new UTF8Encoding(false));

                MessageBox.Show("Summary report generated and saved to summary.txt successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating summary report: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


    }
}

