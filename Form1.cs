using MQTTnet;
using MQTTnet.Client;
using DiscordRPC;
using DiscordRPC.Logging;
using Newtonsoft.Json;
using MQTTnet.Extensions.ManagedClient;
using System.Diagnostics;
using DiscordRPMQTTC_.Properties;
using Microsoft.Toolkit.Uwp.Notifications;
using System.Configuration.Internal;
using System.Drawing.Text;





namespace DiscordRPMQTTC_
{

    public partial class Form1 : Form
    {
        public DiscordRpcClient rpcClient;
        public MqttFactory Factory = new MqttFactory();
        public bool SettingSaved = false;
        public string MQTTBaseTopic = "tautulli/playing_notifications/";
        public bool MQTTCleanClosed = false;
        public string FinalTopic = "";
        public IManagedMqttClient mqclient;
        public ManagedMqttClientOptions mqclientOps;
        public DiscordRPC.RichPresence PresenceActivity;
        public ToolTipIcon CustomIcon;
        public Form1()

        {

            // Create a new MQTT client.
            PresenceActivity = UpdatePresence("Connecting...", "Connecting...", "icon", "Plexamp", "state_connected");
            InitializeComponent();
            DiscordRPC.DiscordRpcClient rpcClient = new("1257773567580573696");

        }
        
        void disableControls()
        {
            txt_mqtt_broker.Enabled = false;
            txt_mqtt_user.Enabled = false;
            txt_mqtt_password.Enabled = false;
            txt_Pdevice.Enabled = false;
            txt_Puser.Enabled = false;
            BtnStop.Enabled = true;
            btnStart.Enabled = false;

        }
        void enableControls()
        {
            txt_mqtt_broker.Enabled = true;
            txt_mqtt_user.Enabled = true;
            txt_mqtt_password.Enabled = true;
            txt_Pdevice.Enabled = true;
            txt_Puser.Enabled = true;
            BtnStop.Enabled = false;
            btnStart.Enabled = true;
            
        }

