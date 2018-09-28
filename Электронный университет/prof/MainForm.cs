using System;
using System.IO;
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
    public partial class MainForm : Form
    {
        public MainForm(string login, string ip, string db, string user, string pass)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.login = login;
            this.ip = ip;
            this.db = db;
            this.user = user;
            this.pass = pass;
            connection = new DB_connect(ip, db, user, pass);
            this.dataGridView1.CellClick += DataGridView1_CellClick;
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        // Функция клика на таблицу
        {
            DataGridViewCell cell = dataGridView1.CurrentCell;
            if (!(cell.Value.ToString() == "") && (cell.ColumnIndex>0))
            {
                //MessageBox.Show(cell.Value.ToString());
                String[] stroke = cell.Value.ToString().Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                // stroke[0] = дисциплина, stroke[1] = группа
                string group_name = stroke[1];
                string course_name = stroke[0];
                MySqlDataReader reader = connection.GetDBData("select * from course where name='" + course_name + "';");
                int course_id = 0;
                if (reader.Read())
                {
                    course_id = Convert.ToInt32(reader["id"]);
                }
                reader.Close();
                if (!(group_name == "") && !(course_id == 0))
                {
                    Progress pr = new Progress(group_name, course_id, ip, db, user, pass);
                    if (ini.FormOpened(pr))
                    {
                        Application.OpenForms[pr.Name].Focus();
                    }
                    else
                    {
                        pr.Show();
                    }
                }
            }
        }

        //public event DataGridViewCellMouseEventHandler CellMouseClick;


        ini_func ini = new ini_func();
        private bool m_exit = true;
        public string login;
        public string ip;
        public string db;
        public string user;
        public string pass;
        int prof_id;
        DB_connect connection;

        private void label2_Click(object sender, EventArgs e)
        {
            Prepsched sched = new Prepsched(login, ip, db, user, pass);
            if (ini.FormOpened(sched))
            {
                Application.OpenForms[sched.Name].Show();
                Application.OpenForms[sched.Name].Focus();
            }
            else
            {
                sched.Show();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Mu mu = new Mu(prof_id, ip, db, user, pass);
            if (ini.FormOpened(mu))
            {
                Application.OpenForms[mu.Name].Focus();
            }
            else
            {
                mu.Show();
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Ads ads = new Ads(prof_id, ip, db, user, pass);
            if (ini.FormOpened(ads))
            {
                Application.OpenForms[ads.Name].Focus();
            }
            else
            {
                ads.Show();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_exit)
            {
                DialogResult dialog = MessageBox.Show("Закрыть приложение?", "Закрыть", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    m_exit = false;
                    Application.Exit();
                } else if (dialog == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            choose_pr pr = new choose_pr(prof_id, ip, db, user, pass);
            if (ini.FormOpened(pr))
            {
                Application.OpenForms[pr.Name].Focus();
            }
            else
            {
                pr.ShowDialog();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //MySqlDataReader reader = connection.GetDBData("SELECT * FROM professors WHERE login='" + login + "';");
            //label1.Text = reader.GetString(1);
            //MessageBox.Show("Hello!");
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            //MessageBox.Show("Hello!");
            MySqlDataReader reader = connection.GetDBData("SELECT * FROM professor WHERE login='" + login + "';");
            //label1.Text = "";
            reader.Read();
            label1.Text = reader["name"].ToString();
            prof_id = Convert.ToInt32(reader["id"]);
            reader.Close();

            //Высчитать, какие сегодня пары
            //Для этого мы должны узнать, какая четность недели
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
                nechet = 1; //числитель
            } else
            {
                nechet = 2; //знаменатель
            }
            // А также день недели
            reader = connection.GetDBData("select * from day_of_week where name='" + DateTime.Today.DayOfWeek.ToString() + "';");
            int day_of_week = 0;
            if (reader.Read())
            {
                day_of_week = Convert.ToInt32(reader["no"]);
            }
            reader.Close();
            // И ID преподавателя
            reader = connection.GetDBData("select * from professor where login='" + login + "';");
            if (reader.Read())
            {
                prof_id = Convert.ToInt32(reader["id"]);
            }
            reader.Close();
            // Вытягиваем время занятий
            reader = connection.GetDBData("select * from pairs");
            while (reader.Read())
            {
                dataGridView1.Rows.Add(reader["pair_no"]+": "+reader["time_start"]+"-"+ reader["time_finish"], "");
            }
            reader.Close();

            // Вытягиваем все занятия и заполняем DataGridView
            if (!(day_of_week == 0))
            {
                reader = connection.GetDBData("select * from schedule_on_week where (parity='" + nechet + "' or parity='0') AND day_of_week='" + day_of_week + "' AND prof_id='" + prof_id + "';");
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
                            // Группа
                            reader2 = connection2.GetDBData("select * from groups where name='" + reader["groups_name"] + "';");
                            reader2.Read();
                            row.Cells[1].Value += reader2["name"] + "\r\n";
                            reader2.Close();
                            // Тип
                            row.Cells[1].Value += reader["classes_type_name"].ToString() + "\r\n";
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
    }
}
