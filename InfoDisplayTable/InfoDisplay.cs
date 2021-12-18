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
        //private ProductInfo.Model1 db.GetDbContext() = new ProductInfo.Model1();
        private ProductInfo.ModelDatabase db = new ProductInfo.ModelDatabase();
        public DataGridViewCellStyle defaultCellStyle, deletedCellStyle;
        public InfoDisplay()
        {
            InitializeComponent();
            deletedCellStyle = new DataGridViewCellStyle();
			defaultCellStyle = new DataGridViewCellStyle();
			deletedCellStyle.ForeColor = Color.Gray;
			// defaultCellStyle.DataSourceNullValue = ((new DataGridViewCellStyle()).ForeColor = Color.Red);
        }

        public void SaveTable() {
            Validate();
            myEntitiesBindingSource.EndEdit();
            try
            {
                db.GetDbContext().SaveChanges();

            }
            catch(DbEntityValidationException)
            {
                MessageBox.Show("All fields must have a value");
            }
            if (db.GetDbContext() != null) 
            {
                db.GetDbContext().Dispose();
                db.RefreshDbContext();

            }
            db.GetDbContext().InfoEntities.Load();
            myEntitiesBindingSource.DataSource = db.GetDbContext().InfoEntities.Local;
            myEntitiesDataGridView.Update();
            myEntitiesDataGridView.Refresh();
        }

        private void InfoDisplay_Load(object sender, EventArgs e)
        {
            db.GetDbContext().InfoEntities.Load();
            myEntitiesBindingSource.DataSource = db.GetDbContext().InfoEntities.Local;
			for (int i = 0; i < myEntitiesDataGridView.RowCount; i++) {
				if (myEntitiesDataGridView.Rows[i].Cells[10].Value != null && (bool) myEntitiesDataGridView.Rows[i].Cells[10].Value == true) {
					for (int cellIndex = 0;
						cellIndex < myEntitiesDataGridView.Rows[i].Cells.Count;
						cellIndex++) {
						myEntitiesDataGridView.Rows[i].Cells[cellIndex].Style = deletedCellStyle;
					}
					myEntitiesDataGridView.Rows[i].ReadOnly = true;
				}
			}
        }

        private void myEntitiesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            SaveTable();
        }

        public void MarkRowForDeletion(bool deleted) {
            DataGridViewSelectedCellCollection cells = myEntitiesDataGridView.SelectedCells;
			for (int i = 0; i < cells.Count; i++) { // gets selected cells' row index
				int rowIndex = cells[i].RowIndex; // save the row index
				myEntitiesDataGridView.Rows[rowIndex].Cells[10].Value = deleted;
                for (int cellIndex = 0;
                        cellIndex < myEntitiesDataGridView.Rows[rowIndex].Cells.Count;
                        cellIndex++) {
                            if (deleted == true) {
                                myEntitiesDataGridView.Rows[rowIndex].Cells[cellIndex].Style = deletedCellStyle;
                            } else {
                                myEntitiesDataGridView.Rows[rowIndex].Cells[cellIndex].Style = myEntitiesDataGridView.Rows[rowIndex].DefaultCellStyle;
                            }
                    myEntitiesDataGridView.Rows[rowIndex].ReadOnly = deleted;
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveTable();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveTable();
        }

        private void undeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MarkRowForDeletion(false);
            SaveTable();
            myEntitiesDataGridView.ClearSelection();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MarkRowForDeletion(true);
            SaveTable();
            myEntitiesDataGridView.ClearSelection();

        }

        private void purgeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Confirm("Are you sure you want to purge deleted entries?")) {
                SaveTable();
                db.Purge();
                SaveTable();
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            MarkRowForDeletion(true);
            SaveTable();
            myEntitiesDataGridView.ClearSelection();
           
        }
        private bool Confirm(string message, string title="Confirm", bool yesNo=true) 
        {
            DialogResult result = MessageBox.Show(message, title, (yesNo == true) ? MessageBoxButtons.YesNo : MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) ;
            return (result == DialogResult.OK || result == DialogResult.Yes);
        }
    }
}