        [Obsolete]
        private async void btnStart_Click(object sender, EventArgs e)
        {
            var clientID = GenClientID();
            Lbl_Status.Text = "Starting MQTT Client";
            ShowBallon("Info", "Starting MQTT Client", "infoIcon");
            if (ValidateFormValues())
            {
                mqclient = Factory.CreateManagedMqttClient();
                mqclient.ApplicationMessageReceivedAsync += e =>
                {
                    string msg = System.Text.Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
                    ParseMQTTMessage(msg);
                    return Task.CompletedTask;
                };
                mqclient.ConnectedAsync += e =>
                {
                    ShowBallon("Info", "Connected to MQTT Broker", "infoIcon");
                    Lbl_Status.Text = "Connected to MQTT Broker";

                    return Task.CompletedTask;
                };
                mqclient.ConnectingFailedAsync += e =>
                {
                    ShowBallon("Info", "Error connecting to MQTT Broker", "infoIcon");
                    Lbl_Status.Text = "Error connecting to MQTT Broker";
                    return Task.CompletedTask;

                };

                if (chkTCP.Checked)
                {
                    if (chkTLS.Checked)
                    {
                        mqclientOps = new ManagedMqttClientOptionsBuilder()
                            .WithAutoReconnectDelay(TimeSpan.FromSeconds(5))
                            .WithClientOptions(
                            new MqttClientOptionsBuilder()
                            .WithTcpServer(txt_mqtt_broker.Text)
                            .WithProtocolVersion(MQTTnet.Formatter.MqttProtocolVersion.V500)
                            .WithCredentials(txt_mqtt_user.Text, txt_mqtt_password.Text)
                            .WithCleanSession()
                            .WithClientId(clientID)
                            .WithTlsOptions(o => o.WithCertificateValidationHandler(_ => true))
                            )
                            .Build();
                    }
                    else
                    {
                        mqclientOps = new ManagedMqttClientOptionsBuilder()
                            .WithAutoReconnectDelay(TimeSpan.FromSeconds(5))
                            .WithClientOptions(new MqttClientOptionsBuilder()
                        .WithTcpServer(txt_mqtt_broker.Text)
                        .WithProtocolVersion(MQTTnet.Formatter.MqttProtocolVersion.V500)
                        .WithCredentials(txt_mqtt_user.Text, txt_mqtt_password.Text)
                        .WithCleanSession()
                        .WithClientId(clientID)
                        )
                        .Build();
                    }
                }
                if (chkWSS.Checked)
                {
                    if (chkTLS.Checked)
                    {
                        mqclientOps = new ManagedMqttClientOptionsBuilder()
                            .WithAutoReconnectDelay(TimeSpan.FromSeconds(5))
                            .WithClientOptions(new MqttClientOptionsBuilder()
                            .WithWebSocketServer(o => o.WithUri(txt_mqtt_broker.Text))
                            .WithProtocolVersion(MQTTnet.Formatter.MqttProtocolVersion.V500)
                            .WithCredentials(txt_mqtt_user.Text, txt_mqtt_password.Text)
                            .WithCleanSession()
                            .WithClientId(clientID)
                            .WithTlsOptions(o => o.WithCertificateValidationHandler(_ => true))
                            )
                            .Build();
                    }
                    else
                    {
                        mqclientOps = new ManagedMqttClientOptionsBuilder()
                            .WithAutoReconnectDelay(TimeSpan.FromSeconds(5))
                            .WithClientOptions(new MqttClientOptionsBuilder()
                            .WithWebSocketServer(o => o.WithUri(txt_mqtt_broker.Text))
                            .WithProtocolVersion(MQTTnet.Formatter.MqttProtocolVersion.V500)
                            .WithCredentials(txt_mqtt_user.Text, txt_mqtt_password.Text)
                            .WithCleanSession()
                            .WithClientId(clientID))
                            .Build();
                    }
                }
                await mqclient.StartAsync(mqclientOps);
                await mqclient.SubscribeAsync(MQTTBaseTopic + txt_Puser.Text + "/" + txt_Pdevice.Text + "/track");
                disableControls();
            }
            else
            {
                MessageBox.Show("Please fill out all required fields", "Warning", MessageBoxButtons.OK);
            }


        }

        private static void upgradeApplicationSettingsIfNecessary()
        {
            // Application settings are stored in a subfolder named after the full #.#.#.# version number of the program. This means that when a new version of the program is installed, the old settings will not be available.
            // Fortunately, there's a method called Upgrade() that you can call to upgrade the settings from the old to the new folder.
            // We control when to do this by having a boolean setting called 'NeedSettingsUpgrade' which is defaulted to true. Therefore, the first time a new version of this program is run, it will have its default value of true.
            // This will cause the code below to call "Upgrade()" which copies the old settings to the new.
            // It then sets "NeedSettingsUpgrade" to false so the upgrade won't be done the next time.

            if (Settings.Default.NeedSettingsUpgrade)
            {
                Settings.Default.Upgrade();
                Settings.Default.NeedSettingsUpgrade = false;
                Settings.Default.Save();
            }
        }

        private async void BtnStop_Click(object sender, EventArgs e)
        {
            
            Lbl_Status.Text = "Disconnecting...";
            ShowBallon("Info", "Disconnecting..", "infoIcon");
            await mqclient.UnsubscribeAsync(MQTTBaseTopic + txt_Puser.Text + "/" + txt_Pdevice.Text + "/track");
            Lbl_Status.Text = "Disconnected!";
            ShowBallon("Info", "Disconnected!", "infoIcon");
            await mqclient.StopAsync();
            enableControls();
        }

        public void ShowBallon(string Title, string TipText,string icon )
        {
                if (this.WindowState == System.Windows.Forms.FormWindowState.Minimized || chkNotifications.Checked) { 
                Uri logouri; 
                if (icon == "infoIcon")
                {
                    logouri = new Uri("file://" + Path.GetFullPath(Application.StartupPath) + "/Resources/infoicon.png");
                } else
                {
                    logouri = new Uri(icon);
                }
                new ToastContentBuilder()
                    .AddAppLogoOverride(logouri)
                    .AddText(Title)
                    .AddText(TipText)
                    .Show();
            }
        }

