using MySql.Data.MySqlClient;
using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Электронный_университет
{
    public class DB_connect
    {
        public DB_connect(string ip, string db, string user, string pass)
        {
            myConnectionString = "Database=" + db + ";Data Source=" + ip + ";User Id=" + user + ";Password=" + pass;
            myConnection = new MySqlConnection(myConnectionString);
            try
            {
                // Открываем соединение
                myConnection.Open();
            }
            catch (Exception ex) // Ловим ошибку
            {
                //Console.WriteLine(ex);
            }
        }
        MySqlConnection myConnection = null;
        public string role = null; // Роль пользователя: "prof" или "stud"
        public string myConnectionString;

        public bool CheckLogPass(string log, string pass)
        {
            try
            {
                string sql = "SELECT COUNT(*) FROM users WHERE login='" + log + "' AND password='" + pass + "';";
                MySqlCommand com = new MySqlCommand(sql, myConnection);
                object scalar = com.ExecuteScalar();
                int count = Convert.ToInt32(scalar);
                if (count == 1)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Невозможно установить соединение с сервером!\r\n\r\n", ex.ToString());
            }
            return false;
        }

        public string CheckRole(string log)
        {
            string sql = "SELECT COUNT(*) FROM professor WHERE login='" + log + "';";
            MySqlCommand com = new MySqlCommand(sql, myConnection);
            object scalar = com.ExecuteScalar();
            int count = Convert.ToInt32(scalar);
            if (count == 1)
            {
                role = "prof";
                return role;
            }
            role = "stud";
            return role;
        }

        public MySqlDataReader GetDBData(string sql)
        {
            MySqlCommand command = new MySqlCommand();
            command.CommandText = sql;
            command.Connection = myConnection;
            MySqlDataReader reader = command.ExecuteReader();
            return reader;
        }

        /* public void updData(string sql)
        {
            MySqlCommand command = new MySqlCommand();
            command.CommandText = sql;
            command.Connection = myConnection;
            command.ExecuteNonQuery();
        } */

        public void Close()
        {
            myConnection.Close();
        }
    }
}
