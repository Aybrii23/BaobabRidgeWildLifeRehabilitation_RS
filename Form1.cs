using System.Xml.Linq;
using BaobabRidgeWildlifeRehabilitation_RS.BusinessLayer;
using BaobabRidgeWildlifeRehabilitation_RS.DataLayer;

namespace BaobabRidgeWildlifeRehabilitation_RS
{
    public partial class Form1 : Form
    {
        DataHandler handler = new DataHandler();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)

        {
            // Populate DataGridView on startup
            DisplayAllAnimals();
            updatebtn.Enabled = false;
        }

        private void BaobabRidgeWildlifeRehabilitationSystem_Enter(object sender, EventArgs e)
        {

        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Basic Validation
                if (animalidtxt.Text == "" || nametxt.Text == "" || speciestxt.Text == "" || agetxt.Text == "" || recoveryscoretxt.Text == "")
                {
                    MessageBox.Show("Please fill in all input fields.");
                    return;
                }

                // Extract Inputs
                string id = animalidtxt.Text.Trim();
                string name = nametxt.Text.Trim();
                string species = speciestxt.Text.Trim();

                if (!int.TryParse(agetxt.Text.Trim(), out int age) || age < 0)
                {
                    MessageBox.Show("Please enter a valid age.");
                    return;
                }

                if (!int.TryParse(recoveryscoretxt.Text.Trim(), out int score) || score < 0 || score > 100)
                {
                    MessageBox.Show("Recovery score must be between 0 and 100.");
                    return;
                }

                // Create Animal Object and Add
                Animal newAnimal = new Animal(id, name, species, age, score);
                handler.AddAnimal(newAnimal);

                MessageBox.Show("Animal added successfully!");

                // Reset and Refresh
                DisplayAllAnimals();
                ClearAllFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while adding: " + ex.Message);
            }
        }

        private void searchbtn_Click(object sender, EventArgs e)
        {
            string searchID = searchidtxt.Text.Trim();
            if (searchID == "")
            {
                MessageBox.Show("Please enter an Animal ID to search.");
                return;
            }
            try
            {
                Animal foundAnimal = handler.SearchAnimal(searchID);
                if (foundAnimal != null)
                {
                    animalidtxt.Text = foundAnimal.AnimalID;
                    nametxt.Text = foundAnimal.Name;
                    speciestxt.Text = foundAnimal.Species;
                    agetxt.Text = foundAnimal.Age.ToString();
                    recoveryscoretxt.Text = foundAnimal.RecoveryScore.ToString();

                    // Switch to Edit Mode
                    animalidtxt.ReadOnly = true;
                    addbtn.Enabled = false;
                    updatebtn.Enabled = true;

                    MessageBox.Show("Animal record found!");
                }
                else
                {
                    MessageBox.Show("No animal found with ID: " + searchID + ", Not Found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching record: " + ex.Message);
            }

        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (animalidtxt.Text == "" || nametxt.Text == "" || speciestxt.Text == "" || agetxt.Text == "" || recoveryscoretxt.Text == "")
                {
                    MessageBox.Show("Please fill in all fields before updating.");
                    return;
                }

                string id = animalidtxt.Text.Trim();
                string name = nametxt.Text.Trim();
                string species = speciestxt.Text.Trim();

                if (!int.TryParse(agetxt.Text.Trim(), out int age) || age < 0)
                {
                    MessageBox.Show("Please enter a valid age.");
                    return;
                }

                if (!int.TryParse(recoveryscoretxt.Text.Trim(), out int score) || score < 0 || score > 100)
                {
                    MessageBox.Show("Recovery score must be between 0 and 100.", "Input Error");
                    return;
                }

                // Create updated Animal object
                Animal updatedAnimal = new Animal(id, name, species, age, score);
                handler.SaveAnimals(updatedAnimal);

                MessageBox.Show("Animal record updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reset Form
                DisplayAllAnimals();
                ClearAllFields();
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("File access denied. Make sure animals.txt is not open or read-only.");
            }
            catch (IOException ex)
            {
                MessageBox.Show("File I/O Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating record: " + ex.Message);
            }

        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            string idToDelete = animalidtxt.Text.Trim();

            if (idToDelete == "")
            {
                MessageBox.Show("Please select or search an animal ID to delete.");
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete animal ID: " + idToDelete + "?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                handler.DeleteAnimal(idToDelete);
                MessageBox.Show("Animal record deleted successfully. Deleted");

                DisplayAllAnimals();
                ClearAllFields();
            }
        }

        private void summarybtn_Click(object sender, EventArgs e)
        {
            string summaryInfo = handler.Summary();
            MessageBox.Show(summaryInfo, "System Summary Report");
        }

        private void clearbtn_Click(object sender, EventArgs e)
        {
            ClearAllFields();
        }
        private void DisplayAllAnimals()
        {
            animalsdfv.DataSource = null;
            animalsdfv.DataSource = handler.GetAnimals();
        }

        private void ClearAllFields()
        {
            animalidtxt.Clear();
            nametxt.Clear();
            speciestxt.Clear();
            agetxt.Clear();
            recoveryscoretxt.Clear();
            searchidtxt.Clear();

            animalidtxt.ReadOnly = false;
            addbtn.Enabled = true;
            updatebtn.Enabled = false;
        }
    }

}
