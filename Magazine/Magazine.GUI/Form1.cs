using System.Windows.Forms;

namespace Magazine.GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var magazine = new Magazine(new StudentsRepository());

            foreach (var listStudent in magazine.GetAll())
            {
                listBox1.Items.Add(listStudent.ToString());
            }
        }
    }
}
