using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Электронный_университет
{
    public partial class Ads : Form
    {
        public Ads(int prof_id, string ip, string db, string user, string pass)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.prof_id = prof_id;
            this.ip = ip;
            this.db = db;
            this.user = user;
            this.pass = pass;
            this.prof_id = prof_id;
            con = new DB_connect(ip, db, user, pass);
            reader = con.GetDBData("select name from professor where id='" + prof_id + "';");
            reader.Read();
            prof_name = reader["name"].ToString();
            reader.Close();
            label1.Text = prof_name;
        }

        DB_connect con;
        MySqlDataReader reader;
        int prof_id;
        string prof_name;
        string ip;
        string db;
        string user;
        string pass;

        private void Ads_Shown(object sender, EventArgs e)
        {
            Upd();
        }

        public void Upd()
        {
            reader = con.GetDBData("select * from ads where prof_id='" + prof_id + "';");
            int i = 0;
            while (reader.Read())
            {
                DateTime dt = DateTime.Parse(reader["date"].ToString());
                string group_name = reader["groups_name"].ToString();
                string subject = reader["subject"].ToString();
                string text = reader["text"].ToString();
                dataGridView1.Rows.Add(String.Format("{0:dd.MM.yyyy}", dt), subject, text, group_name);
                dataGridView1.Rows[i].Height = 65;
                i++;
            }
            reader.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Add_ad ads = new Add_ad(prof_id, ip, db, user, pass);
            ads.ShowDialog();
        }
    }
}
