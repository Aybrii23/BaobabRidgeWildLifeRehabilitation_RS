using System;
using System.Collections.Generic;
using System.Text;

namespace BaobabRidgeWildlifeRehabilitation_RS
{
     class DataHandler
    { 
        public DataHandler() //Used to initialize the datahandler
        {
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
            string filePath = "animals.txt";
            try
            {
                // Get the current list of animals from the current 
                List<Animal> animals = new List<Animal>(File.ReadAllLines(filePath));

                if (animals == null)
                {
                    messagebox.show("No animals found in the file.", "Error");
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
