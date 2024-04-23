namespace CharactiniotisTest
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
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            menuStrip1 = new MenuStrip();
            connectToolStripMenuItem = new ToolStripMenuItem();
            addClientToolStripMenuItem = new ToolStripMenuItem();
            toolStripTextBox1 = new ToolStripMenuItem();
            toolStripTextBox2 = new ToolStripTextBox();
            toolStripMenuItem1 = new ToolStripMenuItem();
            toolStripTextBox3 = new ToolStripTextBox();
            toolStripMenuItem2 = new ToolStripMenuItem();
            toolStripTextBox4 = new ToolStripTextBox();
            toolStripMenuItem3 = new ToolStripMenuItem();
            toolStripTextBox5 = new ToolStripTextBox();
            toolStripMenuItem4 = new ToolStripMenuItem();
            toolStripTextBox6 = new ToolStripTextBox();
            toolStripMenuItem5 = new ToolStripMenuItem();
            toolStripTextBox7 = new ToolStripTextBox();
            toolStripSeparator1 = new ToolStripSeparator();
            button_Insert = new ToolStripMenuItem();
            updateCLIENTToolStripMenuItem = new ToolStripMenuItem();
            clientIDintegerToolStripMenuItem = new ToolStripMenuItem();
            toolStripTextBox8 = new ToolStripTextBox();
            firstName50CharsToolStripMenuItem = new ToolStripMenuItem();
            toolStripTextBox9 = new ToolStripTextBox();
            lastName50CharsToolStripMenuItem = new ToolStripMenuItem();
            toolStripTextBox10 = new ToolStripTextBox();
            toolStripMenuItem7 = new ToolStripMenuItem();
            toolStripTextBox12 = new ToolStripTextBox();
            postalCode5DigitsToolStripMenuItem = new ToolStripMenuItem();
            toolStripTextBox11 = new ToolStripTextBox();
            phoneNumber10DigitsToolStripMenuItem = new ToolStripMenuItem();
            toolStripTextBox13 = new ToolStripTextBox();
            email320CharsToolStripMenuItem = new ToolStripMenuItem();
            toolStripTextBox14 = new ToolStripTextBox();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripMenuItem6 = new ToolStripMenuItem();
            panel1 = new Panel();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            menuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(label1, 0, 2);
            tableLayoutPanel1.Controls.Add(dataGridView1, 0, 1);
            tableLayoutPanel1.Controls.Add(menuStrip1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 15.9375F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 84.0625F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 94F));
            tableLayoutPanel1.Size = new Size(1795, 1055);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(3, 960);
            label1.Name = "label1";
            label1.Size = new Size(1789, 95);
            label1.TabIndex = 0;
            label1.Text = "System messages";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(3, 156);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 123;
            dataGridView1.Size = new Size(1789, 801);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
            // 
            // menuStrip1
            // 
            menuStrip1.Dock = DockStyle.Fill;
            menuStrip1.ImageScalingSize = new Size(48, 48);
            menuStrip1.Items.AddRange(new ToolStripItem[] { connectToolStripMenuItem, addClientToolStripMenuItem, updateCLIENTToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1795, 153);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // connectToolStripMenuItem
            // 
            connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            connectToolStripMenuItem.Size = new Size(179, 149);
            connectToolStripMenuItem.Text = "Connect";
            connectToolStripMenuItem.Click += connectToolStripMenuItem_Click;
            // 
            // addClientToolStripMenuItem
            // 
            addClientToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripTextBox1, toolStripMenuItem1, toolStripMenuItem2, toolStripMenuItem3, toolStripMenuItem4, toolStripMenuItem5, toolStripSeparator1, button_Insert });
            addClientToolStripMenuItem.Name = "addClientToolStripMenuItem";
            addClientToolStripMenuItem.Size = new Size(260, 149);
            addClientToolStripMenuItem.Text = "Insert CLIENT";
            // 
            // toolStripTextBox1
            // 
            toolStripTextBox1.DropDownItems.AddRange(new ToolStripItem[] { toolStripTextBox2 });
            toolStripTextBox1.Name = "toolStripTextBox1";
            toolStripTextBox1.Size = new Size(626, 66);
            toolStripTextBox1.Text = "First Name (50 chars)";
            // 
            // toolStripTextBox2
            // 
            toolStripTextBox2.MaxLength = 50;
            toolStripTextBox2.Name = "toolStripTextBox2";
            toolStripTextBox2.Size = new Size(300, 55);
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { toolStripTextBox3 });
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(626, 66);
            toolStripMenuItem1.Text = "Last Name (50 chars)";
            // 
            // toolStripTextBox3
            // 
            toolStripTextBox3.MaxLength = 50;
            toolStripTextBox3.Name = "toolStripTextBox3";
            toolStripTextBox3.Size = new Size(300, 55);
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.DropDownItems.AddRange(new ToolStripItem[] { toolStripTextBox4 });
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(626, 66);
            toolStripMenuItem2.Text = "Address  (100 chars)";
            // 
            // toolStripTextBox4
            // 
            toolStripTextBox4.MaxLength = 100;
            toolStripTextBox4.Name = "toolStripTextBox4";
            toolStripTextBox4.Size = new Size(300, 55);
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.DropDownItems.AddRange(new ToolStripItem[] { toolStripTextBox5 });
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(626, 66);
            toolStripMenuItem3.Text = "Postal code (5 digits)";
            // 
            // toolStripTextBox5
            // 
            toolStripTextBox5.MaxLength = 5;
            toolStripTextBox5.Name = "toolStripTextBox5";
            toolStripTextBox5.Size = new Size(300, 55);
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.DropDownItems.AddRange(new ToolStripItem[] { toolStripTextBox6 });
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new Size(626, 66);
            toolStripMenuItem4.Text = "Phone Number (10 digits)";
            // 
            // toolStripTextBox6
            // 
            toolStripTextBox6.MaxLength = 10;
            toolStripTextBox6.Name = "toolStripTextBox6";
            toolStripTextBox6.Size = new Size(300, 55);
            toolStripTextBox6.ToolTipText = "Enter a number of exactly 10 digits";
            // 
            // toolStripMenuItem5
            // 
            toolStripMenuItem5.DropDownItems.AddRange(new ToolStripItem[] { toolStripTextBox7 });
            toolStripMenuItem5.Name = "toolStripMenuItem5";
            toolStripMenuItem5.Size = new Size(626, 66);
            toolStripMenuItem5.Text = "E-mail (320 chars)";
            // 
            // toolStripTextBox7
            // 
            toolStripTextBox7.MaxLength = 320;
            toolStripTextBox7.Name = "toolStripTextBox7";
            toolStripTextBox7.Size = new Size(300, 55);
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(623, 6);
            // 
            // button_Insert
            // 
            button_Insert.Name = "button_Insert";
            button_Insert.Size = new Size(626, 66);
            button_Insert.Text = "INSERT";
            button_Insert.Click += Button_Insert_Click;
            // 
            // updateCLIENTToolStripMenuItem
            // 
            updateCLIENTToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { clientIDintegerToolStripMenuItem, firstName50CharsToolStripMenuItem, lastName50CharsToolStripMenuItem, toolStripMenuItem7, postalCode5DigitsToolStripMenuItem, phoneNumber10DigitsToolStripMenuItem, email320CharsToolStripMenuItem, toolStripSeparator2, toolStripMenuItem6 });
            updateCLIENTToolStripMenuItem.Name = "updateCLIENTToolStripMenuItem";
            updateCLIENTToolStripMenuItem.Size = new Size(287, 149);
            updateCLIENTToolStripMenuItem.Text = "Update CLIENT";
            // 
            // clientIDintegerToolStripMenuItem
            // 
            clientIDintegerToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripTextBox8 });
            clientIDintegerToolStripMenuItem.Name = "clientIDintegerToolStripMenuItem";
            clientIDintegerToolStripMenuItem.Size = new Size(626, 66);
            clientIDintegerToolStripMenuItem.Text = "Client ID (integer)";
            // 
            // toolStripTextBox8
            // 
            toolStripTextBox8.Name = "toolStripTextBox8";
            toolStripTextBox8.Size = new Size(200, 55);
            // 
            // firstName50CharsToolStripMenuItem
            // 
            firstName50CharsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripTextBox9 });
            firstName50CharsToolStripMenuItem.Name = "firstName50CharsToolStripMenuItem";
            firstName50CharsToolStripMenuItem.Size = new Size(626, 66);
            firstName50CharsToolStripMenuItem.Text = "First Name (50 chars)";
            // 
            // toolStripTextBox9
            // 
            toolStripTextBox9.MaxLength = 50;
            toolStripTextBox9.Name = "toolStripTextBox9";
            toolStripTextBox9.Size = new Size(300, 55);
            // 
            // lastName50CharsToolStripMenuItem
            // 
            lastName50CharsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripTextBox10 });
            lastName50CharsToolStripMenuItem.Name = "lastName50CharsToolStripMenuItem";
            lastName50CharsToolStripMenuItem.Size = new Size(626, 66);
            lastName50CharsToolStripMenuItem.Text = "Last Name (50 chars)";
            // 
            // toolStripTextBox10
            // 
            toolStripTextBox10.MaxLength = 50;
            toolStripTextBox10.Name = "toolStripTextBox10";
            toolStripTextBox10.Size = new Size(300, 55);
            // 
            // toolStripMenuItem7
            // 
            toolStripMenuItem7.DropDownItems.AddRange(new ToolStripItem[] { toolStripTextBox12 });
            toolStripMenuItem7.Name = "toolStripMenuItem7";
            toolStripMenuItem7.Size = new Size(626, 66);
            toolStripMenuItem7.Text = "Address (100 chars)";
            // 
            // toolStripTextBox12
            // 
            toolStripTextBox12.MaxLength = 100;
            toolStripTextBox12.Name = "toolStripTextBox12";
            toolStripTextBox12.Size = new Size(300, 55);
            // 
            // postalCode5DigitsToolStripMenuItem
            // 
            postalCode5DigitsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripTextBox11 });
            postalCode5DigitsToolStripMenuItem.Name = "postalCode5DigitsToolStripMenuItem";
            postalCode5DigitsToolStripMenuItem.Size = new Size(626, 66);
            postalCode5DigitsToolStripMenuItem.Text = "Postal code (5 digits)";
            // 
            // toolStripTextBox11
            // 
            toolStripTextBox11.MaxLength = 5;
            toolStripTextBox11.Name = "toolStripTextBox11";
            toolStripTextBox11.Size = new Size(300, 55);
            // 
            // phoneNumber10DigitsToolStripMenuItem
            // 
            phoneNumber10DigitsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripTextBox13 });
            phoneNumber10DigitsToolStripMenuItem.Name = "phoneNumber10DigitsToolStripMenuItem";
            phoneNumber10DigitsToolStripMenuItem.Size = new Size(626, 66);
            phoneNumber10DigitsToolStripMenuItem.Text = "Phone Number (10 digits)";
            // 
            // toolStripTextBox13
            // 
            toolStripTextBox13.MaxLength = 10;
            toolStripTextBox13.Name = "toolStripTextBox13";
            toolStripTextBox13.Size = new Size(300, 55);
            // 
            // email320CharsToolStripMenuItem
            // 
            email320CharsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripTextBox14 });
            email320CharsToolStripMenuItem.Name = "email320CharsToolStripMenuItem";
            email320CharsToolStripMenuItem.Size = new Size(626, 66);
            email320CharsToolStripMenuItem.Text = "E-mail (320 chars)";
            // 
            // toolStripTextBox14
            // 
            toolStripTextBox14.MaxLength = 320;
            toolStripTextBox14.Name = "toolStripTextBox14";
            toolStripTextBox14.Size = new Size(300, 55);
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(623, 6);
            // 
            // toolStripMenuItem6
            // 
            toolStripMenuItem6.Name = "toolStripMenuItem6";
            toolStripMenuItem6.Size = new Size(626, 66);
            toolStripMenuItem6.Text = "UPDATE";
            toolStripMenuItem6.Click += Button_Update_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1795, 1055);
            panel1.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(20F, 48F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1795, 1055);
            Controls.Add(panel1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private Label label1;
        private DataGridView dataGridView1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem connectToolStripMenuItem;
        private ToolStripMenuItem addClientToolStripMenuItem;
        private ToolStripMenuItem toolStripTextBox1;
        private ToolStripTextBox toolStripTextBox2;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripTextBox toolStripTextBox3;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripTextBox toolStripTextBox4;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripTextBox toolStripTextBox5;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripTextBox toolStripTextBox6;
        private ToolStripMenuItem toolStripMenuItem5;
        private ToolStripTextBox toolStripTextBox7;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem button_Insert;
        private ToolStripMenuItem updateCLIENTToolStripMenuItem;
        private ToolStripMenuItem clientIDintegerToolStripMenuItem;
        private ToolStripTextBox toolStripTextBox8;
        private ToolStripMenuItem firstName50CharsToolStripMenuItem;
        private ToolStripTextBox toolStripTextBox9;
        private ToolStripMenuItem lastName50CharsToolStripMenuItem;
        private ToolStripTextBox toolStripTextBox10;
        private ToolStripMenuItem postalCode5DigitsToolStripMenuItem;
        private ToolStripTextBox toolStripTextBox11;
        private ToolStripMenuItem phoneNumber10DigitsToolStripMenuItem;
        private ToolStripMenuItem email320CharsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem toolStripMenuItem6;
        private ToolStripMenuItem toolStripMenuItem7;
        private ToolStripTextBox toolStripTextBox12;
        private ToolStripTextBox toolStripTextBox13;
        private ToolStripTextBox toolStripTextBox14;
    }
}
