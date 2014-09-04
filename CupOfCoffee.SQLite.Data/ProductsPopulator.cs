namespace CupOfCoffee.SQLite.Data
{
    using CupOfCoffee.SQLite.Data.DatabaseSqlite;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ProductsPopulator
    {

        public static void Populate(ProductsContext context)
        {
            context.VendorsProducts.Add(new VendorsProduct()
                    {
                        Id = 1,
                        Name = "Espresso",
                        BasePrice = 40

                    });
            context.VendorsProducts.Add(new VendorsProduct()
                  {

                      Id = 2,
                      Name = "Macchiato",
                      BasePrice = 50

                  });

            context.VendorsProducts.Add(new VendorsProduct()
                  {
                      Id = 3,
                      Name = "Mocha",
                      BasePrice = 100

                  });

            context.VendorsProducts.Add(new VendorsProduct()
                   {

                       Id = 4,
                       Name = "Turkish coffee",
                       BasePrice = 15
                   });

            context.VendorsProducts.Add(new VendorsProduct()
                    {
                        Id = 5,
                        Name = "Cappuccino",
                        BasePrice = 60

                    });

            context.VendorsProducts.Add(new VendorsProduct()
                  {
                      Id = 6,
                      Name = "Earl Gray",
                      BasePrice = 60

                  });

            context.VendorsProducts.Add(new VendorsProduct()
                  {
                      Id = 7,
                      Name = "Ceylon Tea",
                      BasePrice = 45


                  });

            context.VendorsProducts.Add(new VendorsProduct()
                  {
                      Id = 8,
                      Name = "Herbal Tea",
                      BasePrice = 35

                  });

            context.VendorsProducts.Add(new VendorsProduct()
                  {

                      Id = 9,
                      Name = "Fruit Tea",
                      BasePrice = 39
                  });

            context.VendorsProducts.Add(new VendorsProduct()
                  {
                      Id = 10,
                      Name = "Masala Chai",
                      BasePrice = 65

                  });

            context.VendorsProducts.Add(new VendorsProduct()
                  {
                      Id = 12,
                      Name = "Zagorka",
                      BasePrice = 110

                  });

            context.VendorsProducts.Add(new VendorsProduct()
                  {

                      Id = 13,
                      Name = "Shumensko",
                      BasePrice = 90

                  });

            context.VendorsProducts.Add(new VendorsProduct()
                  {
                      Id = 14,
                      Name = "Ariana Radler",
                      BasePrice = 50

                  });

            context.VendorsProducts.Add(new VendorsProduct()
                  {

                      Id = 15,
                      Name = "Beck's",
                      BasePrice = 140
                  });

            context.VendorsProducts.Add(new VendorsProduct()
                  {
                      Id = 16,
                      Name = "Amstel",
                      BasePrice = 120

                  });

            context.VendorsProducts.Add(new VendorsProduct()
                  {
                      Id = 17,
                      Name = "Parliament",
                      BasePrice = 350

                  });

            context.VendorsProducts.Add(new VendorsProduct()
                  {
                      Id = 18,
                      Name = "Victory",
                      BasePrice = 200

                  });

            context.VendorsProducts.Add(new VendorsProduct()
                  {

                      Id = 19,
                      Name = "Muratti",
                      BasePrice = 250

                  });

            context.VendorsProducts.Add(new VendorsProduct()
                  {
                      Id = 20,
                      Name = "Sredets Jult",
                      BasePrice = 200

                  });

            context.VendorsProducts.Add(new VendorsProduct()
                  {
                      Id = 21,
                      Name = "Davidoff Gold",
                      BasePrice = 230

                  });
            context.VendorsProducts.Add(new VendorsProduct()
                  {
                      Id = 22,
                      Name = "Corny",
                      BasePrice = 50

                  });
            context.VendorsProducts.Add(new VendorsProduct()
                  {
                      Id = 23,
                      Name = "Vafli Chaika",
                      BasePrice = 10

                  });
            context.VendorsProducts.Add(new VendorsProduct()
                  {
                      Id = 24,
                      Name = "7 Days Double",
                      BasePrice = 30

                  });
            context.VendorsProducts.Add(new VendorsProduct()
                  {
                      Id = 25,
                      Name = "Gorna Bania 0.5l",
                      BasePrice = 25

                  });
            context.VendorsProducts.Add(new VendorsProduct()
                  {
                      Id = 26,
                      Name = "Prestige Qdesh Sega ili Gorish",
                      BasePrice = 120

                  });
            context.VendorsProducts.Add(new VendorsProduct()
                  {
                      Id = 27,
                      Name = "Croissant 7Days",
                      BasePrice = 32

                  });
            context.VendorsProducts.Add(new VendorsProduct()
                  {
                      Id = 28,
                      Name = "Croissant Fresh Baked",
                      BasePrice = 39

                  });
            context.VendorsProducts.Add(new VendorsProduct()
                  {
                      Id = 29,
                      Name = "Toast sandwitch",
                      BasePrice = 55

                  });
            context.VendorsProducts.Add(new VendorsProduct()
                  {
                      Id = 30,
                      Name = "Аvocado",
                      BasePrice = 110

                  });
            context.VendorsProducts.Add(new VendorsProduct()
                  {
                      Id = 31,
                      Name = "Olives",
                      BasePrice = 70

                  });
            context.VendorsProducts.Add(new VendorsProduct()
                  {
                      Id = 32,
                      Name = "Lemon",
                      BasePrice = 10

                  });
            context.VendorsProducts.Add(new VendorsProduct()
                  {
                      Id = 33,
                      Name = "Banana",
                      BasePrice = 10

                  });
            context.VendorsProducts.Add(new VendorsProduct()
                  {
                      Id = 34,
                      Name = "Orange",
                      BasePrice = 10

                  });
            context.VendorsProducts.Add(new VendorsProduct()
                  {
                      Id = 35,
                      Name = "Almonds",
                      BasePrice = 110

                  });
            context.VendorsProducts.Add(new VendorsProduct()
                  {
                      Id = 36,
                      Name = "Peanuts",
                      BasePrice = 75

                  });

            context.VendorsProducts.Add(new VendorsProduct()
                  {
                      Id = 37,
                      Name = "Hazelnuts",
                      BasePrice = 90


                  });

            context.SaveChanges();
        }
    }
}
