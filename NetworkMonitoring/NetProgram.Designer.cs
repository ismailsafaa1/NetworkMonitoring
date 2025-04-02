namespace NetworkMonitoring
{
    partial class NetProgram
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NetProgram));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.picSwi = new System.Windows.Forms.PictureBox();
            this.picFingerPoint = new System.Windows.Forms.PictureBox();
            this.picAP = new System.Windows.Forms.PictureBox();
            this.picRouter = new System.Windows.Forms.PictureBox();
            this.picTelephone = new System.Windows.Forms.PictureBox();
            this.picDesktop = new System.Windows.Forms.PictureBox();
            this.picCamera = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picSwi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFingerPoint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRouter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTelephone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDesktop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCamera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // timer2
            // 
            this.timer2.Interval = 5000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // picSwi
            // 
            this.picSwi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picSwi.Image = ((System.Drawing.Image)(resources.GetObject("picSwi.Image")));
            this.picSwi.Location = new System.Drawing.Point(125, 24);
            this.picSwi.Name = "picSwi";
            this.picSwi.Size = new System.Drawing.Size(106, 30);
            this.picSwi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSwi.TabIndex = 7;
            this.picSwi.TabStop = false;
            // 
            // picFingerPoint
            // 
            this.picFingerPoint.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picFingerPoint.Image = ((System.Drawing.Image)(resources.GetObject("picFingerPoint.Image")));
            this.picFingerPoint.Location = new System.Drawing.Point(8, 225);
            this.picFingerPoint.Name = "picFingerPoint";
            this.picFingerPoint.Size = new System.Drawing.Size(58, 60);
            this.picFingerPoint.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picFingerPoint.TabIndex = 6;
            this.picFingerPoint.TabStop = false;
            // 
            // picAP
            // 
            this.picAP.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picAP.Image = ((System.Drawing.Image)(resources.GetObject("picAP.Image")));
            this.picAP.Location = new System.Drawing.Point(1041, 488);
            this.picAP.Name = "picAP";
            this.picAP.Size = new System.Drawing.Size(82, 74);
            this.picAP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAP.TabIndex = 5;
            this.picAP.TabStop = false;
            // 
            // picRouter
            // 
            this.picRouter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picRouter.Image = ((System.Drawing.Image)(resources.GetObject("picRouter.Image")));
            this.picRouter.Location = new System.Drawing.Point(1077, 407);
            this.picRouter.Name = "picRouter";
            this.picRouter.Size = new System.Drawing.Size(46, 63);
            this.picRouter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picRouter.TabIndex = 4;
            this.picRouter.TabStop = false;
            // 
            // picTelephone
            // 
            this.picTelephone.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picTelephone.Image = ((System.Drawing.Image)(resources.GetObject("picTelephone.Image")));
            this.picTelephone.Location = new System.Drawing.Point(43, 415);
            this.picTelephone.Name = "picTelephone";
            this.picTelephone.Size = new System.Drawing.Size(53, 48);
            this.picTelephone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picTelephone.TabIndex = 3;
            this.picTelephone.TabStop = false;
            // 
            // picDesktop
            // 
            this.picDesktop.BackColor = System.Drawing.Color.White;
            this.picDesktop.Location = new System.Drawing.Point(88, 362);
            this.picDesktop.Name = "picDesktop";
            this.picDesktop.Size = new System.Drawing.Size(92, 59);
            this.picDesktop.TabIndex = 2;
            this.picDesktop.TabStop = false;
            // 
            // picCamera
            // 
            this.picCamera.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picCamera.Image = ((System.Drawing.Image)(resources.GetObject("picCamera.Image")));
            this.picCamera.Location = new System.Drawing.Point(1041, 6);
            this.picCamera.Name = "picCamera";
            this.picCamera.Size = new System.Drawing.Size(82, 100);
            this.picCamera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCamera.TabIndex = 1;
            this.picCamera.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1135, 574);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // NetProgram
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1135, 574);
            this.Controls.Add(this.picSwi);
            this.Controls.Add(this.picFingerPoint);
            this.Controls.Add(this.picAP);
            this.Controls.Add(this.picRouter);
            this.Controls.Add(this.picTelephone);
            this.Controls.Add(this.picDesktop);
            this.Controls.Add(this.picCamera);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "NetProgram";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Network Monitore";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picSwi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFingerPoint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRouter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTelephone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDesktop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCamera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox picCamera;
        private System.Windows.Forms.PictureBox picDesktop;
        private System.Windows.Forms.PictureBox picTelephone;
        private System.Windows.Forms.PictureBox picRouter;
        private System.Windows.Forms.PictureBox picAP;
        private System.Windows.Forms.PictureBox picFingerPoint;
        private System.Windows.Forms.PictureBox picSwi;
        private System.Windows.Forms.Timer timer1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
    }
}

