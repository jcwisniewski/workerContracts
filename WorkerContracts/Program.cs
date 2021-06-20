using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkerContracts.Entities.Enums;



namespace WorkerContracts
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter departament name: ");
            string depName = Console.ReadLine();

            Console.WriteLine("Enter Worker data: ");
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Level: Junior/MiddleLevel/Senior: ");
            WorkerLevel level  = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.WriteLine("Base Salary: ");
            double baseSalary = double.Parse(Console.ReadLine());
            Console.WriteLine("How many contracts to this worker ? ");


            Departament departament = new Departament(depName);

            Worker workerOne = new Worker(name, baseSalary, level, departament);

            int contracts = int.Parse(Console.ReadLine());
            
            for (int i =0; i<contracts; i++)
            {
                Console.WriteLine("Enter the contracts data  #" + i);
                Console.WriteLine("Date (DD/YY/MM): ");
                DateTime date =  DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine());
                Console.WriteLine("Hours: ");
                int hours = int.Parse(Console.ReadLine());
                HourContract contract = new HourContract(date, valuePerHour, hours);
                workerOne.addContracts(contract);

            }

            Console.WriteLine("Enter month and year to calculate income (MM/YYYY): ");
            string monthYear = Console.ReadLine();
            int month = int.Parse(monthYear.Substring(0, 2));
            int year = int.Parse(monthYear.Substring(3));


            Console.WriteLine("Name: "+ workerOne.Name);
            Console.WriteLine("Departament: " + workerOne.Departament.Name);
            Console.WriteLine("Income for " + monthYear + ": " + workerOne.income(month, year).ToString());
            


















            /* CreateHostBuilder(args).Build().Run(); */
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
