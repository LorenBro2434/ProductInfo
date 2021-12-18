using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InfoDisplayTable
{
    public partial class InfoDisplay : Form
    {
        private ProductInfo.Model1 dbcontext = new ProductInfo.Model1();
        public InfoDisplay()
        {
            InitializeComponent();
            
        }

        private void InfoDisplay_Load(object sender, EventArgs e)
        {
            dbcontext.InfoEntities.Load();
            myEntitiesBindingSource.DataSource = dbcontext.InfoEntities.Local;
        }

        private void myEntitiesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            Validate();
            myEntitiesBindingSource.EndEdit();
            try
            {
                dbcontext.SaveChanges();

            }
            catch(DbEntityValidationException)
            {
                MessageBox.Show("All fields must have a value");
            }
            if (dbcontext != null) 
            {
                dbcontext.Dispose();
                dbcontext = new ProductInfo.Model1();

            }
            dbcontext.InfoEntities.Load();
            myEntitiesBindingSource.DataSource = dbcontext.InfoEntities.Local;
            
        }

        
    }
}
