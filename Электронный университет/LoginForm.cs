using System;
using System.Windows.Forms;

namespace Электронный_университет
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            textBox1.Select();
        }

        string[][] txt = null;
        ini_func ini = new ini_func();



        private void button1_Click(object sender, EventArgs e)
        {
            int k = comboBox1.SelectedIndex;
            DB_connect con = new DB_connect(txt[k][1], txt[k][3], txt[k][4], txt[k][5]);
            if (con.CheckLogPass(textBox1.Text, textBox2.Text))
            {
                if (con.CheckRole(textBox1.Text) == "prof")
                {
                    this.Hide();
                    MainForm mf = new MainForm(textBox1.Text, txt[k][1], txt[k][3], txt[k][4], txt[k][5]);
                    mf.Show();
                }
                if (con.CheckRole(textBox1.Text) == "stud")
                {
                    this.Hide();
                    StudForm st = new StudForm(textBox1.Text, txt[k][1], txt[k][3], txt[k][4], txt[k][5]);
                    st.Show();
                }
            } else
            {
                MessageBox.Show("Неверные логин или пароль!");
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            txt = ini.ReadIni();
            for (int i = 0; i <= txt.Length - 1; i++)
            {
                comboBox1.Items.Add(txt[i][0]);
            }
            comboBox1.SelectedIndex = 0;
        }
    }
}
