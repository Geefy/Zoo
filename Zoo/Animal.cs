using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    abstract class Animal
    {
        string name;
        int shitHr;
        Shit shit;
        public Animal(string name, int shitHr, Shit shit)
        {
            this.Name = name;
            this.shitHr = shitHr * 10000;
            this.Shit = shit;
        }

        public string Name { get => name; set => name = value; }
        public int ShitHr { get => shitHr; set => shitHr = value; }
        internal Shit Shit { get => shit; set => shit = value; }

        public virtual Shit ShitInEnclosure()
        {
            return shit;
        }
    }
}
