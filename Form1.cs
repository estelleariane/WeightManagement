namespace WeightManagement
{
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
            double bmi =

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
                MessageBox.Show("please enter a number for your height!");
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
            private static double Bmi(double height, double weight)
            {
                return (weight / height * height) * 703;
            }

            //User person = new User(name, height, weight);//



            MessageBox.Show("Hi " + name + " you are underweight");
        }

    }
}