        public Boolean ValidateFormValues()
        {
            Boolean result = true;
            if (String.IsNullOrEmpty(txt_mqtt_broker.Text))
            {
                result = false;
            }
            if (String.IsNullOrEmpty(txt_mqtt_user.Text))
            {
                result = false;
            }
            if (String.IsNullOrEmpty(txt_mqtt_password.Text))
            {
                result = false;
            }
            if (String.IsNullOrEmpty(txt_Pdevice.Text))
            {
                result = false;
            }
            if (String.IsNullOrEmpty(txt_Puser.Text))
            {
                result = false;
            }

            return result;
        }

        public static RichPresence UpdatePresence(string Detais, string State, string LGImgKey, string LGImgText, string SMImgKey)
        {
            var presense = new RichPresence()
            {
                Details = Detais,
                State = State,
                Assets = new Assets()
                {
                    LargeImageKey = LGImgKey,
                    LargeImageText = LGImgText,
                    SmallImageKey = SMImgKey
                }
            };

            return presense;
        }
        void LoadSettings()
        {
            
            if (String.IsNullOrEmpty(Properties.Settings.Default.MQTT_Broker) == false)
            {
                txt_mqtt_broker.Text = Properties.Settings.Default.MQTT_Broker;
            }
            if (String.IsNullOrEmpty(Properties.Settings.Default.MQTT_Username) == false)
            {
                txt_mqtt_user.Text = Properties.Settings.Default.MQTT_Username;
            }
            if (String.IsNullOrEmpty(Properties.Settings.Default.MQTT_Password) == false)
            {
                txt_mqtt_password.Text = Properties.Settings.Default.MQTT_Password;
            }
            if (String.IsNullOrEmpty(Properties.Settings.Default.PUser) == false)

                txt_Puser.Text = Properties.Settings.Default.PUser;

            if (String.IsNullOrEmpty(Properties.Settings.Default.PDevice) == false)
            {
                txt_Pdevice.Text = Properties.Settings.Default.PDevice;
            }
            chkTCP.Checked = Properties.Settings.Default.TCP_Checked;
            chkWSS.Checked = Properties.Settings.Default.WSS_Checked;
            chkTLS.Checked = Properties.Settings.Default.TLS_Checked;
            chkNotifications.Checked = Properties.Settings.Default.Show_Notifications;
            chkRunMinimised.Checked = Properties.Settings.Default.Start_Minimized;

        }


        private void Form1_Load(object sender, EventArgs e)
            
        {
            upgradeApplicationSettingsIfNecessary();
            Lbl_Status.Text = "Welcome!";
            //remove this before publish


            LoadSettings();
            RpcInitialize();
            if (Properties.Settings.Default.Start_Minimized == true)
            {
                this.Hide();
                SystemTrayManager.Visible = true;
                ShowBallon("Info", "Running in the system Tray", "infoIcon");

                btnStart_Click(sender, new EventArgs());

            }

        }

        private void RpcInitialize()
        {
            rpcClient = new DiscordRpcClient("1257773567580573696");
            rpcClient.Logger = new DiscordRPC.Logging.ConsoleLogger()
            {
                Level = DiscordRPC.Logging.LogLevel.Warning
            };
            rpcClient.Initialize();
            rpcClient.SetPresence(PresenceActivity);
            TimerRPCUpdate.Enabled = true;
        }


