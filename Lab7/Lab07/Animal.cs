using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    public class Animal
    {
        public string Name { get; set; }
        public string Species { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public string Region { get; set; }
        public bool IsWild { get; set; }
        public bool IsDied { get; set; }

        public double IndexMassBody
        {
            get
            {
                return GetIndexMassBody();
            }
        }

        public double GetIndexMassBody()
        {
            return Weight / (Height * Height);
        }

        public Animal()
        {
           
        }

        public Animal(string name, string species, int age, double weight, double height, string region, bool isWild, bool isDied)
        {
            Name = name;
            Species = species;
            Age = age;
            Weight = weight;
            Height = height;
            Region = region;
            IsWild = isWild;
            IsDied = isDied;
        }
    }
}