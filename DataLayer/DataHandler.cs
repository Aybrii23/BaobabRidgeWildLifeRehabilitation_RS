using System;
using System.Collections.Generic;
using System.Text;

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
                string species = a.Age;
                string ageText = a.Age;
                string scoreText = a.RecoveryScore;
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
                // After writing to the file, show a success message and clear the input fields

                MessageBox.Show("Animal added successfully!", "Success");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error writing to file: " + ex.Message, "Error");
            }
        }
    }
}
