using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Zoo
{
    class Guest
    {
        double happiness = 100;

        public Guest()
        {

        }

        public double Happiness { get => happiness; set => happiness = value; }

        public void WatchAnimal(Enclosure enclosure)
        {
            lock (Enclosure._lock)
            {

                foreach (Shit shit in enclosure.shitInEnclosure)
                {
                    Happiness -= enclosure.species.Shit.ShitStenchFactor;
                }
                Monitor.PulseAll(Enclosure._lock);
            }
        }
    }
}
