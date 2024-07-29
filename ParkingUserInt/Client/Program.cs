using ParkingManagementData;
using ParkingManagementModels;
using System;

namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool active = true;
            while (active)
            {
                {
                    Console.WriteLine("- - - - - - - - - - - - - - - - - - ");
                    Console.WriteLine("|Kurt's Parking Management System|");
                    Console.WriteLine("- - - - - - - - - - - - - - - - - - ");
                    Console.WriteLine("What's good in the hood?");
                    Console.WriteLine("1.Car wants to Park");
                    Console.WriteLine("2.Car wants to go Out");
                    Console.WriteLine("3.View Color and PlateNumber of the Cars that Parked");
                    Console.WriteLine("4.Update the Color and PlateNumber of the Cars that Parked");
                    Console.WriteLine("- - - - - - - - - - - - - - - - - - ");


                    Console.WriteLine("Enter the number of your choice:");
                    string number = Console.ReadLine();

                    if (number == "1")
                    {
                        Console.WriteLine("- - - - - - - - - - - - - - - - - - ");
                        Console.WriteLine("What is the plateNumber?");
                        Console.WriteLine("- - - - - - - - - - - - - - - - - - ");
                        string plateNum = Console.ReadLine();


                        Console.WriteLine("- - - - - - - - - - - - - - - - - - ");
                        Console.WriteLine("What is the color of the Car?");
                        Console.WriteLine("- - - - - - - - - - - - - - - - - - ");
                        string colorCar = Console.ReadLine();
                        SqlDbData.AddCar(plateNum, colorCar);

                        Console.WriteLine("- - - - - - - - - - - - - - - - - - ");
                        Console.WriteLine("Okay Cool! Heres the parking ticket!");
                        Console.WriteLine("- - - - - - - - - - - - - - - - - - ");

                    }

                    else if (number == "2")
                    {
                        Console.WriteLine("- - - - - - - - - - - - - - - - - - ");
                        Console.WriteLine("What is the plateNumber?");
                        Console.WriteLine("- - - - - - - - - - - - - - - - - - ");
                        string plateNum = Console.ReadLine();
                        SqlDbData.DeleteCar(plateNum);

                        Console.WriteLine("- - - - - - - - - - - - - - - - - - ");
                        Console.WriteLine("Okay Cool! The Data of that Car is Deleted!");
                        Console.WriteLine("- - - - - - - - - - - - - - - - - - ");
                    }
                    else if (number == "3")
                    {
                        Console.WriteLine("- - - - - - - - - - - - - - - - - - ");
                        Console.WriteLine("Okay, heres the plate number and the color of the car that parked:");
                        Console.WriteLine("");
                        GetParked();
                        Console.WriteLine("- - - - - - - - - - - - - - - - - - ");
                    }
                    else if (number == "4")
                    {
                        Console.WriteLine("- - - - - - - - - - - - - - - - - - ");
                        Console.WriteLine("Okay, What is the plateNumber that you want to update?");
                        Console.WriteLine("- - - - - - - - - - - - - - - - - - ");
                        string plateNum = Console.ReadLine();
                        Console.WriteLine("- - - - - - - - - - - - - - - - - - ");
                        Console.WriteLine("Okay, What is the updated plateNumber?");
                        Console.WriteLine("- - - - - - - - - - - - - - - - - - ");
                        string parkedNum = Console.ReadLine();
                        Console.WriteLine("- - - - - - - - - - - - - - - - - - ");
                        Console.WriteLine("How about the updated Color of the car?");
                        Console.WriteLine("- - - - - - - - - - - - - - - - - - ");
                        string colorCar = Console.ReadLine();
                        SqlDbData.UpdateCar(parkedNum,colorCar);
                        Console.WriteLine("- - - - - - - - - - - - - - - - - - ");

                        Console.WriteLine("- - - - - - - - - - - - - - - - - - ");
                        Console.WriteLine("Okay Cool! The Data of that Car is Updated!");
                        Console.WriteLine("- - - - - - - - - - - - - - - - - - ");
                    }

                    else
                {
                    Console.WriteLine("ERROR");
                }


            }
        }


        }

        public static void GetParked()
        {
            List<Park> usersFromDB = SqlDbData.GetParked();

            foreach (var item in usersFromDB)
            {
                Console.WriteLine(item.plateNum);
                Console.WriteLine(item.colorCar);
            }
        }
    }
}
