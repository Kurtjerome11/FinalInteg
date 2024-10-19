using MimeKit;
using ParkingManagementData;
using ParkingManagementModels;
using MailKit.Net.Smtp;
using System;
using System.ComponentModel.DataAnnotations;
using ParkingBL;
using ParkingManagementServices;

namespace Client
{
    internal class Program
    {
       public static void Main(string[] args)
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

                        if (SqlDbData.PlateNumberExists(plateNum))
                        {
                            Console.WriteLine("- - - - - - - - - - - - - - - - - - ");
                            Console.WriteLine("The car is already parked.");
                            Console.WriteLine("- - - - - - - - - - - - - - - - - - ");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                        }
                        else
                        {
                            Console.WriteLine("- - - - - - - - - - - - - - - - - - ");
                            Console.WriteLine("What is the color of the Car?");
                            Console.WriteLine("- - - - - - - - - - - - - - - - - - ");
                            string colorCar = Console.ReadLine();
                            SqlDbData.AddCar(plateNum, colorCar);

                            Console.WriteLine("- - - - - - - - - - - - - - - - - - ");
                            Console.WriteLine("Okay Cool! Here's the parking ticket!");
                            Console.WriteLine("- - - - - - - - - - - - - - - - - - ");
                            Email.AddEmail(plateNum, colorCar);
                            Console.WriteLine("- - - - - - - - - - - - - - - - - - ");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                        }
                    }

                    else if (number == "2")
                    {
                        Console.WriteLine("- - - - - - - - - - - - - - - - - - ");
                        Console.WriteLine("What is the plateNumber?");
                        Console.WriteLine("- - - - - - - - - - - - - - - - - - ");
                        string plateNum = Console.ReadLine();

                        if (!SqlDbData.PlateNumberExists(plateNum))
                        {
                            Console.WriteLine("- - - - - - - - - - - - - - - - - - ");
                            Console.WriteLine("The Car is not our parking area anymore.");
                            Console.WriteLine("- - - - - - - - - - - - - - - - - - ");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                        }
                        else
                        {
                            Console.WriteLine("- - - - - - - - - - - - - - - - - - ");
                            Console.WriteLine("What is the color of the Car?");
                            Console.WriteLine("- - - - - - - - - - - - - - - - - - ");
                            string colorCar = Console.ReadLine();
                            SqlDbData.DeleteCar(plateNum);
                            Console.WriteLine("- - - - - - - - - - - - - - - - - - ");
                            Console.WriteLine("Okay Cool! The Data of that Car is Deleted!");
                            Console.WriteLine("- - - - - - - - - - - - - - - - - - ");
                            Email.DeleteEmail(plateNum, colorCar);
                            Console.WriteLine("- - - - - - - - - - - - - - - - - - ");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                        }
                    }
                    else if (number == "3")
                    {
                        Console.WriteLine("- - - - - - - - - - - - - - - - - - ");
                        Console.WriteLine("Okay, heres the plate number and the color of the car that parked:");
                        Console.WriteLine("");
                        GetParked();
                        Console.WriteLine("- - - - - - - - - - - - - - - - - - ");
                        Email.DisplayEmail();
                        Console.WriteLine("- - - - - - - - - - - - - - - - - - ");
                        Console.WriteLine("");
                        Console.WriteLine("");
                        Console.WriteLine("");

                    }
                    else if (number == "4")
                    {
                        Console.WriteLine("- - - - - - - - - - - - - - - - - - ");
                        Console.WriteLine("Okay, What is the plateNumber that you want to update?");
                        Console.WriteLine("- - - - - - - - - - - - - - - - - - ");
                        string originalplateNum = Console.ReadLine();
                        Console.WriteLine("- - - - - - - - - - - - - - - - - - ");
                        Console.WriteLine("Okay, What is the updated plateNumber?");
                        Console.WriteLine("- - - - - - - - - - - - - - - - - - ");
                        string updatedplateNum = Console.ReadLine();
                        Console.WriteLine("- - - - - - - - - - - - - - - - - - ");
                        Console.WriteLine("How about the updated Color of the car?");
                        Console.WriteLine("- - - - - - - - - - - - - - - - - - ");
                        string updatedcolorCar = Console.ReadLine();
                        SqlDbData.UpdateCar(originalplateNum, updatedplateNum, updatedcolorCar);
                        Console.WriteLine("- - - - - - - - - - - - - - - - - - ");
                        Console.WriteLine("- - - - - - - - - - - - - - - - - - ");
                        Console.WriteLine("Okay Cool! The Data of that Car is Updated!");
                        Console.WriteLine("- - - - - - - - - - - - - - - - - - ");
                        Email.UpdateEmail(originalplateNum, updatedplateNum, updatedcolorCar);
                        Console.WriteLine("- - - - - - - - - - - - - - - - - - ");
                        Console.WriteLine("");
                        Console.WriteLine("");
                        Console.WriteLine("");
                    }

                    else
                {
                    Console.WriteLine("ERROR");
                        Console.WriteLine("");
                        Console.WriteLine("");
                        Console.WriteLine("");
                    }


            }
        }


        }

        public static void GetParked()
        {
            List<Park> usersFromDB = SqlDbData.GetParked();

            foreach (var item in usersFromDB)
            {
                Console.WriteLine($"PlateNumber: {item.plateNum}");
                Console.WriteLine($"ColorCar: {item.colorCar}");
                Console.WriteLine(); 
            }

        }
    }
}
