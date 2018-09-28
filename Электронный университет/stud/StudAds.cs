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
    public partial class StudAds : Form
    {
        public StudAds()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        private void StudAds_Shown(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add("30.05.2016", "Тема 1", "Объявление 1.", "РК9-81");
            dataGridView1.Rows.Add("05.06.2016", "Тема 2", "Объявление 2.", "РК9-81");
        }
    }
}
