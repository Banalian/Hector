using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Diagnostics;

namespace Hector.Controller
{
    internal class ConnectionDB
    {

        private static SQLiteConnection _DBConnection = null;
        public static SQLiteConnection DBConnection {
            get
            {
                if (_DBConnection == null)
                {
                    try
                    {
                        _DBConnection = new SQLiteConnection("Data Source=" + Path.GetFullPath("Hector.SQLite") + ";Version=3;");
                        _DBConnection.Open();
                        return _DBConnection;

                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                        _DBConnection = null;
                        return null;
                    }
                }
                else
                {
                    return _DBConnection;
                }
            }

            private set => _DBConnection = value; 
        }

        public static int Dernier_Id_Insert()
        {
            string sql = "SELECT last_insert_rowid()";
            SQLiteCommand cmd = new SQLiteCommand(sql, DBConnection);
            int lastID = (Int32)cmd.ExecuteScalar();
            return lastID;
        }





    }
}
