using System;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Diagnostics;
using System.Windows.Forms;
using Telegram.Bot;
using System.Threading.Tasks;
using System.IO.Pipes;
using System.Data.SqlClient;

namespace NetworkMonitoring
{
    public partial class NetProgram : Form
    {
        public NetProgram()
        {
            InitializeComponent();
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(this.picCamera, "CCTV-Account-192.168.1.1, Account Switch F a0/12");
        }
        string MessageAPup = "تم تشغيل الشبكة ";
        string IpAPup = "IP Address: 192.128.1.113";
        string DateTimeAPup = "وقت التشغيل = '" + DateTime.Now.ToString() + "'";

        string MessageAPDown = "تم ايقاف الشبكة ";
        string IpAPDown = "IP Address: 192.128.1.113";
        string DateTimeAPDown = "وقت التوقف = '" + DateTime.Now.ToString() + "'";

        private static string connectionString = "data source=DESKTOP-GE3H3SI; database=mastr; User Id=sa; Password=sa123456; integrated security=True";
        private static bool lastStatus = false; // لتتبع آخر حالة معروفة



        public async Task SendMessage(string destID, string Text)
        {
            try
            {
                var bot = new Telegram.Bot.TelegramBotClient("7273141592:AAGYJvKXyGunU_JeItXuc1Jni2YDbry4rjs");
                await bot.SendTextMessageAsync(destID, Text);

            } catch (Exception ex)
            {
                Console.WriteLine("Error");
            }
        }
      
        private void Form1_Load(object sender, EventArgs e)
        {
            SendMessage("2020938951", "Welcome to Network monjtor Program");

            // بدء المؤقتات
            timer1.Interval = 5000; // التحقق كل 5 ثوانٍ
            timer1.Tick += timer1_Tick;
            timer1.Start();

            timer2.Interval = 5000; // التحقق كل 5 ثوانٍ
            timer2.Tick += timer2_Tick;
            timer2.Start();

        }
        

        private void timer1_Tick(object sender, EventArgs e)
        {
          

            // تعطيل المؤقت مؤقتًا لتجنب التكرار
            timer1.Enabled = false;

            // تشغيل الخلفية إذا لم تكن تعمل بالفعل
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }

            // إعادة تمكين المؤقت
            timer1.Enabled = true;
        }


        private void timer2_Tick(object sender, EventArgs e)
        {
            CheckNetworkStatus();
        }

        private void CheckNetworkStatus()
        {
            try
            {
                Ping pingAP = new Ping();
                PingReply pingAPResult = pingAP.Send("192.168.0.100");

                if (pingAPResult.Status == IPStatus.Success)
                {
                    if (!lastStatus) // إذا كانت الحالة السابقة غير متصلة
                    {
                        picAP.BackColor = Color.Green;
                        SaveEventToDatabase("Connected", MessageAPup, IpAPup);
                        SendMessage("2020938951", MessageAPup + Environment.NewLine + IpAPup + Environment.NewLine + DateTimeAPup);
                        timer2.Enabled = true;
                        lastStatus = true; // تحديث الحالة الأخيرة
                    }
                }
                else
                {
                    if (lastStatus) // إذا كانت الحالة السابقة متصلة
                    {
                        picAP.BackColor = Color.Red;
                        SaveEventToDatabase("Disconnected", MessageAPDown, IpAPDown);
                        SendMessage("2020938951", MessageAPDown + Environment.NewLine + IpAPDown + Environment.NewLine + DateTimeAPDown);
                        timer2.Enabled = false;
                        lastStatus = false; // تحديث الحالة الأخيرة
                    }
                }
            }
            catch (Exception ex)
            {
                picAP.BackColor = Color.Red;
                SendMessage("2020938951", "حدث خطأ أثناء محاولة الاتصال: " + ex.Message);
            }
        }

