using System;
using System.Collections.Generic;
using System.Text;
using BaobabRidgeWildlifeRehabilitation_RS.BusinessLayer;

namespace BaobabRidgeWildlifeRehabilitation_RS.DataLayer
{
    class DataHandler
    {
        public DataHandler() //Constructor
        {
        }

        public void Summary()
        {
            try
            {
                // Get the current list of animals from the DataGridView data source
                List<Animal> animals = dgvAnimals.DataSource as List<Animal>;

                if (animals == null)
                {
                    animals = new List<Animal>();
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

                // Attempt to update optional labels on the form if they exist (designer may not include them)
                void TrySetLabelByName(string name, string text)
                {
                    var ctrls = this.Controls.Find(name, true);
                    if (ctrls.Length > 0 && ctrls[0] is Label l)
                    {
                        l.Text = text;
                    }
                }

                TrySetLabelByName("lblTotalAnimals", $"Total Animals: {totalAnimals}");
                TrySetLabelByName("lblAvgAge", $"Average Age: {avgAgeStr}");
                TrySetLabelByName("lblAvgScore", $"Average Recovery Score: {avgScoreStr}");
                TrySetLabelByName("lblStatusCounts", $"Critical: {criticalCount} | Serious: {seriousCount} | Stable: {stableCount} | Recovering: {recoveringCount} | Release-Ready: {releaseReadyCount}");

                MessageBox.Show("Summary report generated and saved to summary.txt successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating summary report: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }

        public void AddAnimal(Animal a)
        {
            string filePath = "animals.txt";

            try
            {
                string name = a.Name;
                string species = a.Age;
                string ageText = a.Age;
                string scoreText = a.RecoveryScore;
                string id = a.AnimalID;

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
                if (int.TryParse(scoreText, out score))
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
                if (int.TryParse(ageText, out age))
                {
                    if (age < 0 || age > 100)
                    {
                        MessageBox.Show("Age must a number between 0 and 100", "Validation Error");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Age must be a whole number.", "Validation Error");
                    return;
                }

                Animal newAnimal = new Animal(id, name, species, age, score);

                using (StreamWriter writer = new StreamWriter(filePath, append: true))
                {
                    writer.WriteLine($"{newAnimal.AnimalID}|{newAnimal.Name}|{newAnimal.Species}|{newAnimal.Age}|{newAnimal.RecoveryScore}");
                }

                MessageBox.Show("Animal added successfully!", "Success");

                ClearInputs();
                LoadAnimalsData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error writing to file: " + ex.Message, "Error");
            }
        }

        public void DeleteAnimal(string animalID)
        {
            string filePath = "animals.txt";
            try
            {
                if (!File.Exists(filePath))
                {
                    MessageBox.Show("Animal data file not found.", "Error");
                    return;
                }

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
                if (animalFound)
                {
                    File.WriteAllLines(filePath, lines);
                    MessageBox.Show("Animal deleted successfully!", "Success");
                    LoadAnimalsData();
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
    }
}
