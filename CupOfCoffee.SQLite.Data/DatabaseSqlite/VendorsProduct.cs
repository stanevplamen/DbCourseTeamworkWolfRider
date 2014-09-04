namespace CupOfCoffee.SQLite.Data.DatabaseSqlite
{
    using System.ComponentModel.DataAnnotations;

    public class VendorsProduct
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int BasePrice { get; set; }
    }
}
