using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace WeightManagement
{
    public class User
    {
        public string EmailAddress { get; set; }

        public string Name { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public double BMi
        {
            get
            {
                return CalculateUserBmi();
            }
        }

       public User(string e, string n, double w, double h)
        {
            EmailAddress = e;
            Name = n;   
            Weight = w;
            Height = h;
        }
        public double CalculateUserBmi()
        {
            return Weight /( Height * Height);
        }

        public bool IsEmailValid()
        {
            try
            {
                MailAddress m = new MailAddress(EmailAddress);

                return true;
            }
            catch (FormatException ex)
            {
                ErrorLogging(ex);
                return false;
            }
        }

        public static void ErrorLogging(Exception ex)
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
                sw.WriteLine("Error Message: " + ex.Message);
                sw.WriteLine("Stack Trace: " + ex.StackTrace);
                sw.WriteLine("===========End============= " + DateTime.Now);

            }
        }
    }
  
    }


