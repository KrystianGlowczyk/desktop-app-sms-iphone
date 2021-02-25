using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Database
    {
        public DataTable ReadData(string sql , string connection )
        {

            SQLiteConnection con = new SQLiteConnection(connection , true);
            con.Open();

            SQLiteCommand cmd = new SQLiteCommand(sql, con);
            cmd.ExecuteNonQuery();
           
            DataTable dt = new DataTable();

            SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
            sda.Fill(dt);
            con.Close();

            return dt;
        }

        public int Execute(string sql ,  string connection)
        {
            SQLiteConnection con = new SQLiteConnection(connection , true);
            con.Open();

            SQLiteCommand cmd = new SQLiteCommand(sql, con);

            int i =  cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
}
