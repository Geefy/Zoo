using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Zoo
{
    class Zoo
    {
        public static object _lock = new object();
        public event EventHandler GuestIsWatching;
        private static Zoo instance;
        List<Enclosure> enclosures = new List<Enclosure>();
        List<Worker> workers = new List<Worker>();
        List<Guest> guests = new List<Guest>();
        private Zoo()
        {
            for (int i = 0; i < 12; i++)
            {
                guests.Add(new Guest());
            }
            for (int i = 0; i < 2; i++)
            {
                Workers.Add(new Worker());
            }
            Enclosures.Add(new Enclosure(new Elephant(), 6));
            Enclosures.Add(new Enclosure(new Giraff(), 12));
        }

        internal List<Guest> Guests { get => guests; set => guests = value; }
        internal List<Worker> Workers { get => workers; set => workers = value; }
        internal List<Enclosure> Enclosures { get => enclosures; set => enclosures = value; }

        public static Zoo GetZoo()
        {
            lock (_lock)
            {

                if (instance == null)
                {
                    instance = new Zoo();
                }
                return instance;
            }
        }

        public void GuestWatchingAnimals()
        {
            while (true)
            {

                lock (_lock)
                {

                    for (int i = 0; i < guests.Count; i++)
                    {
                        foreach (Enclosure enclosure in Enclosures)
                        {
                            guests[i].WatchAnimal(enclosure);
                            Monitor.PulseAll(_lock);
                            GuestIsWatching?.Invoke("Guest " + i + " is watching " + enclosure.species.Name, new EventArgs());

                        }
                        if (guests[i].Happiness < 50)
                        {
                            GuestIsWatching?.Invoke("Guest " + i + " happiness is low currently: " + guests[i].Happiness, new EventArgs());
                        }
                    }
                    Thread.Sleep(60000);
                }
            }
        }
    }
}
