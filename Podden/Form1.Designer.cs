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
            txtNamn = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btnFiltrera = new Button();
            btnAterstall = new Button();
            label6 = new Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            label7 = new Label();
            SuspendLayout();
            // 
            // textBox4
            // 
            textBox4.Location = new Point(931, 142);
            textBox4.Margin = new Padding(4, 3, 4, 3);
            textBox4.Name = "textBox4";
            textBox4.ScrollBars = ScrollBars.Horizontal;
            textBox4.Size = new Size(210, 31);
            textBox4.TabIndex = 40;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(931, 114);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(93, 25);
            label5.TabIndex = 39;
            label5.Text = "Kategorier";
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { Namn, Avsnitt, URL, Kategori });
            listView1.GridLines = true;
            listView1.Location = new Point(226, 287);
            listView1.Margin = new Padding(4, 5, 4, 3);
            listView1.Name = "listView1";
            listView1.Size = new Size(638, 204);
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
            textBox3.Location = new Point(931, 527);
            textBox3.Margin = new Padding(4, 3, 4, 3);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(488, 204);
            textBox3.TabIndex = 37;
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 25;
            listBox2.Location = new Point(224, 527);
            listBox2.Margin = new Padding(4, 3, 4, 3);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(638, 204);
            listBox2.TabIndex = 36;
            listBox2.SelectedIndexChanged += listBox2_SelectedIndexChanged;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 25;
            listBox1.Location = new Point(931, 287);
            listBox1.Margin = new Padding(4, 3, 4, 3);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(488, 204);
            listBox1.TabIndex = 35;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // button4
            // 
            button4.Location = new Point(1209, 212);
            button4.Margin = new Padding(4, 3, 4, 3);
            button4.Name = "button4";
            button4.Size = new Size(119, 37);
            button4.TabIndex = 34;
            button4.Text = "Ta bort ";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(1070, 212);
            button5.Margin = new Padding(4, 3, 4, 3);
            button5.Name = "button5";
            button5.Size = new Size(119, 37);
            button5.TabIndex = 33;
            button5.Text = "Ändra";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(931, 212);
            button6.Margin = new Padding(4, 3, 4, 3);
            button6.Name = "button6";
            button6.Size = new Size(119, 37);
            button6.TabIndex = 32;
            button6.Text = "Lägg till";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // txtUrl
            // 
            txtUrl.Location = new Point(224, 213);
            txtUrl.Margin = new Padding(4, 3, 4, 3);
            txtUrl.Name = "txtUrl";
            txtUrl.Size = new Size(210, 31);
            txtUrl.TabIndex = 31;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(224, 183);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(43, 25);
            label4.TabIndex = 30;
            label4.Text = "URL";
            // 
            // btnTaBortRss
            // 
            btnTaBortRss.Location = new Point(721, 213);
            btnTaBortRss.Margin = new Padding(4, 3, 4, 3);
            btnTaBortRss.Name = "btnTaBortRss";
            btnTaBortRss.Size = new Size(119, 37);
            btnTaBortRss.TabIndex = 29;
            btnTaBortRss.Text = "Ta bort ";
            btnTaBortRss.UseVisualStyleBackColor = true;
            btnTaBortRss.Click += btnTaBortRss_Click;
            // 
            // btnAndraRss
            // 
            btnAndraRss.Location = new Point(596, 213);
            btnAndraRss.Margin = new Padding(4, 3, 4, 3);
            btnAndraRss.Name = "btnAndraRss";
            btnAndraRss.Size = new Size(119, 37);
            btnAndraRss.TabIndex = 28;
            btnAndraRss.Text = "Ändra";
            btnAndraRss.UseVisualStyleBackColor = true;
            btnAndraRss.Click += btnAndraRss_Click;
            // 
            // btnLaggaTillRss
            // 
            btnLaggaTillRss.Location = new Point(471, 213);
            btnLaggaTillRss.Margin = new Padding(4, 3, 4, 3);
            btnLaggaTillRss.Name = "btnLaggaTillRss";
            btnLaggaTillRss.Size = new Size(119, 37);
            btnLaggaTillRss.TabIndex = 27;
            btnLaggaTillRss.Text = "Lägg till";
            btnLaggaTillRss.UseVisualStyleBackColor = true;
            btnLaggaTillRss.Click += btnLaggaTillRss_Click;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(224, 126);
            comboBox2.Margin = new Padding(4, 3, 4, 3);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(133, 33);
            comboBox2.TabIndex = 26;
            // 
            // txtNamn
            // 
            txtNamn.Location = new Point(226, 43);
            txtNamn.Margin = new Padding(4, 3, 4, 3);
            txtNamn.Name = "txtNamn";
            txtNamn.Size = new Size(210, 31);
            txtNamn.TabIndex = 24;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(224, 98);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(0, 25);
            label3.TabIndex = 23;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(224, 98);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(78, 25);
            label2.TabIndex = 22;
            label2.Text = "Kategori";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(224, 15);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(60, 25);
            label1.TabIndex = 21;
            label1.Text = "Namn";
            // 
            // btnFiltrera
            // 
            btnFiltrera.Location = new Point(471, 119);
            btnFiltrera.Name = "btnFiltrera";
            btnFiltrera.Size = new Size(112, 34);
            btnFiltrera.TabIndex = 41;
            btnFiltrera.Text = "Filtrera";
            btnFiltrera.UseVisualStyleBackColor = true;
            btnFiltrera.Click += btnFiltrera_Click;
            // 
            // btnAterstall
            // 
            btnAterstall.Location = new Point(596, 119);
            btnAterstall.Name = "btnAterstall";
            btnAterstall.Size = new Size(112, 34);
            btnAterstall.TabIndex = 42;
            btnAterstall.Text = "Återställ";
            btnAterstall.UseVisualStyleBackColor = true;
            btnAterstall.Click += btnAterstall_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(520, 81);
            label6.Name = "label6";
            label6.Size = new Size(139, 25);
            label6.TabIndex = 43;
            label6.Text = "Sortera kategori";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(1209, 114);
            label7.Name = "label7";
            label7.Size = new Size(59, 25);
            label7.TabIndex = 44;
            label7.Text = "label7";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1759, 808);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(btnAterstall);
            Controls.Add(btnFiltrera);
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
            Controls.Add(txtNamn);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(4, 3, 4, 3);
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
        private TextBox txtNamn;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnFiltrera;
        private Button btnAterstall;
        private Label label6;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Label label7;
    }
}