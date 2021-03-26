using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircusTrein
{
    public class Animal
    {
        public readonly AnimalSize AnimalSize;
        public readonly AnimalType AnimalType;
        public Animal(AnimalSize size, AnimalType type)
        {
            this.AnimalSize = size;
            this.AnimalType = type;
        }
    }
}
