using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Электронный_университет
{
    public partial class Add_mu : Form
    {
        public Add_mu(int id, string group_name, int prof_id, string ip, string db, string user, string pass)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.id = id;
            this.ip = ip;
            this.db = db;
            this.user = user;
            this.pass = pass;
            this.prof_id = prof_id;
            this.group_name = group_name;
        }
        string group_name;
        int id;
        string ip;
        string db;
        string user;
        string pass;
        int prof_id;

        public void UpdMu(int id)
        {
            DB_connect cn = new DB_connect(ip, db, user, pass);
            MySqlDataReader reader;
            if (id == 0)
            {
                reader = cn.GetDBData("select * from capacity where prof_id='" + prof_id + "';");
                while (reader.Read())
                {
                    int course_id = Convert.ToInt32(reader["course_id"]);
                    int classes_id = Convert.ToInt32(reader["classes_id"]);
                    string groups_name = reader["groups_name"].ToString();
                    string course_name;

                    DB_connect con = new DB_connect(ip, db, user, pass);
                    MySqlDataReader reader2 = con.GetDBData("select * from course where id='" + course_id + "';");
                    if (reader2.Read())
                    {
                        course_name = reader2["name"].ToString();
                        if (comboBox1.FindString(course_name) == -1)
                        {
                            comboBox1.Items.Add(course_name);
                        }
                    }
                    reader2.Close();
                    if (comboBox2.FindString(groups_name) == -1)
                    {
                        comboBox2.Items.Add(groups_name);
                    }
                    reader2 = con.GetDBData("select * from classes_type;");
                    while (reader2.Read())
                    {
                        string cl_name = reader2["name"].ToString();
                        if (comboBox3.FindString(cl_name) == -1)
                        {
                            comboBox3.Items.Add(cl_name);
                        }
                    }
                    reader2.Close();
                }
                reader.Close();
            }
            else
            {
                reader = cn.GetDBData("select * from mu where id='" + id + "';");
                reader.Read();
                int course_id = Convert.ToInt32(reader["course_id"]);
                int classes_id = Convert.ToInt32(reader["classes_id"]);
                string comment = reader["comment"].ToString();
                string link = reader["link"].ToString();
                DateTime date = DateTime.Parse(reader["date"].ToString());
                reader.Close();
                // ----
                reader = cn.GetDBData("select name from course where id='"+course_id+"';");
                reader.Read();
                string course_name = reader["name"].ToString();
                reader.Close();
                reader = cn.GetDBData("select * from classes where id='"+classes_id+"' and course_id='"+course_id+"';");
                reader.Read();
                string cl_t_n = reader["classes_type_name"].ToString();
                int c_number = Convert.ToInt32(reader["number"]);
                reader.Close();

                comboBox1.Items.Add(course_name);
                comboBox1.SelectedItem = course_name;
                comboBox2.Items.Add(group_name);
                comboBox2.SelectedItem = group_name;
                comboBox3.Items.Add(cl_t_n);
                comboBox3.SelectedItem = cl_t_n;
                textBox1.Text = c_number.ToString();
                textBox2.Text = comment;
                textBox3.Text = link;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Вы не заполнили поле \"Дисциплина\"!");
                return;
            }
            string course_name = comboBox1.SelectedItem.ToString();
            if (comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Вы не заполнили поле \"Группа\"!");
                return;
            }
            string group_name = comboBox2.SelectedItem.ToString();
            if (comboBox3.SelectedItem == null)
            {
                MessageBox.Show("Вы не заполнили поле \"Тип занятия\"!");
                return;
            }
            string cl_type = comboBox3.SelectedItem.ToString();
            if (textBox1.Text == "")
            {
                MessageBox.Show("Вы не заполнили поле \"Номер занятия\"!");
                return;
            }
            int cl_id = Convert.ToInt32(textBox1.Text);
            
            string comment = textBox2.Text;
            string link = textBox3.Text;
            DB_connect con2 = new DB_connect(ip, db, user, pass);
            MySqlDataReader reader2 = con2.GetDBData("select * from course where name='" + course_name + "';");
            int course_id = 0;
            if (reader2.Read())
            {
                course_id = Convert.ToInt32(reader2["id"]);
            }
            reader2.Close();
            reader2 = con2.GetDBData("select * from classes where id='" + cl_id + "' and course_id='" + course_id + "';");
            if (reader2.Read())
            {
                DB_connect con3 = new DB_connect(ip, db, user, pass);
                MySqlDataReader reader3;
                if (id == 0)
                {
                    reader3 = con3.GetDBData("insert into mu (classes_id, course_id, prof_id, comment, link, date) values ('" + cl_id + "', '" + course_id + "', '" + prof_id + "', '" + comment + "', '" + link + "', '" + String.Format("{0:yyyy-MM-dd}", DateTime.Today) + "');");
                    while (reader3.Read()) { }
                    MessageBox.Show("МУ успешно добавлено!", "Успех!");
                } else
                {
                    reader3 = con3.GetDBData("update mu set comment='" + comment + "', link='" + link + "' where id='" + id + "';");
                    while (reader3.Read()) { }
                    MessageBox.Show("МУ успешно обновлено!", "Успех!");
                }
                this.Close();
                Mu mu = Application.OpenForms["Mu"] as Mu;
                mu.UpdMu();
            }
            else
            {
                MessageBox.Show("Такого урока не существует!", "Ошибка.");
            }
        }

        private void Add_mu_Shown(object sender, EventArgs e)
        {
            UpdMu(id);
        }
    }
}
