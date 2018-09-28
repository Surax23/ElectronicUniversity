namespace Электронный_университет
{
    partial class StudSched
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tuesday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wednesday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thursday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.friday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saturday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(559, 62);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(78, 20);
            this.textBox2.TabIndex = 23;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(450, 63);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(78, 20);
            this.textBox1.TabIndex = 22;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.time,
            this.monday,
            this.tuesday,
            this.wednesday,
            this.thursday,
            this.friday,
            this.saturday});
            this.dataGridView1.Location = new System.Drawing.Point(15, 99);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1053, 351);
            this.dataGridView1.TabIndex = 21;
            // 
            // time
            // 
            this.time.HeaderText = "Время";
            this.time.Name = "time";
            this.time.ReadOnly = true;
            this.time.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.time.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.time.Width = 110;
            // 
            // monday
            // 
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.monday.DefaultCellStyle = dataGridViewCellStyle13;
            this.monday.HeaderText = "Понедельник";
            this.monday.Name = "monday";
            this.monday.ReadOnly = true;
            this.monday.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.monday.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.monday.Width = 150;
            // 
            // tuesday
            // 
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tuesday.DefaultCellStyle = dataGridViewCellStyle14;
            this.tuesday.HeaderText = "Вторник";
            this.tuesday.Name = "tuesday";
            this.tuesday.ReadOnly = true;
            this.tuesday.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.tuesday.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.tuesday.Width = 150;
            // 
            // wednesday
            // 
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.wednesday.DefaultCellStyle = dataGridViewCellStyle15;
            this.wednesday.HeaderText = "Среда";
            this.wednesday.Name = "wednesday";
            this.wednesday.ReadOnly = true;
            this.wednesday.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.wednesday.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.wednesday.Width = 150;
            // 
            // thursday
            // 
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.thursday.DefaultCellStyle = dataGridViewCellStyle16;
            this.thursday.HeaderText = "Четверг";
            this.thursday.Name = "thursday";
            this.thursday.ReadOnly = true;
            this.thursday.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.thursday.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.thursday.Width = 150;
            // 
            // friday
            // 
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.friday.DefaultCellStyle = dataGridViewCellStyle17;
            this.friday.HeaderText = "Пятница";
            this.friday.Name = "friday";
            this.friday.ReadOnly = true;
            this.friday.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.friday.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.friday.Width = 150;
            // 
            // saturday
            // 
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.saturday.DefaultCellStyle = dataGridViewCellStyle18;
            this.saturday.HeaderText = "Суббота";
            this.saturday.Name = "saturday";
            this.saturday.ReadOnly = true;
            this.saturday.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.saturday.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.saturday.Width = 150;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(643, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 16);
            this.label4.TabIndex = 20;
            this.label4.Text = ">>>";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(534, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 16);
            this.label3.TabIndex = 19;
            this.label3.Text = "—";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(411, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 16);
            this.label2.TabIndex = 18;
            this.label2.Text = "<<<";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 25);
            this.label1.TabIndex = 17;
            this.label1.Text = "{ФИО студента}";
            // 
            // StudSched
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 462);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "StudSched";
            this.Text = "StudSched";
            this.Shown += new System.EventHandler(this.StudSched_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn time;
        private System.Windows.Forms.DataGridViewTextBoxColumn monday;
        private System.Windows.Forms.DataGridViewTextBoxColumn tuesday;
        private System.Windows.Forms.DataGridViewTextBoxColumn wednesday;
        private System.Windows.Forms.DataGridViewTextBoxColumn thursday;
        private System.Windows.Forms.DataGridViewTextBoxColumn friday;
        private System.Windows.Forms.DataGridViewTextBoxColumn saturday;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}