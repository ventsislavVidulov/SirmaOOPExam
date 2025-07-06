using SirmaOOPExam.Core.Interfaces;
using SirmaOOPExam.Core.Models;
using SirmaOOPExam.Core.Services;
using SirmaOOPExam.Infrastructure.FileManagment;
using SirmaOOPExam.Infrastructure.FileManagment.Utils;
using SirmaOOPExam.Infrastructure.UI.Menus.MainMenu;
using SirmaOOPExam.Infrastructure.UI.Menus.MainMenu.Options;
using SirmaOOPExam.Infrastructure.UI.Menus.ManageOrders;
using SirmaOOPExam.Infrastructure.UI.Menus.ManageOrders.Options;

namespace SirmaOOPExam
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            DateOnly.TryParse("1/1/1111", out DateOnly dateTime);
            Console.WriteLine(dateTime);

            //initialize and inject the dependencies of FileManagerAsync
            CSVFileManipulator csvFileManipulator = new CSVFileManipulator();
            Converter converter = new Converter();
            FileManagerAsync fileManager = new(csvFileManipulator, converter);

            //load data from CSV files and convert their types from class instances to interfaces
            //the file managment uses reflection to read the data so it needs to know the concrete types
            List<Car> carsFromCSV = await fileManager.GetAllCarsFromFile();
            List<ICar> cars = new List<ICar>();
            foreach (var car in carsFromCSV)
            {
                cars.Add((ICar)car);
            }
            List<Customer> customersFromCSV = await fileManager.GetAllCustomersFromFile();
            List<ICustomer> customers = new List<ICustomer>();
            foreach (var customer in customersFromCSV)
            {
                customers.Add((ICustomer)customer);
            }
            List<RentalOrder> rentalOrdersFromCSV = await fileManager.GetAllRentalOrdersFromFile();
            List<IRentalOrder> rentalOrders = new List<IRentalOrder>();
            foreach (var order in rentalOrdersFromCSV)
            {
                rentalOrders.Add((IRentalOrder)order);
            }

            //initialize the rental order service with the loaded data
            IRentalOrderService rentalOrderService = new RentalOrderService(rentalOrders, cars, customers);

            //initialize the menu options and menus
            int choise = 0;
            bool exit = false;
            string currentMenu = "Main Menu";

            MainMenu mainMenu = new();
            mainMenu.RegisterOption(new ManageOrdersOption());
            mainMenu.RegisterOption(new ManageCarsOption());
            mainMenu.RegisterOption(new ManageCustomersOption());
            mainMenu.RegisterOption(new ExitOption());

            ManageOrdersMenu manageOrdersMenu = new();
            manageOrdersMenu.RegisterOption(new RentCarOption(rentalOrderService));
            manageOrdersMenu.RegisterOption(new ReturnCarOption(rentalOrderService));
            manageOrdersMenu.RegisterOption(new BackToMainOption());

            while (!exit)
            {
                if (currentMenu == "Main Menu")
                {
                    choise = mainMenu.DisplayMenu();
                    if (choise == 1)
                    {
                        currentMenu = "Manage Orders";
                    }
                    else if (choise == 2)
                    {
                        currentMenu = "Manage Cars";
                    }
                    else if (choise == 3)
                    {
                        currentMenu = "Manage Customers";
                    }
                    else if (choise == 4)
                    {
                        exit = true;
                    }
                }
                else if (currentMenu == "Manage Orders")
                {
                    choise = manageOrdersMenu.DisplayMenu();
                    if (choise != 3)
                    {
                        manageOrdersMenu.ExecuteOption(choise);
                    }
                    else if (choise == 3)
                    {
                        currentMenu = "Main Menu";
                    }
                }
            }

            //save the data back to the CSV files before exiting, again converting the type of lists
            //from interfaces to concrete classes
            customersFromCSV.Clear();
            foreach (var customer in customers)
            {
                customersFromCSV.Add((Customer)customer);
            }
            carsFromCSV.Clear();
            foreach (var car in cars)
            {
                carsFromCSV.Add((Car)car);
            }
            rentalOrdersFromCSV.Clear();
            foreach (var order in rentalOrders)
            {
                rentalOrdersFromCSV.Add((RentalOrder)order);
            }
            await fileManager.SaveAllCarsToFile(carsFromCSV);
            await fileManager.SaveAllCustomersToFile(customersFromCSV);
            await fileManager.SaveAllRentalOrdersToFile(rentalOrdersFromCSV);
        }
    }
}
