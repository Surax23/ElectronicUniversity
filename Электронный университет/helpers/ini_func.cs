using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Электронный_университет
{
    class ini_func
    {
        public string[][] ReadIni()
        // Чтение файла конфигурации servers.ini
        // Если его нет -- то создаем пустой.
        { 
            string name = "servers.ini";
            FileInfo fle = new FileInfo(name);
            String[][] fitems = null;
            if (fle.Exists)
            {
                string str = null;
                StreamReader strr = new StreamReader(name, Encoding.UTF8);
                while (!strr.EndOfStream)
                {
                    str += strr.ReadLine();
                }
                String[] stroke = str.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < stroke.Length; i++)
                {
                    String[] items = null;
                    items = stroke[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    Array.Resize(ref fitems, i + 1);
                    for (int j = 0; j < items.Length; j++)
                    {
                        Array.Resize(ref fitems[i], j + 1);
                        fitems[i][j] = items[j];
                    }
                }
                strr.Close();
            }
            else fle.Create();

            return fitems;
        }

        public bool FormOpened(Form form)
            // Проверка открыта ли форма
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == form.Name)// Объект Форма с именем form.name уже открыт.
                {
                    return true;
                }
            }
            return false;
        }

        /* public void SheduleToDate(string ip, string db, string user, string pass)
        {
            // Будем подбивать расписание
            DB_connect con = new DB_connect(ip, db, user, pass);
            MySqlDataReader reader = con.GetDBData("select * from schedule_on_week;");
            while (reader.Read())
            {
                int parity = Convert.ToInt32(reader["parity"]);
                int course_id = Convert.ToInt32(reader["course_id"]);
                string classes_type_name = reader["classes_type_name"].ToString();
                int pair_no = Convert.ToInt32(reader["pair_no"]);
                int day_of_week = Convert.ToInt32(reader["day_of_week"]);
                string group_name = reader["groups_name"].ToString();
                DB_connect con2 = new DB_connect(ip, db, user, pass);
                MySqlDataReader reader2 = con2.GetDBData("select * from course where id='" + course_id + "';");
                reader2.Read();
                DateTime str_d_s = DateTime.Parse(reader2["date_start"].ToString());
                DateTime str_d_f = DateTime.Parse(reader2["date_finish"].ToString());
                reader2.Close();
                reader2 = con2.GetDBData("select count(*) from week where date_start>='" + String.Format("{0:yyyy-MM-dd}", str_d_s) + "' and date_finish<='" + String.Format("{0:yyyy-MM-dd}", str_d_f) + "';");
                reader2.Read();
                int weeks = Convert.ToInt32(reader2[0]); // Считаем количество недель между датами курса.
                reader2.Close();
                DateTime class_date = str_d_s;
                for (int i = 1; i <= weeks; i++) 
                {
                    DB_connect con3 = new DB_connect(ip, db, user, pass);
                    MySqlDataReader reader3 = con3.GetDBData("select * from week where date_start>='" + String.Format("{0:yyyy-MM-dd}", class_date) + "';");
                    reader3.Read();
                    int week_no = Convert.ToInt32(reader3["week_no"]);
                    int par = 0;
                    if (week_no % 2 == 0)
                    {
                        par = 2;
                    }
                    else
                    {
                        par = 1;
                    }
                    reader3.Close();
                    reader3 = con3.GetDBData("select count(*) from classes where course_id='" + course_id + "';");
                    reader3.Read();
                    int num = Convert.ToInt32(reader3[0])+1;
                    reader3.Close();
                    if (parity == 0 || parity == par)
                    {
                        // Проверяем, вдруг уже добвалено занятие
                        DB_connect con4 = new DB_connect(ip, db, user, pass);
                        MySqlDataReader reader4 = con4.GetDBData("select count(*) from classes where course_id='" + course_id + "' and classes_type_name='" + classes_type_name + "' and date='" + String.Format("{0:yyyy-MM-dd}", class_date.AddDays(day_of_week - 1)) + "' and id='"+ num +"';");
                        reader4.Read();
                        int count = Convert.ToInt32(reader4[0]);
                        reader4.Close();
                        if (count == 0)
                        {
                            //Тут инсерт занятия
                            string date_c = String.Format("{0:yyyy-MM-dd}", class_date.AddDays(day_of_week - 1));
                            DB_connect con5 = new DB_connect(ip, db, user, pass);
                            //MessageBox.Show("INSERT INTO classes (course_id, classes_type_name, date, id) VALUES ('" + course_id + "', '" + classes_type_name + "', '" + String.Format("{0:yyyy-MM-dd}", class_date.AddDays(day_of_week - 1)) + "', '" + num + "');");
                            MySqlDataReader reader5 = con5.GetDBData("INSERT INTO classes (course_id, classes_type_name, date, id) VALUES ('" + course_id + "', '" + classes_type_name + "', '" + date_c + "', '" + num + "');");
                            while (reader5.Read())
                            {

                            }
                            reader5.Close();
                        }
                    }
                    class_date = class_date.AddDays(7);
                }
                reader2.Close();
            }
            reader.Close();
        } */
    }
}
