using System;
using System.Data.Entity;
using System.Linq;

namespace ProductInfo {
    public class ModelDatabase {
        private Model1 dbcontext;
        public ModelDatabase() {
            dbcontext = new Model1();
        }

        public void Purge() {
             dbcontext.Database.ExecuteSqlCommand("DELETE FROM dbo.MyEntities WHERE Deleted='true'");
        }

        public Model1 GetDbContext() {
            return dbcontext;
        }

        public void RefreshDbContext() {
            if (dbcontext != null) {
                dbcontext.Dispose();
            }
            dbcontext = new Model1();
        }
    }
}