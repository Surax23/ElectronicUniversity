using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Электронный_университет
{
    public partial class choose_pr : Form
    {
        public choose_pr(int prof_id, string ip, string db, string user, string pass)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.ip = ip;
            this.db = db;
            this.user = user;
            this.pass = pass;
            this.prof_id = prof_id;
            con = new DB_connect(ip, db, user, pass);
        }
        string ip;
        string db;
        string user;
        string pass;
        int prof_id;
        DB_connect con;
        MySqlDataReader reader;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
        private void choose_pr_Load(object sender, EventArgs e)
        {
            reader = con.GetDBData("select * from capacity where prof_id='"+prof_id+"' group by groups_name;");
            while (reader.Read())
            {
                comboBox1.Items.Add(reader["groups_name"]);
            }
            reader.Close();
            reader = con.GetDBData("select * from capacity where prof_id='"+prof_id+ "' group by course_id;");
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["course_id"]);
                DB_connect con2 = new DB_connect(ip, db, user, pass);
                MySqlDataReader reader2 = con2.GetDBData("select * from course where id='"+id+"'");
                reader2.Read();
                comboBox2.Items.Add(reader2["name"]);
                reader2.Close();
            }
            reader.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!(comboBox1.SelectedItem == null) && !(comboBox2.SelectedItem == null))
            {
                string group_name = comboBox1.SelectedItem.ToString();
                reader = con.GetDBData("select * from course where name='" + comboBox2.SelectedItem.ToString() + "';");
                reader.Read();
                int course_id = Convert.ToInt32(reader["id"]);
                reader.Close();
                ini_func ini = new ini_func();
                Progress pr = new Progress(group_name, course_id, ip, db, user, pass);
                this.Close();
                if (ini.FormOpened(pr))
                {
                    Application.OpenForms[pr.Name].Focus();
                }
                else
                {
                    pr.Show();
                }
            } else
            {
                MessageBox.Show("Не выбрана группа или дисциплина!", "Ошибка");
            }
        }
    }
}
