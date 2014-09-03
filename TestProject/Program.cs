namespace TestProject
{
    using CupOfCoffee.Data;
    using CupOfCoffee.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    class Program
    {
        static void Main(string[] args)
        {
            DatabasePopulator.Seed();

            CupOfCoffeeContext db = new CupOfCoffeeContext();
        }
    }
}
