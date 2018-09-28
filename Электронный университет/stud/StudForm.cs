using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Электронный_университет
{
    public partial class StudForm : Form
    {
        public StudForm(string login, string ip, string db, string user, string pass)
        {
            InitializeComponent();
            this.login = login;
            this.ip = ip;
            this.db = db;
            this.user = user;
            this.pass = pass;
            connection = new DB_connect(ip, db, user, pass);
        }

        public string login;
        public string ip;
        public string db;
        public string user;
        public string pass;
        DB_connect connection;
        string zk;
        string group_name;
        bool m_exit = true;
        ini_func ini = new ini_func();

        private void StudForm_Shown(object sender, EventArgs e)
        {
            //Смотрим, что за студент
            connection = new DB_connect(ip, db, user, pass);
            MySqlDataReader reader = connection.GetDBData("SELECT * FROM students WHERE login='" + login + "';");
            reader.Read();
            label1.Text = reader["name"].ToString();
            group_name = reader["groups_name"].ToString();
            zk = reader["zk"].ToString();
            reader.Close();

            //Достаем расписание
            string today = DateTime.Today.Year + "-" + DateTime.Today.Month + "-" + DateTime.Today.Day;
            reader = connection.GetDBData("select * from week where date_start<='" + today + "' and date_finish>='" + today + "';");
            string d_s;
            string d_f;
            int week_no = -1;
            if (reader.Read())
            {
                d_s = reader["date_start"].ToString();
                d_f = reader["date_finish"].ToString();
                week_no = Convert.ToInt32(reader["week_no"]);
            }
            reader.Close();
            int nechet;
            if (!(week_no == -1) && (week_no % 2 == 0))
            {
                nechet = 0; //знаменатель
            }
            else
            {
                nechet = 1; //числитель
            }
            // А также день недели
            reader = connection.GetDBData("select * from day_of_week where name='" + DateTime.Today.DayOfWeek.ToString() + "';");
            int day_of_week = 0;
            if (reader.Read())
            {
                day_of_week = Convert.ToInt32(reader["no"]);
            }
            reader.Close();
            reader = connection.GetDBData("select * from pairs");
            while (reader.Read())
            {
                dataGridView1.Rows.Add(reader["pair_no"] + ": " + reader["time_start"] + "-" + reader["time_finish"], "");
            }
            reader.Close();


            // Вытягиваем все занятия и заполняем DataGridView
            if (!(day_of_week == 0))
            {
                reader = connection.GetDBData("select * from schedule_on_week where parity='" + nechet + "' AND day_of_week='" + day_of_week + "' AND groups_name='" + group_name + "';");
                while (reader.Read())
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Index == Convert.ToInt32(reader["pair_no"]))
                        {
                            row.Cells[1].Value = "";
                            //Приходится еще раз подключаться в виду некоторых ограничений
                            DB_connect connection2 = new DB_connect(ip, db, user, pass);
                            // Дисциплина
                            MySqlDataReader reader2 = connection2.GetDBData("select * from course where id='" + reader["course_id"] + "';");
                            reader2.Read();
                            row.Cells[1].Value += reader2["name"] + "\r\n";
                            reader2.Close();
                            // Преподаватель
                            reader2 = connection2.GetDBData("select * from professor where id='" + reader["prof_id"] + "';");
                            reader2.Read();
                            row.Cells[1].Value += reader2["name"] + "\r\n";
                            reader2.Close();
                            // Тип
                            row.Cells[1].Value += reader2["name"] + "\r\n";
                            // Аудитория уже есть.
                            row.Cells[1].Value += reader["auditory_no"].ToString();
                            row.Height = 65;
                        }
                    }
                }
            }
            reader.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            if (m_exit)
            {
                DialogResult dialog = MessageBox.Show("Закрыть приложение?", "Закрыть", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    m_exit = false;
                    Application.Exit();
                }
                else if (dialog == DialogResult.No)
                {
                    ((FormClosingEventArgs)e).Cancel = true;
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            StudSched ssh = new StudSched(label1.Text, group_name, ip, db, user, pass);
            if (ini.FormOpened(ssh))
            {
                Application.OpenForms[ssh.Name].Show();
                Application.OpenForms[ssh.Name].Focus();
            }
            else
            {
                ssh.Show();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            StudMu mu = new StudMu(label1.Text, ip, db, user, pass);
            if (ini.FormOpened(mu))
            {
                Application.OpenForms[mu.Name].Focus();
            }
            else
            {
                mu.Show();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Error Code: 1452. Cannot add or update a child row: a foreign key constraint fails", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
        }

        private void StudForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_exit)
            {
                DialogResult dialog = MessageBox.Show("Закрыть приложение?", "Закрыть", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    m_exit = false;
                    Application.Exit();
                }
                else if (dialog == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Error Code: 1452. Cannot add or update a child row: a foreign key constraint fails", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
        }
    }
}