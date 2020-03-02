using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    class Giraff : Animal
    {
        public Giraff() : base("Giraffe", 2, new Shit(4, 4))
        {
        }
    }
}
