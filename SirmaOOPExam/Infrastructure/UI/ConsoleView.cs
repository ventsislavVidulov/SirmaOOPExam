using SirmaOOPExam.Core.Interfaces;
using SirmaOOPExam.Infrastructure.UI.Menus.Interfaces;

namespace SirmaOOPExam.Infrastructure.UserInterface
{
    public static class ConsoleView
    {
        public static void ClearConsole()
        {
            Console.Clear();
        }

        public static void DisplayHeader(string title)
        {
            ClearConsole();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("------------------------------------------");
            Console.WriteLine($" {title.ToUpper()}");
            Console.WriteLine("------------------------------------------");
            Console.ResetColor();
            Console.WriteLine();
        }

        public static void DisplayMessage(string message, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void DisplayError(string errorMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error: {errorMessage}");
            Console.ResetColor();
            PromptToContinue();
        }

        public static string GetStringInput(string prompt)
        {
            DisplayMessage(prompt, ConsoleColor.Yellow);
            return Console.ReadLine();
        }

        public static int GetIntegerInput(string prompt)
        {
            int value;
            while (true)
            {
                DisplayMessage(prompt, ConsoleColor.Yellow);
                string input = Console.ReadLine();
                if (int.TryParse(input, out value))
                {
                    return value;
                }
                DisplayError("Invalid input. Please enter a valid integer.");
            }
        }

        public static DateOnly GetDateInput(string prompt)
        {
            DateOnly date;
            while (true)
            {
                DisplayMessage(prompt, ConsoleColor.Yellow);
                string input = Console.ReadLine();
                if (DateOnly.TryParse(input, out date))
                {
                    return date;
                }
                DisplayError("Invalid input. Please enter a valid date (e.g., 2023-10-01).");
            }
        }

        public static decimal GetDecimalInput(string prompt)
        {
            decimal value;
            while (true)
            {
                DisplayMessage(prompt, ConsoleColor.Yellow);
                string input = Console.ReadLine();
                if (decimal.TryParse(input, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out value))
                {
                    return value;
                }
                DisplayError("Invalid input. Please enter a valid decimal number (e.g., 12.99).");
            }
        }

        public static void DisplayOption(IMenuOption option)
        {
            DisplayMessage($"{option.CommandNumber}. {option.MenuText}", ConsoleColor.White);
        }

        public static void DisplayCars(List<ICar> cars)
        {
            if (!cars.Any())
            {
                DisplayMessage("No cars available.", ConsoleColor.Yellow);
                return;
            }

            //ConsoleView.DisplayMessage("Available Cars:", ConsoleColor.White);
            foreach (var car in cars)
            {
                ConsoleView.DisplayMessage($"Car id: {car.Id}, {car.Make} {car.Model} {car.Year} {car.Type} {car.Availability}");
            }
        }

        public static void DisplayCustomers(List<ICustomer> customers)
        {
            if (!customers.Any())
            {
                DisplayMessage("No customers available.", ConsoleColor.Yellow);
                return;
            }

            ConsoleView.DisplayMessage("Customers:", ConsoleColor.White);
            foreach (var customer in customers)
            {
                ConsoleView.DisplayMessage($"Customer id: {customer.Id}, {customer.Name}");
            }
        }
        public static void PromptToContinue()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Press any key to continue...");
            Console.ResetColor();
            Console.ReadKey(true);
        }
    }
}