using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Zoo
{
    class Worker
    {
        public event EventHandler workerWorking;
        public Worker()
        {
        }
        public void CleanEnclosure(object temp)
        {

            Enclosure enclosure = (Enclosure)temp;
            while (true)
            {

                lock (Enclosure._lock)
                {


                    foreach (Shit shit in enclosure.shitInEnclosure)
                    {
                        CleanShit(shit);
                        workerWorking?.Invoke("Worker is cleaning shit up at " + enclosure.species.Name, new EventArgs());
                        Monitor.PulseAll(Enclosure._lock);
                        Thread.Sleep(enclosure.species.Shit.TimeToClean);
                    }
                    enclosure.shitInEnclosure.Clear();
                    Monitor.Wait(Enclosure._lock);
                }

            }
        }

        void CleanShit(Shit shit)
        {
            foreach (Guest guest in Zoo.GetZoo().Guests)
            {
                guest.Happiness += shit.ShitStenchFactor;
            }
        }
    }
}
