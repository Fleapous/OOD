using System;
using PM=Lab1.ParcelsManipulator;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            IParcel[] parcels =
            {
                new OrdinaryParcel()
                {
                    Name = "Ordinary parcel",
                    Weight = 10f,
                    DeliveryDate = DateTime.Today.AddDays(6)
                },
                new OrdinaryParcel()
                {
                    Name = "Food parcel",
                    Weight = 5f,
                    DeliveryDate = DateTime.Today.AddDays(-1)
                },
                new OrdinaryParcel()
                {
                    Name = "Art parcel",
                    Weight = 0.5f,
                    DeliveryDate = DateTime.Today.AddYears(13)
                },
                new OrdinaryParcel()
                {
                    Name = "Parcel with books",
                    Weight = 42f,
                    DeliveryDate = DateTime.Today.AddMonths(1)
                },
                new OrdinaryParcel()
                {
                    Name = "Empty parcel",
                    Weight = 100f,
                    DeliveryDate = DateTime.Today.AddDays(10)
                },
                new OrdinaryParcel()
                {
                    Name = "Very heavy parcel",
                    Weight = 3f,
                    DeliveryDate = DateTime.Today.AddMonths(2)
                },
                new OrdinaryParcel()
                {
                    Name = "Expensive parcel",
                    Weight = 1000f,
                    DeliveryDate = DateTime.Today.AddMonths(-1)
                },
                new OrdinaryParcel()
                {
                    Name = "Test parcel",
                    Weight = 4f,
                    DeliveryDate = DateTime.Today.AddMonths(12)
                },
                new OrdinaryParcel()
                {
                    Name = "Invisible parcel",
                    Weight = 200f,
                    DeliveryDate = DateTime.Today.AddYears(2)
                },
                new OrdinaryParcel()
                {
                    Name = "Unknown parcel",
                    Weight = 15f,
                    DeliveryDate = DateTime.Today.AddDays(4)
                },
            };
            

            foreach (var parcel in parcels)
            {
                Console.WriteLine($"{parcel}\n");
            }

            {
                Console.WriteLine("----------------------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ChangedCubatureParcel\n");
                Console.ForegroundColor = ConsoleColor.White;
                TestPrintParcel(parcels[0]);
                parcels[0] = PM.ChangeParcelCubature(parcels[0], parcels[0].GetCubature() + 10f);
                TestPrintParcel(parcels[0]);

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ColoredParcel\n");
                Console.ForegroundColor = ConsoleColor.White;
                TestPrintParcel(parcels[1]);
                parcels[1] = PM.MakeParcelFragile(parcels[1], FragilityType.Art);
                TestPrintParcel(parcels[1]);

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ExpressParcel\n");
                Console.ForegroundColor = ConsoleColor.White;
                TestPrintParcel(parcels[2]);
                parcels[2] = PM.MakeParcelExpress(parcels[2], 32);
                TestPrintParcel(parcels[2]);

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ForgottenParcel\n");
                Console.ForegroundColor = ConsoleColor.White;
                TestPrintParcel(parcels[3]);
                parcels[3] = PM.SetParcelAsForgotten(parcels[3]);
                TestPrintParcel(parcels[3]);
                
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ForgottenParcel\n");
                Console.ForegroundColor = ConsoleColor.White;
                TestPrintParcel(parcels[8]);
                parcels[8] = PM.ChangeParcelWeight(parcels[8], 10);
                TestPrintParcel(parcels[8]);
                Console.WriteLine("----------------------------------------------------------------------");
            }
            
            //Part 2
            {
                //Write your code here

                //foreach(var parcel, in parcels)
                //{
                //    PM.ChangeParcelCubature(parcels,)
                //}

            }
            
            //Part 3
            //{
            //    //write your code here
            //    IParcel unreadableParcel = ..... parcels[5];
            //    IParcel translatedDescriptionParcel = .... parcels[5];
                
            //    Console.WriteLine("Unreadable parcel");
            //    Console.WriteLine($"{unreadableParcel.Name}");
            //    Console.WriteLine($"{unreadableParcel.GetDescription()}");
                
            //    Console.WriteLine("Translated description parcel");
            //    Console.WriteLine($"{translatedDescriptionParcel.Name}");
            //    Console.WriteLine($"{translatedDescriptionParcel.GetDescription()}");
            //}
            
        }

        private static void TestPrintParcel(IParcel parcel)
        {
            Console.WriteLine($"Name: {parcel.Name}");
            Console.WriteLine($"Weight: {parcel.Weight}");
            Console.WriteLine($"Cubature: {parcel.GetCubature()}");
            Console.WriteLine($"Delivery date: {parcel.DeliveryDate}");
            Console.WriteLine($"Description: {parcel.GetDescription()}\n");
        }
    }
}