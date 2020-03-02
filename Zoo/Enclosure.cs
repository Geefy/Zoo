using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Zoo
{
    class Enclosure
    {
        public Animal species;
        public static object _lock = new object();
        public event EventHandler AnimalIsShitting;
        int speciesAmount;
        public List<Shit> shitInEnclosure = new List<Shit>();

        public Enclosure(Animal species, int amount)
        {
            this.species = species;
            this.speciesAmount = amount;
        }

        public void AnimalShit()
        {
            while (true)
            {
                lock (_lock)
                {

                    for (int i = 0; i < speciesAmount; i++)
                    {
                        AnimalIsShitting?.Invoke(species.Name + " is shitting", new EventArgs());

                        shitInEnclosure.Add(species.ShitInEnclosure());
                        Monitor.PulseAll(_lock);
                        Thread.Sleep(species.ShitHr);
                    }
                    Monitor.Wait(_lock);
                }
            }
        }
    }
}
