using System;
using System.Threading;

namespace Zoo
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread GuestThread = new Thread(Zoo.GetZoo().GuestWatchingAnimals);
            GuestThread.Start();

            Zoo.GetZoo().GuestIsWatching += GuestWatched;
            
            foreach (Enclosure enclosure in Zoo.GetZoo().Enclosures)
            {
                enclosure.AnimalIsShitting += AnimalShat;
                Thread enclosureThread = new Thread(enclosure.AnimalShit);
                enclosureThread.Start();
            }

            foreach (Worker worker in Zoo.GetZoo().Workers)
            {
                foreach (Enclosure enclosure in Zoo.GetZoo().Enclosures)
                {

                    Thread workerThread = new Thread(worker.CleanEnclosure);
                    workerThread.Start(enclosure);
                }
                worker.workerWorking += WorkerWorked;
            }
            
        }

        static void WorkerWorked(object sender, EventArgs e)
        {
            string msg = (string)sender;
            Console.WriteLine(msg);
        }
        static void AnimalShat(object sender, EventArgs e)
        {
            string msg = (string)sender;
            Console.WriteLine(msg);
        }
        static void GuestWatched(object sender, EventArgs e)
        {
            string msg = (string)sender;
            Console.WriteLine(msg);
        }
    }
}
