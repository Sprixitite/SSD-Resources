using System;

namespace Mod6Task4 {

    class Program {

        static void Main(string[] args) {

            Employee no_tax = new Employee("A", 8999);
            Console.WriteLine(no_tax.salary_taxed);

            Employee fifteen_percent_tax = new Employee("B", 14500);
            Console.WriteLine(fifteen_percent_tax.salary_taxed);

            Employee twenty_five_percent_tax = new Employee("C", 20001);
            Console.WriteLine(twenty_five_percent_tax.salary_taxed);

        }

    }

}