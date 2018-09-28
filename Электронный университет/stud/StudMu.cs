using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Электронный_университет
{
    public partial class StudMu : Form
    {
        public StudMu(string name, string ip, string db, string user, string pass)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.ip = ip;
            this.db = db;
            this.user = user;
            this.pass = pass;
            this.connection = new DB_connect(ip, db, user, pass);
            label1.Text = name;
        }
        string ip;
        string db;
        string user;
        string pass;
        DB_connect connection;
        MySqlDataReader reader;

        private void updMu()
        {
            reader = connection.GetDBData("select * from mu;");
            while (reader.Read())
            {
                int course_id = Convert.ToInt32(reader["course_id"]);
                int classes_id = Convert.ToInt32(reader["classes_id"]);
                int prof_id = Convert.ToInt32(reader["prof_id"]);
                string comment = reader["comment"].ToString();
                string link = reader["link"].ToString();
                DateTime dt = DateTime.Parse(reader["date"].ToString());
                DateTime dt_cl = new DateTime();
                string crs_name = "";
                string prf_name = "";
                string classes_type_name = "";
                int number = 0;

                DB_connect con = new DB_connect(ip, db, user, pass);
                MySqlDataReader reader2 = con.GetDBData("select * from course where id='" + course_id + "';");
                if (reader2.Read())
                {
                    crs_name = reader2["name"].ToString();
                }
                reader2.Close();
                reader2 = con.GetDBData("select * from professor where id='" + prof_id + "';");
                if (reader2.Read())
                {
                    prf_name = reader2["name"].ToString();
                }
                reader2.Close();
                reader2 = con.GetDBData("select * from classes where id='" + classes_id + "' and course_id='" + course_id + "';");
                if (reader2.Read())
                {
                    classes_type_name = reader2["classes_type_name"].ToString();
                    dt_cl = DateTime.Parse(reader["date"].ToString());
                }
                reader2.Close();
                dataGridView1.Rows.Add(crs_name, prf_name, classes_type_name, "", String.Format("{0:dd.MM.yyyy}", dt_cl), comment, link, String.Format("{0:dd.MM.yyyy}", dt));
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Height = 75;
            }
        }

        private void StudMu_Shown(object sender, EventArgs e)
        {
            updMu();
        }
    }
}
