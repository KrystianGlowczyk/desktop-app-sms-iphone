using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Data.SQLite;

namespace WindowsFormsApp1
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            db = new Database();
        }
        Database db;

        bool displayingFromBackup = true;

        private void frmMain_Load(object sender, EventArgs e)
        {
            // check if file already exists
            if (!File.Exists(Helper.DbFilePath))
            {
                CreateBackupDb();

            }

            ReadLocalDb();
        }

        private void CreateBackupDb()
        {
            // if it does not then create the file
            SQLiteConnection.CreateFile(Helper.DbFilePath);
            string sql = "create table sms_backup (rowid integer primary key, guid Text, text Text, service Text, handle_id integer, date Text, date_read Text, is_from_me Text)";
            db.Execute(sql, Helper.ConnectionString);
        }

        private void ReadLocalDb()
        {
            displayingFromBackup = true;
            lblIndicator.Text = "Displaying From (Backup)";

            string sql_getLocalData = "select * from sms_backup";
            dgvData.DataSource =Transform( db.ReadData(sql_getLocalData , Helper.ConnectionString));

        }
        
        private void ReadImportedDb()
        {
            try
            {
                if (tbDatabaseFile.Text.Length > 0)
                {
                    displayingFromBackup = false;
                    lblIndicator.Text = "Displaying From (Loaded File)";


                    string sql_getImportedData = "SELECT message.rowid, guid, text, message.service, handle.id, date, date_read, is_from_me FROM message JOIN handle ON message.handle_id = handle.ROWID ORDER BY date ASC";
                    dgvData.DataSource = Transform(db.ReadData(sql_getImportedData, "Data Source = " + tbDatabaseFile.Text));
                }
                else
                {
                    MessageBox.Show("Please Load Database File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           

        }

        private void MergeRecords()
        {
            if(tbDatabaseFile.Text.Length == 0)
            {
                MessageBox.Show("Please Load Backup File first", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            try
            {

                string sql_selectDataFromFile = "SELECT message.rowid, guid, text, message.service, handle.id, date, date_read, is_from_me FROM message JOIN handle ON message.handle_id = handle.ROWID ORDER BY date ASC";

                DataTable dt = db.ReadData(sql_selectDataFromFile, "Data Source = " + tbDatabaseFile.Text);
                if (dt.Rows.Count > 0)
                {
                   
                    foreach (DataRow dr in dt.Rows)
                    {
                        try
                        {
                            string rowId = Convert.ToString(dr["ROWID"]);
                            string guid = Convert.ToString(dr["GUID"]);
                            string service = Convert.ToString(dr["SERVICE"]) != null ? Convert.ToString(dr["SERVICE"]) : "N/A";
                            string handleId = Convert.ToString(dr["ID"]) != null ? Convert.ToString(dr["ID"]) : "N/A";
                            string date = Convert.ToString(dr["DATE"]) != null ? Convert.ToString(dr["DATE"]) : "N/A";
                            string dateRead = Convert.ToString(dr["DATE_READ"]) != null ? Convert.ToString(dr["DATE_READ"]) : "N/A";
                            string isFromMe = Convert.ToString(dr["IS_FROM_ME"]) != null ? Convert.ToString(dr["IS_FROM_ME"]) : "N/A";
                            string text = Convert.ToString(dr["TEXT"]) != null ? Convert.ToString(dr["TEXT"]) : "N/A";
                            string sqlInsert = "insert into sms_backup (rowid, guid, text, service, handle_id, date, date_read, is_from_me) values " +
                                "(" + rowId + ",'" + guid + "','" + text + "','" + service + "'," + handleId + "," + date + "," + dateRead + "," + isFromMe + ")";

                           int i = db.Execute (sqlInsert, Helper.ConnectionString);
                            
                        }
                        catch (Exception ex)
                        {
                            // unknown errors
                        }
                    }

                    MessageBox.Show("Data Merged Successfully ","Merged",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
               
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        
        private static DataTable Transform(DataTable dt)
        {
            dt.Columns.Add("DATE_STR");
            dt.Columns.Add("DATE_READ_STR");
            foreach (DataRow dr in dt.Rows)
            {
                DateTime epoch = new DateTime(2001, 1, 1, 0, 0, 0, 0);
                long dd = Convert.ToInt64(dr["DATE"]) / 1000000000;
                long ddd = Convert.ToInt64(dr["DATE_READ"]) / 1000000000;

                dr["DATE_STR"] = epoch.AddSeconds(dd);
                dr["DATE_READ_STR"] = epoch.AddSeconds(ddd);
            }
            return dt;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (displayingFromBackup)
            {
                string sql_Search = $"select * from sms_backup where text like '%{tbSearch.Text}%'";
                dgvData.DataSource = Transform(db.ReadData(sql_Search, Helper.ConnectionString));

            }

            else
            {
                if (tbDatabaseFile.Text.Length > 0)
                {

                    string allMessagesQuery = $@"SELECT message.rowid, guid, text, message.service, handle.id, date, date_read, is_from_me FROM message JOIN handle ON message.handle_id = handle.ROWID where text like '%{tbSearch.Text}%' ORDER BY date ASC";

                    dgvData.DataSource = Transform(db.ReadData(allMessagesQuery, "Data Source = " + tbDatabaseFile.Text));
                }
                else
                {
                    MessageBox.Show("Please Load Database File ","Error" , MessageBoxButtons.OK , MessageBoxIcon.Error);
                }

            }

        }

        private void btnShowBackupData_Click(object sender, EventArgs e)
        {
            ReadLocalDb();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Select Backed Up iPhone SMS Backup DB";
            try
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    tbDatabaseFile.Text = dialog.FileName;
                    ReadImportedDb();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message , "Error", MessageBoxButtons.OK , MessageBoxIcon.Information);
            }
          
        }

        private void btnMerge_Click(object sender, EventArgs e)
        {
            if (
                    MessageBox.Show("Are you sure you want to merge loaded database with local backup ?" 
                    , "Merge"
                    , MessageBoxButtons.YesNo 
                    , 
                    MessageBoxIcon.Question) == DialogResult.Yes
                )
            {
                MergeRecords();
                ReadLocalDb();
            }
        }

        private void btnShowLoadedDb_Click(object sender, EventArgs e)
        {
            ReadImportedDb();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (dgvData.CurrentRow != null)
            {
                string rowId = dgvData.CurrentRow.Cells[0].Value.ToString();


                if (
                       MessageBox.Show("Are you sure you want to delete selected message ?"
                       , "Delete"
                       , MessageBoxButtons.YesNo
                       ,
                       MessageBoxIcon.Question) == DialogResult.Yes
                   )
                {

                    if (displayingFromBackup)
                    {
                        // delete message from local Db
                        string sql_delete = $"delete from sms_backup where rowid = {rowId}";
                        db.Execute(sql_delete , Helper.ConnectionString);

                        MessageBox.Show("Message Deleted" , "Deleted",MessageBoxButtons.OK , MessageBoxIcon.Information);
                        ReadLocalDb();
                    }
                    else if (tbDatabaseFile.Text.Length > 0)
                    {
                       
                        string deleteQuery = @"Delete FROM message where rowid = " + rowId;
                        db.Execute(deleteQuery, "Data Source = "+ tbDatabaseFile.Text);
                        MessageBox.Show("Message Deleted", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ReadImportedDb();
                    }

                }

            }

            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow != null)
            {
                string rowId = dgvData.CurrentRow.Cells[0].Value.ToString();

                if (displayingFromBackup)
                {
                    frmUpdate frm = new frmUpdate(rowId, dgvData.CurrentRow.Cells[2].Value.ToString() ,true);
                    if (frm.ShowDialog(this) == DialogResult.OK)
                    {
                        MessageBox.Show("Message Updated Successfully !","Updated" , MessageBoxButtons.OK , MessageBoxIcon.Information);
                        ReadLocalDb();
                    }
                    
                }
                else if (tbDatabaseFile.Text.Length > 0)
                {
                    frmUpdate frm = new frmUpdate(rowId, dgvData.CurrentRow.Cells[2].Value.ToString(), false , tbDatabaseFile.Text);
                    if (frm.ShowDialog(this) == DialogResult.OK)
                    {
                        MessageBox.Show("Message Updated Successfully !", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ReadLocalDb();
                    }

                    ReadImportedDb();
                }


            }
        }

        private void btnSearchByNumber_Click(object sender, EventArgs e)
        {
            if (displayingFromBackup)
            {
                string sql_Search = $"select * from sms_backup where handle_id like '%{tbSearchByNumber.Text}%'";
                dgvData.DataSource = Transform(db.ReadData(sql_Search, Helper.ConnectionString));

            }

            else
            {
                if (tbDatabaseFile.Text.Length > 0)
                {

                    string allMessagesQuery = $@"SELECT message.rowid, guid, text, message.service, handle.id, date, date_read, is_from_me FROM message JOIN handle ON message.handle_id = handle.ROWID where id like '%{tbSearchByNumber.Text}%' ORDER BY date ASC";

                    dgvData.DataSource = Transform(db.ReadData(allMessagesQuery, "Data Source = " + tbDatabaseFile.Text));
                }
                else
                {
                    MessageBox.Show("Please Load Database File ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
    }
}
