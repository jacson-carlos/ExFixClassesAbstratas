using System;
using System.Globalization;
using System.Collections.Generic;
using ExFixClassesAbstratas.Entities;
namespace ExFixClassesAbstratas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of tax payers: ");
            int n = int.Parse(Console.ReadLine());

            List<TaxPayer> ListTaxPayer = new List<TaxPayer>();
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Tax payer #{i} data: ");
                Console.Write("Individual or company (i/c)? ");
                char resp = char.Parse(Console.ReadLine());

                Console.Write("Name: ");
                String Name = Console.ReadLine();

                Console.Write("Anual income: ");
                double AnualIncome = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);


                if (resp == 'i' || resp == 'I')
                {
                    if (AnualIncome >= 20000.00)
                    {
                        Console.Write("Health expeditures: ");
                        double HealthExpeditures = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                        ListTaxPayer.Add(new Individual(Name, AnualIncome, HealthExpeditures));
                    }
                    else
                    {
                        ListTaxPayer.Add(new Individual(Name, AnualIncome));
                    }

                }
                else if (resp == 'c' || resp == 'C')
                {
                    Console.Write("Number of employees: ");
                    int NumberOfEmployees = int.Parse(Console.ReadLine());
                    ListTaxPayer.Add(new Company(Name, AnualIncome, NumberOfEmployees));
                }
            }
            Console.WriteLine("TAXES PAID");
            foreach (TaxPayer payer in ListTaxPayer)
            {
                Console.WriteLine(payer);
            }
            double Sum = 0.0;
            foreach (TaxPayer tax in ListTaxPayer)
            {
                Sum += tax.Tax();
            }
            Console.WriteLine($"TOTAL TAXES: $ {Sum.ToString("F2", CultureInfo.InvariantCulture)}");
        }
    }
}
