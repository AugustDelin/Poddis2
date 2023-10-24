namespace Podden
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox4 = new TextBox();
            label5 = new Label();
            listView1 = new ListView();
            Namn = new ColumnHeader();
            Avsnitt = new ColumnHeader();
            URL = new ColumnHeader();
            Kategori = new ColumnHeader();
            textBox3 = new TextBox();
            listBox2 = new ListBox();
            listBox1 = new ListBox();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            txtUrl = new TextBox();
            label4 = new Label();
            btnTaBortRss = new Button();
            btnAndraRss = new Button();
            btnLaggaTillRss = new Button();
            comboBox2 = new ComboBox();
            comboBox1 = new ComboBox();
            txtNamn = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // textBox4
            // 
            textBox4.Location = new Point(652, 56);
            textBox4.Margin = new Padding(3, 2, 3, 2);
            textBox4.Name = "textBox4";
            textBox4.ScrollBars = ScrollBars.Horizontal;
            textBox4.Size = new Size(148, 23);
            textBox4.TabIndex = 40;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(652, 9);
            label5.Name = "label5";
            label5.Size = new Size(61, 15);
            label5.TabIndex = 39;
            label5.Text = "Kategorier";
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { Namn, Avsnitt, URL, Kategori });
            listView1.GridLines = true;
            listView1.Location = new Point(158, 172);
            listView1.Margin = new Padding(3, 3, 3, 2);
            listView1.Name = "listView1";
            listView1.Size = new Size(448, 124);
            listView1.TabIndex = 38;
            listView1.TileSize = new Size(300, 100);
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // Namn
            // 
            Namn.Text = "Namn";
            Namn.Width = 159;
            // 
            // Avsnitt
            // 
            Avsnitt.Text = "Avsnitt";
            Avsnitt.Width = 76;
            // 
            // URL
            // 
            URL.Text = "URL";
            URL.Width = 135;
            // 
            // Kategori
            // 
            Kategori.Text = "Kategori";
            Kategori.Width = 286;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(652, 316);
            textBox3.Margin = new Padding(3, 2, 3, 2);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(343, 124);
            textBox3.TabIndex = 37;
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 15;
            listBox2.Location = new Point(157, 316);
            listBox2.Margin = new Padding(3, 2, 3, 2);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(448, 124);
            listBox2.TabIndex = 36;
            listBox2.SelectedIndexChanged += listBox2_SelectedIndexChanged;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(652, 172);
            listBox1.Margin = new Padding(3, 2, 3, 2);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(343, 124);
            listBox1.TabIndex = 35;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // button4
            // 
            button4.Location = new Point(846, 127);
            button4.Margin = new Padding(3, 2, 3, 2);
            button4.Name = "button4";
            button4.Size = new Size(83, 22);
            button4.TabIndex = 34;
            button4.Text = "Ta bort ";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(749, 127);
            button5.Margin = new Padding(3, 2, 3, 2);
            button5.Name = "button5";
            button5.Size = new Size(83, 22);
            button5.TabIndex = 33;
            button5.Text = "Ändra";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(652, 127);
            button6.Margin = new Padding(3, 2, 3, 2);
            button6.Name = "button6";
            button6.Size = new Size(83, 22);
            button6.TabIndex = 32;
            button6.Text = "Lägg till";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // txtUrl
            // 
            txtUrl.Location = new Point(157, 128);
            txtUrl.Margin = new Padding(3, 2, 3, 2);
            txtUrl.Name = "txtUrl";
            txtUrl.Size = new Size(148, 23);
            txtUrl.TabIndex = 31;
            txtUrl.TextChanged += txtUrl_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(157, 110);
            label4.Name = "label4";
            label4.Size = new Size(28, 15);
            label4.TabIndex = 30;
            label4.Text = "URL";
            // 
            // btnTaBortRss
            // 
            btnTaBortRss.Location = new Point(505, 128);
            btnTaBortRss.Margin = new Padding(3, 2, 3, 2);
            btnTaBortRss.Name = "btnTaBortRss";
            btnTaBortRss.Size = new Size(83, 22);
            btnTaBortRss.TabIndex = 29;
            btnTaBortRss.Text = "Ta bort ";
            btnTaBortRss.UseVisualStyleBackColor = true;
            btnTaBortRss.Click += btnTaBortRss_Click;
            // 
            // btnAndraRss
            // 
            btnAndraRss.Location = new Point(417, 128);
            btnAndraRss.Margin = new Padding(3, 2, 3, 2);
            btnAndraRss.Name = "btnAndraRss";
            btnAndraRss.Size = new Size(83, 22);
            btnAndraRss.TabIndex = 28;
            btnAndraRss.Text = "Ändra";
            btnAndraRss.UseVisualStyleBackColor = true;
            btnAndraRss.Click += btnAndraRss_Click;
            // 
            // btnLaggaTillRss
            // 
            btnLaggaTillRss.Location = new Point(330, 128);
            btnLaggaTillRss.Margin = new Padding(3, 2, 3, 2);
            btnLaggaTillRss.Name = "btnLaggaTillRss";
            btnLaggaTillRss.Size = new Size(83, 22);
            btnLaggaTillRss.TabIndex = 27;
            btnLaggaTillRss.Text = "Lägg till";
            btnLaggaTillRss.UseVisualStyleBackColor = true;
            btnLaggaTillRss.Click += btnLaggaTillRss_Click;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(267, 76);
            comboBox2.Margin = new Padding(3, 2, 3, 2);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(94, 23);
            comboBox2.TabIndex = 26;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(157, 76);
            comboBox1.Margin = new Padding(3, 2, 3, 2);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(94, 23);
            comboBox1.TabIndex = 25;
            // 
            // txtNamn
            // 
            txtNamn.Location = new Point(158, 26);
            txtNamn.Margin = new Padding(3, 2, 3, 2);
            txtNamn.Name = "txtNamn";
            txtNamn.Size = new Size(148, 23);
            txtNamn.TabIndex = 24;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(157, 59);
            label3.Name = "label3";
            label3.Size = new Size(53, 15);
            label3.TabIndex = 23;
            label3.Text = "Frekvens";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(259, 59);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 22;
            label2.Text = "Kategori";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(157, 9);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 21;
            label1.Text = "Namn";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1231, 485);
            Controls.Add(textBox4);
            Controls.Add(label5);
            Controls.Add(listView1);
            Controls.Add(textBox3);
            Controls.Add(listBox2);
            Controls.Add(listBox1);
            Controls.Add(button4);
            Controls.Add(button5);
            Controls.Add(button6);
            Controls.Add(txtUrl);
            Controls.Add(label4);
            Controls.Add(btnTaBortRss);
            Controls.Add(btnAndraRss);
            Controls.Add(btnLaggaTillRss);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(txtNamn);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox4;
        private Label label5;
        private ListView listView1;
        private ColumnHeader Avsnitt;
        private ColumnHeader URL;
        private ColumnHeader Namn;
        private ColumnHeader Kategori;
        private TextBox textBox3;
        private ListBox listBox2;
        private ListBox listBox1;
        private Button button4;
        private Button button5;
        private Button button6;
        private TextBox txtUrl;
        private Label label4;
        private Button btnTaBortRss;
        private Button btnAndraRss;
        private Button btnLaggaTillRss;
        private ComboBox comboBox2;
        private ComboBox comboBox1;
        private TextBox txtNamn;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}