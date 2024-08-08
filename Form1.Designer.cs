namespace DiscordRPMQTTC_
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            TimerRPCUpdate = new System.Windows.Forms.Timer(components);
            btnStart = new Button();
            LblAlbum = new Label();
            LblArtist = new Label();
            LblTrack = new Label();
            groupBox2 = new GroupBox();
            txt_Pdevice = new TextBox();
            Label4 = new Label();
            txt_Puser = new TextBox();
            Label3 = new Label();
            SystemTrayManager = new NotifyIcon(components);
            txt_mqtt_password = new TextBox();
            txt_mqtt_user = new TextBox();
            BtnStop = new Button();
            GroupBox1 = new GroupBox();
            chkRunMinimised = new CheckBox();
            chkTLS = new CheckBox();
            chkWSS = new CheckBox();
            chkTCP = new CheckBox();
            txt_mqtt_broker = new TextBox();
            Lbl_Username = new Label();
            Label2 = new Label();
            Label1 = new Label();
            Lbl_Status = new ToolStripStatusLabel();
            StatusStrip1 = new StatusStrip();
            PBPosterImg = new Panel();
            chkNotifications = new CheckBox();
            groupBox2.SuspendLayout();
            GroupBox1.SuspendLayout();
            StatusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // TimerRPCUpdate
            // 
            TimerRPCUpdate.Interval = 1000;
            TimerRPCUpdate.Tick += TimerRPCUpdate_Tick;
            // 
            // btnStart
            // 
            btnStart.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnStart.BackColor = Color.Gainsboro;
            btnStart.Cursor = Cursors.Hand;
            btnStart.FlatStyle = FlatStyle.System;
            btnStart.Location = new Point(6, 186);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(75, 23);
            btnStart.TabIndex = 11;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click;
            // 
            // LblAlbum
            // 
            LblAlbum.Font = new Font("0xProto Nerd Font", 9.749999F);
            LblAlbum.Location = new Point(6, 183);
            LblAlbum.Name = "LblAlbum";
            LblAlbum.Size = new Size(269, 19);
            LblAlbum.TabIndex = 12;
            LblAlbum.Text = "Album";
            LblAlbum.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LblArtist
            // 
            LblArtist.Font = new Font("0xProto Nerd Font", 9.749999F);
            LblArtist.Location = new Point(6, 105);
            LblArtist.Name = "LblArtist";
            LblArtist.Size = new Size(269, 18);
            LblArtist.TabIndex = 11;
            LblArtist.Text = "Artist";
            LblArtist.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LblTrack
            // 
            LblTrack.Font = new Font("0xProto Nerd Font", 9.749999F);
            LblTrack.Location = new Point(6, 25);
            LblTrack.Name = "LblTrack";
            LblTrack.Size = new Size(269, 20);
            LblTrack.TabIndex = 10;
            LblTrack.Text = "Track";
            LblTrack.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox2.BackColor = Color.Transparent;
            groupBox2.Controls.Add(LblAlbum);
            groupBox2.Controls.Add(LblTrack);
            groupBox2.Controls.Add(LblArtist);
            groupBox2.FlatStyle = FlatStyle.Flat;
            groupBox2.ForeColor = SystemColors.ControlLight;
            groupBox2.Location = new Point(280, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(281, 223);
            groupBox2.TabIndex = 13;
            groupBox2.TabStop = false;
            // 
            // txt_Pdevice
            // 
            txt_Pdevice.BackColor = Color.Gainsboro;
            txt_Pdevice.BorderStyle = BorderStyle.FixedSingle;
            txt_Pdevice.Cursor = Cursors.IBeam;
            txt_Pdevice.Font = new Font("0xProto Nerd Font", 9F);
            txt_Pdevice.Location = new Point(128, 133);
            txt_Pdevice.Name = "txt_Pdevice";
            txt_Pdevice.Size = new Size(112, 22);
            txt_Pdevice.TabIndex = 9;
            // 
            // Label4
            // 
            Label4.AutoSize = true;
            Label4.Font = new Font("0xProto Nerd Font", 9.749999F);
            Label4.Location = new Point(6, 133);
            Label4.Name = "Label4";
            Label4.Size = new Size(95, 16);
            Label4.TabIndex = 8;
            Label4.Text = "Plex Device";
            // 
            // txt_Puser
            // 
            txt_Puser.BackColor = Color.Gainsboro;
            txt_Puser.BorderStyle = BorderStyle.FixedSingle;
            txt_Puser.Cursor = Cursors.IBeam;
            txt_Puser.Font = new Font("0xProto Nerd Font", 9F);
            txt_Puser.Location = new Point(128, 101);
            txt_Puser.Name = "txt_Puser";
            txt_Puser.Size = new Size(112, 22);
            txt_Puser.TabIndex = 7;
            // 
            // Label3
            // 
            Label3.AutoSize = true;
            Label3.Font = new Font("0xProto Nerd Font", 9.749999F);
            Label3.Location = new Point(6, 107);
            Label3.Name = "Label3";
            Label3.Size = new Size(111, 16);
            Label3.TabIndex = 6;
            Label3.Text = "Plex Username";
            // 
            // SystemTrayManager
            // 
            SystemTrayManager.Icon = (Icon)resources.GetObject("SystemTrayManager.Icon");
            SystemTrayManager.Text = "DiscordMQTTRPC";
            SystemTrayManager.Visible = true;
            SystemTrayManager.Click += SystemTrayManager_Click;
            SystemTrayManager.MouseDoubleClick += SystemTrayManager_MouseDoubleClick;
            // 
            // txt_mqtt_password
            // 
            txt_mqtt_password.BackColor = Color.Gainsboro;
            txt_mqtt_password.BorderStyle = BorderStyle.FixedSingle;
            txt_mqtt_password.Font = new Font("0xProto Nerd Font", 9F);
            txt_mqtt_password.Location = new Point(128, 73);
            txt_mqtt_password.Name = "txt_mqtt_password";
            txt_mqtt_password.PasswordChar = '*';
            txt_mqtt_password.Size = new Size(112, 22);
            txt_mqtt_password.TabIndex = 5;
            // 
            // txt_mqtt_user
            // 
            txt_mqtt_user.BackColor = Color.Gainsboro;
            txt_mqtt_user.BorderStyle = BorderStyle.FixedSingle;
            txt_mqtt_user.Font = new Font("0xProto Nerd Font", 9F);
            txt_mqtt_user.Location = new Point(128, 45);
            txt_mqtt_user.Name = "txt_mqtt_user";
            txt_mqtt_user.Size = new Size(112, 22);
            txt_mqtt_user.TabIndex = 4;
            // 
            // BtnStop
            // 
            BtnStop.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            BtnStop.BackColor = Color.Gainsboro;
            BtnStop.Cursor = Cursors.Hand;
            BtnStop.Enabled = false;
            BtnStop.FlatStyle = FlatStyle.System;
            BtnStop.ForeColor = SystemColors.ControlLight;
            BtnStop.Location = new Point(87, 186);
            BtnStop.Name = "BtnStop";
            BtnStop.Size = new Size(75, 23);
            BtnStop.TabIndex = 12;
            BtnStop.Text = "Stop";
            BtnStop.UseVisualStyleBackColor = false;
            BtnStop.Click += BtnStop_Click;
            // 
            // GroupBox1
            // 
            GroupBox1.BackColor = Color.Transparent;
            GroupBox1.Controls.Add(chkNotifications);
            GroupBox1.Controls.Add(chkRunMinimised);
            GroupBox1.Controls.Add(btnStart);
            GroupBox1.Controls.Add(BtnStop);
            GroupBox1.Controls.Add(chkTLS);
            GroupBox1.Controls.Add(chkWSS);
            GroupBox1.Controls.Add(chkTCP);
            GroupBox1.Controls.Add(txt_Pdevice);
            GroupBox1.Controls.Add(Label4);
            GroupBox1.Controls.Add(txt_Puser);
            GroupBox1.Controls.Add(Label3);
            GroupBox1.Controls.Add(txt_mqtt_password);
            GroupBox1.Controls.Add(txt_mqtt_user);
            GroupBox1.Controls.Add(txt_mqtt_broker);
            GroupBox1.Controls.Add(Lbl_Username);
            GroupBox1.Controls.Add(Label2);
            GroupBox1.Controls.Add(Label1);
            GroupBox1.FlatStyle = FlatStyle.Flat;
            GroupBox1.ForeColor = SystemColors.ControlLight;
            GroupBox1.Location = new Point(12, 4);
            GroupBox1.Name = "GroupBox1";
            GroupBox1.Size = new Size(262, 223);
            GroupBox1.TabIndex = 9;
            GroupBox1.TabStop = false;
            GroupBox1.Text = "Settings";
            // 
            // chkRunMinimised
            // 
            chkRunMinimised.AutoSize = true;
            chkRunMinimised.Location = new Point(146, 161);
            chkRunMinimised.Name = "chkRunMinimised";
            chkRunMinimised.Size = new Size(109, 19);
            chkRunMinimised.TabIndex = 13;
            chkRunMinimised.Text = "Start Minimised";
            chkRunMinimised.UseVisualStyleBackColor = true;
            // 
            // chkTLS
            // 
            chkTLS.AutoSize = true;
            chkTLS.Location = new Point(101, 161);
            chkTLS.Name = "chkTLS";
            chkTLS.Size = new Size(44, 19);
            chkTLS.TabIndex = 12;
            chkTLS.Text = "TLS";
            chkTLS.UseVisualStyleBackColor = true;
            // 
            // chkWSS
            // 
            chkWSS.AutoSize = true;
            chkWSS.Location = new Point(52, 161);
            chkWSS.Name = "chkWSS";
            chkWSS.Size = new Size(49, 19);
            chkWSS.TabIndex = 11;
            chkWSS.Text = "WSS";
            chkWSS.UseVisualStyleBackColor = true;
            chkWSS.CheckedChanged += chkWSS_CheckedChanged;
            // 
            // chkTCP
            // 
            chkTCP.AutoSize = true;
            chkTCP.Checked = true;
            chkTCP.CheckState = CheckState.Checked;
            chkTCP.Location = new Point(6, 161);
            chkTCP.Name = "chkTCP";
            chkTCP.Size = new Size(46, 19);
            chkTCP.TabIndex = 10;
            chkTCP.Text = "TCP";
            chkTCP.UseVisualStyleBackColor = true;
            chkTCP.CheckedChanged += chkTCP_CheckedChanged;
            // 
            // txt_mqtt_broker
            // 
            txt_mqtt_broker.BackColor = Color.Gainsboro;
            txt_mqtt_broker.BorderStyle = BorderStyle.FixedSingle;
            txt_mqtt_broker.Cursor = Cursors.IBeam;
            txt_mqtt_broker.Font = new Font("0xProto Nerd Font", 9F);
            txt_mqtt_broker.Location = new Point(128, 17);
            txt_mqtt_broker.Name = "txt_mqtt_broker";
            txt_mqtt_broker.Size = new Size(112, 22);
            txt_mqtt_broker.TabIndex = 3;
            // 
            // Lbl_Username
            // 
            Lbl_Username.AutoSize = true;
            Lbl_Username.Font = new Font("0xProto Nerd Font", 9.749999F);
            Lbl_Username.Location = new Point(6, 23);
            Lbl_Username.Name = "Lbl_Username";
            Lbl_Username.Size = new Size(95, 16);
            Lbl_Username.TabIndex = 2;
            Lbl_Username.Text = "MQTT Broker";
            // 
            // Label2
            // 
            Label2.AutoSize = true;
            Label2.Font = new Font("0xProto Nerd Font", 9.749999F);
            Label2.Location = new Point(6, 79);
            Label2.Name = "Label2";
            Label2.Size = new Size(111, 16);
            Label2.TabIndex = 2;
            Label2.Text = "MQTT Password";
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Font = new Font("0xProto Nerd Font", 9.749999F);
            Label1.Location = new Point(6, 51);
            Label1.Name = "Label1";
            Label1.Size = new Size(111, 16);
            Label1.TabIndex = 2;
            Label1.Text = "MQTT Username";
            // 
            // Lbl_Status
            // 
            Lbl_Status.Name = "Lbl_Status";
            Lbl_Status.Size = new Size(0, 17);
            // 
            // StatusStrip1
            // 
            StatusStrip1.Items.AddRange(new ToolStripItem[] { Lbl_Status });
            StatusStrip1.Location = new Point(0, 567);
            StatusStrip1.Name = "StatusStrip1";
            StatusStrip1.RenderMode = ToolStripRenderMode.Professional;
            StatusStrip1.Size = new Size(573, 22);
            StatusStrip1.TabIndex = 8;
            StatusStrip1.Text = "StatusStrip1";
            // 
            // PBPosterImg
            // 
            PBPosterImg.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            PBPosterImg.BackgroundImage = Properties.Resources.unnamed;
            PBPosterImg.BackgroundImageLayout = ImageLayout.Zoom;
            PBPosterImg.Location = new Point(12, 233);
            PBPosterImg.Name = "PBPosterImg";
            PBPosterImg.Size = new Size(549, 331);
            PBPosterImg.TabIndex = 14;
            // 
            // chkNotifications
            // 
            chkNotifications.AutoSize = true;
            chkNotifications.Location = new Point(168, 189);
            chkNotifications.Name = "chkNotifications";
            chkNotifications.Size = new Size(94, 19);
            chkNotifications.TabIndex = 14;
            chkNotifications.Text = "Notifications";
            chkNotifications.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DimGray;
            ClientSize = new Size(573, 589);
            Controls.Add(PBPosterImg);
            Controls.Add(groupBox2);
            Controls.Add(GroupBox1);
            Controls.Add(StatusStrip1);
            ForeColor = SystemColors.ControlLight;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(589, 628);
            Name = "Form1";
            Text = "Discord RPC";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            Shown += Form1_Shown;
            Resize += Form1_Resize;
            groupBox2.ResumeLayout(false);
            GroupBox1.ResumeLayout(false);
            GroupBox1.PerformLayout();
            StatusStrip1.ResumeLayout(false);
            StatusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        internal System.Windows.Forms.Timer TimerRPCUpdate;
        internal Button btnStart;
        internal Label LblAlbum;
        internal Label LblArtist;
        internal Label LblTrack;
        internal TextBox txt_Pdevice;
        internal Label Label4;
        internal TextBox txt_Puser;
        internal Label Label3;
        internal NotifyIcon SystemTrayManager;
        internal TextBox txt_mqtt_password;
        internal TextBox txt_mqtt_user;
        internal Button BtnStop;
        internal GroupBox GroupBox1;
        internal TextBox txt_mqtt_broker;
        internal Label Lbl_Username;
        internal Label Label2;
        internal Label Label1;
        internal ToolStripStatusLabel Lbl_Status;
        internal StatusStrip StatusStrip1;
        private CheckBox chkTLS;
        private CheckBox chkWSS;
        private CheckBox chkTCP;
        private CheckBox chkRunMinimised;
        private GroupBox groupBox2;
        private Panel PBPosterImg;
        private CheckBox chkNotifications;
    }
}