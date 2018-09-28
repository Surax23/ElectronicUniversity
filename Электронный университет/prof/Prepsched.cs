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
    public partial class Prepsched : Form
    {
        public Prepsched(string login, string ip, string db, string user, string pass)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.ip = ip;
            this.db = db;
            this.user = user;
            this.pass = pass;
            this.login = login;
            con = new DB_connect(ip, db, user, pass);
            string today = DateTime.Today.Year + "-" + DateTime.Today.Month + "-" + DateTime.Today.Day;
            reader = con.GetDBData("select * from week where date_start<='" + today + "' and date_finish>='" + today + "';");
            reader.Read();
            week = Convert.ToInt32(reader["week_no"]);
            reader.Close();
            this.dataGridView1.CellClick += DataGridView1_CellClick;
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell cell = dataGridView1.CurrentCell;
            if (!(cell.Value == null) && !(cell.Value.ToString() == "") && (cell.ColumnIndex > 0))
            {
                //MessageBox.Show(cell.Value.ToString());
                String[] stroke = cell.Value.ToString().Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                // stroke[0] = дисциплина, stroke[1] = группа
                string group_name = stroke[1];
                string course_name = stroke[0];
                ini_func ini = new ini_func();
                DB_connect connection = new DB_connect(ip, db, user, pass);
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

        string ip;
        string db;
        string user;
        string pass;
        string login;
        int week;
        DB_connect con;
        MySqlDataReader reader;

        private void Prepsched_Load(object sender, EventArgs e)
        {
           //Upd(0);
        }

        private void Upd(int week_no)
        {
            // Очистка таблицы
            dataGridView1.Rows.Clear();

            //Заполнение
            reader = con.GetDBData("SELECT * FROM professor WHERE login='" + login + "';");
            reader.Read();
            label1.Text = reader["name"].ToString();
            int prof_id = Convert.ToInt32(reader["id"]);
            reader.Close();

            // Выбранная неделя
            reader = con.GetDBData("select * from week where week_no='" + week_no + "';");
            reader.Read();
            string[] d_s = reader["date_start"].ToString().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] d_f = reader["date_finish"].ToString().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            textBox1.Text = d_s[0];
            textBox2.Text = d_f[0];
            reader.Close();
            int nechet;
            if (week_no % 2 == 0)
            {
                nechet = 2;
            }
            else
            {
                nechet = 1;
            }
            reader = con.GetDBData("select * from pairs");
            while (reader.Read())
            {
                dataGridView1.Rows.Add(reader["pair_no"] + ": " + reader["time_start"] + "-" + reader["time_finish"]);
            }
            string group_name = "";
            for (int i = 1; i < 7; i++)
            {
                DB_connect con2 = new DB_connect(ip, db, user, pass);
                MySqlDataReader reader2 = con2.GetDBData("select * from schedule_on_week where (parity='" + nechet + "' or parity='0') and day_of_week='" + i + "' and prof_id='" + prof_id + "';");
                while (reader2.Read())
                {
                    int pair_no = Convert.ToInt32(reader2["pair_no"]);
                    group_name = reader2["groups_name"].ToString();
                    string classes_type_name = reader2["classes_type_name"].ToString();
                    int course_id = Convert.ToInt32(reader2["course_id"]);
                    int auditory = Convert.ToInt32(reader2["auditory_no"]);
                    DB_connect con3 = new DB_connect(ip, db, user, pass);
                    MySqlDataReader reader3 = con3.GetDBData("select * from course where id='" + course_id + "';");
                    reader3.Read();
                    string course_name = reader3["name"].ToString();
                    reader3.Close();
                    string str = course_name + "\r\n" + group_name + "\r\n" + classes_type_name + "\r\n" + auditory;
                    dataGridView1.Rows[pair_no-1].Cells[i].Value = str;
                    dataGridView1.Rows[pair_no-1].Height = 65;
                }
            }
            reader.Close();

        }

        private void Prepsched_Shown(object sender, EventArgs e)
        {
            
            Upd(week);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            week -= 1;
            Upd(week);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            week += 1;
            Upd(week);
        }
    }
}
