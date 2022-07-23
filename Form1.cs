namespace WeightManagement
{
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox5.Text;
            string height_Text = textBox2.Text;
            double height;
            string weight_Text = textBox1.Text;
            double weight;
            string email = textBox3.Text;

            if (String.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("please enter your Name!");
                return;
            }
            if (String.IsNullOrWhiteSpace(height_Text))
            {
                MessageBox.Show("please enter your Height!");
                return;
            }
            if (!double.TryParse(height_Text, out height))
            {
                MessageBox.Show("please enter a valid number for your height!");
                ErrorLogging("please enter a valid number for your height!");
                return;
            }
            if (height <= 0)
            {
                MessageBox.Show("please enter a number bigger than 0 for your height");
                return;
            }

            if (String.IsNullOrWhiteSpace(weight_Text))
            {
                MessageBox.Show("please enter your Weight!");
                return;
            }
            if (!double.TryParse(weight_Text, out weight))
            {
                MessageBox.Show("please enter a number for your weight!");
                return;
            }
            if (weight <= 0)
            {
                MessageBox.Show("please enter a number bigger than 0 for your weight");
                return;
            }
            if (String.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("please enter your email!");
                return;
            }

            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (!match.Success)
            {
                MessageBox.Show("your email is not valid!");
                return;
            }

            if (heightUnit.Text == "FT")
            {
                height = height / 3.28084;
            }

            if (weightUnit.Text == "LB")
            {
                weight = weight / 2.20462262185;
            }

            User person = new User(Name, email, weight, height);

            if (person.BMi <= 18.4)
            {
                MessageBox.Show("your BMI is " + person.BMi + " you are underweight!");
            }

        }

        private void ErrorLogging(String message)
        {
            string strPath = @"C:\Temp\Log.txt";
            if (!File.Exists(strPath))
            {
                File.Create(strPath).Dispose();
            }
            using (StreamWriter sw = File.AppendText(strPath))
            {
                sw.WriteLine("=============Error Logging ===========");
                sw.WriteLine("===========Start============= " + DateTime.Now);
                sw.WriteLine("Error Message: " + message);
                sw.WriteLine("===========End============= " + DateTime.Now);

            }
        }
    }
}