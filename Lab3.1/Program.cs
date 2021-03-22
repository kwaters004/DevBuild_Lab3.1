using System;
using System.Threading;

namespace Lab3._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Lab 3.1!");
            bool done = false;
            while (!done)
            {
                Console.WriteLine("\nHere are the students in the class: ");
                string[] students = { "Claude", "Johnnie", "Julie", "Agnes", "Jaime", "Eleanor", "Joanne", "Ismael", "Valerie", "Caroline" };
                string[] favFood = { "tacos", "burgers", "pizza", "grapes", "chicken fingers", "cornish hen", "pizza", "asparagus", "french fries", "chocolate" };
                string[] hobby = { "gaming", "reading", "running", "climbing", "knitting", "cooking", "cleaning", "swimming", "driving", "working out" };
                for (int student = 0; student < students.Length; student++)
                {
                    Console.WriteLine($"{student + 1}. {students[student]}");
                }
                bool valid = false;
                int choice = 0;
                while (!valid)
                {
                    Console.Write($"\nWhich student would you like to know more about? (Enter 1-{students.Length}): ");
                    try
                    {
                        choice = Int32.Parse(Console.ReadLine());
                        if (choice > 0 && choice <= 10)
                        {
                            valid = true;
                        }
                        else
                        {
                            Console.WriteLine("\nSorry, that was not a valid choice. Please try again.");
                        }
                    }
                    catch
                    {
                        Console.WriteLine("\nSorry, that was not a valid choice. Please try again.");
                    }
                }
                Console.Clear();
                Console.WriteLine($"\nYou have chosen: {students[choice - 1]}");
                string ownership = "'s";
                string catChoice = "";
                int catIntChoice = 0;
                valid = false;
                while (!valid)
                {
                    string lastLetter = students[choice-1].Substring(students[choice - 1].Length - 1,1);
                    if (lastLetter == "s")
                    {
                        ownership = "'";
                    }
                    Console.Write($"\nWould you like to know about {students[choice - 1]}{ownership} favorite food(1) or hobby(2)? ");

                    catChoice = Console.ReadLine();
                    try
                    {
                        

                        catIntChoice = Int32.Parse(catChoice);
                        if (catIntChoice == 1 || catIntChoice == 2)
                        {
                            valid = true;
                            if (catIntChoice == 1)
                            {
                                Console.WriteLine($"\n{students[choice - 1]}{ownership} favorite food is {favFood[choice - 1]}!");
                            }
                            else if (catIntChoice == 2)
                            {
                                Console.WriteLine($"\n{students[choice - 1]}{ownership} hobby is {hobby[choice - 1]}!");
                            }
                        }
                        else
                        {

                            
                            Console.WriteLine("\nSorry, that was not a valid choice. Please try again.");
                        }
                    }
                    catch
                    {
                        catChoice = catChoice.ToLower();
                        if (catChoice == "favorite food" || catChoice == "food" || catChoice == "hobby")
                        {
                            if (catChoice.Substring(0, 1) == "f")
                            {
                                catIntChoice = 1;
                                Console.WriteLine($"\n{students[choice - 1]}{ownership} favorite food is {favFood[choice - 1]}!");
                                valid = true;
                            }
                            else
                            {
                                catIntChoice = 2;
                                Console.WriteLine($"\n{students[choice - 1]}{ownership} hobby is {hobby[choice - 1]}!");
                                valid = true;
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nSorry, that was not a valid choice. Please try again.");
                        }
                        
                    }
                }

                static void clearPauseRestart()
                {
                    Console.WriteLine("Awesome! Let's get you back to the beginning!");
                    Thread.Sleep(1500);
                    Console.Clear();
                }

                static int secondQuestion()
                {
                    bool valid = false;
                    while (!valid)
                    {
                        //Console.Clear();
                        Console.WriteLine("\nWhat would you like to do next?\n");
                        Console.WriteLine("1) Get information about another student");
                        Console.WriteLine("2) Exit the program");
                        Console.Write("Please enter 1-2 >> ");
                        try
                        {
                            int ans2 = Int32.Parse(Console.ReadLine());
                            valid = true;
                            if (ans2 > 0 && ans2 <= 2)
                            {
                                return ans2;
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Sorry, that was not a valid input. Please try again.");
                            return 0;
                        }
                    }
                    return 0;
                }
                valid = false;
                while (!valid)
                {
                    //Console.Clear();
                    Console.WriteLine("\nWhat would you like to do next?\n");
                    Console.WriteLine($"1) Additional information about {students[choice - 1]}");
                    Console.WriteLine("2) Get information about another student");
                    Console.WriteLine("3) Exit the program");
                    Console.Write("Please enter 1-3 >> ");
                    //Console.Write("Would you like to know additional information about this student (y/n)? ");
                    try
                    {
                        int ans = Int32.Parse(Console.ReadLine());
                        if (ans > 0 && ans <= 3)
                        {
                            if (ans == 1)
                            {
                                valid = true;
                                if (catIntChoice == 2)
                                {
                                    Console.WriteLine($"\n{students[choice - 1]}'s favorite food is {favFood[choice - 1]}!");
                                    if (secondQuestion() == 2)
                                    {
                                        Console.WriteLine("\nThanks for stopping by!\n");
                                        done = true;
                                    }
                                    else
                                    {
                                        clearPauseRestart();
                                    }
                                }
                                else if (catIntChoice == 1)
                                {
                                    Console.WriteLine($"\n{students[choice - 1]}'s hobby is {hobby[choice - 1]}!");
                                    if (secondQuestion() == 2)
                                    {
                                        Console.WriteLine("\nThanks for stopping by!\n");
                                        done = true;
                                    }
                                    else
                                    {
                                        clearPauseRestart();
                                    }
                                }
                            }
                            else if (ans == 2)
                            {
                                valid = true;
                                clearPauseRestart();
                            }
                            else if (ans == 3)
                            {
                                valid = true;
                                done = true;
                                Console.WriteLine("Thanks for stopping by!");
                            }
                        }
                    }
                    catch
                    {
                        Console.WriteLine("\nSorry, that was not a valid option. Please try again\n");
                    }
                }
            }
        }
    }
}
