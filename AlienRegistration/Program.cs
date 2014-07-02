using AlienRegistrationCoreLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlienRegistration
{
    class Program
    {
        static void Main(string[] args)
        {

            char choice = 'y';
            int option;
            string[] types = new string[10];

            do
            {
                Console.WriteLine("Welcome to Alien Registration");
                Console.WriteLine("------------------------------------");

                Console.WriteLine("Enter the Code Name: ");
                string codeName = Console.ReadLine();
                Console.WriteLine("Enter the Blood color: ");
                string bloodColor = Console.ReadLine();
                Console.WriteLine("Enter the number of Antennas: ");
                string antennaNumber = Console.ReadLine();
                Console.WriteLine("Enter the number of Legs: ");
                string legsNumber = Console.ReadLine();
                Console.WriteLine("Enter the name of Home Planet: ");
                string planetName = Console.ReadLine();

                string msg =
                    String.Format("\r\nCode Name: {0} \r\n Blood Color: {1} \r\n Number of Antennas: {2} \r\n Number of Legs: {3} \r\n Home Planet: {4}",
                        codeName, bloodColor, antennaNumber, legsNumber, planetName);

            tryagain:
                Console.WriteLine("How do you want to save the data?");
                int i = 1, j = 0;
                foreach (FileWriterHost fw in FileWriterHostProvider.Writers)
                {
                    types[j] = fw.GetDescription();
                    Console.WriteLine("{0}. {1}", i, fw.GetDescription());
                    i = i + 1;
                    j = j + 1;
                }

                try
                {
                    option = Convert.ToInt32(Console.ReadLine());
                    foreach (FileWriterHost fw in FileWriterHostProvider.Writers.Where(s => s.GetDescription() == types[option - 1]))
                    {
                        fw.X = msg;
                        fw.FileWrite();
                    }
                }
                catch
                {
                    Console.WriteLine("Enter valid Input");
                    goto tryagain;
                }
                //Console.WriteLine("Do you want to register another Alien..? (y/n)");
                //choice = (char)Console.Read();
                Console.Clear();
            }
            while (choice == 'y');
        }
    }
}
