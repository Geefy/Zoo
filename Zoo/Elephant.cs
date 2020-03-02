using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    class Elephant : Animal
    {
        public Elephant() : base("Elephant", 4, new Shit(10, 6))
        {
        }
    }
}