        private void SaveEventToDatabase(string eventType, string message, string ipAddress)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "INSERT INTO networkRegister (MessageAPup, MessageAPDown, IpAPDown, DateTimeAPDown) VALUES (@MessageAPup, @MessageAPDown, @IpAPDown, @DateTimeAPDown)";
                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        command.Parameters.AddWithValue("@MessageAPup", eventType);
                        command.Parameters.AddWithValue("@MessageAPDown", message);
                        command.Parameters.AddWithValue("@IpAPDown", ipAddress);
                        command.Parameters.AddWithValue("@DateTimeAPDown", DateTime.Now);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // يمكنك تسجيل الخطأ أو إرساله للإدارة
                SendMessage("2020938951", "حدث خطأ أثناء حفظ البيانات في قاعدة البيانات: " + ex.Message);
            }
        }
        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {


            try
            {
                // إنشاء كائن Ping لإرسال طلبات Ping
                Ping pingAP = new Ping();

                // إرسال Ping إلى العنوان IP المحدد
                PingReply pingAPResult = pingAP.Send("192.168.0.100");

                // التحقق من حالة الرد
                if (pingAPResult.Status == IPStatus.Success)
                {
                    // إذا كان اللون الأخضر معين بالفعل، لا داعي للتحديث
                    if (picAP.BackColor != Color.Green)
                    {
                        picAP.BackColor = Color.Green;

                        // إرسال رسالة بالحالة الجديدة
                        SendMessage("2020938951", MessageAPup + Environment.NewLine + IpAPup + Environment.NewLine + DateTimeAPup);

                        // تفعيل المؤقت
                        timer2.Enabled = true;
                    }
                }
                else
                {
                    // إذا كان اللون الأحمر معين بالفعل، لا داعي للتحديث
                    if (picAP.BackColor != Color.Red)
                    {
                        picAP.BackColor = Color.Red;

                        // إرسال رسالة بالحالة الجديدة
                        SendMessage("2020938951", MessageAPDown + Environment.NewLine + IpAPDown + Environment.NewLine + DateTimeAPDown);

                        // إيقاف المؤقت
                        timer2.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                // في حالة حدوث أي استثناء، قم بتعيين اللون الأحمر وإرسال رسالة الخطأ
                picAP.BackColor = Color.Red;

                // يمكنك تسجيل الخطأ أو إرساله للإدارة
                SendMessage("2020938951", "حدث خطأ أثناء محاولة الاتصال: " + ex.Message);
            }




            try
            {
                Ping pingCamera = new Ping();
                PingReply pingRCamera = pingCamera.Send("192.168.0.100");

                if (pingRCamera.Status.ToString() == "Success")
                {
                    picCamera.BackColor = Color.Green;
                }
                else
                {
                    picCamera.BackColor = Color.Red;
                }
            }
            catch
            {
                picCamera.BackColor = Color.Red;
            }


            try
            {
                Ping pingTelephone = new Ping();
                PingReply pingRTelephone = pingTelephone.Send("192.168.0.100");

                if (pingRTelephone.Status.ToString() == "Success")
                {
                    picTelephone.BackColor = Color.Green;
                }
                else
                {
                    picTelephone.BackColor = Color.Red;
                }
            }
            catch
            {
                picTelephone.BackColor = Color.Red;
            }


            try
            {
                Ping pingRouter = new Ping();
                PingReply pingRouterResult = pingRouter.Send("192.168.0.100");

                if (pingRouterResult.Status.ToString() == "Success")
                {
                    picRouter.BackColor = Color.Green;
                }
                else
                {
                    picRouter.BackColor = Color.Red;
                }
            }
            catch
            {
                picRouter.BackColor = Color.Red;
            }


            try
            {
                Ping pingDesktop = new Ping();
                PingReply pingResultDesktop = pingDesktop.Send("192.168.0.100");

                if (pingResultDesktop.Status.ToString() == "Success")
                {
                    picDesktop.BackColor = Color.Green;
                }
                else
                {
                    picDesktop.BackColor = Color.Red;
                }
            }
            catch
            {
                picDesktop.BackColor = Color.Red;
            }



            try
            {
                Ping pingFingerPoint = new Ping();
                PingReply pingResultFP = pingFingerPoint.Send("192.168.0.100");

                if (pingResultFP.Status.ToString() == "Success")
                {
                    picFingerPoint.BackColor = Color.Green;
                }
                else
                {
                    picFingerPoint.BackColor = Color.Red;
                }
            }
            catch
            {
                picFingerPoint.BackColor = Color.Red;
            }


            try
            {
                Ping pingSw = new Ping();
                PingReply pingResultSW = pingSw.Send("192.168.0.100");

                if (pingResultSW.Status.ToString() == "Success")
                {
                    picSwi.BackColor = Color.Green;
                }
                else
                {
                    picSwi.BackColor = Color.Red;
                }
            }
            catch
            {
                picSwi.BackColor = Color.Red;
            }


        }

        private void backgroundWorker2_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
           
        }

    }
}
