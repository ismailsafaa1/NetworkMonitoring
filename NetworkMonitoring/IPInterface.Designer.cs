namespace NetworkMonitoring
{
    partial class IPInterface
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IPInterface));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.guna2ComboBox1 = new Guna.UI2.WinForms.Guna2ComboBox();
            this.textIPaddress = new Guna.UI2.WinForms.Guna2TextBox();
            this.textSubnetMask = new Guna.UI2.WinForms.Guna2TextBox();
            this.textDafaultGetway = new Guna.UI2.WinForms.Guna2TextBox();
            this.textPrimayDns = new Guna.UI2.WinForms.Guna2TextBox();
            this.textSecondDns = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSataic = new Guna.UI2.WinForms.Guna2Button();
            this.btnDhcp = new Guna.UI2.WinForms.Guna2Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(980, 55);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(902, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 55);
            this.button1.TabIndex = 1;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // guna2ComboBox1
            // 
            this.guna2ComboBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ComboBox1.BorderRadius = 9;
            this.guna2ComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.guna2ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.guna2ComboBox1.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2ComboBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2ComboBox1.Font = new System.Drawing.Font("Yu Gothic UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2ComboBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.guna2ComboBox1.ItemHeight = 30;
            this.guna2ComboBox1.Location = new System.Drawing.Point(312, 116);
            this.guna2ComboBox1.Name = "guna2ComboBox1";
            this.guna2ComboBox1.Size = new System.Drawing.Size(341, 36);
            this.guna2ComboBox1.TabIndex = 4;
            // 
            // textIPaddress
            // 
            this.textIPaddress.BackColor = System.Drawing.Color.Cornsilk;
            this.textIPaddress.BorderRadius = 9;
            this.textIPaddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textIPaddress.DefaultText = "";
            this.textIPaddress.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textIPaddress.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textIPaddress.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textIPaddress.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textIPaddress.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textIPaddress.Font = new System.Drawing.Font("Yu Gothic UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textIPaddress.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textIPaddress.Location = new System.Drawing.Point(312, 195);
            this.textIPaddress.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.textIPaddress.Name = "textIPaddress";
            this.textIPaddress.PasswordChar = '\0';
            this.textIPaddress.PlaceholderText = "";
            this.textIPaddress.SelectedText = "";
            this.textIPaddress.Size = new System.Drawing.Size(522, 56);
            this.textIPaddress.TabIndex = 5;
            // 
            // textSubnetMask
            // 
            this.textSubnetMask.BackColor = System.Drawing.Color.Cornsilk;
            this.textSubnetMask.BorderRadius = 9;
            this.textSubnetMask.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textSubnetMask.DefaultText = "";
            this.textSubnetMask.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textSubnetMask.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textSubnetMask.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textSubnetMask.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textSubnetMask.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textSubnetMask.Font = new System.Drawing.Font("Yu Gothic UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textSubnetMask.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textSubnetMask.Location = new System.Drawing.Point(312, 263);
            this.textSubnetMask.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.textSubnetMask.Name = "textSubnetMask";
            this.textSubnetMask.PasswordChar = '\0';
            this.textSubnetMask.PlaceholderText = "";
            this.textSubnetMask.SelectedText = "";
            this.textSubnetMask.Size = new System.Drawing.Size(522, 56);
            this.textSubnetMask.TabIndex = 6;
            // 
            // textDafaultGetway
            // 
            this.textDafaultGetway.BackColor = System.Drawing.Color.Cornsilk;
            this.textDafaultGetway.BorderRadius = 9;
            this.textDafaultGetway.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textDafaultGetway.DefaultText = "";
            this.textDafaultGetway.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textDafaultGetway.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textDafaultGetway.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textDafaultGetway.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textDafaultGetway.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textDafaultGetway.Font = new System.Drawing.Font("Yu Gothic UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textDafaultGetway.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textDafaultGetway.Location = new System.Drawing.Point(312, 329);
            this.textDafaultGetway.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.textDafaultGetway.Name = "textDafaultGetway";
            this.textDafaultGetway.PasswordChar = '\0';
            this.textDafaultGetway.PlaceholderText = "";
            this.textDafaultGetway.SelectedText = "";
            this.textDafaultGetway.Size = new System.Drawing.Size(522, 56);
            this.textDafaultGetway.TabIndex = 7;
            // 
            // textPrimayDns
            // 
            this.textPrimayDns.BackColor = System.Drawing.Color.Cornsilk;
            this.textPrimayDns.BorderRadius = 9;
            this.textPrimayDns.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textPrimayDns.DefaultText = "";
            this.textPrimayDns.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textPrimayDns.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textPrimayDns.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textPrimayDns.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textPrimayDns.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textPrimayDns.Font = new System.Drawing.Font("Yu Gothic UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textPrimayDns.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textPrimayDns.Location = new System.Drawing.Point(312, 401);
            this.textPrimayDns.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.textPrimayDns.Name = "textPrimayDns";
            this.textPrimayDns.PasswordChar = '\0';
            this.textPrimayDns.PlaceholderText = "";
            this.textPrimayDns.SelectedText = "";
            this.textPrimayDns.Size = new System.Drawing.Size(522, 56);
            this.textPrimayDns.TabIndex = 8;
            // 
            // textSecondDns
            // 
            this.textSecondDns.BackColor = System.Drawing.Color.Cornsilk;
            this.textSecondDns.BorderRadius = 9;
            this.textSecondDns.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textSecondDns.DefaultText = "";
            this.textSecondDns.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textSecondDns.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textSecondDns.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textSecondDns.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textSecondDns.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textSecondDns.Font = new System.Drawing.Font("Yu Gothic UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textSecondDns.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textSecondDns.Location = new System.Drawing.Point(312, 473);
            this.textSecondDns.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.textSecondDns.Name = "textSecondDns";
            this.textSecondDns.PasswordChar = '\0';
            this.textSecondDns.PlaceholderText = "";
            this.textSecondDns.SelectedText = "";
            this.textSecondDns.Size = new System.Drawing.Size(522, 56);
            this.textSecondDns.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(145, 196);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 38);
            this.label1.TabIndex = 10;
            this.label1.Text = "IP Address:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Yu Gothic UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(114, 277);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 38);
            this.label2.TabIndex = 11;
            this.label2.Text = "Subnet Mask:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Yu Gothic UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(83, 344);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(220, 38);
            this.label3.TabIndex = 12;
            this.label3.Text = "Dafault Getway:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Yu Gothic UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(118, 413);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(185, 38);
            this.label4.TabIndex = 13;
            this.label4.Text = "Primary DNS:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Yu Gothic UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(122, 486);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(181, 38);
            this.label5.TabIndex = 14;
            this.label5.Text = "Second DNS:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Yu Gothic UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(677, 114);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(169, 38);
            this.label6.TabIndex = 15;
            this.label6.Text = ":محول الشبكة";
            // 
            // btnSataic
            // 
            this.btnSataic.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSataic.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSataic.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSataic.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSataic.FillColor = System.Drawing.Color.White;
            this.btnSataic.Font = new System.Drawing.Font("Yu Gothic UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSataic.ForeColor = System.Drawing.Color.Black;
            this.btnSataic.Location = new System.Drawing.Point(610, 569);
            this.btnSataic.Name = "btnSataic";
            this.btnSataic.Size = new System.Drawing.Size(219, 77);
            this.btnSataic.TabIndex = 16;
            this.btnSataic.Text = "تعيين يدوي";
            this.btnSataic.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // btnDhcp
            // 
            this.btnDhcp.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDhcp.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDhcp.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDhcp.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDhcp.FillColor = System.Drawing.Color.White;
            this.btnDhcp.Font = new System.Drawing.Font("Yu Gothic UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDhcp.ForeColor = System.Drawing.Color.Black;
            this.btnDhcp.Location = new System.Drawing.Point(323, 569);
            this.btnDhcp.Name = "btnDhcp";
            this.btnDhcp.Size = new System.Drawing.Size(219, 77);
            this.btnDhcp.TabIndex = 17;
            this.btnDhcp.Text = "تعيين تلقائي";
            this.btnDhcp.Click += new System.EventHandler(this.btnDhcp_Click);
            // 
            // IPInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(980, 695);
            this.Controls.Add(this.btnDhcp);
            this.Controls.Add(this.btnSataic);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textSecondDns);
            this.Controls.Add(this.textPrimayDns);
            this.Controls.Add(this.textDafaultGetway);
            this.Controls.Add(this.textSubnetMask);
            this.Controls.Add(this.textIPaddress);
            this.Controls.Add(this.guna2ComboBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "IPInterface";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IPInterface";
            this.Load += new System.EventHandler(this.IPInterface_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private Guna.UI2.WinForms.Guna2ComboBox guna2ComboBox1;
        private Guna.UI2.WinForms.Guna2TextBox textIPaddress;
        private Guna.UI2.WinForms.Guna2TextBox textSubnetMask;
        private Guna.UI2.WinForms.Guna2TextBox textDafaultGetway;
        private Guna.UI2.WinForms.Guna2TextBox textPrimayDns;
        private Guna.UI2.WinForms.Guna2TextBox textSecondDns;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2Button btnSataic;
        private Guna.UI2.WinForms.Guna2Button btnDhcp;
    }
}