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
                ErrorLogging(" Name cannot be empty");
                return;
            }

            if (String.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("please enter your email!");
                ErrorLogging(" Email cannot be empty");
                return;
            }

            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (!match.Success)
            {
                MessageBox.Show("your email is not valid!");
                return;
            }

            if (String.IsNullOrWhiteSpace(height_Text))
            {
                MessageBox.Show("please enter your Height!");
                ErrorLogging(" Height cannot be empty");
                return;
            }
            if (!double.TryParse(height_Text, out height))
            {
                MessageBox.Show("please enter a valid number for your height!");
                ErrorLogging(" Height has to be an integer!");
                return;
            }
            if (height <= 0)
            {
                MessageBox.Show("please enter a number bigger than 0 for your height");
                ErrorLogging(" Height cannot be less than 0!");
                return;
            }

            if (String.IsNullOrWhiteSpace(weight_Text))
            {
                MessageBox.Show("please enter your Weight!");
                ErrorLogging(" Weight cannot be empty");
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

            if (heightUnit.Text == "FT")
            {
                height = height / 3.28084;
            }

            if (weightUnit.Text == "LB")
            {
                weight = weight / 2.20462262185;
            }

            User person = new User(email, name, weight, height);

            if (!person.IsEmailValid())
            {
                MessageBox.Show("your email is not valid!");
                return;
            }

            if (person.Bmi <= 18.4)
            {
                MessageBox.Show("your BMI is " + person.Bmi + " you are Underweight!");
            }


            if (person.Bmi > 18.4 && person.Bmi <= 24.9)
            {
                MessageBox.Show("your BMI is " + person.Bmi + " you are Healthy!");
            }

            if (person.Bmi > 24.9 && person.Bmi <= 39.9)
            {
                MessageBox.Show("your BMI is " + person.Bmi + " you are Overweight!");
            }

            if (person.Bmi >= 40.0)
            {
                MessageBox.Show("your BMI is " + person.Bmi + " you are Obese!");
            }

        }

        private void ErrorLogging(String message)
        {
            string strPath = @"..\..\..\LogFolder\Log.txt";
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