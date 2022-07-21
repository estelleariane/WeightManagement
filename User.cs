using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeightManagement
{
    public class User
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string EmailAddress { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string? Name { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }

       //public User(string e, string n, double h, double w);//
        

        }
    }

