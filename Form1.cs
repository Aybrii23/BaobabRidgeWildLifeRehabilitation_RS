using BaobabRidgeWildlifeRehabilitation_RS.BusinessLayer;
using BaobabRidgeWildlifeRehabilitation_RS.DataLayer;

namespace BaobabRidgeWildlifeRehabilitation_RS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
            
        {
            AnimalRepo repo = new AnimalRepo();
            List<Animal> animallist = repo.GetAllAnimalsFromFile();
            dgvAnimalsOutput.DataSource = animallist;
            dgvAnimalsOutput.ReadOnly = true;
        }
    }
}
