using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Электронный_университет
{
    public partial class Add_ad : Form
    {
        public Add_ad(int prof_id, string ip, string db, string user, string pass)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.prof_id = prof_id;
            this.ip = ip;
            this.db = db;
            this.user = user;
            this.pass = pass;
        }

        string ip;
        string db;
        string user;
        string pass;
        int prof_id;

        private void Add_ad_Shown(object sender, EventArgs e)
        {
            DB_connect con = new DB_connect(ip, db, user, pass);
            MySqlDataReader reader = con.GetDBData("select * from capacity where prof_id='" + prof_id + "' group by groups_name;");
            while (reader.Read())
            {
                string group_name = reader["groups_name"].ToString();
                checkedListBox1.Items.Add(group_name);
            }
            reader.Close();
        }
    }
}
