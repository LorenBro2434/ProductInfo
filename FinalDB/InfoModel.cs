using System;
using System.Data.Entity;
using System.Linq;

namespace FinalDB
{
    public class InfoModel : DbContext
    {
        // Your context has been configured to use a 'InfoModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'FinalDB.InfoModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'InfoModel' 
        // connection string in the application configuration file.
        public InfoModel()
            : base("InfoModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<MyEntity> InfoEntities { get; set; }
    }

    public class MyEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public decimal Weight { get; set; }
        public int SerialNumber { get; set; }
        public string PackagingGrade { get; set; }
        public int Stock { get; set; }
        public string ShipDate { get; set; }
        public string Location { get; set; }
        public decimal Price { get; set; }
    }
}