using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frmUpdate : Form
    {
        private readonly string id;
        private readonly bool fromLocal;
        private readonly string file;

        public frmUpdate(string id , string message , bool fromLocal , string file = "")
        {
            InitializeComponent();
            tbMessage.Text = message;
            this.id = id;
            this.fromLocal = fromLocal;
            this.file = file;
            db = new Database();
        }
        Database db;
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (
                      MessageBox.Show("Are you sure you want to update message ?"
                      , "Update"
                      , MessageBoxButtons.YesNo
                      ,
                      MessageBoxIcon.Question) == DialogResult.Yes
                  )
                {
                    if (fromLocal)
                    {
                        // update from local db
                        string sql_update = $"update sms_backup set text = '{tbMessage.Text}' where rowid = {id}";
                        db.Execute(sql_update, Helper.ConnectionString);

                    }
                    else
                    {
                        string sql_update = $"update message set text = '{tbMessage.Text}' where ROWID = {id}";
                        db.Execute(sql_update, "Data Source = " + file);
                    }

                    DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
