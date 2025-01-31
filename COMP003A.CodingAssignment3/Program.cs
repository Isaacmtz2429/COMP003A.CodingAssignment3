/*
// Author: Isaac Martinez
// Course: COMP-003A
// Faculty: Jonathan Cruz
// Purpose: Budget management application demonstrating control flow.
*/
using System.Diagnostics;

namespace COMP003A.CodingAssignment3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Budget Management Tool!\n");

            Console.Write("Enter your monthly income: ");
            int income = int.Parse(Console.ReadLine());

            // Two empty list, one to store the name of the expenses and the other is for the amount
            List<string> expenseNames = new List<string>();
            List<int> expensesAmounts = new List<int>();

            bool exit = false; //keep the program running

            while (!exit) //keeps loop running until existing

            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Add an Expense");
                Console.WriteLine("2. View Expense and Budget");
                Console.WriteLine("3. Remove an Expense");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Write("Enter the expense name: ");
                        string expenseName = Console.ReadLine();
                        Console.Write("Enter the expense amount: ");
                        int expenseAmount = int.Parse(Console.ReadLine());

                        expenseNames.Add(expenseName);
                        expensesAmounts.Add(expenseAmount);

                        Console.WriteLine("Expense added successfully!");
                        break;
                    case "2":
                        Console.WriteLine("\nView Expenses and Budget:");
                        int totalExpenses = 0;

                        for (int i = 0; i < expenseNames.Count; i++) // expenseNames.Count tells how many expenses have been added so far
                        {
                            Console.WriteLine($"{expenseNames[i]}: {expensesAmounts[i]:C}"); // ":C" changes the number format into a currency format
                            totalExpenses += expensesAmounts[i];
                        }

                        Console.WriteLine($"Total Expenses: {totalExpenses:C}");
                        Console.WriteLine($"Remainig Budget: {income - totalExpenses:C}");
                        break;
                    case "3":

                        // IdexToRemove will help find which expense to remove
                        Console.Write("Enter the name of the expense to remove: ");
                        string removeExpenseName = Console.ReadLine();
                        int indextoRemove = expenseNames.IndexOf(removeExpenseName);

                        if (indextoRemove >= 0)
                        {
                            expenseNames.RemoveAt(indextoRemove);
                            expensesAmounts.RemoveAt(indextoRemove);

                            Console.WriteLine("Expense removed successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Expense not found.");
                        }
                        break;
                    case "4":
                        Console.WriteLine("\nGoodbye!");
                        exit = true;
                        break;
                }
            }
        }
    }
}
