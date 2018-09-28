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

namespace Электронный_университет.stud
{
    public partial class StudProgress : Form
    {
        public StudProgress()
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
            NewMethod();
            this.listBox1.MouseDoubleClick += listBox1_MouseDoubleClick;
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void NewMethod()
        {
            con = new DB_connect(ip, db, user, pass);
        }

        string ip;
        string db;
        string user;
        string pass;
        string groups_name;
        int course_id;
        DB_connect con;
        MySqlDataReader reader;
    }
}
