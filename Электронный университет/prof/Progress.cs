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
    public partial class Progress : Form
    {
        public Progress(string groups_name, int course_id, string ip, string db, string user, string pass)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.groups_name = groups_name;
            this.course_id = course_id;
            this.ip = ip;
            this.db = db;
            this.user = user;
            this.pass = pass;
            con = new DB_connect(ip, db, user, pass);
            this.listBox1.MouseDoubleClick += listBox1_MouseDoubleClick;
            this.dataGridView2.CellEndEdit += dataGridView2_labs;
            this.dataGridView3.CellEndEdit += dataGridView3_rk;
            this.dataGridView4.CellEndEdit += dataGridView4_dz;
        }

        private void dataGridView4_dz(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show("Hell");
            if (dataGridView4.Columns[e.ColumnIndex].Name == "mark_dz")
            {
                DataGridViewRow row = dataGridView4.CurrentRow;
                DB_connect cn = new DB_connect(ip, db, user, pass);
                DateTime dt = DateTime.Parse(row.Cells[1].Value.ToString());
                MySqlDataReader reader2 = cn.GetDBData("select * from classes where date='" + String.Format("{0:yyyy-MM-dd}", dt) + "' and course_id='" + course_id + "';");
                int class_id = -1;
                if (reader2.Read())
                {
                    class_id = Convert.ToInt32(reader2["id"]);
                    DB_connect cn2 = new DB_connect(ip, db, user, pass);
                    MySqlDataReader rc = cn2.GetDBData("UPDATE classes_progress SET mark='" + row.Cells[3].Value.ToString() + "' WHERE st_zk_no='" + zk + "' and course_id='" + course_id + "' and classes_id='" + class_id + "';");
                    rc.Read();
                    MessageBox.Show("Значение обновлено!");
                    rc.Close();
                }
                reader2.Close();
            }
        }

        private void dataGridView3_rk(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView3.Columns[e.ColumnIndex].Name == "mark_rk")
            {
                DataGridViewRow row = dataGridView3.CurrentRow;
                //MessageBox.Show("Hello " + row.Cells[3].Value.ToString());
                DB_connect cn = new DB_connect(ip, db, user, pass);
                DateTime dt = DateTime.Parse(row.Cells[1].Value.ToString());
                MySqlDataReader reader2 = cn.GetDBData("select * from classes where date='" + String.Format("{0:yyyy-MM-dd}", dt) + "' and course_id='" + course_id + "';");
                int class_id = -1;
                if (reader2.Read())
                {
                    class_id = Convert.ToInt32(reader2["id"]);
                    DB_connect cn2 = new DB_connect(ip, db, user, pass);
                    MySqlDataReader rc = cn2.GetDBData("UPDATE classes_progress SET mark='" + row.Cells[3].Value.ToString() + "' WHERE st_zk_no='" + zk + "' and course_id='" + course_id + "' and classes_id='" + class_id + "';");
                    rc.Read();
                    MessageBox.Show("Значение обновлено!");
                    rc.Close();
                }
                reader2.Close();
            }
        }

        private void dataGridView2_labs(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.Columns[e.ColumnIndex].Name == "mark")
            {
                DataGridViewRow row = dataGridView2.CurrentRow;
                //MessageBox.Show("Hello " + row.Cells[3].Value.ToString());
                DB_connect cn = new DB_connect(ip, db, user, pass);
                DateTime dt = DateTime.Parse(row.Cells[1].Value.ToString());
                MySqlDataReader reader2 = cn.GetDBData("select * from classes where date='" + String.Format("{0:yyyy-MM-dd}", dt) + "' and course_id='" + course_id + "';");
                int class_id = -1;
                if (reader2.Read())
                {
                    class_id = Convert.ToInt32(reader2["id"]);
                    DB_connect cn2 = new DB_connect(ip, db, user, pass);
                    MySqlDataReader rc = cn2.GetDBData("UPDATE classes_progress SET mark='" + row.Cells[3].Value.ToString() + "' WHERE st_zk_no='" + zk + "' and course_id='" + course_id + "' and classes_id='" + class_id + "';");
                    rc.Read();
                    MessageBox.Show("Значение обновлено!");
                    rc.Close();
                }
                reader2.Close();
            }
        }

        string ip;
        string db;
        string user;
        string pass;
        string groups_name;
        int course_id;
        string zk;
        DB_connect con;
        MySqlDataReader reader;

        void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //int index = this.listBox1.IndexFromPoint(e.Location);
            //if (index != System.Windows.Forms.ListBox.NoMatches)
            //MessageBox.Show(listBox1.SelectedItem.ToString());
            {
                Lab_Upd(listBox1.SelectedItem.ToString());
            }
        }

        private void Progress_Load(object sender, EventArgs e)
        {
        }

        private void Upd()
        {
            // Очистка всех таблиц --------------------------------------------------
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
            dataGridView4.Rows.Clear();
            dataGridView5.Rows.Clear();


            //Заполняем таблицу на первой вкладке ------------------------------------
            //Создаем колонки
            reader = con.GetDBData("select * from classes where classes_type_name='Семинар' AND course_id='" + course_id + "';");
            int days = 0;
            dataGridView1.Columns.Add("student", "Студент");
            dataGridView1.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[0].Resizable = DataGridViewTriState.False;
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[0].Width = 150;
            String[] stroke;
            int i = 1;
            while (reader.Read())
            {
                stroke = reader["date"].ToString().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                dataGridView1.Columns.Add(stroke[0], stroke[0].ToString());
                dataGridView1.Columns[i].Width = 65;
                dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[i].Resizable = DataGridViewTriState.False;
                string today = DateTime.Today.ToString(); //.Year + "-" + DateTime.Today.Month + "-" + DateTime.Today.Day;
                string date = reader["date"].ToString();
                if (!(date == today))
                {
                    dataGridView1.Columns[i].ReadOnly = true;
                    dataGridView1.Columns[i].DefaultCellStyle.ForeColor = DefaultForeColor;
                }
                else
                {
                    dataGridView1.Columns[i].ReadOnly = false;
                    dataGridView1.Columns[i].DefaultCellStyle.BackColor = Color.LightGreen;
                }
                i++;
            }
            days = i - 1;
            reader.Close();
            dataGridView1.Columns.Add("late", "Опозданий");
            dataGridView1.Columns[i].Width = 80;
            dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[i].Resizable = DataGridViewTriState.False;
            dataGridView1.Columns[i].ReadOnly = true;
            dataGridView1.Columns.Add("work", "Работа на семинарах");
            dataGridView1.Columns[i + 1].Width = 90;
            dataGridView1.Columns[i + 1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[i + 1].Resizable = DataGridViewTriState.False;
            dataGridView1.Columns[i + 1].ReadOnly = true;

            //Заполняем данными
            reader = con.GetDBData("select * from students where groups_name='" + groups_name + "';");
            i = 0;
            while (reader.Read())
            {
                string name = reader["name"].ToString();
                string zk = reader["zk"].ToString();
                dataGridView1.Rows.Add(name);
                try
                {
                    DB_connect con2 = new DB_connect(ip, db, user, pass);
                    MySqlDataReader reader2 = con2.GetDBData("select * from attendance where st_zk_no='" + zk + "' and course_id='" + course_id + "';");
                    int sum_late = 0;
                    int sum_answer = 0;
                    int k = 0;
                    for (int j = 1; j <= days; j++)
                    {
                        reader2.Read();
                        //MessageBox.Show(reader2["attend"].ToString());
                        dataGridView1.Rows[i].Cells[j].Value = "";

                        var attend = reader2["attend"].ToString();
                        var lateness = reader2["lateness"].ToString();
                        var answer = reader2["answer"].ToString();
                        string str = "";
                        if (attend == "True")
                        {
                            str += "+";
                        }
                        if (lateness == "True")
                        {
                            str += "о";
                            sum_late += 1;
                        }
                        if (answer == "True")
                        {
                            str += "д";
                            sum_answer += 1;
                        }
                        dataGridView1.Rows[i].Cells[j].Value = str;
                        k = j;
                    }
                    if (!(sum_late == 0))
                    {
                        dataGridView1.Rows[i].Cells[k + 1].Value = sum_late.ToString() + "/" + days;
                    }
                    if (!(sum_answer == 0))
                    {
                        dataGridView1.Rows[i].Cells[k + 2].Value = sum_answer.ToString() + "/" + days;
                    }

                    i++;
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.ToString());
                }

            }
            reader.Close();


            // Вторая вкладка ---------------------------------
            // listbox
            listBox1.Items.Clear();
            DB_connect connect = new DB_connect(ip, db, user, pass);
            MySqlDataReader newread = connect.GetDBData("select * from students where groups_name='" + groups_name + "';");
            while (newread.Read())
            {
                listBox1.Items.Add(newread["name"].ToString());
            }
            newread.Close();
            connect.Close();
            // заполнение по щелчку dataGridView2, 3 и 4 (лб, рк, дз) отдельной функцией ниже

        }

        private void Lab_Upd(string name)
        {
            // Очистка датагридвью
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
            dataGridView4.Rows.Clear();

            //dataGridView2 --------------------------------------------
            DB_connect connect = new DB_connect(ip, db, user, pass);
            MySqlDataReader newread = connect.GetDBData("select * from students where name='" + name + "';");
            if (newread.Read())
            {
                zk = newread["zk"].ToString();
            }
            newread.Close();
            newread = connect.GetDBData("select * from classes where course_id='" + course_id + "' and classes_type_name='Лабораторная работа';");
            int[] lab_no = null;
            int[] lab_id = null;
            int i = 0;
            while (newread.Read())
            {
                Array.Resize(ref lab_no, i+1);
                lab_no[i] = Convert.ToInt32(newread["number"]);
                Array.Resize(ref lab_id, i+1);
                lab_id[i] = Convert.ToInt32(newread["id"]);
                dataGridView2.Rows.Add(lab_no[i].ToString());
                string[] stroke = newread["date"].ToString().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                string s = stroke[0];
                dataGridView2.Rows[i].Cells[1].Value = stroke[0];
                DB_connect connect2 = new DB_connect(ip, db, user, pass);
                MySqlDataReader newread2 = connect2.GetDBData("select * from attendance where st_zk_no='" + zk + "' and course_id='" + course_id + "' and classes_id='" + lab_id[i] + "';");
                if (newread2.Read())
                {
                    bool attend = Convert.ToBoolean(newread2["attend"]);
                    if (attend)
                    {
                        dataGridView2.Rows[i].Cells[2].Value = "+";
                    }
                    DateTime late_date = DateTime.Parse(stroke[0]);
                    late_date = late_date.AddDays(7);
                    TimeSpan ts = DateTime.Today - late_date;
                    int days_left = ts.Days;
                    if (days_left > 7)
                    {
                        dataGridView2.Rows[i].Cells[4].Value = "+";
                    }
                }
                newread2.Close();
                newread2 = connect2.GetDBData("select * from classes_progress where st_zk_no='" + zk + "' and course_id='" + course_id + "' and classes_id='" + lab_id[i] + "';");
                if (newread2.Read())
                {
                    int mark = Convert.ToInt32(newread2["mark"]);
                    dataGridView2.Rows[i].Cells[3].Value = mark;
                }
                newread2.Close();

                i++;
            }
            newread.Close();
            


            //dataGridView3 ------------------------------------------
            //string zk;
            newread = connect.GetDBData("select * from students where name='" + name + "';");
            if (newread.Read())
            {
                zk = newread["zk"].ToString();
            }
            newread.Close();
            newread = connect.GetDBData("select * from classes where course_id='" + course_id + "' and classes_type_name='Рубежный контроль';");
            lab_no = null;
            lab_id = null;
            i = 0;
            while (newread.Read())
            {
                Array.Resize(ref lab_no, i + 1);
                lab_no[i] = Convert.ToInt32(newread["number"]);
                Array.Resize(ref lab_id, i + 1);
                lab_id[i] = Convert.ToInt32(newread["id"]);
                dataGridView3.Rows.Add(lab_no[i].ToString());
                string[] stroke = newread["date"].ToString().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                string s = stroke[0];
                dataGridView3.Rows[i].Cells[1].Value = stroke[0];
                DB_connect connect2 = new DB_connect(ip, db, user, pass);
                MySqlDataReader newread2 = connect2.GetDBData("select * from attendance where st_zk_no='" + zk + "' and course_id='" + course_id + "' and classes_id='" + lab_id[i] + "';");
                if (newread2.Read())
                {
                    bool attend = Convert.ToBoolean(newread2["attend"]);
                    if (attend)
                    {
                        dataGridView3.Rows[i].Cells[2].Value = "+";
                    }
                    DateTime late_date = DateTime.Parse(stroke[0]);
                    late_date = late_date.AddDays(7);
                    TimeSpan ts = DateTime.Today - late_date;
                    int days_left = ts.Days;
                    if (days_left > 7)
                    {
                        dataGridView3.Rows[i].Cells[4].Value = "+";
                    }
                }
                newread2.Close();
                newread2 = connect2.GetDBData("select * from classes_progress where st_zk_no='" + zk + "' and course_id='" + course_id + "' and classes_id='" + lab_id[i] + "';");
                if (newread2.Read())
                {
                    int mark = Convert.ToInt32(newread2["mark"]);
                    dataGridView3.Rows[i].Cells[3].Value = mark;
                }
                newread2.Close();

                i++;
            }
            newread.Close();


            // dataGridView4 ---------------------------------------------------
            //string zk;
            newread = connect.GetDBData("select * from students where name='" + name + "';");
            if (newread.Read())
            {
                zk = newread["zk"].ToString();
            }
            newread.Close();
            newread = connect.GetDBData("select * from classes where course_id='" + course_id + "' and classes_type_name='Домашнее задание';");
            lab_no = null;
            lab_id = null;
            i = 0;
            while (newread.Read())
            {
                Array.Resize(ref lab_no, i + 1);
                lab_no[i] = Convert.ToInt32(newread["number"]);
                Array.Resize(ref lab_id, i + 1);
                lab_id[i] = Convert.ToInt32(newread["id"]);
                dataGridView4.Rows.Add(lab_no[i].ToString());
                string[] stroke = newread["date"].ToString().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                string s = stroke[0];
                dataGridView4.Rows[i].Cells[1].Value = stroke[0];
                DB_connect connect2 = new DB_connect(ip, db, user, pass);
                MySqlDataReader newread2 = connect2.GetDBData("select * from attendance where st_zk_no='" + zk + "' and course_id='" + course_id + "' and classes_id='" + lab_id[i] + "';");
                if (newread2.Read())
                {
                    bool attend = Convert.ToBoolean(newread2["attend"]);
                    if (attend)
                    {
                        dataGridView4.Rows[i].Cells[2].Value = "+";
                    }
                    DateTime late_date = DateTime.Parse(stroke[0]);
                    late_date = late_date.AddDays(7);
                    TimeSpan ts = DateTime.Today - late_date;
                    int days_left = ts.Days;
                    if (days_left > 7)
                    {
                        dataGridView4.Rows[i].Cells[4].Value = "+";
                    }
                }
                newread2.Close();
                newread2 = connect2.GetDBData("select * from classes_progress where st_zk_no='" + zk + "' and course_id='" + course_id + "' and classes_id='" + lab_id[i] + "';");
                if (newread2.Read())
                {
                    int mark = Convert.ToInt32(newread2["mark"]);
                    dataGridView4.Rows[i].Cells[3].Value = mark;
                }
                newread2.Close();

                i++;
            }
            newread.Close();
        }

        // А тут обновляем последнюю вкладку с экзаменом.
        public void exam_tab_update()
        {
            
            //Очищаем, снова.
            dataGridView5.Rows.Clear();
            //dataGridView5.Columns.Clear();

            DB_connect con = new DB_connect(ip, db, user, pass);

            /*MySqlDataReader newread = con.GetDBData("select * from modules where course_id='" + course_id + "';");
            int i = 2;
            while (newread.Read())
            {
                int mdl_id = Convert.ToInt32(newread["id"]);
                DataGridViewColumn module2 = new DataGridViewColumn();
                module2.Name = "in_time_" + i;
                module2.HeaderText = "В срок";
                dataGridView5.Columns.Insert(i, module2);
                DataGridViewColumn module1 = new DataGridViewColumn();
                module1.Name = "module" + i;
                module1.HeaderText = "Модуль " + i/2;
                dataGridView5.Columns.Insert(i, module1);
                i += 2;
            }
            newread.Close(); */

            MySqlDataReader newread = con.GetDBData("select * from students where groups_name='" + groups_name + "';");
            int j = 1;
            int i = 0;
            string zk2 = "";
            while (newread.Read())
            {
                string st = newread["name"].ToString();
                dataGridView5.Rows.Add(st);
                zk2 = newread["zk"].ToString();
                DB_connect con2 = new DB_connect(ip, db, user, pass);
                MySqlDataReader newreader2 = con2.GetDBData("select * from classes_progress where st_zk_no='" + zk2 + "' and course_id='" + course_id + "';");
                int sum_mark = 0;
                while (newreader2.Read())
                {
                    sum_mark += Convert.ToInt32(newreader2["mark"]);
                }
                dataGridView5.Rows[i].Cells[j+5].Value = sum_mark;
                newreader2.Close();

                newreader2 = con2.GetDBData("select * from attendance where st_zk_no='" + zk2 + "' and course_id='" + course_id + "';");
                int sum_late = 0;
                int sum_act = 0;
                int num = 0;
                while (newreader2.Read())
                {
                    string late = newreader2["attend"].ToString();
                    string act = newreader2["answer"].ToString();
                    if (late == "True")
                    {
                        sum_late++;
                    }
                    if (act == "True")
                    {
                        sum_act++;
                    }
                    num++;
                }
                dataGridView5.Rows[i].Cells[j+2].Value = sum_late + "/" + num;
                dataGridView5.Rows[i].Cells[j+3].Value = sum_late + "/" + num;
                newreader2.Close();

                newreader2 = con2.GetDBData("select * from classes where classes_type_name='Экзамен' and course_id='"+course_id+"';");
                int ekz_cl_id = 0;
                if (newreader2.Read())
                {
                    ekz_cl_id = Convert.ToInt32(newreader2["id"]);
                }
                newreader2.Close();

                newreader2 = con2.GetDBData("select * from classes_progress where st_zk_no='" + zk2 + "' and classes_id='" + ekz_cl_id + "' and course_id='" + course_id + "';");
                if (newreader2.Read())
                {
                    int mark = Convert.ToInt32(newreader2["mark"]);
                    dataGridView5.Rows[i].Cells[j+4].Value = mark;
                }
                newreader2.Close();
                i++;
            }
            newread.Close();

            newread = con.GetDBData("select * from modules where course_id='" + course_id + "';");
            i = 2;
            while (newread.Read())
            {
                int mod_id = Convert.ToInt32(newread["id"]);
                int mdl_id = Convert.ToInt32(newread["id"]);
                dataGridView5.Columns.Add("in_time" + (i / 2).ToString(), "В срок");
                dataGridView5.Columns["in_time" + (i / 2).ToString()].DisplayIndex = i;
                dataGridView5.Columns.Add("moudule" + (i / 2).ToString(), "Модуль " + (i / 2).ToString());
                dataGridView5.Columns["moudule" + (i / 2).ToString()].DisplayIndex = i;
                int col_id = dataGridView5.Columns["moudule" + (i / 2).ToString()].Index;

                for (int k = 0; k < dataGridView5.RowCount; k++)
                {
                    int mod_mark = 0;
                    DB_connect con3 = new DB_connect(ip, db, user, pass);
                    string st_n = dataGridView5.Rows[k].Cells[0].Value.ToString();
                    MySqlDataReader newreader2 = con3.GetDBData("select * from students where name='" + st_n + "';");
                    string zk = "";
                    if (newreader2.Read())
                    {
                        zk = newreader2["zk"].ToString();
                    }
                    newreader2.Close();
                    newreader2 = con3.GetDBData("select * from module_progress where course_id='" + course_id + "' and st_zk_no='" + zk + "' and module_id='" + mod_id + "';");
                    
                    if (newreader2.Read())
                    {
                        mod_mark = Convert.ToInt32(newreader2["summ_mark"]);
                    }
                    newreader2.Close();
                    if (!(mod_mark == 0))
                    {
                        dataGridView5.Rows[k].Cells[col_id].Value = mod_mark.ToString();
                    }
                    newreader2.Close();
                }
                i += 2;
            }
            newread.Close();



        }


        private void Progress_Shown(object sender, EventArgs e)
        {
            Upd();
            exam_tab_update();
        }
    }
}