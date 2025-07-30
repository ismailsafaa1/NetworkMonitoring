namespace NetworkMonitoring
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.picCamera = new System.Windows.Forms.PictureBox();
            this.picDesktop = new System.Windows.Forms.PictureBox();
            this.picTelephone = new System.Windows.Forms.PictureBox();
            this.picRouter = new System.Windows.Forms.PictureBox();
            this.picAP = new System.Windows.Forms.PictureBox();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCamera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDesktop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTelephone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRouter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAP)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(141, 380);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 32);
            this.label2.TabIndex = 16;
            this.label2.Text = "PC";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(957, 513);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 32);
            this.label1.TabIndex = 15;
            this.label1.Text = "Laptop";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(950, 436);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(101, 74);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // picCamera
            // 
            this.picCamera.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picCamera.Image = ((System.Drawing.Image)(resources.GetObject("picCamera.Image")));
            this.picCamera.Location = new System.Drawing.Point(42, 44);
            this.picCamera.Name = "picCamera";
            this.picCamera.Size = new System.Drawing.Size(82, 100);
            this.picCamera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCamera.TabIndex = 9;
            this.picCamera.TabStop = false;
            // 
            // picDesktop
            // 
            this.picDesktop.BackColor = System.Drawing.Color.White;
            this.picDesktop.Location = new System.Drawing.Point(117, 318);
            this.picDesktop.Name = "picDesktop";
            this.picDesktop.Size = new System.Drawing.Size(92, 59);
            this.picDesktop.TabIndex = 10;
            this.picDesktop.TabStop = false;
            // 
            // picTelephone
            // 
            this.picTelephone.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picTelephone.Image = ((System.Drawing.Image)(resources.GetObject("picTelephone.Image")));
            this.picTelephone.Location = new System.Drawing.Point(623, 419);
            this.picTelephone.Name = "picTelephone";
            this.picTelephone.Size = new System.Drawing.Size(94, 78);
            this.picTelephone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picTelephone.TabIndex = 11;
            this.picTelephone.TabStop = false;
            // 
            // picRouter
            // 
            this.picRouter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picRouter.Image = ((System.Drawing.Image)(resources.GetObject("picRouter.Image")));
            this.picRouter.Location = new System.Drawing.Point(351, 256);
            this.picRouter.Name = "picRouter";
            this.picRouter.Size = new System.Drawing.Size(67, 57);
            this.picRouter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picRouter.TabIndex = 12;
            this.picRouter.TabStop = false;
            // 
            // picAP
            // 
            this.picAP.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picAP.Image = ((System.Drawing.Image)(resources.GetObject("picAP.Image")));
            this.picAP.Location = new System.Drawing.Point(885, 157);
            this.picAP.Name = "picAP";
            this.picAP.Size = new System.Drawing.Size(82, 96);
            this.picAP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAP.TabIndex = 13;
            this.picAP.TabStop = false;
            // 
            // timer2
            // 
            this.timer2.Interval = 5000;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImage = global::NetworkMonitoring.Properties.Resources.photo_2025_04_10_16_49_33;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1063, 613);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.picAP);
            this.Controls.Add(this.picRouter);
            this.Controls.Add(this.picTelephone);
            this.Controls.Add(this.picDesktop);
            this.Controls.Add(this.picCamera);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCamera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDesktop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTelephone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRouter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox picCamera;
        private System.Windows.Forms.PictureBox picDesktop;
        private System.Windows.Forms.PictureBox picTelephone;
        private System.Windows.Forms.PictureBox picRouter;
        private System.Windows.Forms.PictureBox picAP;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Timer timer2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Timer timer1;
    }
}