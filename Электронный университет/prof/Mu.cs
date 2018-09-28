using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Электронный_университет
{
    public partial class Mu : Form
    {
        public Mu(int prof_id, string ip, string db, string user, string pass)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.prof_id = prof_id;
            this.ip = ip;
            this.db = db;
            this.user = user;
            this.pass = pass;
            this.connection = new DB_connect(ip, db, user, pass);
            this.reader = connection.GetDBData("select * from professor where id='" + prof_id + "';");
            this.reader.Read();
            this.label1.Text = reader["name"].ToString();
            this.reader.Close();
        }
        int prof_id;
        string ip;
        string db;
        string user;
        string pass;
        DB_connect connection;
        MySqlDataReader reader;

        public void UpdMu()
        {
            reader = connection.GetDBData("select * from mu where prof_id='" + prof_id.ToString() + "';");
            int i = 0;
            while (reader.Read())
            {
                string comment = reader["comment"].ToString();
                int course_id = Convert.ToInt32(reader["course_id"]);
                int classes_id = Convert.ToInt32(reader["classes_id"]);
                string[] stroke = reader["date"].ToString().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string link = reader["link"].ToString();
                DB_connect cn = new DB_connect(ip, db, user, pass);
                MySqlDataReader reader2 = cn.GetDBData("select * from course where id='" + course_id.ToString() + "';");
                reader2.Read();
                string name = reader2["name"].ToString();
                reader2.Close();
                reader2 = cn.GetDBData("select * from classes where id='" + classes_id + "';");
                reader2.Read();
                string classes_type_name = reader2["classes_type_name"].ToString();
                string num = reader2["number"].ToString();
                string[] stroke2 = reader2["date"].ToString().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                reader2.Close();
                reader2 = cn.GetDBData("select * from capacity where prof_id='" + prof_id + "' and course_id='" + course_id + "' and classes_id='" + classes_id + "';");
                string group_name = "";
                if (reader2.Read())
                {
                    group_name = reader2["groups_name"].ToString();
                }
                reader2.Close();
                dataGridView1.Rows.Add(name, group_name, classes_type_name, num, stroke2[0], comment, link, stroke[0]);
                dataGridView1.Rows[i].Height = 80;
                i++; 
            }
        }

        private void Mu_Shown(object sender, EventArgs e)
        {
            UpdMu();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void Mu_Load(object sender, EventArgs e)
        {
            UpdMu();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Add_mu mu = new Add_mu(0, prof_id, ip, db, user, pass);
            mu.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