        private void UpdateSettings()
        {
            if (Properties.Settings.Default.MQTT_Broker != txt_mqtt_broker.Text)
            {
                Properties.Settings.Default.MQTT_Broker = txt_mqtt_broker.Text;
            }
            if (Properties.Settings.Default.MQTT_Username != txt_mqtt_user.Text)
            {
                Properties.Settings.Default.MQTT_Username = txt_mqtt_user.Text;
            }
            if (Properties.Settings.Default.MQTT_Password != txt_mqtt_password.Text)
            {
                Properties.Settings.Default.MQTT_Password = txt_mqtt_password.Text;
            }
            if (Properties.Settings.Default.PUser != txt_Pdevice.Text)
            {
                Properties.Settings.Default.PUser = txt_Puser.Text;
            }
            if (Properties.Settings.Default.PDevice != txt_Pdevice.Text)
            {
                Properties.Settings.Default.PDevice = txt_Pdevice.Text;
            }
            Properties.Settings.Default.TCP_Checked = chkTCP.Checked;
            Properties.Settings.Default.WSS_Checked = chkWSS.Checked;
            Properties.Settings.Default.TLS_Checked = chkTLS.Checked;
            Properties.Settings.Default.Start_Minimized = chkRunMinimised.Checked;
            Properties.Settings.Default.Show_Notifications = chkNotifications.Checked;
            Properties.Settings.Default.Save();
        }

        public void UpdateUIText(string Track, string Artist, string Album, string PosterURl)
        {
            
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(() =>
                {
                    this.Text = Track + " - " + Artist;
                }));
            }




            if (LblTrack.InvokeRequired)
            {
                LblTrack.BeginInvoke(new MethodInvoker(() =>
                {
                    LblTrack.Text = Track;
                }));
            }
            if (LblArtist.InvokeRequired)
            {
                LblArtist.BeginInvoke(new MethodInvoker(() =>
                {
                    LblArtist.Text = Artist;
                }));
            }
            if (LblAlbum.InvokeRequired)
            {
                LblAlbum.BeginInvoke(new MethodInvoker(() =>
                {
                    LblAlbum.Text = Album;
                }));
            }

            System.Net.WebClient MyWebClient = new System.Net.WebClient();
            byte[] ImageInBytes = MyWebClient.DownloadData(PosterURl);
            System.IO.MemoryStream ImageStream = new System.IO.MemoryStream(ImageInBytes);
            Bitmap ImageOut = new System.Drawing.Bitmap(ImageStream);
            if (PBPosterImg.InvokeRequired)
            {
                PBPosterImg.BeginInvoke(new MethodInvoker(() =>
                {
                    PBPosterImg.BackgroundImage = ImageOut;
                }));
            }
            ShowBallon(Track + " - " + Artist, Album, PosterURl);
            MyWebClient.Dispose();
        }

        public void ParseMQTTMessage(string Message)
        {
            NowPlayingInfo MSGJSON = JsonConvert.DeserializeObject<NowPlayingInfo>(Message);
            ParseToRPC(MSGJSON);

        }

        public string GenClientID()
        {
            var Prefix = "vbDiscordRPC";
            var OGUID = Guid.NewGuid().ToString();
            var OGUIDSplit = OGUID.Split("-");
            var Postfix = OGUIDSplit[0] + OGUIDSplit[2];
            var hostname = Environment.MachineName;
            string FinalClientID = Prefix + "_" + hostname + "_" + Postfix;
            // Debug.WriteLine(FinalClientID)
            return FinalClientID;
        }

        public void ParseToRPC(NowPlayingInfo Data)
        {
            var state = "state_" + Data.body.action;
            UpdateUIText(Data.body.track_name, Data.body.track_artist, Data.body.album_name, Data.body.poster_url);
            PresenceActivity = UpdatePresence(Data.body.title, Data.body.album_name, Data.body.poster_url, Data.body.title + " on " + Data.body.album_name, state);
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            e.Cancel = true;
            UpdateSettings();
            e.Cancel = false;

        }

        private void TimerRPCUpdate_Tick(object sender, EventArgs e)
        {
            rpcClient.SetPresence(PresenceActivity);
        }

        private void chkTCP_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTCP.Checked)
            {
                chkWSS.Checked = false;
            }
            else
            {
                chkWSS.Checked = true;
            }
        }

        private void chkWSS_CheckedChanged(object sender, EventArgs e)
        {
            if (chkWSS.Checked)
            {
                chkTCP.Checked = false;
            }
            else
            {
                chkTCP.Checked = true;
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();

            }
        }

        private void SystemTrayManager_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;

        }

        private void SystemTrayManager_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;

        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Start_Minimized == true)
            {
                this.Hide();

            }
        }
    }
}
