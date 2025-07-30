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

        string IpAPup = "IP Address: 192.168.137.218";
        string DateTimeAPup = "وقت التشغيل = '" + DateTime.Now.ToString() + "'";

        string IpAPDown = "IP Address: 192.168.137.218";
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
      
        private async void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();

          await SendMessage("2020938951", "مرحباً بكم في برنامج مراقبة الشبكة");

            // بدء المؤقتات
            timer1.Interval = 5000; // التحقق كل 5 ثوانٍ
            timer1.Tick += timer1_Tick;
            timer1.Start();

            timer2.Interval = 5000; // التحقق كل 5 ثوانٍ
            timer2.Tick += timer2_Tick;
            timer2.Start();



        }
        bool cameraAlertSent = false;

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
                PingReply pingAPResult = pingAP.Send("192.168.137.218");

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
                        SaveEventToDatabase("Disconnected", "MessageAPDown", IpAPDown);
                        SendMessage("2020938951", "MessageAPDown" + Environment.NewLine + IpAPDown + Environment.NewLine + DateTimeAPDown);
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

        private void CheckNetworkStatusAP()
        {
            string ApUp = "تم تشغيل الاكسس الشبكة ap";
            string ApDo = "تم اطفاء الاكسس الشبكة ap";
            try
            {
                Ping pingAP = new Ping();
                PingReply pingAPResult = pingAP.Send("192.168.137.218");

                if (pingAPResult.Status == IPStatus.Success)
                {
                    if (!lastStatus) // إذا كانت الحالة السابقة غير متصلة
                    {
                        picAP.BackColor = Color.Green;
                        SaveEventToDatabase("Connected", ApUp, IpAPup);
                        SendMessage("2020938951", ApUp + Environment.NewLine + IpAPup + Environment.NewLine + DateTimeAPup);
                        timer2.Enabled = true;
                        lastStatus = true; // تحديث الحالة الأخيرة
                    }
                }
                else
                {
                    if (lastStatus) // إذا كانت الحالة السابقة متصلة
                    {
                        picAP.BackColor = Color.Red;
                        SaveEventToDatabase("Disconnected", ApDo, IpAPDown);
                        SendMessage("2020938951", ApDo + Environment.NewLine + IpAPDown + Environment.NewLine + DateTimeAPDown);
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
        private void CheckNetworkStatusCamera()
        {
            string piCameraUp = "تم تشغيل الكاميرا ";
            string piCameraDo = "تم اطفاء الكاميرا ";
            try
            {
                Ping pingCmaera = new Ping();
                PingReply pingAPResult = pingCmaera.Send("192.168.0.100");

                if (pingAPResult.Status == IPStatus.Success)
                {
                    if (!lastStatus) // إذا كانت الحالة السابقة غير متصلة
                    {
                        picCamera.BackColor = Color.Green;
                        SaveEventToDatabase("Connected", piCameraUp, IpAPup);
                        SendMessage("2020938951", piCameraUp + Environment.NewLine + IpAPup + Environment.NewLine + DateTimeAPup);
                        timer2.Enabled = true;
                        lastStatus = true; // تحديث الحالة الأخيرة
                    }
                }
                else
                {
                    if (lastStatus) // إذا كانت الحالة السابقة متصلة
                    {
                        picCamera.BackColor = Color.Red;
                        SaveEventToDatabase("Disconnected", piCameraDo, IpAPDown);
                        SendMessage("2020938951", piCameraDo + Environment.NewLine + IpAPDown + Environment.NewLine + DateTimeAPDown);
                        timer2.Enabled = false;
                        lastStatus = false; // تحديث الحالة الأخيرة
                    }
                }
            }
            catch (Exception ex)
            {
                picCamera.BackColor = Color.Red;
                SendMessage("2020938951", "حدث خطأ أثناء محاولة الاتصال: " + ex.Message);
            }
        }
        private void CheckNetworkStatusLaptop()
        {
            try
            {
                string piLaptopUp = "تم تشغيل اللابتوب";
                string piLaptopDo = "تم اطفاء اللابتوب";
                Ping pingAP = new Ping();
                PingReply pingAPResult = pingAP.Send("192.168.0.100");

                if (pingAPResult.Status == IPStatus.Success)
                {
                    if (!lastStatus) // إذا كانت الحالة السابقة غير متصلة
                    {
                        picDesktop.BackColor = Color.Green;
                        SaveEventToDatabase("Connected", piLaptopUp, IpAPup);
                        SendMessage("2020938951", "تم تشغيل اللابتوب " + Environment.NewLine + IpAPup + Environment.NewLine + DateTimeAPup);
                        timer2.Enabled = true;
                        lastStatus = true; // تحديث الحالة الأخيرة
                    }
                }
                else
                {
                    if (lastStatus) // إذا كانت الحالة السابقة متصلة
                    {
                        picDesktop.BackColor = Color.Red;
                        SaveEventToDatabase("Disconnected", piLaptopDo, IpAPDown);
                        SendMessage("2020938951", "تم اطفاء اللابتوب " + Environment.NewLine + IpAPDown + Environment.NewLine + DateTimeAPDown);
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
        private void CheckNetworkStatusRouter()
        {
            string piRouterUp = "تم تشغيل الراوتر";
            string piRouterDo = "تم اطفاء الراوتر";
            try
            {
                Ping pingAP = new Ping();
                PingReply pingAPResult = pingAP.Send("192.168.0.100");

                if (pingAPResult.Status == IPStatus.Success)
                {
                    if (!lastStatus) // إذا كانت الحالة السابقة غير متصلة
                    {
                        picRouter.BackColor = Color.Green;
                        SaveEventToDatabase("Connected", piRouterUp, IpAPup);
                        SendMessage("2020938951", "تم تشغيل الراوتر " + Environment.NewLine + IpAPup + Environment.NewLine + DateTimeAPup);
                        timer2.Enabled = true;
                        lastStatus = true; // تحديث الحالة الأخيرة
                    }
                }
                else
                {
                    if (lastStatus) // إذا كانت الحالة السابقة متصلة
                    {
                        picRouter.BackColor = Color.Red;
                        SaveEventToDatabase("Disconnected", piRouterDo, IpAPDown);
                        SendMessage("2020938951", "تم اطفاء الراوتر " + Environment.NewLine + IpAPDown + Environment.NewLine + DateTimeAPDown);
                        timer2.Enabled = false;
                        lastStatus = false; // تحديث الحالة الأخيرة
                    }
                }
            }
            catch (Exception ex)
            {
                picRouter.BackColor = Color.Red;
                SendMessage("2020938951", "حدث خطأ أثناء محاولة الاتصال: " + ex.Message);
            }
        }
        private void CheckNetworkStatusPhone()
        {
            string piPhoneUp = "2تم تشغيل الهاتف";
            string piPhoneDo = "2تم اطفاء الهاتف";
            try
            {
                Ping pingAP = new Ping();
                PingReply pingAPResult = pingAP.Send("192.168.0.100");

                if (pingAPResult.Status == IPStatus.Success)
                {
                    if (!lastStatus) // إذا كانت الحالة السابقة غير متصلة
                    {
                        picTelephone.BackColor = Color.Green;
                        SaveEventToDatabase("Connected", piPhoneUp, IpAPup);
                       SendMessage("2020938951", "تم تشغيل الهاتف " + Environment.NewLine + IpAPup + Environment.NewLine + DateTimeAPup);
                        timer2.Enabled = true;
                        lastStatus = true; // تحديث الحالة الأخيرة
                    }
                }
                else
                {
                    if (lastStatus) // إذا كانت الحالة السابقة متصلة
                    {
                        picTelephone.BackColor = Color.Red;
                        SaveEventToDatabase("Disconnected", piPhoneDo, IpAPDown);
                       SendMessage("2020938951", "تم اطفاء الهاتف " + Environment.NewLine + IpAPDown + Environment.NewLine + DateTimeAPDown);
                        timer2.Enabled = false;
                        lastStatus = false; // تحديث الحالة الأخيرة
                    }
                }
            }
            catch (Exception ex)
            {
                picTelephone.BackColor = Color.Red;
                SendMessage("2020938951", "حدث خطأ أثناء محاولة الاتصال: " + ex.Message);
            }
        }
        private void CheckNetworkStatusFingerPoint()
        {
            string piFingerPointUp = "تم تشغيل جهاز البصمة";
            string piFingerPointDo = "تم اطفاء جهاز البصمة";
            try
            {
                Ping pingAP = new Ping();
                PingReply pingAPResult = pingAP.Send("192.168.0.100");

                if (pingAPResult.Status == IPStatus.Success)
                {
                    if (!lastStatus) // إذا كانت الحالة السابقة غير متصلة
                    {
                        picFingerPoint.BackColor = Color.Green;
                        SaveEventToDatabase("Connected", piFingerPointUp, IpAPup);
                        SendMessage("2020938951", "تم تشغيل حهاز البصمة " + Environment.NewLine + IpAPup + Environment.NewLine + DateTimeAPup);
                        timer2.Enabled = true;
                        lastStatus = true; // تحديث الحالة الأخيرة
                    }
                }
                else
                {
                    if (lastStatus) // إذا كانت الحالة السابقة متصلة
                    {
                        picFingerPoint.BackColor = Color.Red;
                        SaveEventToDatabase("Disconnected", piFingerPointDo, IpAPDown);
                        SendMessage("2020938951", "تم اطفاء جهاز البصمة " + Environment.NewLine + IpAPDown + Environment.NewLine + DateTimeAPDown);
                        timer2.Enabled = false;
                        lastStatus = false; // تحديث الحالة الأخيرة
                    }
                }
            }
            catch (Exception ex)
            {
                picFingerPoint.BackColor = Color.Red;
                SendMessage("2020938951", "حدث خطأ أثناء محاولة الاتصال: " + ex.Message);
            }
        }
        private void CheckNetworkStatusSwitch()
        {
            string piSwitchUp = "تم تشغيل المفتاح";
            string piSwitchDo = "تم اطفاء المفتاح";
            try
            {
                Ping pingAP = new Ping();
                PingReply pingAPResult = pingAP.Send("192.168.0.100");

                if (pingAPResult.Status == IPStatus.Success)
                {
                    if (!lastStatus) // إذا كانت الحالة السابقة غير متصلة
                    {
                        picSwi.BackColor = Color.Green;
                        SaveEventToDatabase("Connected", piSwitchUp, IpAPup);
                        SendMessage("2020938951", "تم تشغيل المفتاح " + Environment.NewLine + IpAPup + Environment.NewLine + DateTimeAPup);
                        timer2.Enabled = true;
                        lastStatus = true; // تحديث الحالة الأخيرة
                    }
                }
                else
                {
                    if (lastStatus) // إذا كانت الحالة السابقة متصلة
                    {
                        picSwi.BackColor = Color.Red;
                        SaveEventToDatabase("Disconnected", piSwitchDo, IpAPDown);
                        SendMessage("2020938951", "تم اطفاء المفتاح " + Environment.NewLine + IpAPDown + Environment.NewLine + DateTimeAPDown);
                        timer2.Enabled = false;
                        lastStatus = false; // تحديث الحالة الأخيرة
                    }
                }
            }
            catch (Exception ex)
            {
                picSwi.BackColor = Color.Red;
                SendMessage("2020938951", "حدث خطأ أثناء محاولة الاتصال: " + ex.Message);
            }
        }
        private void CheckNetworkStatusDesktop()
        {
            string piSwitchUp = "تم تشغيل الديسكتوب";
            string piSwitchDo = "تم اطفاء الدبسكتوب";
            try
            {
                Ping pingAP = new Ping();
                PingReply pingAPResult = pingAP.Send("192.168.0.100");

                if (pingAPResult.Status == IPStatus.Success)
                {
                    if (!lastStatus) // إذا كانت الحالة السابقة غير متصلة
                    {
                        picDesktop.BackColor = Color.Green;
                        SaveEventToDatabase("Connected", piSwitchUp, IpAPup);
                        SendMessage("2020938951", piSwitchUp + Environment.NewLine + IpAPup + Environment.NewLine + DateTimeAPup);
                        timer2.Enabled = true;
                        lastStatus = true; // تحديث الحالة الأخيرة
                    }
                }
                else
                {
                    if (lastStatus) // إذا كانت الحالة السابقة متصلة
                    {
                        picDesktop.BackColor = Color.Red;
                        SaveEventToDatabase("Disconnected", piSwitchDo, IpAPDown);
                        SendMessage("2020938951", piSwitchDo + Environment.NewLine + IpAPDown + Environment.NewLine + DateTimeAPDown);
                        timer2.Enabled = false;
                        lastStatus = false; // تحديث الحالة الأخيرة
                    }
                }
            }
            catch (Exception ex)
            {
                picDesktop.BackColor = Color.Red;
                SendMessage("2020938951", "حدث خطأ أثناء محاولة الاتصال: " + ex.Message);
            }
        }
        private async void CheckNetworkStatusCamera1()
        {
            string piCameraUp = "تم تشغيل الكاميرا";
            string piCameraDown = "تم إطفاء الكاميرا";

            try
            {
                Ping pingCamera = new Ping();
                PingReply reply = pingCamera.Send(IpAPup);

                if (reply.Status == IPStatus.Success)
                {
                    if (!lastStatus)
                    {
                        picCamera.BackColor = Color.Green;

                        SaveEventToDatabase("Connected", piCameraUp, IpAPup);
                        await SendMessage("2020938951", $"{piCameraUp}\n{IpAPup}\n{DateTimeAPup}");

                        lastStatus = true;
                    }
                }
                else
                {
                    if (lastStatus)
                    {
                        picCamera.BackColor = Color.Red;

                        SaveEventToDatabase("Disconnected", piCameraDown, IpAPDown);
                        await SendMessage("2020938951", $"{piCameraDown}\n{IpAPDown}\n{DateTimeAPDown}");

                        lastStatus = false;
                    }
                }
            }
            catch (Exception ex)
            {
                picCamera.BackColor = Color.Red;

                if (lastStatus)
                {
                    await SendMessage("2020938951", "حدث خطأ أثناء الاتصال بالشبكة: " + ex.Message);
                    SaveEventToDatabase("Disconnected", "خطأ: " + ex.Message, IpAPDown);
                    lastStatus = false;
                }
            }
        }





        //database
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
            //CheckFingerStatusFull();
            //CheckTelephoneStatusFull();
            //CheckSwitchStatusFull();
            //CheckCameraStatusFull();
            //CheckAPStatusFull();
            //CheckDesktopStatusFull();
            //CheckRouterStatusFull();
            //  CheckNetworkStatusAP();
            //  CheckNetworkStatusAP();

            //try
            //{
            //    // إنشاء كائن Ping لإرسال طلبات Ping
            //    Ping pingAP = new Ping();

            //    // إرسال Ping إلى العنوان IP المحدد
            //    PingReply pingAPResult = pingAP.Send("192.168.137.218");

            //    // التحقق من حالة الرد
            //    if (pingAPResult.Status == IPStatus.Success)
            //    {
            //        // إذا كان اللون الأخضر معين بالفعل، لا داعي للتحديث
            //        if (picAP.BackColor != Color.Green)
            //        {
            //            picAP.BackColor = Color.Green;

            //            // إرسال رسالة بالحالة الجديدة
            //            SendMessage("2020938951", "تم تشغيل الاكسس بوينت" + Environment.NewLine + IpAPup + Environment.NewLine + DateTimeAPup);

            //            // تفعيل المؤقت
            //            timer2.Enabled = true;
            //        }
            //    }
            //    else
            //    {
            //        // إذا كان اللون الأحمر معين بالفعل، لا داعي للتحديث
            //        if (picAP.BackColor != Color.Red)
            //        {
            //            picAP.BackColor = Color.Red;

            //            // إرسال رسالة بالحالة الجديدة
            //            SendMessage("2020938951", "تم اطفاء الاكسس بوينت " + Environment.NewLine + IpAPDown + Environment.NewLine + DateTimeAPDown);

            //            // إيقاف المؤقت
            //            timer2.Enabled = false;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    // في حالة حدوث أي استثناء، قم بتعيين اللون الأحمر وإرسال رسالة الخطأ
            //    picAP.BackColor = Color.Red;

            //    // يمكنك تسجيل الخطأ أو إرساله للإدارة
            //    SendMessage("2020938951", "حدث خطأ أثناء محاولة الاتصال: " + ex.Message);
            //}

            //try
            //{
            //    // إنشاء كائن Ping لإرسال طلبات Ping
            //    Ping pingCamera = new Ping();

            //    // إرسال Ping إلى العنوان IP المحدد
            //    PingReply pingAPResult = pingCamera.Send("192.168.137.218");

            //    // التحقق من حالة الرد
            //    if (pingAPResult.Status == IPStatus.Success)
            //    {
            //        // إذا كان اللون الأخضر معين بالفعل، لا داعي للتحديث
            //        if (picCamera.BackColor != Color.Green)
            //        {
            //            picCamera.BackColor = Color.Green;

            //            // إرسال رسالة بالحالة الجديدة
            //            SendMessage("2020938951", "تم تشغيل الكاميرا " + Environment.NewLine + IpAPup + Environment.NewLine + DateTimeAPup);

            //            // تفعيل المؤقت
            //            timer2.Enabled = true;
            //        }
            //    }
            //    else
            //    {
            //        // إذا كان اللون الأحمر معين بالفعل، لا داعي للتحديث
            //        if (picCamera.BackColor != Color.Red)
            //        {
            //            picCamera.BackColor = Color.Red;

            //            // إرسال رسالة بالحالة الجديدة
            //            SendMessage("2020938951", "تم اطفاء الكاميرا  " + Environment.NewLine + IpAPDown + Environment.NewLine + DateTimeAPDown);

            //            // إيقاف المؤقت
            //            timer2.Enabled = false;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    // في حالة حدوث أي استثناء، قم بتعيين اللون الأحمر وإرسال رسالة الخطأ
            //    picCamera.BackColor = Color.Red;

            //    // يمكنك تسجيل الخطأ أو إرساله للإدارة
            //    SendMessage("2020938951", "حدث خطأ أثناء محاولة الاتصال: " + ex.Message);
            //}

            //try
            //{
            //    // إنشاء كائن Ping لإرسال طلبات Ping
            //    Ping pingPhone = new Ping();

            //    // إرسال Ping إلى العنوان IP المحدد
            //    PingReply pingAPResult = pingPhone.Send("192.168.137.218");

            //    // التحقق من حالة الرد
            //    if (pingAPResult.Status == IPStatus.Success)
            //    {
            //        // إذا كان اللون الأخضر معين بالفعل، لا داعي للتحديث
            //        if (picTelephone.BackColor != Color.Green)
            //        {
            //            picTelephone.BackColor = Color.Green;

            //            // إرسال رسالة بالحالة الجديدة
            //            SendMessage("2020938951", "تم تشغيل الهاتف " + Environment.NewLine + IpAPup + Environment.NewLine + DateTimeAPup);

            //            // تفعيل المؤقت
            //            timer2.Enabled = true;
            //        }
            //    }
            //    else
            //    {
            //        // إذا كان اللون الأحمر معين بالفعل، لا داعي للتحديث
            //        if (picTelephone.BackColor != Color.Red)
            //        {
            //            picTelephone.BackColor = Color.Red;

            //            // إرسال رسالة بالحالة الجديدة
            //            SendMessage("2020938951", "تم اطفاء الهاتف  " + Environment.NewLine + IpAPDown + Environment.NewLine + DateTimeAPDown);

            //            // إيقاف المؤقت
            //            timer2.Enabled = false;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    // في حالة حدوث أي استثناء، قم بتعيين اللون الأحمر وإرسال رسالة الخطأ
            //    picTelephone.BackColor = Color.Red;

            //    // يمكنك تسجيل الخطأ أو إرساله للإدارة
            //    SendMessage("2020938951", "حدث خطأ أثناء محاولة الاتصال: " + ex.Message);
            //}


            //try
            //{
            //    // إنشاء كائن Ping لإرسال طلبات Ping
            //    Ping pingRouter = new Ping();

            //    // إرسال Ping إلى العنوان IP المحدد
            //    PingReply pingAPResult = pingRouter.Send("192.168.137.218");

            //    // التحقق من حالة الرد
            //    if (pingAPResult.Status == IPStatus.Success)
            //    {
            //        // إذا كان اللون الأخضر معين بالفعل، لا داعي للتحديث
            //        if (picRouter.BackColor != Color.Green)
            //        {
            //            picRouter.BackColor = Color.Green;

            //            // إرسال رسالة بالحالة الجديدة
            //            SendMessage("2020938951", "تم تشغيل الراوتر " + Environment.NewLine + IpAPup + Environment.NewLine + DateTimeAPup);

            //            // تفعيل المؤقت
            //            timer2.Enabled = true;
            //        }
            //    }
            //    else
            //    {
            //        // إذا كان اللون الأحمر معين بالفعل، لا داعي للتحديث
            //        if (picRouter.BackColor != Color.Red)
            //        {
            //            picRouter.BackColor = Color.Red;

            //            // إرسال رسالة بالحالة الجديدة
            //            SendMessage("2020938951", "تم اطفاء الراوتر  " + Environment.NewLine + IpAPDown + Environment.NewLine + DateTimeAPDown);

            //            // إيقاف المؤقت
            //            timer2.Enabled = false;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    // في حالة حدوث أي استثناء، قم بتعيين اللون الأحمر وإرسال رسالة الخطأ
            //    picRouter.BackColor = Color.Red;

            //    // يمكنك تسجيل الخطأ أو إرساله للإدارة
            //    SendMessage("2020938951", "حدث خطأ أثناء محاولة الاتصال: " + ex.Message);
            //}


            //try
            //{
            //    // إنشاء كائن Ping لإرسال طلبات Ping
            //    Ping pingDesktop = new Ping();

            //    // إرسال Ping إلى العنوان IP المحدد
            //    PingReply pingAPResult = pingDesktop.Send("192.168.137.218");

            //    // التحقق من حالة الرد
            //    if (pingAPResult.Status == IPStatus.Success)
            //    {
            //        // إذا كان اللون الأخضر معين بالفعل، لا داعي للتحديث
            //        if (picDesktop.BackColor != Color.Green)
            //        {
            //            picDesktop.BackColor = Color.Green;

            //            // إرسال رسالة بالحالة الجديدة
            //            SendMessage("2020938951", "تم تشغيل الديسكتوب " + Environment.NewLine + IpAPup + Environment.NewLine + DateTimeAPup);

            //            // تفعيل المؤقت
            //            timer2.Enabled = true;
            //        }
            //    }
            //    else
            //    {
            //        // إذا كان اللون الأحمر معين بالفعل، لا داعي للتحديث
            //        if (picDesktop.BackColor != Color.Red)
            //        {
            //            picDesktop.BackColor = Color.Red;

            //            // إرسال رسالة بالحالة الجديدة
            //            SendMessage("2020938951", "تم اطفاء الديسكتوب  " + Environment.NewLine + IpAPDown + Environment.NewLine + DateTimeAPDown);

            //            // إيقاف المؤقت
            //            timer2.Enabled = false;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    // في حالة حدوث أي استثناء، قم بتعيين اللون الأحمر وإرسال رسالة الخطأ
            //    picRouter.BackColor = Color.Red;

            //    // يمكنك تسجيل الخطأ أو إرساله للإدارة
            //    SendMessage("2020938951", "حدث خطأ أثناء محاولة الاتصال: " + ex.Message);
            //}
            //try
            //{
            //    // إنشاء كائن Ping لإرسال طلبات Ping
            //    Ping pingFingerPoint = new Ping();

            //    // إرسال Ping إلى العنوان IP المحدد
            //    PingReply pingAPResult = pingFingerPoint.Send("192.168.137.218");

            //    // التحقق من حالة الرد
            //    if (pingAPResult.Status == IPStatus.Success)
            //    {
            //        // إذا كان اللون الأخضر معين بالفعل، لا داعي للتحديث
            //        if (picFingerPoint.BackColor != Color.Green)
            //        {
            //            picFingerPoint.BackColor = Color.Green;

            //            // إرسال رسالة بالحالة الجديدة
            //            SendMessage("2020938951", "تم تشغيل الديسكتوب " + Environment.NewLine + IpAPup + Environment.NewLine + DateTimeAPup);

            //            // تفعيل المؤقت
            //            timer2.Enabled = true;
            //        }
            //    }
            //    else
            //    {
            //        // إذا كان اللون الأحمر معين بالفعل، لا داعي للتحديث
            //        if (picFingerPoint.BackColor != Color.Red)
            //        {
            //            picFingerPoint.BackColor = Color.Red;

            //            // إرسال رسالة بالحالة الجديدة
            //            SendMessage("2020938951", "تم اطفاء الديسكتوب  " + Environment.NewLine + IpAPDown + Environment.NewLine + DateTimeAPDown);

            //            // إيقاف المؤقت
            //            timer2.Enabled = false;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    // في حالة حدوث أي استثناء، قم بتعيين اللون الأحمر وإرسال رسالة الخطأ
            //    picFingerPoint.BackColor = Color.Red;

            //    // يمكنك تسجيل الخطأ أو إرساله للإدارة
            //    SendMessage("2020938951", "حدث خطأ أثناء محاولة الاتصال: " + ex.Message);
            //}
            //try
            //{
            //    // إنشاء كائن Ping لإرسال طلبات Ping
            //    Ping pingSw = new Ping();

            //    // إرسال Ping إلى العنوان IP المحدد
            //    PingReply pingAPResult = pingSw.Send("192.168.137.218");

            //    // التحقق من حالة الرد
            //    if (pingAPResult.Status == IPStatus.Success)
            //    {
            //        // إذا كان اللون الأخضر معين بالفعل، لا داعي للتحديث
            //        if (picSwi.BackColor != Color.Green)
            //        {
            //            picSwi.BackColor = Color.Green;

            //            // إرسال رسالة بالحالة الجديدة
            //            SendMessage("2020938951", "تم تشغيل المفناح " + Environment.NewLine + IpAPup + Environment.NewLine + DateTimeAPup);

            //            // تفعيل المؤقت
            //            timer2.Enabled = true;
            //        }
            //    }
            //    else
            //    {
            //        // إذا كان اللون الأحمر معين بالفعل، لا داعي للتحديث
            //        if (picSwi.BackColor != Color.Red)
            //        {
            //            picSwi.BackColor = Color.Red;

            //            // إرسال رسالة بالحالة الجديدة
            //            SendMessage("2020938951", "تم اطفاء المفتاح  " + Environment.NewLine + IpAPDown + Environment.NewLine + DateTimeAPDown);

            //            // إيقاف المؤقت
            //            timer2.Enabled = false;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    // في حالة حدوث أي استثناء، قم بتعيين اللون الأحمر وإرسال رسالة الخطأ
            //    picSwi.BackColor = Color.Red;

            //    // يمكنك تسجيل الخطأ أو إرساله للإدارة
            //    SendMessage("2020938951", "حدث خطأ أثناء محاولة الاتصال: " + ex.Message);
            //}

            //try
            //{
            //    // إنشاء كائن Ping لإرسال طلبات Ping
            //    Ping pingAP = new Ping();

            //    // إرسال Ping إلى العنوان IP المحدد
            //    PingReply pingAPResult = pingAP.Send("192.168.137.218");

            //    // التحقق من حالة الرد
            //    if (pingAPResult.Status == IPStatus.Success)
            //    {
            //        // إذا كان اللون الأخضر معين بالفعل، لا داعي للتحديث
            //        if (picAP.BackColor != Color.Green)
            //        {
            //            picAP.BackColor = Color.Green;

            //            // إرسال رسالة بالحالة الجديدة
            //            //  SendMessage("2020938951", "تم تشغيل الاكسس " + Environment.NewLine + IpAPup + Environment.NewLine + DateTimeAPup);

            //            // تفعيل المؤقت
            //            timer2.Enabled = true;
            //        }
            //    }
            //    else
            //    {
            //        // إذا كان اللون الأحمر معين بالفعل، لا داعي للتحديث
            //        if (picAP.BackColor != Color.Red)
            //        {
            //            picAP.BackColor = Color.Red;

            //            // إرسال رسالة بالحالة الجديدة
            //            //  SendMessage("2020938951", "تم اطفاء الاكسس" + Environment.NewLine + IpAPDown + Environment.NewLine + DateTimeAPDown);

            //            // إيقاف المؤقت
            //            timer2.Enabled = false;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    // في حالة حدوث أي استثناء، قم بتعيين اللون الأحمر وإرسال رسالة الخطأ
            //    picAP.BackColor = Color.Red;

            //    // يمكنك تسجيل الخطأ أو إرساله للإدارة
            //    SendMessage("2020938951", "حدث خطأ أثناء محاولة الاتصال: " + ex.Message);
            //}




            //try
            //{
            //    Ping pingCamera = new Ping();
            //    PingReply pingRCamera = pingCamera.Send("192.168.137.218");

            //    if (pingRCamera.Status.ToString() == "Success")
            //    {
            //        picCamera.BackColor = Color.Green;
            //    }
            //    else
            //    {
            //       if( picCamera.BackColor == Color.Red)
            //        {
            //            return;
            //        }
            //       picCamera.BackColor = Color.Red;
            //                  SendMessage("2020938951", "تم اشغال الكاميرا  " + Environment.NewLine + IpAPDown + Environment.NewLine + DateTimeAPDown);
            //        timer2.Enabled = true;
            //    }
            //}
            //catch
            //{
            //    picCamera.BackColor = Color.Red;
            //}


            //try
            //{
            //    Ping pingTelephone = new Ping();
            //    PingReply pingRTelephone = pingTelephone.Send("192.168.137.218");

            //    if (pingRTelephone.Status.ToString() == "Success")
            //    {
            //        picTelephone.BackColor = Color.Green;
            //    }
            //    else
            //    {
            //        picTelephone.BackColor = Color.Red;
            //    }
            //}
            //catch
            //{
            //    picTelephone.BackColor = Color.Red;
            //}


            //try
            //{
            //    Ping pingRouter = new Ping();
            //    PingReply pingRouterResult = pingRouter.Send("192.168.137.218");

            //    if (pingRouterResult.Status.ToString() == "Success")
            //    {
            //        picRouter.BackColor = Color.Green;
            //    }
            //    else
            //    {
            //        picRouter.BackColor = Color.Red;
            //    }
            //}
            //catch
            //{
            //    picRouter.BackColor = Color.Red;
            //}


            //try
            //{
            //    Ping pingDesktop = new Ping();
            //    PingReply pingResultDesktop = pingDesktop.Send("192.168.137.218");

            //    if (pingResultDesktop.Status.ToString() == "Success")
            //    {
            //        picDesktop.BackColor = Color.Green;
            //    }
            //    else
            //    {
            //        picDesktop.BackColor = Color.Red;
            //    }
            //}
            //catch
            //{
            //    picDesktop.BackColor = Color.Red;
            //}



            //try
            //{
            //    Ping pingFingerPoint = new Ping();
            //    PingReply pingResultFP = pingFingerPoint.Send("192.168.137.218");

            //    if (pingResultFP.Status.ToString() == "Success")
            //    {
            //        picFingerPoint.BackColor = Color.Green;
            //    }
            //    else
            //    {
            //        picFingerPoint.BackColor = Color.Red;
            //    }
            //}
            //catch
            //{
            //    picFingerPoint.BackColor = Color.Red;
            //}


            //try
            //{
            //    Ping pingSw = new Ping();
            //    PingReply pingResultSW = pingSw.Send("192.168.137.218");

            //    if (pingResultSW.Status.ToString() == "Success")
            //    {
            //        picSwi.BackColor = Color.Green;
            //    }
            //    else
            //    {
            //        picSwi.BackColor = Color.Red;
            //    }
            //}
            //catch
            //{
            //    picSwi.BackColor = Color.Red;
            //}



            try
            {
                // إنشاء كائن Ping لإرسال طلبات Ping
                Ping pingAP = new Ping();

                // إرسال Ping إلى العنوان IP المحدد
                PingReply pingAPResult = pingAP.Send("192.168.137.218");

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
                        SendMessage("2020938951", "MessageAPDown" + Environment.NewLine + IpAPDown + Environment.NewLine + DateTimeAPDown);

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
                PingReply pingRCamera = pingCamera.Send("192.168.137.218");

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
                PingReply pingRTelephone = pingTelephone.Send("192.168.137.218");

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
                PingReply pingRouterResult = pingRouter.Send("192.168.137.218");

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
                PingReply pingResultDesktop = pingDesktop.Send("192.168.137.218");

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
                PingReply pingResultFP = pingFingerPoint.Send("192.168.137.218");

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
                PingReply pingResultSW = pingSw.Send("192.168.137.218");

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

        private void NetProgram_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private bool lastCameraStatus = false;

        private bool IsInternetAvailable()
        {
            try
            {
                using (Ping ping = new Ping())
                {
                    PingReply reply = ping.Send("8.8.8.8", 1000); // Google DNS
                    return reply.Status == IPStatus.Success;
                }
            }
            catch
            {
                return false;
            }
        }

      //  bool cameraAlertSent = false; // عرفها خارج الدالة (في أعلى الكلاس)

        private void CheckCameraStatusFull()
        {
            string ipAddress = "192.168.137.218";
            string messageUp = "تم تشغيل الكاميرا";
            string messageDown = "تم إطفاء الكاميرا بسبب انقطاع الإنترنت";

            try
            {
                if (!IsInternetAvailable())
                {
                    picCamera.BackColor = Color.Red;

                    // إرسال مرة واحدة عند انقطاع الإنترنت
                    if (!cameraAlertSent)
                    {
                        SendMessage("2020938951", messageDown + Environment.NewLine + ipAddress + Environment.NewLine + DateTime.Now.ToString());
                        SaveEventToDatabase("Disconnected", messageDown, ipAddress);
                        cameraAlertSent = true;
                    }

                    lastCameraStatus = false;
                    return;
                }

                // إذا الإنترنت شغال، يتم فحص الكاميرا
                Ping pingCamera = new Ping();
                PingReply reply = pingCamera.Send(ipAddress);

                if (reply.Status == IPStatus.Success)
                {
                    picCamera.BackColor = Color.Green;

                    if (!lastCameraStatus)
                    {
                        SendMessage("2020938951", messageUp + Environment.NewLine + ipAddress + Environment.NewLine + DateTime.Now.ToString());
                        SaveEventToDatabase("Connected", messageUp, ipAddress);
                        lastCameraStatus = true;
                        cameraAlertSent = false; // إعادة التهيئة للسماح بالإرسال عند انقطاع جديد
                    }
                }
                else
                {
                    picCamera.BackColor = Color.Red;

                    if (!cameraAlertSent)
                    {
                        SendMessage("2020938951", messageDown + Environment.NewLine + ipAddress + Environment.NewLine + DateTime.Now.ToString());
                        SaveEventToDatabase("Disconnected", messageDown, ipAddress);
                        cameraAlertSent = true;
                    }

                    lastCameraStatus = false;
                }
            }
            catch (Exception ex)
            {
                picCamera.BackColor = Color.Red;

                if (!cameraAlertSent)
                {
                    SendMessage("2020938951", "فشل الاتصال بالكاميرا أو الإنترنت: " + Environment.NewLine + ex.Message);
                    SaveEventToDatabase("Disconnected", messageDown, ipAddress);
                    cameraAlertSent = true;
                }

                lastCameraStatus = false;
            }
        }
        private bool lastAPStatus = false;

        private void CheckAPStatusFull()
        {
            string ipAddress = "192.168.137.218"; // عدل هذا العنوان حسب عنوان الأكسس بوينت
            string messageUp = "تم تشغيل الأكسس بوينت";
            string messageDown = "تم إطفاء الأكسس بوينت بسبب انقطاع الإنترنت";

            try
            {
                if (!IsInternetAvailable())
                {
                    picAP.BackColor = Color.Red;

                    if (lastAPStatus)
                    {
                        SaveEventToDatabase("Disconnected", messageDown, ipAddress);
                        SendMessage("2020938951", messageDown + Environment.NewLine + ipAddress + Environment.NewLine + DateTime.Now.ToString());
                        lastAPStatus = false;
                    }
                    return;
                }

                Ping pingAP = new Ping();
                PingReply reply = pingAP.Send(ipAddress);

                if (reply.Status == IPStatus.Success)
                {
                    picAP.BackColor = Color.Green;

                    if (!lastAPStatus)
                    {
                        SaveEventToDatabase("Connected", messageUp, ipAddress);
                        SendMessage("2020938951", messageUp + Environment.NewLine + ipAddress + Environment.NewLine + DateTime.Now.ToString());
                        lastAPStatus = true;
                    }
                }
                else
                {
                    picAP.BackColor = Color.Red;

                    if (lastAPStatus)
                    {
                        SaveEventToDatabase("Disconnected", messageDown, ipAddress);
                        SendMessage("2020938951", messageDown + Environment.NewLine + ipAddress + Environment.NewLine + DateTime.Now.ToString());
                        lastAPStatus = false;
                    }
                }
            }
            catch (Exception ex)
            {
                picAP.BackColor = Color.Red;

                if (lastAPStatus)
                {
                    SaveEventToDatabase("Disconnected", messageDown, ipAddress);
                    SendMessage("2020938951", "فشل الاتصال بالأكسس بوينت أو الإنترنت: " + Environment.NewLine + ex.Message);
                    lastAPStatus = false;
                }
            }
        }

        private bool lastDesktopStatus = false;

        private void CheckDesktopStatusFull()
        {
            string ipAddress = "192.168.137.218"; // غيّر هذا إلى عنوان IP الخاص بجهاز الديسكتوب
            string messageUp = "تم تشغيل جهاز الديسكتوب";
            string messageDown = "تم إطفاء جهاز الديسكتوب بسبب انقطاع الإنترنت";

            try
            {
                if (!IsInternetAvailable())
                {
                    picDesktop.BackColor = Color.Red;

                    if (lastDesktopStatus)
                    {
                        SaveEventToDatabase("Disconnected", messageDown, ipAddress);
                        SendMessage("2020938951", messageDown + Environment.NewLine + ipAddress + Environment.NewLine + DateTime.Now.ToString());
                        lastDesktopStatus = false;
                    }
                    return;
                }

                Ping ping = new Ping();
                PingReply reply = ping.Send(ipAddress);

                if (reply.Status == IPStatus.Success)
                {
                    picDesktop.BackColor = Color.Green;

                    if (!lastDesktopStatus)
                    {
                        SaveEventToDatabase("Connected", messageUp, ipAddress);
                        SendMessage("2020938951", messageUp + Environment.NewLine + ipAddress + Environment.NewLine + DateTime.Now.ToString());
                        lastDesktopStatus = true;
                    }
                }
                else
                {
                    picDesktop.BackColor = Color.Red;

                    if (lastDesktopStatus)
                    {
                        SaveEventToDatabase("Disconnected", messageDown, ipAddress);
                        SendMessage("2020938951", messageDown + Environment.NewLine + ipAddress + Environment.NewLine + DateTime.Now.ToString());
                        lastDesktopStatus = false;
                    }
                }
            }
            catch (Exception ex)
            {
                picDesktop.BackColor = Color.Red;

                if (lastDesktopStatus)
                {
                    SaveEventToDatabase("Disconnected", messageDown, ipAddress);
                    SendMessage("2020938951", "فشل الاتصال بجهاز الديسكتوب أو الإنترنت: " + Environment.NewLine + ex.Message);
                    lastDesktopStatus = false;
                }
            }
        }

        private bool lastRouterStatus = false;

        private void CheckRouterStatusFull()
        {
            string ipAddress = "192.168.137.218"; // غيّر هذا إلى عنوان الراوتر الحقيقي إذا كان مختلف
            string messageUp = "تم تشغيل الراوتر";
            string messageDown = "تم إطفاء الراوتر بسبب انقطاع الإنترنت";

            try
            {
                if (!IsInternetAvailable())
                {
                    picRouter.BackColor = Color.Red;

                    if (lastRouterStatus)
                    {
                        SaveEventToDatabase("Disconnected", messageDown, ipAddress);
                        SendMessage("2020938951", messageDown + Environment.NewLine + ipAddress + Environment.NewLine + DateTime.Now.ToString());
                        lastRouterStatus = false;
                    }
                    return;
                }

                Ping ping = new Ping();
                PingReply reply = ping.Send(ipAddress);

                if (reply.Status == IPStatus.Success)
                {
                    picRouter.BackColor = Color.Green;

                    if (!lastRouterStatus)
                    {
                        SaveEventToDatabase("Connected", messageUp, ipAddress);
                        SendMessage("2020938951", messageUp + Environment.NewLine + ipAddress + Environment.NewLine + DateTime.Now.ToString());
                        lastRouterStatus = true;
                    }
                }
                else
                {
                    picRouter.BackColor = Color.Red;

                    if (lastRouterStatus)
                    {
                        SaveEventToDatabase("Disconnected", messageDown, ipAddress);
                        SendMessage("2020938951", messageDown + Environment.NewLine + ipAddress + Environment.NewLine + DateTime.Now.ToString());
                        lastRouterStatus = false;
                    }
                }
            }
            catch (Exception ex)
            {
                picRouter.BackColor = Color.Red;

                if (lastRouterStatus)
                {
                    SaveEventToDatabase("Disconnected", messageDown, ipAddress);
                    SendMessage("2020938951", "فشل الاتصال بالراوتر أو الإنترنت: " + Environment.NewLine + ex.Message);
                    lastRouterStatus = false;
                }
            }
        }

        private bool lastFingerStatus = false;

        private void CheckFingerStatusFull()
        {
            string ipAddress = "192.168.137.218"; // غيّر الـ IP إذا كان مختلف
            string messageUp = "تم تشغيل جهاز البصمة";
            string messageDown = "تم إطفاء جهاز البصمة بسبب انقطاع الإنترنت";

            try
            {
                if (!IsInternetAvailable())
                {
                    picFingerPoint.BackColor = Color.Red;

                    if (lastFingerStatus)
                    {
                        SaveEventToDatabase("Disconnected", messageDown, ipAddress);
                        SendMessage("2020938951", messageDown + Environment.NewLine + ipAddress + Environment.NewLine + DateTime.Now.ToString());
                        lastFingerStatus = false;
                    }
                    return;
                }

                Ping ping = new Ping();
                PingReply reply = ping.Send(ipAddress);

                if (reply.Status == IPStatus.Success)
                {
                    picFingerPoint.BackColor = Color.Green;

                    if (!lastFingerStatus)
                    {
                        SaveEventToDatabase("Connected", messageUp, ipAddress);
                        SendMessage("2020938951", messageUp + Environment.NewLine + ipAddress + Environment.NewLine + DateTime.Now.ToString());
                        lastFingerStatus = true;
                    }
                }
                else
                {
                    picFingerPoint.BackColor = Color.Red;

                    if (lastFingerStatus)
                    {
                        SaveEventToDatabase("Disconnected", messageDown, ipAddress);
                        SendMessage("2020938951", messageDown + Environment.NewLine + ipAddress + Environment.NewLine + DateTime.Now.ToString());
                        lastFingerStatus = false;
                    }
                }
            }
            catch (Exception ex)
            {
                picFingerPoint.BackColor = Color.Red;

                if (lastFingerStatus)
                {
                    SaveEventToDatabase("Disconnected", messageDown, ipAddress);
                    SendMessage("2020938951", "فشل الاتصال بجهاز البصمة أو الإنترنت: " + Environment.NewLine + ex.Message);
                    lastFingerStatus = false;
                }
            }
        }

        private bool lastTelephoneStatus = false;

        private void CheckTelephoneStatusFull()
        {
            string ipAddress = "192.168.137.218"; // غيّر الـ IP حسب جهاز التليفون
            string messageUp = "تم تشغيل التليفون";
            string messageDown = "تم إطفاء التليفون بسبب انقطاع الإنترنت";

            try
            {
                if (!IsInternetAvailable())
                {
                    picTelephone.BackColor = Color.Red;

                    if (lastTelephoneStatus)
                    {
                        SaveEventToDatabase("Disconnected", messageDown, ipAddress);
                        SendMessage("2020938951", messageDown + Environment.NewLine + ipAddress + Environment.NewLine + DateTime.Now.ToString());
                        lastTelephoneStatus = false;
                    }
                    return;
                }

                Ping ping = new Ping();
                PingReply reply = ping.Send(ipAddress);

                if (reply.Status == IPStatus.Success)
                {
                    picTelephone.BackColor = Color.Green;

                    if (!lastTelephoneStatus)
                    {
                        SaveEventToDatabase("Connected", messageUp, ipAddress);
                        SendMessage("2020938951", messageUp + Environment.NewLine + ipAddress + Environment.NewLine + DateTime.Now.ToString());
                        lastTelephoneStatus = true;
                    }
                }
                else
                {
                    picTelephone.BackColor = Color.Red;

                    if (lastTelephoneStatus)
                    {
                        SaveEventToDatabase("Disconnected", messageDown, ipAddress);
                        SendMessage("2020938951", messageDown + Environment.NewLine + ipAddress + Environment.NewLine + DateTime.Now.ToString());
                        lastTelephoneStatus = false;
                    }
                }
            }
            catch (Exception ex)
            {
                picTelephone.BackColor = Color.Red;

                if (lastTelephoneStatus)
                {
                    SaveEventToDatabase("Disconnected", messageDown, ipAddress);
                    SendMessage("2020938951", "فشل الاتصال بجهاز التليفون أو الإنترنت: " + Environment.NewLine + ex.Message);
                    lastTelephoneStatus = false;
                }
            }
        }

        private bool lastSwiStatus = false;

        private void CheckSwitchStatusFull()
        {
            string ipAddress = "192.168.137.218"; // غيّر الـ IP حسب جهاز السويتش
            string messageUp = "تم تشغيل السويتش";
            string messageDown = "تم إطفاء السويتش بسبب انقطاع الإنترنت";

            try
            {
                if (!IsInternetAvailable())
                {
                    picSwi.BackColor = Color.Red;

                    if (lastSwiStatus)
                    {
                        SaveEventToDatabase("Disconnected", messageDown, ipAddress);
                        SendMessage("2020938951", messageDown + Environment.NewLine + ipAddress + Environment.NewLine + DateTime.Now.ToString());
                        lastSwiStatus = false;
                    }
                    return;
                }

                Ping ping = new Ping();
                PingReply reply = ping.Send(ipAddress);

                if (reply.Status == IPStatus.Success)
                {
                    picSwi.BackColor = Color.Green;

                    if (!lastSwiStatus)
                    {
                        SaveEventToDatabase("Connected", messageUp, ipAddress);
                        SendMessage("2020938951", messageUp + Environment.NewLine + ipAddress + Environment.NewLine + DateTime.Now.ToString());
                        lastSwiStatus = true;
                    }
                }
                else
                {
                    picSwi.BackColor = Color.Red;

                    if (lastSwiStatus)
                    {
                        SaveEventToDatabase("Disconnected", messageDown, ipAddress);
                        SendMessage("2020938951", messageDown + Environment.NewLine + ipAddress + Environment.NewLine + DateTime.Now.ToString());
                        lastSwiStatus = false;
                    }
                }
            }
            catch (Exception ex)
            {
                picSwi.BackColor = Color.Red;

                if (lastSwiStatus)
                {
                    SaveEventToDatabase("Disconnected", messageDown, ipAddress);
                    SendMessage("2020938951", "فشل الاتصال بالسويتش أو الإنترنت: " + Environment.NewLine + ex.Message);
                    lastSwiStatus = false;
                }
            }
        }

        private void CheckDeviceStatus(PictureBox pic, string ip, string deviceName)
        {
            if (!IsInternetAvailable())
            {
                pic.BackColor = Color.Red;
                SendMessage("2020938951", "تم فقد الاتصال بالإنترنت - لا يمكن التحقق من حالة " + deviceName);
                return;
            }

            try
            {
                Ping ping = new Ping();
                PingReply reply = ping.Send(ip, 1000);

                if (reply.Status == IPStatus.Success)
                {
                    pic.BackColor = Color.Green;
                }
                else
                {
                    pic.BackColor = Color.Red;
                    SendMessage("2020938951", $"تم اطفاء {deviceName} - {ip}");
                }
            }
            catch
            {
                pic.BackColor = Color.Red;
                SendMessage("2020938951", $"تعذر الوصول إلى {deviceName} - {ip}");
            }
        }

        private void CheckAllDevices()
        {
            CheckDeviceStatus(picCamera, "192.168.137.218", "الكاميرا");
            CheckDeviceStatus(picAP, "192.168.0.100", "الأكسس بوينت");
            CheckDeviceStatus(picDesktop, "192.168.0.109", "جهاز الديسكتوب");
            CheckDeviceStatus(picRouter, "192.168.0.100", "الراوتر");
            CheckDeviceStatus(picFingerPoint, "192.168.0.109", "جهاز البصمة");
            CheckDeviceStatus(picTelephone, "192.168.0.109", "الهاتف");
            CheckDeviceStatus(picSwi, "192.168.0.109", "السويتش");
        }
        //drw line
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Red, 2);

            // مراكز الصور بناءً على الإحداثيات التي زودتني بها
            Point routerCenter = new Point(584, 267);
            Point phoneCenter = new Point(90, 487);

            g.DrawLine(pen, routerCenter, phoneCenter);



            Graphics g1 = e.Graphics;
            Pen pen1 = new Pen(Color.Green, 2); // لون مختلف للتمييز

            // مركز السويتش
            Point switchCenter = new Point(157, 57);

            // مركز الراوتر
            Point routerCenter1 = new Point(584, 267);

            // رسم الخط
            g1.DrawLine(pen1, switchCenter, routerCenter1);


            Graphics g2 = e.Graphics;
            Pen pen2 = new Pen(Color.Red, 2);

            Point routerCenter3 = new Point(584, 267);
            Point cameraCenter = new Point(1082, 56);
            Point fingerprintCenter = new Point(37, 255);
            Point apCenter = new Point(1075, 516);
            Point desktopCenter = new Point(945, 284);

            // خطوط من كل جهاز إلى الراوتر
            g.DrawLine(pen2, routerCenter3, cameraCenter);
            g.DrawLine(pen2, routerCenter3, fingerprintCenter);
            g.DrawLine(pen2, routerCenter3, apCenter);
            g.DrawLine(pen2, routerCenter3, desktopCenter);
        }

        private void backgroundWorker2_DoWork_1(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
           
        }
    }
}
