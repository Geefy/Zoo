using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    class Shit
    {
        double shitStenchFactor;
        int timeToClean;

        public Shit(double shitStenchFactor, int timeToClean)
        {
            this.ShitStenchFactor = shitStenchFactor;
            this.TimeToClean = timeToClean * 100;
        }

        public double ShitStenchFactor { get => shitStenchFactor; set => shitStenchFactor = value; }
        public int TimeToClean { get => timeToClean; set => timeToClean = value; }
    }
}
