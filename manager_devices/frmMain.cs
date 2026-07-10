using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThanVong
{
    public partial class frmMain : Form
    {
        public static bool CONG_TAC = false;
        public static bool Blynk_den_roi = false;
        public static bool bat_dau_hanh_lang = false;
        public static bool Blynk_den_roi_hanh_lang = false;
        public static bool De_4_nguoi = false;
        public static bool De_5_nguoi = false;
        public static bool De_6_nguoi = false;
        public static bool De_7_nguoi = false;
        public static bool De_8_nguoi = false;
        public static bool De_4_1 = false;
        public static bool De_4_2 = false;
        public static bool De_5_1 = false;
        public static bool De_5_2 = false;
        public static bool De_6_1 = false;
        public static bool De_6_2 = false;
        public static bool De_7_1 = false;
        public static bool De_7_2 = false;
        public static bool De_8_1 = false;
        public static bool De_8_2 = false;
        public static bool Den_roi_san_khau = false;
        public static int DAP_AN_DE_4_1 = 512 + 32 + 32768 + 262144;
        public static int DAP_AN_DE_4_2 = 512 + 1024 + 524288 + 262144; // 
        public static int DAP_AN_DE_5_1 = 16384 + 1024 + 32 + 16 + 65536;
        public static int DAP_AN_DE_5_2 = 128 + 8192 + 32768 + 65536 + 1048576;
        public static int DAP_AN_DE_6_1 = 16384 + 4096 + 16 + 32768 + 524288 + 262144;
        public static int DAP_AN_DE_6_2 = 2097152 + 512 + 128 + 1024 + 262144 + 1048576;
        public static int DAP_AN_DE_7_1 = 16384 + 4096 + 1024 + 32 + 16 + 131072 + 1048576;
        public static int DAP_AN_DE_7_2 = 512 + 128 + 2048 + 1024 + 32768 + 524288 + 1048576;
        public static int DAP_AN_DE_8_1 = 2097152 + 16384 + 4096 + 256 + 32 + 524288 + 262144 + 1048576;
        public static int DAP_AN_DE_8_2 = 2097152 + 16384 + 128 + 2048 + 1024 + 64 + 131072 + 1048576;
        public static bool bComPortConnect = false;
        public static string PhongChoIpAdd = "192.168.50.150";
        public static string PhongThoIpAdd = "192.168.50.200";

        public static string SanKhauIpAdd = "192.168.50.159";
        public static string TuDienIpAdd = "192.168.50.153";
        public static string DimmerIpAdd = "192.168.50.154";
        public static string DanTranhIpAdd = "192.168.50.205";
        public static string MayChieuSanKhauIpAdd = "192.168.50.5";
        public static string TiviSanKhauIpAdd = "192.168.50.30";
        public static string TiviTrangdiemTraiIpAdd = "192.168.50.128";
        public static string TiviTrangdiemPhaiIpAdd = "192.168.50.129";

        public static string MaychieuPhongThoIpAdd = "192.168.50.7";
        public static TcpServerConnection PhongCho_Server = new TcpServerConnection(PhongChoIpAdd, 1000, "PHONG_CHO");
        public static TcpServerConnection Dimmer_Server = new TcpServerConnection(DimmerIpAdd, 1000, "DIMMER");
        public static TcpServerConnection Tudien_Server = new TcpServerConnection(TuDienIpAdd, 1000, "TU_DIEN");
        public static TcpServerConnection SanKhau_Server = new TcpServerConnection(SanKhauIpAdd, 1000, "SAN_KHAU");
        public static TcpServerConnection PhongTho_Server = new TcpServerConnection(PhongThoIpAdd, 1000, "PHONG_THO");
        public static TcpServerConnection DanTranh_Server = new TcpServerConnection(DanTranhIpAdd, 1000, "Danh_TRANH");
        public static TcpServerConnection MayChieuSanKhau_Server = new TcpServerConnection(MayChieuSanKhauIpAdd, 8080, "MAY_CHIEU_SAN_KHAU");
        public static TcpServerConnection TiviSanKhau_Server = new TcpServerConnection(TiviSanKhauIpAdd, 8080, "TIVI_SAN_KHAU");
        public static TcpServerConnection TiviTrangDiemTrai_Server = new TcpServerConnection(TiviTrangdiemTraiIpAdd, 8080, "TIVI_TRANG_DIEM_TRAI");
        public static TcpServerConnection TiviTrangDiemPhai_Server = new TcpServerConnection(TiviTrangdiemPhaiIpAdd, 8080, "TIVI_TRANG_DIEM_PHAI");
        public static TcpServerConnection MayChieuPhongTho_Server = new TcpServerConnection(MaychieuPhongThoIpAdd, 8080, "MAY_CHIEU_PHONG_THO");
        // public static    int DEN_CHAO_VANG = 0;
        // public static    int DEN_CHAO_DO = 1;
        // public static    int TU_SAN_KHAU_HANH_LANG = 2;
        // public static    int TU_DAN_KHACH = 3;
        // public static    int DEN_DAU = 4;
        // public static    int TU_CHAO_VAO_THO = 5;
        // public static    int DEN_CHO_TIM = 6;

        // public static    int DEN_SPOT_LIGH_VANG = 7;
        // public static    int DEN_GUONG = 8;
        // public static    int TU_CHO_SAN_KHAU = 9;
        // public static    int DEN_CHOP = 10;
        // public static    int DEN_TIM_SANKHAU = 11;

        // public static    int TU_TU_PHAI_THO = 12;
        // public static    int TU_TU_TRAI_THO = 13;
        // public static    int TU_NGAN_PHAI_THO = 14;
        // public static    int TU_NGAN_TRAI_THO = 15;
        // public static    int TU_TRANG_DIEM_THO = 16;

        // public static    int TU_CUA_PHU = 17;
        // public static    int TU_TU_QUAN_AO = 18;
        // public static    int DEN_TIM_TRANG_DIEM = 19;
        // public static    int DEN_TIM_THO = 20;
        // public static    int DEN_TIM_HANG_LANG = 21;


        public static int DEN_CHAO_VANG = 25;
        public static int DEN_CHAO_DO = 33;
        public static int TU_SAN_KHAU_HANH_LANG = 20;
        public static int TU_DAN_KHACH = 23;
        public static int DEN_DAU = 27;
        public static int TU_CHAO_VAO_THO = 17;
        public static int DEN_CHO_TIM = 39;

        public static int DEN_SPOT_LIGH_VANG = 34;
        public static int DEN_GUONG = 21;
        public static int TU_CHO_SAN_KHAU = 9;
        public static int DEN_CHOP = 28;
        public static int DEN_TIM_SANKHAU = 31;

        public static int TU_TU_PHAI_THO = 38;
        public static int TU_TU_TRAI_THO = 35;
        public static int TU_NGAN_PHAI_THO = 22;
        public static int TU_NGAN_TRAI_THO = 10;
        public static int TU_TRANG_DIEM_THO = 29;

        public static int TU_CUA_PHU = 30;
        public static int TU_TU_QUAN_AO = 37;
        public static int DEN_TIM_TRANG_DIEM = 36;
        public static int DEN_TIM_THO = 19;
        public static int DEN_TIM_HANG_LANG = 11;

        public static int NUT_1 = 11;
        public static int NUT_2 = 10;
        public static int NUT_3 = 9;
        public static int NUT_4 = 23;
        public static int NUT_5 = 19;
        public static int NUT_6 = 22;
        public static int NUT_7 = 21;

        public static int NUT_8 = 20;
        public static int NUT_9 = 36;
        public static int NUT_10 = 35;
        public static int NUT_11 = 34;
        public static int NUT_12 = 33;

        public static int NUT_13 = 37;
        public static int NUT_14 = 38;
        public static int NUT_15 = 39;
        public static int NUT_16 = 25;
        public static int NUT_17 = 30;

        public static int NUT_18 = 31;
        public static int NUT_19 = 17;
        public static int NUT_20 = 27;
        public static int NUT_21 = 29;
        public static int NUT_22 = 28;

        public static int RELAY_1 = 1;
        public static int RELAY_2 = 2;
        public static int RELAY_3 = 3;
        public static int RELAY_4 = 4;
        public static int RELAY_5 = 12;
        public static int RELAY_6 = 13;
        public static int RELAY_7 = 14;
        public static int RELAY_8 = 15;
        public static int RELAY_9 = 26;
        public static int RELAY_10 = 18;


        public frmMain()
        {
            InitializeComponent();
            _ = AutoConnect();
        }

        public static async Task AutoConnect()
        {

            //TcpServerConnection temp = new TcpServerConnection("127.0.0.1", 5678, "Abc");
            await Task.WhenAll(PhongCho_Server.ConnectAsync(), Dimmer_Server.ConnectAsync(), SanKhau_Server.ConnectAsync(), Tudien_Server.ConnectAsync(), PhongTho_Server.ConnectAsync(), DanTranh_Server.ConnectAsync(), MayChieuSanKhau_Server.ConnectAsync(), TiviSanKhau_Server.ConnectAsync(), TiviTrangDiemTrai_Server.ConnectAsync(), TiviTrangDiemPhai_Server.ConnectAsync(), MayChieuPhongTho_Server.ConnectAsync());

            await Task.Delay(-1);
        }

        void PingHost_PhongCho()
        {
            try
            {

                Ping pingSender = new Ping();
                pingSender.PingCompleted += new PingCompletedEventHandler(Ping_PhongCho);
                pingSender.SendAsync(PhongChoIpAdd, 1);
            }
            catch
            {

            }
        }
        void PingHost_DanhTranh()
        {
            try
            {

                Ping pingSender = new Ping();
                pingSender.PingCompleted += new PingCompletedEventHandler(Ping_DanhTranh);
                pingSender.SendAsync(DanTranhIpAdd, 1);
            }
            catch
            {

            }
        }

        void PingHost_PhongTho()
        {
            try
            {

                Ping pingSender = new Ping();
                pingSender.PingCompleted += new PingCompletedEventHandler(Ping_PhongTho);
                pingSender.SendAsync(PhongThoIpAdd, 1);
            }
            catch
            {

            }
        }

        void PingHost_SanKhau()
        {
            try
            {

                Ping pingSender = new Ping();
                pingSender.PingCompleted += new PingCompletedEventHandler(Ping_SanKhau);
                pingSender.SendAsync(SanKhauIpAdd, 1);
            }
            catch
            {

            }
        }

        void PingHost_TuDien()
        {
            try
            {

                Ping pingSender = new Ping();
                pingSender.PingCompleted += new PingCompletedEventHandler(Ping_TuDien);
                pingSender.SendAsync(TuDienIpAdd, 1);
            }
            catch
            {

            }
        }

        void Ping_TuDien(object sender, PingCompletedEventArgs e)
        {
            try
            {

                PingReply reply = e.Reply;
                if (reply.Status != IPStatus.Success)
                {
                    button83.BackColor = Color.Red;
                }
                else
                {
                    button83.BackColor = Color.Green;
                }
                _ = Tudien_Server.SendMessageAsync("APP-YOUR_NAME");
            }
            catch
            {

            }
        }

        void Ping_DanhTranh(object sender, PingCompletedEventArgs e)
        {
            try
            {

                PingReply reply = e.Reply;
                if (reply.Status != IPStatus.Success)
                {
                    button171.BackColor = Color.Red;
                }
                else
                {
                    button171.BackColor = Color.Green;
                }
                _ = DanTranh_Server.SendMessageAsync("APP-YOUR_NAME");
            }
            catch
            {

            }
        }

        void Ping_PhongCho(object sender, PingCompletedEventArgs e)
        {
            try
            {

                PingReply reply = e.Reply;
                if (reply.Status != IPStatus.Success)
                {
                    btnStatusPcb1.BackColor = Color.Red;
                }
                else
                {
                    btnStatusPcb1.BackColor = Color.Green;
                }
                _ = PhongCho_Server.SendMessageAsync("APP-YOUR_NAME");
            }
            catch
            {

            }
        }

        void Ping_PhongTho(object sender, PingCompletedEventArgs e)
        {
            try
            {

                PingReply reply = e.Reply;
                if (reply.Status != IPStatus.Success)
                {
                    button61.BackColor = Color.Red;
                }
                else
                {
                    button61.BackColor = Color.Green;
                }
                _ = PhongTho_Server.SendMessageAsync("APP-YOUR_NAME");
            }
            catch
            {

            }
        }

        void Ping_MayChieuPhongTho(object sender, PingCompletedEventArgs e)
        {
            try
            {

                PingReply reply = e.Reply;
                if (reply.Status != IPStatus.Success)
                {
                    button107.BackColor = Color.Red;
                }
                else
                {
                    button107.BackColor = Color.Green;
                }
                _ = MayChieuPhongTho_Server.SendMessageAsync("APP-YOUR_NAME");
            }
            catch
            {

            }
        }

        void Ping_SanKhau(object sender, PingCompletedEventArgs e)
        {
            try
            {

                PingReply reply = e.Reply;
                if (reply.Status != IPStatus.Success)
                {
                    button137.BackColor = Color.Red;
                }
                else
                {
                    button137.BackColor = Color.Green;
                }
                _ = SanKhau_Server.SendMessageAsync("APP-YOUR_NAME");
            }
            catch
            {

            }
        }


        void Ping_TiviSanKhau(object sender, PingCompletedEventArgs e)
        {
            try
            {

                PingReply reply = e.Reply;
                if (reply.Status != IPStatus.Success)
                {
                    button153.BackColor = Color.Red;
                }
                else
                {
                    button153.BackColor = Color.Green;
                }
                _ = TiviSanKhau_Server.SendMessageAsync("APP-YOUR_NAME");
            }
            catch
            {

            }
        }

        void PingHost_TiviSanKhau()
        {
            try
            {

                Ping pingSender = new Ping();
                pingSender.PingCompleted += new PingCompletedEventHandler(Ping_TiviSanKhau);
                pingSender.SendAsync(TiviSanKhauIpAdd, 1);
            }
            catch
            {

            }
        }

        void Ping_MayChieuSanKhau(object sender, PingCompletedEventArgs e)
        {
            try
            {

                PingReply reply = e.Reply;
                if (reply.Status != IPStatus.Success)
                {
                    button45.BackColor = Color.Red;
                }
                else
                {
                    button45.BackColor = Color.Green;
                }
                _ = MayChieuSanKhau_Server.SendMessageAsync("YOUR_NAME");
            }
            catch
            {

            }
        }

        void PingHost_MayChieuSanKhau()
        {
            try
            {
                Ping pingSender = new Ping();
                pingSender.PingCompleted += new PingCompletedEventHandler(Ping_MayChieuSanKhau);
                pingSender.SendAsync(MayChieuSanKhauIpAdd, 1);
            }
            catch
            {

            }
        }
        void PingHost_MayChieuPhongTho()
        {
            try
            {
                Ping pingSender = new Ping();
                pingSender.PingCompleted += new PingCompletedEventHandler(Ping_MayChieuPhongTho);
                pingSender.SendAsync(MaychieuPhongThoIpAdd, 1);
            }
            catch
            {

            }
        }


        void PingHost_Dimmer()
        {
            try
            {
                Ping pingSender = new Ping();
                pingSender.PingCompleted += new PingCompletedEventHandler(Ping_Dimmer);
                pingSender.SendAsync(DimmerIpAdd, 1);
            }
            catch
            {

            }
        }

        void PingHost_TiviTrangDiemTrai()
        {
            try
            {
                Ping pingSender = new Ping();
                pingSender.PingCompleted += new PingCompletedEventHandler(Ping_TiviTrangDiemTrai);
                pingSender.SendAsync(TiviTrangdiemTraiIpAdd, 1);
            }
            catch
            {

            }
        }

        void PingHost_TiviTrangDiemPhai()
        {
            try
            {
                Ping pingSender = new Ping();
                pingSender.PingCompleted += new PingCompletedEventHandler(Ping_TiviTrangDiemPhai);
                pingSender.SendAsync(TiviTrangdiemPhaiIpAdd, 1);
            }
            catch
            {

            }
        }
        void Ping_Dimmer(object sender, PingCompletedEventArgs e)
        {
            PingReply reply = e.Reply;
            if (reply.Status != IPStatus.Success)
            {
                btnStatusDimmer.BackColor = Color.Red;
            }
            else
            {
                btnStatusDimmer.BackColor = Color.Green;
            }
            _ = Dimmer_Server.SendMessageAsync("APP-YOUR_NAME");
        }

        void Ping_TiviTrangDiemTrai(object sender, PingCompletedEventArgs e)
        {
            PingReply reply = e.Reply;
            if (reply.Status != IPStatus.Success)
            {
                button70.BackColor = Color.Red;
            }
            else
            {
                button70.BackColor = Color.Green;
            }
            _ = TiviTrangDiemTrai_Server.SendMessageAsync("APP-YOUR_NAME");
        }

        void Ping_TiviTrangDiemPhai(object sender, PingCompletedEventArgs e)
        {
            PingReply reply = e.Reply;
            if (reply.Status != IPStatus.Success)
            {
                button62.BackColor = Color.Red;
            }
            else
            {
                button62.BackColor = Color.Green;
            }
            _ = TiviTrangDiemPhai_Server.SendMessageAsync("APP-YOUR_NAME");
        }

        private void timerPing_Tick(object sender, EventArgs e)
        {
            PingHost_Dimmer();
            PingHost_PhongCho();
            PingHost_PhongTho();
            PingHost_SanKhau();
            PingHost_TuDien();
            PingHost_DanhTranh();
            PingHost_TiviSanKhau();
            PingHost_MayChieuSanKhau();
            PingHost_MayChieuPhongTho();
            PingHost_TiviTrangDiemTrai();
            PingHost_TiviTrangDiemPhai();

            if (SetChangeColor)
            {
                countChangeColor++;
                if (countChangeColor > 5)
                {
                    SetChangeColor = false;
                    btnCheckCorrect.Invoke((MethodInvoker)delegate
                    {
                        btnCheckCorrect.BackColor = Color.Gainsboro;
                    });
                }
                else
                {
                    if (countChangeColor % 2 == 0)
                    {
                        btnCheckCorrect.Invoke((MethodInvoker)delegate
                        {
                            btnCheckCorrect.BackColor = Color.Gainsboro;
                        });
                    }
                    else
                    {
                        btnCheckCorrect.Invoke((MethodInvoker)delegate
                        {
                            btnCheckCorrect.BackColor = Color.Blue;
                        });
                    }
                }
            }
        }

        private void soundPlay_Click(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                string temp = btn.Text.Split('.')[0].Trim();
                switch (temp)
                {
                    case "1":
                        {
                            Mp3.PlaySong(Mp3.SOUND_0);
                            break;
                        }
                    case "2":
                        {
                            Mp3.PlaySong(Mp3.SOUND_1);
                            break;
                        }
                    case "3":
                        {
                            Mp3.PlaySong(Mp3.SOUND_2);
                            break;
                        }
                    case "4":
                        {
                            Mp3.PlaySong(Mp3.SOUND_3);
                            break;
                        }
                    case "5":
                        {
                            Mp3.PlaySong(Mp3.SOUND_4);
                            break;
                        }
                    case "6":
                        {
                            Mp3.PlaySong(Mp3.SOUND_5);
                            break;
                        }
                    case "7":
                        {
                            Mp3.PlaySong(Mp3.SOUND_6);
                            break;
                        }
                    case "8":
                        {
                            Mp3.PlaySong(Mp3.SOUND_7);
                            break;
                        }
                    case "9":
                        {
                            Mp3.bPlayCutsen = false;
                            Mp3.PlaySong(Mp3.SOUND_8);
                            break;
                        }
                    case "10":
                        {
                            Mp3.PlaySong(Mp3.SOUND_9);
                            break;
                        }
                    case "11":
                        {
                            Mp3.PlaySong(Mp3.SOUND_10);
                            break;
                        }
                    case "12":
                        {
                            Mp3.PlaySong(Mp3.SOUND_11);
                            break;
                        }
                    case "13":
                        {
                            Mp3.PlaySong(Mp3.SOUND_12);
                            break;
                        }
                    case "14":
                        {
                            Mp3.bPlayCutsen = false;
                            Mp3.PlaySong(Mp3.SOUND_13);
                            break;
                        }
                    case "15":
                        {
                            Mp3.PlaySong(Mp3.SOUND_14);
                            break;
                        }
                    case "16":
                        {
                            Mp3.PlaySong(Mp3.SOUND_15);
                            break;
                        }
                    case "17":
                        {
                            Mp3.bPlayCutsen = false;
                            Mp3.PlaySong(Mp3.SOUND_16);
                            break;
                        }
                    case "18":
                        {
                            Mp3.PlaySong(Mp3.SOUND_17);
                            break;
                        }
                    case "19":
                        {
                            Mp3.PlaySong(Mp3.SOUND_18);
                            break;
                        }
                    case "20":
                        {
                            Mp3.PlaySong(Mp3.SOUND_19);
                            break;
                        }
                    case "21":
                        {
                            Mp3.PlaySong(Mp3.SOUND_20);
                            break;
                        }
                    case "22":
                        {
                            Mp3.PlaySong(Mp3.SOUND_21);
                            break;
                        }
                    case "23":
                        {
                            Mp3.PlaySong(Mp3.SOUND_22);
                            break;
                        }
                    case "24":
                        {
                            Mp3.PlaySong(Mp3.SOUND_23);
                            break;
                        }
                    case "25":
                        {
                            Mp3.PlaySong(Mp3.SOUND_24);
                            break;
                        }
                    case "26":
                        {
                            Mp3.PlaySong(Mp3.SOUND_25);
                            break;
                        }
                    case "27":
                        {
                            Mp3.PlaySong(Mp3.SOUND_26);
                            break;
                        }
                    case "28":
                        {
                            Mp3.PlaySong(Mp3.SOUND_27);
                            break;
                        }
                    case "29":
                        {
                            Mp3.PlaySong(Mp3.SOUND_28);
                            break;
                        }
                    case "30":
                        {
                            Mp3.PlaySong(Mp3.SOUND_29);
                            break;
                        }
                    case "31":
                        {
                            Mp3.PlaySong(Mp3.SOUND_30);
                            break;
                        }
                    case "32":
                        {
                            Mp3.PlaySong(Mp3.SOUND_31);
                            break;
                        }
                    case "33":
                        {
                            Mp3.PlaySong(Mp3.SOUND_32);
                            break;
                        }
                    case "34":
                        {
                            Mp3.PlaySong(Mp3.SOUND_33);
                            break;
                        }
                    case "35":
                        {
                            Mp3.PlaySong(Mp3.SOUND_34);
                            break;
                        }
                    case "36":
                        {
                            Mp3.PlaySong(Mp3.SOUND_35);
                            break;
                        }
                    case "37":
                        {
                            Mp3.PlaySong(Mp3.SOUND_36);
                            break;
                        }
                    case "38":
                        {
                            //   Mp3.bPlayCutsen = false;
                            Mp3.PlaySong(Mp3.SOUND_37);
                            break;
                        }

                    case "39":
                        {
                            //   Mp3.bPlayCutsen = false;
                            Mp3.PlaySong(Mp3.SOUND_38);
                            break;
                        }

                    case "40":
                        {
                            //   Mp3.bPlayCutsen = false;
                            Mp3.PlaySong(Mp3.SOUND_39);
                            break;
                        }

                    case "41":
                        {
                            //   Mp3.bPlayCutsen = false;
                            Mp3.PlaySong(Mp3.SOUND_40);
                            break;
                        }

                    case "42":
                        {
                            //    Mp3.bPlayCutsen = false;
                            Mp3.PlaySong(Mp3.SOUND_41);
                            break;
                        }
                    case "43":
                        {
                            //   Mp3.bPlayCutsen = false;
                            Mp3.PlaySong(Mp3.SOUND_42);
                            break;
                        }
                    case "44":
                        {
                            //    Mp3.bPlayCutsen = false;
                            Mp3.PlaySong(Mp3.SOUND_45);
                            break;
                        }
                    default:
                        break;
                }
            }
            catch
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string temp = btn.Text.Split('.')[0].Trim();
            switch (temp)
            {
                case "1": // Background 1
                    {
                        Mp3.PlayBackground(Mp3.SOUND_0);

                        break;
                    }
                //case "2":
                //    {
                //        Mp3.PlayBackground(Mp3.SOUND_1);
                //        break;
                //    }
                case "3": // Background 3
                    {
                        Mp3.PlayBackground(Mp3.SOUND_2);
                        break;
                    }
                case "4":
                    {
                        Mp3.PlayBackground(Mp3.SOUND_3);
                        break;
                    }
                //case "5":
                //    {
                //        Mp3.PlayBackground(Mp3.SOUND_4);
                //        break;
                //    }
                case "6": // Background 6
                    {
                        Mp3.PlayBackground(Mp3.SOUND_5);
                        break;
                    }
                case "7":
                    {
                        Mp3.PlayBackground(Mp3.SOUND_6);
                        break;
                    }
                case "8":
                    {
                        Mp3.PlayBackground(Mp3.SOUND_7);
                        break;
                    }
                //case "9":
                //    {
                //        Mp3.PlayBackground(Mp3.SOUND_8);
                //        break;
                //    }
                //case "10":
                //    {
                //        Mp3.PlayBackground(Mp3.SOUND_9);
                //        break;
                //    }
                //case "11":
                //    {
                //        Mp3.PlayBackground(Mp3.SOUND_10);
                //        break;
                //    }
                //case "12":
                //    {
                //        Mp3.PlayBackground(Mp3.SOUND_11);
                //        break;
                //    }
                //case "13":
                //    {
                //        Mp3.PlayBackground(Mp3.SOUND_12);
                //        break;
                //    }
                //case "14":
                //    {
                //        Mp3.PlayBackground(Mp3.SOUND_13);
                //        break;
                //    }
                //case "15":
                //    {
                //        Mp3.PlayBackground(Mp3.SOUND_14);
                //        break;
                //    }
                //case "16":
                //    {
                //        Mp3.PlayBackground(Mp3.SOUND_15);
                //        break;
                //    }
                //case "17":
                //    {
                //        Mp3.PlayBackground(Mp3.SOUND_16);
                //        break;
                //    }
                //case "18":
                //    {
                //        Mp3.PlayBackground(Mp3.SOUND_17);
                //        break;
                //    }
                //case "19":
                //    {
                //        Mp3.PlayBackground(Mp3.SOUND_18);
                //        break;
                //    }
                //case "20":
                //    {
                //        Mp3.PlayBackground(Mp3.SOUND_19);
                //        break;
                //    }
                //case "21":
                //    {
                //        Mp3.PlayBackground(Mp3.SOUND_20);
                //        break;
                //    }
                //case "22":
                //    {
                //        Mp3.PlayBackground(Mp3.SOUND_21);
                //        break;
                //    }
                //case "23":
                //    {
                //        Mp3.PlayBackground(Mp3.SOUND_22);
                //        break;
                //    }
                //case "24":
                //    {
                //        Mp3.PlayBackground(Mp3.SOUND_23);
                //        break;
                //    }
                //case "25":
                //    {
                //        Mp3.PlayBackground(Mp3.SOUND_24);
                //        break;
                //    }
                //case "26":
                //    {
                //        Mp3.PlayBackground(Mp3.SOUND_25);
                //        break;
                //    }
                //case "27":
                //    {
                //        Mp3.PlayBackground(Mp3.SOUND_26);
                //        break;
                //    }
                //case "28":
                //    {
                //        Mp3.PlayBackground(Mp3.SOUND_27);
                //        break;
                //    }
                //case "29":
                //    {
                //        Mp3.PlayBackground(Mp3.SOUND_28);
                //        break;
                //    }
                //case "44":
                //    {
                //        Mp3.PlayBackground(Mp3.SOUND_29);
                //        break;
                //    }
                default:
                    break;
            }
        }

        private async void excute_timer2Async()
        {
            try
            {
                if (Mp3.playSound.URL != "")
                {
                    Invoke((MethodInvoker)delegate
                    {
                        lbMusic.Text = Mp3.playSound.URL.Split('\\')[Mp3.playSound.URL.Split('\\').Length - 1];
                    });

                    if (Mp3.playSound.playState == WMPLib.WMPPlayState.wmppsPlaying)
                    {

                        progressMusic.Maximum = (int)Mp3.playSound.currentMedia.duration;
                        progressMusic.Value = (int)Mp3.playSound.controls.currentPosition;
                        picPauseMusic.Image = Properties.Resources.pause;

                        float Onpercent = (float)(progressMusic.Maximum / 100.0);
                        float nowPercent = (float)((Mp3.playSound.controls.currentPosition / Mp3.playSound.currentMedia.duration) * 100.0);
                        //Mp3.playBG.controls.pause();
                        if (nowPercent < 2 * Onpercent)
                        {
                            Mp3.playBG.settings.volume = 35;
                            Mp3.playSound.settings.volume = 65;
                        }
                        else if (nowPercent < 4 * Onpercent)
                        {
                            Mp3.playBG.settings.volume = 30;
                            Mp3.playSound.settings.volume = 70;
                        }
                        else if (nowPercent < 6 * Onpercent)
                        {
                            Mp3.playBG.settings.volume = 25;
                            Mp3.playSound.settings.volume = 75;
                        }
                        else if (nowPercent < 8 * Onpercent)
                        {
                            Mp3.playBG.settings.volume = 20;
                            Mp3.playSound.settings.volume = 80;
                        }
                        else if (nowPercent < 9 * Onpercent)
                        {
                            Mp3.playBG.settings.volume = 15;
                            Mp3.playSound.settings.volume = 85;
                        }
                        else if (nowPercent < 10 * Onpercent)
                        {
                            Mp3.playBG.settings.volume = 10;
                            Mp3.playSound.settings.volume = 90;
                        }
                        else if ((nowPercent > 10 * Onpercent) && (nowPercent < 90))
                        {
                            Mp3.playBG.settings.volume = 0;
                            Mp3.playSound.settings.volume = 95;
                        }

                        else if (nowPercent >= 90 * Onpercent)
                        {
                            Mp3.playBG.settings.volume = 50;
                            Mp3.playSound.settings.volume = 50;
                        }
                        else if (nowPercent > 92 * Onpercent)
                        {
                            Mp3.playBG.settings.volume = 60;
                            Mp3.playSound.settings.volume = 40;
                        }
                        else if (nowPercent > 94 * Onpercent)
                        {
                            Mp3.playBG.settings.volume = 70;
                            Mp3.playSound.settings.volume = 30;
                        }
                        else if (nowPercent > 96 * Onpercent)
                        {
                            Mp3.playBG.settings.volume = 80;
                            Mp3.playSound.settings.volume = 20;
                        }
                        else if (nowPercent > 98 * Onpercent)
                        {
                            Mp3.playBG.settings.volume = 90;
                            Mp3.playSound.settings.volume = 10;
                        }
                        else if (nowPercent >= 100 * Onpercent)
                        {
                            Mp3.playBG.settings.volume = 100;
                            Mp3.playSound.settings.volume = 0;
                        }

                    }
                    else
                    {
                        Mp3.playBG.settings.volume = 100;
                        Mp3.playSound.settings.volume = 0;
                        picPauseMusic.Image = Properties.Resources._continue;
                        if (progressMusic.Value == progressMusic.Maximum)
                            progressMusic.Value = 0;
                    }
                }

                if (Mp3.playBG.URL != "")
                {
                    Invoke((MethodInvoker)delegate
                    {
                        lbSoundBG.Text = Mp3.playBG.URL.Split('\\')[Mp3.playBG.URL.Split('\\').Length - 1]; ;
                    });

                    if (Mp3.playBG.playState == WMPLib.WMPPlayState.wmppsPlaying)
                    {
                        progressBG.Maximum = (int)Mp3.playBG.currentMedia.duration;
                        progressBG.Value = (int)Mp3.playBG.controls.currentPosition;
                        picPauseBG.Image = Properties.Resources.pause;
                    }
                    else
                    {
                        picPauseBG.Image = Properties.Resources._continue;
                        if (progressBG.Value == progressBG.Maximum)
                            progressBG.Value = 0;
                    }
                }
            }
            catch
            { }

        }

        private void timer2_TickAsync(object sender, EventArgs e)
        {
            excute_timer2Async();
        }

        private void picPauseBG_Click(object sender, EventArgs e)
        {
            if (Mp3.playBG.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                Mp3.playBG.controls.pause();
                Mp3.backGroundisPlaying = false;
            }
            else
            {
                Mp3.playBG.controls.play();
                Mp3.backGroundisPlaying = true;
            }
        }

        private void picPauseMusic_Click(object sender, EventArgs e)
        {
            if (Mp3.playSound.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                Mp3.playSound.controls.pause();
            }
            else
            {
                Mp3.playSound.controls.play();
            }
        }

        private void picStopBG_Click(object sender, EventArgs e)
        {
            Mp3.playBG.controls.stop();
            progressBG.Value = 0;
            Mp3.backGroundisPlaying = false;
        }

        private void picStopMusic_Click(object sender, EventArgs e)
        {
            Mp3.playSound.controls.stop();
            progressMusic.Value = 0;
        }

        private void button29_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string percent = btn.Text.Split('%')[0];
            _ = Dimmer_Server.SendMessageAsync("DIMMER-SET-" + percent);
        }

        private void btnConnectDimmer_Click(object sender, EventArgs e)
        {
            // _=DimmerConnect();
        }


        private void btnStartHand_Click(object sender, EventArgs e)
        {
            //dong tu dan khach
            //dong tu ban tho
            //dong tu san khau
            //tat den tim phong cho
            //tat den do phong cho
            _ = PhongCho_Server.SendMessageAsync("PHONG_CHO-START_GAME");
            Mp3.PlaySong(Mp3.SOUND_4);

        }

        private void btnResetHand_Click(object sender, EventArgs e)
        {
            btnStartHand.BackColor = Color.Gainsboro;
            btnWinHand.BackColor = Color.Gainsboro;
            btnWinHand.Text = "Thắng game";
            Mp3.playSound.controls.stop();
            _ = PhongCho_Server.SendMessageAsync("PHONG_CHO-RESET_GAME");
        }

        private void btnWinHand_Click(object sender, EventArgs e)
        {
            _ = PhongCho_Server.SendMessageAsync("PHONG_CHO-WIN_GAME");

        }

        private void button42_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void button48_Click(object sender, EventArgs e)
        {
            _ = frmMain.PhongCho_Server.SendMessageAsync("RESET_PCB");

            De_4_nguoi = false;
            De_5_nguoi = false;
            De_6_nguoi = false;
            De_7_nguoi = false;
            De_8_nguoi = false;
            button129.BackColor = Color.Gainsboro;
            button130.BackColor = Color.Gainsboro;
            button131.BackColor = Color.Gainsboro;
            button132.BackColor = Color.Gainsboro;
            button133.BackColor = Color.Gainsboro;

            De_4_1 = false;
            De_4_2 = false;
            De_5_1 = false;
            De_5_2 = false;
            De_6_1 = false;
            De_6_2 = false;
            De_7_1 = false;
            De_7_2 = false;
            De_8_1 = false;
            De_8_2 = false;
            button145.BackColor = Color.Gainsboro;
            button144.BackColor = Color.Gainsboro;
            button146.BackColor = Color.Gainsboro;
            button147.BackColor = Color.Gainsboro;
            button148.BackColor = Color.Gainsboro;
            button149.BackColor = Color.Gainsboro;
            button34.BackColor = Color.Gainsboro;
            button150.BackColor = Color.Gainsboro;
            button151.BackColor = Color.Gainsboro;
            button152.BackColor = Color.Gainsboro;

            btnStartHand.BackColor = Color.Gainsboro;

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Text = "Oán Vũ v083";

            try
            {
                serialPort1.Open();
            }
            catch (Exception ex)
            {
                Log.Error("Lỗi kết nối mạch remote: " + ex.ToString());
                MessageBox.Show("Lỗi kết nối mạch remote: " + ex.ToString());
            }
            button122.Enabled = false;
            button156.Text = "Tắt UV";
            trackBar1.Value = 100;
            button121.Visible = false;

            button68.Text = "-";
            button84.Text = "-";
            button105.Text = "-";
            button101.Text = "-";
            button108.Text = "-";
        }

        private void button50_Click(object sender, EventArgs e)
        {
            if (button50.BackColor == Color.Gainsboro)
            {
                _ = PhongCho_Server.SendMessageAsync("PHONG_CHO-ON_UV");
            }
            else
            {
                _ = PhongCho_Server.SendMessageAsync("PHONG_CHO-OFF_UV");
            }
        }

        private void button49_Click(object sender, EventArgs e)
        {
            if (button49.BackColor == Color.Gainsboro)
            {
                _ = PhongCho_Server.SendMessageAsync("PHONG_CHO-TU_QUAY_VE_OFF");
            }
            else
            {
                _ = PhongCho_Server.SendMessageAsync("PHONG_CHO-TU_QUAY_VE_ON");
            }
        }

        private void button51_Click(object sender, EventArgs e)
        {
            //show dap an uv
            Answer_UV a = new Answer_UV();
            a.ShowDialog();
        }


        public static bool isPlayMusicDoaMa = false;
        private void button46_Click_1(object sender, EventArgs e)
        {
            //isPlayMusicDoaMa = false;
            //if (button144.)
            //{
            //    MessageBox.Show("Bạn hãy chọn đề phù hợp với số lượng người chơi");
            //}
            //else
            //{
            _ = Tudien_Server.SendMessageAsync("ON-" + NUT_3.ToString()); // Bat den nen tivi
            _ = PhongCho_Server.SendMessageAsync("SAN_KHAU-START_GAME");
            Mp3.PlaySong(Mp3.SOUND_11);
            string exampl = "";
            if (De_4_1 == true)
            {
                exampl = "DE_4NG_1";
            }
            else if (De_4_2 == true)
            {
                exampl = "DE_4NG_2";
            }
            else if (De_5_1 == true)
            {
                exampl = "DE_5NG_1";
            }
            else if (De_5_2 == true)
            {
                exampl = "DE_5NG_2";
            }
            else if (De_6_1 == true)
            {
                exampl = "DE_6NG_1";
            }
            else if (De_6_2 == true)
            {
                exampl = "DE_6NG_2";
            }
            else if (De_7_1 == true)
            {
                exampl = "DE_7NG_1";
            }
            else if (De_7_2 == true)
            {
                exampl = "DE_7NG_2";
            }
            else if (De_8_1 == true)
            {
                exampl = "DE_8NG_1";
            }
            else if (De_8_2 == true)
            {
                exampl = "DE_8NG_2";
            }
            _ = TiviSanKhau_Server.SendMessageAsync(exampl);


            //           }
        }

        private void button34_Click_1(object sender, EventArgs e)
        {
            Chair t = new Chair();
            t.ShowDialog();
        }

        private void button44_Click(object sender, EventArgs e)
        {

            button46.BackColor = Color.Gainsboro;
            button43.BackColor = Color.Gainsboro;
            _ = PhongCho_Server.SendMessageAsync("SAN_KHAU-RESET_GAME");
        }

        private void button43_Click(object sender, EventArgs e)
        {
            _ = PhongCho_Server.SendMessageAsync("SAN_KHAU-WIN_GAME");
        }

        private void button45_Click(object sender, EventArgs e)
        {
            _ = PhongCho_Server.SendMessageAsync("RESET_PCB");
        }

        private void button87_Click(object sender, EventArgs e)
        {
            if (button87.BackColor == Color.Gainsboro)
            {
                //serialPort1.Write("APP-ON-" + DEN_CHO_TIM.ToString() + "\r\n");
                _ = Tudien_Server.SendMessageAsync("ON-" + NUT_19.ToString());
            }
            else
            {
                //serialPort1.Write("APP-OFF-" + DEN_CHO_TIM.ToString() + "\r\n");
                _ = Tudien_Server.SendMessageAsync("OFF-" + NUT_19.ToString());
            }

        }

        private void button63_Click(object sender, EventArgs e)
        {
            if (button63.BackColor == Color.Gainsboro)
            {
                //serialPort1.Write("APP-ON-" + TU_CHAO_VAO_THO.ToString() + "\r\n");
                _ = Tudien_Server.SendMessageAsync("ON-" + NUT_11.ToString());
            }
            else
            {
                //serialPort1.Write("APP-OFF-" + TU_CHAO_VAO_THO.ToString() + "\r\n");
                _ = Tudien_Server.SendMessageAsync("OFF-" + NUT_11.ToString());
            }
        }

        private void button38_Click(object sender, EventArgs e)
        {
            if (button38.BackColor == Color.Gainsboro)
            {
                //serialPort1.Write("APP-ON-" + TU_DAN_KHACH.ToString() + "\r\n");
                _ = Tudien_Server.SendMessageAsync("ON-" + NUT_21.ToString());
            }
            else
            {
                //serialPort1.Write("APP-OFF-" + TU_DAN_KHACH.ToString() + "\r\n");
                _ = Tudien_Server.SendMessageAsync("OFF-" + NUT_21.ToString());
            }
        }

        private void button33_Click(object sender, EventArgs e)
        {
            if (button33.BackColor == Color.Gainsboro)
            {
                //serialPort1.Write("APP-ON-" + TU_SAN_KHAU_HANH_LANG.ToString() + "\r\n");
                _ = Tudien_Server.SendMessageAsync("ON-" + NUT_4.ToString());
            }
            else
            {
                //serialPort1.Write("APP-OFF-" + TU_SAN_KHAU_HANH_LANG.ToString() + "\r\n");
                _ = Tudien_Server.SendMessageAsync("OFF-" + NUT_4.ToString());
            }
        }

        private void button85_Click(object sender, EventArgs e)
        {
            if (button85.BackColor == Color.Gainsboro)
            {
                //serialPort1.Write("APP-ON-" + TU_TU_PHAI_THO.ToString() + "\r\n");
                _ = Tudien_Server.SendMessageAsync("ON-" + NUT_20.ToString());
            }
            else
            {
                //serialPort1.Write("APP-OFF-" + TU_TU_PHAI_THO.ToString() + "\r\n");
                _ = Tudien_Server.SendMessageAsync("OFF-" + NUT_20.ToString());
            }
        }

        private void button81_Click(object sender, EventArgs e)
        {
            if (button81.BackColor == Color.Gainsboro)
            {
                //serialPort1.Write("APP-ON-" + TU_CHO_SAN_KHAU.ToString() + "\r\n");
                _ = Tudien_Server.SendMessageAsync("ON-" + NUT_9.ToString());
            }
            else
            {
                //serialPort1.Write("APP-OFF-" + TU_CHO_SAN_KHAU.ToString() + "\r\n");
                _ = Tudien_Server.SendMessageAsync("OFF-" + NUT_9.ToString());
            }
        }

        private void button64_Click(object sender, EventArgs e)
        {
            if (button64.BackColor == Color.Gainsboro)
            {
                //serialPort1.Write("APP-ON-" + DEN_CHOP.ToString() + "\r\n");
                _ = Tudien_Server.SendMessageAsync("ON-" + NUT_16.ToString());
            }
            else
            {
                //serialPort1.Write("APP-OFF-" + DEN_CHOP.ToString() + "\r\n");
                _ = Tudien_Server.SendMessageAsync("OFF-" + NUT_16.ToString());
            }
        }

        private void button86_Click(object sender, EventArgs e)
        {
            if (button86.BackColor == Color.Gainsboro)
            {
                //serialPort1.Write("APP-ON-" + DEN_TIM_SANKHAU.ToString() + "\r\n");
                _ = Tudien_Server.SendMessageAsync("ON-" + NUT_18.ToString());
            }
            else
            {
                //serialPort1.Write("APP-OFF-" + DEN_TIM_SANKHAU.ToString() + "\r\n");
                _ = Tudien_Server.SendMessageAsync("OFF-" + NUT_18.ToString());
            }
        }

        private void button88_Click(object sender, EventArgs e)
        {
            if (button88.BackColor == Color.Gainsboro)
            {
                //serialPort1.Write("APP-ON-" + TU_TRANG_DIEM_THO.ToString() + "\r\n");
                _ = Tudien_Server.SendMessageAsync("ON-" + NUT_10.ToString());
            }
            else
            {
                //serialPort1.Write("APP-OFF-" + TU_TRANG_DIEM_THO.ToString() + "\r\n");
                _ = Tudien_Server.SendMessageAsync("OFF-" + NUT_10.ToString());
            }
        }

        private void button94_Click(object sender, EventArgs e)
        {
            if (button94.BackColor == Color.Gainsboro)
            {
                //serialPort1.Write("APP-ON-" + TU_NGAN_TRAI_THO.ToString() + "\r\n");
                _ = Tudien_Server.SendMessageAsync("ON-" + NUT_2.ToString());
            }
            else
            {
                //serialPort1.Write("APP-OFF-" + TU_NGAN_TRAI_THO.ToString() + "\r\n");
                _ = Tudien_Server.SendMessageAsync("OFF-" + TU_NGAN_TRAI_THO.ToString());
            }
        }

        private void button95_Click(object sender, EventArgs e)
        {
            if (button95.BackColor == Color.Gainsboro)
            {
                //serialPort1.Write("APP-ON-" + TU_NGAN_PHAI_THO.ToString() + "\r\n");
                _ = Tudien_Server.SendMessageAsync("ON-" + NUT_6.ToString());
            }
            else
            {
                //serialPort1.Write("APP-OFF-" + TU_NGAN_PHAI_THO.ToString() + "\r\n");
                _ = Tudien_Server.SendMessageAsync("OFF-" + NUT_6.ToString());
            }
        }

        private void button96_Click(object sender, EventArgs e)
        {
            if (button96.BackColor == Color.Gainsboro)
            {
                //serialPort1.Write("APP-ON-" + TU_TU_TRAI_THO.ToString() + "\r\n");
                _ = Tudien_Server.SendMessageAsync("ON-" + NUT_3.ToString());
            }
            else
            {
                //serialPort1.Write("APP-OFF-" + TU_TU_TRAI_THO.ToString() + "\r\n");
                _ = Tudien_Server.SendMessageAsync("OFF-" + NUT_3.ToString());
            }
        }

        private void button97_Click(object sender, EventArgs e)
        {
            if (button97.BackColor == Color.Gainsboro)
            {
                //serialPort1.Write("APP-ON-" + TU_TU_PHAI_THO.ToString() + "\r\n");
                _ = Tudien_Server.SendMessageAsync("ON-" + NUT_7.ToString());
            }
            else
            {
                //serialPort1.Write("APP-OFF-" + TU_TU_PHAI_THO.ToString() + "\r\n");
                _ = Tudien_Server.SendMessageAsync("OFF-" + NUT_7.ToString());
            }
        }

        private void button93_Click(object sender, EventArgs e)
        {
            if (button93.BackColor == Color.Gainsboro)
            {
                //serialPort1.Write("APP-ON-" + TU_CUA_PHU.ToString() + "\r\n");
                _ = Tudien_Server.SendMessageAsync("ON-" + NUT_1.ToString());
            }
            else
            {
                //serialPort1.Write("APP-OFF-" + TU_CUA_PHU.ToString() + "\r\n");
                _ = Tudien_Server.SendMessageAsync("OFF-" + NUT_1.ToString());
            }
        }

        private void button92_Click(object sender, EventArgs e)
        {
            if (button92.BackColor == Color.Gainsboro)
            {
                //serialPort1.Write("APP-ON-" + TU_TU_QUAN_AO.ToString() + "\r\n");
                _ = Tudien_Server.SendMessageAsync("ON-" + NUT_5.ToString());
            }
            else
            {
                //serialPort1.Write("APP-OFF-" + TU_TU_QUAN_AO.ToString() + "\r\n");
                _ = Tudien_Server.SendMessageAsync("OFF-" + NUT_5.ToString());
                // Mp3.PlaySong(Mp3.SOUND_36);
            }
        }

        private void button91_Click(object sender, EventArgs e)
        {
            if (button91.BackColor == Color.Gainsboro)
            {
                //serialPort1.Write("APP-ON-" + DEN_TIM_TRANG_DIEM.ToString() + "\r\n");
                _ = Tudien_Server.SendMessageAsync("ON-" + NUT_17.ToString());
            }
            else
            {
                //serialPort1.Write("APP-OFF-" + DEN_TIM_TRANG_DIEM.ToString() + "\r\n");
                _ = Tudien_Server.SendMessageAsync("OFF-" + NUT_17.ToString());
            }
        }

        private void button90_Click(object sender, EventArgs e)
        {
            if (button90.BackColor == Color.Gainsboro)
            {
                //serialPort1.Write("APP-ON-" + DEN_TIM_THO.ToString() + "\r\n");
                _ = Tudien_Server.SendMessageAsync("ON-" + NUT_14.ToString());
            }
            else
            {
                //serialPort1.Write("APP-OFF-" + DEN_TIM_THO.ToString() + "\r\n");
                _ = Tudien_Server.SendMessageAsync("OFF-" + NUT_14.ToString());
            }
        }

        private void button89_Click(object sender, EventArgs e)
        {
            if (button89.BackColor == Color.Gainsboro)
            {
                //serialPort1.Write("APP-ON-" + DEN_TIM_HANG_LANG.ToString() + "\r\n");
                _ = Tudien_Server.SendMessageAsync("ON-" + NUT_13.ToString());
            }
            else
            {
                //serialPort1.Write("APP-OFF-" + DEN_TIM_HANG_LANG.ToString() + "\r\n");
                _ = Tudien_Server.SendMessageAsync("OFF-" + NUT_13.ToString());
            }
        }

        string strRxStr = "";

        bool remote3Cpress = false;
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            strRxStr = serialPort1.ReadLine();
            serialPort1.DiscardOutBuffer();
            serialPort1.DiscardInBuffer();
            richTextBox1.Invoke((MethodInvoker)delegate
            {
                richTextBox1.Text += strRxStr.Trim() + "\r\n";
                frmMain.richTextBox1.SelectionStart = frmMain.richTextBox1.Text.Length;
                frmMain.richTextBox1.ScrollToCaret();
            });

            try
            {
                switch (strRxStr.Trim())
                {

                    ///////// DK_1 /////////
                    case "11AP":
                        {
                            //on off đèn tổng - tắt cả các đèn chiếu sáng
                            _ = Tudien_Server.SendMessageAsync("TOGGLE_LIGHT");
                            Mp3.PlaySong(Mp3.SOUND_47);
                            break;
                        }
                    case "11AH":
                        {
                            //on off đèn tổng - tắt cả các đèn chiếu sáng
                            _ = Tudien_Server.SendMessageAsync("TOGGLE_LIGHT");

                            if ((button90.BackColor == Color.Gainsboro) || (button90.BackColor == Color.Gainsboro))
                            {
                                //am thanh bat ngo
                                Mp3.PlaySong(Mp3.SOUND_47);
                            }
                            else
                            {
                                //am thanh bat ngo
                                Mp3.StopMusic();
                            }
                            break;
                        }
                    case "11BP":
                        {
                            //tonggle cửa từ sân khấu -> hành lang
                            if (button88.BackColor == Color.Gainsboro)
                            {
                                //serialPort1.Write("APP-ON-" + TU_TRANG_DIEM_THO.ToString() + "\r\n");
                                _ = Tudien_Server.SendMessageAsync("ON-" + NUT_10.ToString());
                            }
                            else
                            {
                                //serialPort1.Write("APP-OFF-" + TU_TRANG_DIEM_THO.ToString() + "\r\n");
                                _ = Tudien_Server.SendMessageAsync("OFF-" + NUT_10.ToString());
                            }
                            break;
                        }
                    case "11BH":
                        {
                            //tonggle cửa từ thờ -> phòng vé
                            if (button120.BackColor == Color.Gainsboro)
                            {
                                //serialPort1.Write("APP-ON-" + TU_TU_PHAI_THO.ToString() + "\r\n");
                                _ = Tudien_Server.SendMessageAsync("ON-" + RELAY_5.ToString());
                            }
                            else
                            {
                                //serialPort1.Write("APP-OFF-" + TU_TU_PHAI_THO.ToString() + "\r\n");
                                _ = Tudien_Server.SendMessageAsync("OFF-" + RELAY_5.ToString());
                            }
                            break;
                        }
                    case "11CP":
                        {
                            //bat tat den chop + am thanh ma ghe san khau
                            if (button72.BackColor == Color.Gainsboro)
                            {
                                //serialPort1.Write("APP-ON-" + TU_TU_PHAI_THO.ToString() + "\r\n");
                                _ = Tudien_Server.SendMessageAsync("ON-" + NUT_22.ToString());
                                //âm thanh dọa ma
                                Mp3.PlaySong(Mp3.SOUND_10);
                                _ = Tudien_Server.SendMessageAsync("OFF-" + NUT_15.ToString());
                            }
                            else
                            {
                                //serialPort1.Write("APP-OFF-" + TU_TU_PHAI_THO.ToString() + "\r\n");
                                _ = Tudien_Server.SendMessageAsync("OFF-" + NUT_22.ToString());
                                Mp3.StopMusic();
                            }

                            _ = PhongCho_Server.SendMessageAsync("PHONG_CHO-REMOTE_3C_TAT_UV");
                            break;
                        }
                    case "11CH":
                        {
                            _ = Tudien_Server.SendMessageAsync("OFF-" + NUT_22.ToString());
                            Mp3.StopMusic();
                            _ = Tudien_Server.SendMessageAsync("ON-" + NUT_15.ToString());

                            break;
                        }
                    case "11DP":
                        {
                            //bat am thanh doa chai toc het am thanh thi tat roi - tra lai den he hong
                            Mp3.PlaySong(Mp3.SOUND_28);
                            _ = Tudien_Server.SendMessageAsync("WAIT_TAT_ROI_TRANG_DIEM");
                            break;
                        }
                    case "11DH":
                        {
                            Mp3.PlaySong(Mp3.SOUND_28);
                            _ = Tudien_Server.SendMessageAsync("WAIT_TAT_ROI_TRANG_DIEM");
                            break;
                        }

                    ///////// DK_2 /////////
                    case "12AP":
                        {
                            //on off đèn tổng - tắt cả các đèn chiếu sáng
                            _ = Tudien_Server.SendMessageAsync("TOGGLE_LIGHT");
                            Mp3.PlaySong(Mp3.SOUND_47);
                            break;
                        }
                    case "12AH":
                        {
                            //on off đèn tổng - tắt cả các đèn chiếu sáng
                            _ = Tudien_Server.SendMessageAsync("TOGGLE_LIGHT");

                            if ((button90.BackColor == Color.Gainsboro) || (button90.BackColor == Color.Gainsboro))
                            {
                                //am thanh bat ngo
                                Mp3.PlaySong(Mp3.SOUND_47);
                            }
                            else
                            {
                                //am thanh bat ngo
                                Mp3.StopMusic();
                            }
                            break;
                        }
                    case "12BP":
                        {
                            //tonggle cửa từ thờ -> sân khấu
                            if (button63.BackColor == Color.Gainsboro)
                            {
                                //serialPort1.Write("APP-ON-" + TU_CHAO_VAO_THO.ToString() + "\r\n");
                                _ = Tudien_Server.SendMessageAsync("ON-" + NUT_11.ToString());
                            }
                            else
                            {
                                //serialPort1.Write("APP-OFF-" + TU_CHAO_VAO_THO.ToString() + "\r\n");
                                _ = Tudien_Server.SendMessageAsync("OFF-" + NUT_11.ToString());
                            }

                            break;
                        }
                    case "12BH":
                        {
                            //tonggle cửa từ thờ -> sân khấu
                            if (button63.BackColor == Color.Gainsboro)
                            {
                                //serialPort1.Write("APP-ON-" + TU_CHAO_VAO_THO.ToString() + "\r\n");
                                _ = Tudien_Server.SendMessageAsync("ON-" + NUT_11.ToString());
                            }
                            else
                            {
                                //serialPort1.Write("APP-OFF-" + TU_CHAO_VAO_THO.ToString() + "\r\n");
                                _ = Tudien_Server.SendMessageAsync("OFF-" + NUT_11.ToString());
                            }
                            break;
                        }
                    case "12CP":
                        {
                            //bat tat den chop + am thanh ma ghe san khau
                            if (button72.BackColor == Color.Gainsboro)
                            {
                                //serialPort1.Write("APP-ON-" + TU_TU_PHAI_THO.ToString() + "\r\n");
                                _ = Tudien_Server.SendMessageAsync("ON-" + NUT_22.ToString());
                                //âm thanh dọa ma
                                Mp3.PlaySong(Mp3.SOUND_10);
                                _ = Tudien_Server.SendMessageAsync("OFF-" + NUT_15.ToString());
                            }
                            else
                            {
                                //serialPort1.Write("APP-OFF-" + TU_TU_PHAI_THO.ToString() + "\r\n");
                                _ = Tudien_Server.SendMessageAsync("OFF-" + NUT_22.ToString());
                                Mp3.StopMusic();
                            }

                            _ = PhongCho_Server.SendMessageAsync("PHONG_CHO-REMOTE_3C_TAT_UV");
                            break;
                        }
                    case "12CH":
                        {
                            _ = Tudien_Server.SendMessageAsync("ON-" + NUT_15.ToString());
                            Mp3.StopMusic();
                            break;
                        }
                    case "12DP":
                        {
                            //thông báo cho phòng kỹ thuật là đúng hoặc sai
                            countChangeColor = 0;
                            SetChangeColor = true;
                            break;
                        }
                    case "12DH":
                        {
                            break;
                        }

                    ///////// DK_3 /////////
                    case "13AP":
                        {
                            //on off đèn tổng - tắt cả các đèn chiếu sáng
                            _ = Tudien_Server.SendMessageAsync("TOGGLE_LIGHT");
                            Mp3.PlaySong(Mp3.SOUND_47);
                            break;
                        }
                    case "13AH":
                        {

                            break;
                        }
                    case "13BP":
                        {
                            //Blynk_den_roi_hanh_lang = !Blynk_den_roi_hanh_lang;
                            //if (Blynk_den_roi_hanh_lang == true)
                            //{
                            //    _ = Tudien_Server.SendMessageAsync("BLYNK_DEN_ROI_HANH_LANG");
                            //}
                            //else
                            //{
                            //    _ = Tudien_Server.SendMessageAsync("NOT_BLYNK_DEN_ROI_HANH_LANG");
                            //}

                            // den roi chop tat
                            if (remote3Cpress == false)
                            {
                                //serialPort1.Write("APP-ON-" + DEN_TIM_TRANG_DIEM.ToString() + "\r\n");
                                _ = Tudien_Server.SendMessageAsync("BLYNK_DEN_ROI_HANH_LANG");
                                Mp3.StopBackground();
                                Mp3.PlaySong(Mp3.SOUND_17);
                                button91.BackColor = Color.Green;
                                remote3Cpress = true;
                            }
                            else
                            {
                                //serialPort1.Write("APP-OFF-" + DEN_TIM_TRANG_DIEM.ToString() + "\r\n");
                                _ = Tudien_Server.SendMessageAsync("NOT_BLYNK_DEN_ROI_HANH_LANG");
                                Thread.Sleep(50);
                                _ = Tudien_Server.SendMessageAsync("OFF-" + NUT_17.ToString());
                                Mp3.PlaySong(Mp3.SOUND_17);
                                remote3Cpress = false;
                            }

                            break;
                        }
                    case "13BH":
                        {
                            //on den roi ko chop chat
                            _ = Tudien_Server.SendMessageAsync("NOT_BLYNK_DEN_ROI_HANH_LANG");
                            Thread.Sleep(50);
                            _ = Tudien_Server.SendMessageAsync("ON-" + NUT_17.ToString());

                            break;
                        }
                    case "13CP":
                        {
                            //âm thanh ma so ra hết âm thanh thì tắt đèn rọi cửa xoay
                            _ = Tudien_Server.SendMessageAsync("NOT_BLYNK_DEN_ROI_HANH_LANG");
                            Thread.Sleep(50);
                            _ = Tudien_Server.SendMessageAsync("OFF-" + NUT_17.ToString());
                            Mp3.PlaySong(Mp3.SOUND_18);
                            _ = Tudien_Server.SendMessageAsync("WAIT_TAT_ROI_CUA_XOAY");
                            break;
                        }
                    case "13CH":
                        {
                            break;
                        }
                    case "13DP":
                        {
                            //win mạch dậy nhảy
                            break;
                        }
                    case "13DH":
                        {
                            break;
                        }

                    ///////// DK_4 /////////
                    case "14AP":
                        {
                            //on off đèn tổng - tắt cả các đèn chiếu sáng
                            _ = Tudien_Server.SendMessageAsync("TOGGLE_LIGHT");
                            break;
                        }
                    case "14AH":
                        {

                            break;
                        }
                    case "14BP":
                        {
                            //toggle đèn rọi của xoay + âm thanh dọa ma
                            break;
                        }
                    case "14BH":
                        {
                            break;
                        }
                    case "14CP":
                        {
                            //toggle máy khói đàn tranh
                            break;
                        }
                    case "14CH":
                        {
                            break;
                        }
                    case "14DP":
                        {
                            //toggle âm thanh dọa ma
                            break;
                        }
                    case "14DH":
                        {
                            break;
                        }

                }
            }
            catch (Exception ex)
            {
                Log.Info("Remote Send: " + ex);
            }
        }

        // public static    void Tu_Dien_Handle_Message(string strRxStr)
        //{
        //    if (strRxStr.Contains("ON") || strRxStr.Contains("OFF"))
        //    {
        //        try
        //        {
        //            string temp = strRxStr.Split('-')[2].Trim();

        //            switch (temp)
        //            {
        //                case "0":
        //                    {
        //                        if (strRxStr.Contains("ON"))
        //                        {
        //                            button99.Invoke((MethodInvoker)delegate
        //                            {
        //                                button99.BackColor = Color.Green;
        //                            });

        //                        }
        //                        else
        //                        {
        //                            button99.Invoke((MethodInvoker)delegate
        //                            {
        //                                button99.BackColor = Color.Gainsboro;
        //                            });
        //                        }
        //                        break;
        //                    }
        //                case "1":
        //                    {
        //                        if (strRxStr.Contains("ON"))
        //                        {
        //                            button98.Invoke((MethodInvoker)delegate
        //                            {
        //                                button98.BackColor = Color.Green;
        //                            });
        //                        }
        //                        else
        //                        {
        //                            button98.Invoke((MethodInvoker)delegate
        //                            {
        //                                button98.BackColor = Color.Gainsboro;
        //                            });
        //                        }
        //                        break;
        //                    }
        //                case "2":
        //                    {
        //                        if (strRxStr.Contains("ON"))
        //                        {
        //                            button33.Invoke((MethodInvoker)delegate
        //                            {
        //                                button33.BackColor = Color.Green;
        //                            });
        //                        }
        //                        else
        //                        {
        //                            button33.Invoke((MethodInvoker)delegate
        //                            {
        //                                button33.BackColor = Color.Gainsboro;
        //                            });
        //                        }
        //                        break;
        //                    }
        //                case "3":
        //                    {
        //                        if (strRxStr.Contains("ON"))
        //                        {
        //                            button38.Invoke((MethodInvoker)delegate
        //                            {
        //                                button38.BackColor = Color.Green;
        //                            });
        //                        }
        //                        else
        //                        {
        //                            button38.Invoke((MethodInvoker)delegate
        //                            {
        //                                button38.BackColor = Color.Gainsboro;
        //                            });
        //                        }
        //                        break;
        //                    }
        //                case "4":
        //                    {
        //                        if (strRxStr.Contains("ON"))
        //                        {
        //                            button62.Invoke((MethodInvoker)delegate
        //                            {
        //                                button62.BackColor = Color.Green;
        //                            });
        //                        }
        //                        else
        //                        {
        //                            button62.Invoke((MethodInvoker)delegate
        //                            {
        //                                button62.BackColor = Color.Gainsboro;
        //                            });
        //                        }
        //                        break;
        //                    }
        //                case "5":
        //                    {
        //                        if (strRxStr.Contains("ON"))
        //                        {
        //                            button63.Invoke((MethodInvoker)delegate
        //                            {
        //                                button63.BackColor = Color.Green;
        //                            });
        //                        }
        //                        else
        //                        {
        //                            button63.Invoke((MethodInvoker)delegate
        //                            {
        //                                button63.BackColor = Color.Gainsboro;
        //                            });
        //                        }
        //                        break;
        //                    }
        //                case "6":
        //                    {
        //                        if (strRxStr.Contains("ON"))
        //                        {
        //                            button87.Invoke((MethodInvoker)delegate
        //                            {
        //                                button87.BackColor = Color.Green;
        //                            });
        //                        }
        //                        else
        //                        {
        //                            button87.Invoke((MethodInvoker)delegate
        //                            {
        //                                button87.BackColor = Color.Gainsboro;
        //                            });
        //                        }
        //                        break;
        //                    }
        //                case "7":
        //                    {
        //                        if (strRxStr.Contains("ON"))
        //                        {
        //                            button85.Invoke((MethodInvoker)delegate
        //                            {
        //                                button85.BackColor = Color.Green;
        //                            });
        //                        }
        //                        else
        //                        {
        //                            button85.Invoke((MethodInvoker)delegate
        //                            {
        //                                button85.BackColor = Color.Gainsboro;
        //                            });
        //                        }
        //                        break;
        //                    }
        //                case "8":
        //                    {
        //                        if (strRxStr.Contains("ON"))
        //                        {
        //                            button84.Invoke((MethodInvoker)delegate
        //                            {
        //                                button84.BackColor = Color.Green;
        //                            });
        //                        }
        //                        else
        //                        {
        //                            button84.Invoke((MethodInvoker)delegate
        //                            {
        //                                button84.BackColor = Color.Gainsboro;
        //                            });
        //                        }
        //                        break;
        //                    }
        //                case "9":
        //                    {
        //                        if (strRxStr.Contains("ON"))
        //                        {
        //                            button81.Invoke((MethodInvoker)delegate
        //                            {
        //                                button81.BackColor = Color.Green;
        //                            });
        //                        }
        //                        else
        //                        {
        //                            button81.Invoke((MethodInvoker)delegate
        //                            {
        //                                button81.BackColor = Color.Gainsboro;
        //                            });
        //                        }
        //                        break;
        //                    }
        //                case "10":
        //                    {
        //                        if (strRxStr.Contains("ON"))
        //                        {
        //                            button64.Invoke((MethodInvoker)delegate
        //                            {
        //                                button64.BackColor = Color.Green;
        //                            });
        //                        }
        //                        else
        //                        {
        //                            button64.Invoke((MethodInvoker)delegate
        //                            {
        //                                button64.BackColor = Color.Gainsboro;
        //                            });
        //                        }
        //                        break;
        //                    }
        //                case "11":
        //                    {
        //                        if (strRxStr.Contains("ON"))
        //                        {
        //                            button86.Invoke((MethodInvoker)delegate
        //                            {
        //                                button86.BackColor = Color.Green;
        //                            });
        //                        }
        //                        else
        //                        {
        //                            button86.Invoke((MethodInvoker)delegate
        //                            {
        //                                button86.BackColor = Color.Gainsboro;
        //                            });
        //                        }
        //                        break;
        //                    }
        //                case "12":
        //                    {
        //                        if (strRxStr.Contains("ON"))
        //                        {
        //                            button97.Invoke((MethodInvoker)delegate
        //                            {
        //                                button97.BackColor = Color.Green;
        //                            });
        //                        }
        //                        else
        //                        {
        //                            button97.Invoke((MethodInvoker)delegate
        //                            {
        //                                button97.BackColor = Color.Gainsboro;
        //                            });
        //                        }
        //                        break;
        //                    }
        //                case "13":
        //                    {
        //                        if (strRxStr.Contains("ON"))
        //                        {
        //                            button96.Invoke((MethodInvoker)delegate
        //                            {
        //                                button96.BackColor = Color.Green;
        //                            });
        //                        }
        //                        else
        //                        {
        //                            button96.Invoke((MethodInvoker)delegate
        //                            {
        //                                button96.BackColor = Color.Gainsboro;
        //                            });
        //                        }
        //                        break;
        //                    }
        //                case "14":
        //                    {
        //                        if (strRxStr.Contains("ON"))
        //                        {
        //                            button95.Invoke((MethodInvoker)delegate
        //                            {
        //                                button95.BackColor = Color.Green;
        //                            });
        //                        }
        //                        else
        //                        {
        //                            button95.Invoke((MethodInvoker)delegate
        //                            {
        //                                button95.BackColor = Color.Gainsboro;
        //                            });
        //                        }
        //                        break;
        //                    }
        //                case "15":
        //                    {
        //                        if (strRxStr.Contains("ON"))
        //                        {
        //                            button94.Invoke((MethodInvoker)delegate
        //                            {
        //                                button94.BackColor = Color.Green;
        //                            });
        //                        }
        //                        else
        //                        {
        //                            button94.Invoke((MethodInvoker)delegate
        //                            {
        //                                button94.BackColor = Color.Gainsboro;
        //                            });
        //                        }
        //                        break;
        //                    }
        //                case "16":
        //                    {
        //                        if (strRxStr.Contains("ON"))
        //                        {
        //                            button88.Invoke((MethodInvoker)delegate
        //                            {
        //                                button88.BackColor = Color.Green;
        //                            });
        //                        }
        //                        else
        //                        {
        //                            button88.Invoke((MethodInvoker)delegate
        //                            {
        //                                button88.BackColor = Color.Gainsboro;
        //                            });
        //                        }
        //                        break;
        //                    }
        //                case "17":
        //                    {
        //                        if (strRxStr.Contains("ON"))
        //                        {
        //                            button93.Invoke((MethodInvoker)delegate
        //                            {
        //                                button93.BackColor = Color.Green;
        //                            });
        //                        }
        //                        else
        //                        {
        //                            button93.Invoke((MethodInvoker)delegate
        //                            {
        //                                button93.BackColor = Color.Gainsboro;
        //                            });
        //                        }
        //                        break;
        //                    }
        //                case "18":
        //                    {
        //                        if (strRxStr.Contains("ON"))
        //                        {
        //                            button92.Invoke((MethodInvoker)delegate
        //                            {
        //                                button92.BackColor = Color.Green;
        //                            });
        //                        }
        //                        else
        //                        {
        //                            button92.Invoke((MethodInvoker)delegate
        //                            {
        //                                button92.BackColor = Color.Gainsboro;
        //                            });

        //                        }
        //                        break;
        //                    }
        //                case "19":
        //                    {
        //                        if (strRxStr.Contains("ON"))
        //                        {
        //                            button91.Invoke((MethodInvoker)delegate
        //                            {
        //                                button91.BackColor = Color.Green;
        //                            });
        //                        }
        //                        else
        //                        {
        //                            button91.Invoke((MethodInvoker)delegate
        //                            {
        //                                button91.BackColor = Color.Gainsboro;
        //                            });
        //                        }
        //                        break;
        //                    }
        //                case "20":
        //                    {
        //                        if (strRxStr.Contains("ON"))
        //                        {
        //                            button90.Invoke((MethodInvoker)delegate
        //                            {
        //                                button90.BackColor = Color.Green;
        //                            });
        //                        }
        //                        else
        //                        {
        //                            button90.Invoke((MethodInvoker)delegate
        //                            {
        //                                button90.BackColor = Color.Gainsboro;
        //                            });
        //                        }
        //                        break;
        //                    }
        //                case "21":
        //                    {
        //                        if (strRxStr.Contains("ON"))
        //                        {
        //                            button89.Invoke((MethodInvoker)delegate
        //                            {
        //                                button89.BackColor = Color.Green;
        //                            });
        //                        }
        //                        else
        //                        {
        //                            button89.Invoke((MethodInvoker)delegate
        //                            {
        //                                button89.BackColor = Color.Gainsboro;
        //                            });
        //                        }
        //                        break;
        //                    }


        //            }

        //        }
        //        catch (Exception ex)
        //        {

        //        }
        //    }
        //}

        public static void Tu_Dien_Handle_Message(string strRxStr)
        {
            if (strRxStr.Contains("ON") || strRxStr.Contains("OFF"))
            {
                try
                {
                    string temp = strRxStr.Split('-')[2].Trim();

                    switch (temp)
                    {
                        case "33":
                            {
                                if (strRxStr.Contains("ON"))
                                {
                                    button73.Invoke((MethodInvoker)delegate
                                    {
                                        button73.BackColor = Color.Green;
                                    });

                                }
                                else
                                {
                                    button73.Invoke((MethodInvoker)delegate
                                    {
                                        button73.BackColor = Color.Gainsboro;
                                    });
                                }
                                break;
                            }
                        case "27":
                            {
                                if (strRxStr.Contains("ON"))
                                {
                                    button85.Invoke((MethodInvoker)delegate
                                    {
                                        button85.BackColor = Color.Green;
                                    });

                                }
                                else
                                {
                                    button85.Invoke((MethodInvoker)delegate
                                    {
                                        button85.BackColor = Color.Gainsboro;
                                    });
                                }
                                break;
                            }
                        case "23":
                            {
                                if (strRxStr.Contains("ON"))
                                {
                                    button33.Invoke((MethodInvoker)delegate
                                    {
                                        button33.BackColor = Color.Green;
                                    });
                                }
                                else
                                {
                                    button33.Invoke((MethodInvoker)delegate
                                    {
                                        button33.BackColor = Color.Gainsboro;
                                    });
                                }
                                break;
                            }
                        case "29":
                            {
                                if (strRxStr.Contains("ON"))
                                {
                                    button38.Invoke((MethodInvoker)delegate
                                    {
                                        button38.BackColor = Color.Green;
                                    });
                                }
                                else
                                {
                                    button38.Invoke((MethodInvoker)delegate
                                    {
                                        button38.BackColor = Color.Gainsboro;
                                    });
                                }
                                break;
                            }
                        case "34":
                            {
                                if (strRxStr.Contains("ON"))
                                {
                                    button63.Invoke((MethodInvoker)delegate
                                    {
                                        button63.BackColor = Color.Green;
                                    });
                                }
                                else
                                {
                                    button63.Invoke((MethodInvoker)delegate
                                    {
                                        button63.BackColor = Color.Gainsboro;
                                    });
                                }
                                break;
                            }
                        case "17":
                            {
                                if (strRxStr.Contains("ON"))
                                {
                                    button87.Invoke((MethodInvoker)delegate
                                    {
                                        button87.BackColor = Color.Green;
                                    });
                                }
                                else
                                {
                                    button87.Invoke((MethodInvoker)delegate
                                    {
                                        button87.BackColor = Color.Gainsboro;
                                    });
                                }
                                break;
                            }
                        case "36":
                            {
                                if (strRxStr.Contains("ON"))
                                {
                                    button81.Invoke((MethodInvoker)delegate
                                    {
                                        button81.BackColor = Color.Green;
                                    });
                                }
                                else
                                {
                                    button81.Invoke((MethodInvoker)delegate
                                    {
                                        button81.BackColor = Color.Gainsboro;
                                    });
                                }
                                break;
                            }
                        case "25":
                            {
                                if (strRxStr.Contains("ON"))
                                {
                                    button64.Invoke((MethodInvoker)delegate
                                    {
                                        button64.BackColor = Color.Green;
                                    });
                                }
                                else
                                {
                                    button64.Invoke((MethodInvoker)delegate
                                    {
                                        button64.BackColor = Color.Gainsboro;
                                    });
                                }
                                break;
                            }
                        case "31":
                            {
                                if (strRxStr.Contains("ON"))
                                {
                                    button86.Invoke((MethodInvoker)delegate
                                    {
                                        button86.BackColor = Color.Green;
                                    });
                                }
                                else
                                {
                                    button86.Invoke((MethodInvoker)delegate
                                    {
                                        button86.BackColor = Color.Gainsboro;
                                    });
                                }
                                break;
                            }
                        case "21":
                            {
                                if (strRxStr.Contains("ON"))
                                {
                                    button97.Invoke((MethodInvoker)delegate
                                    {
                                        button97.BackColor = Color.Green;
                                    });
                                }
                                else
                                {
                                    button97.Invoke((MethodInvoker)delegate
                                    {
                                        button97.BackColor = Color.Gainsboro;
                                    });
                                }
                                break;
                            }
                        case "9":
                            {
                                if (strRxStr.Contains("ON"))
                                {
                                    button96.Invoke((MethodInvoker)delegate
                                    {
                                        button96.BackColor = Color.Green;
                                    });
                                }
                                else
                                {
                                    button96.Invoke((MethodInvoker)delegate
                                    {
                                        button96.BackColor = Color.Gainsboro;
                                    });
                                }
                                break;
                            }
                        case "22":
                            {
                                if (strRxStr.Contains("ON"))
                                {
                                    button95.Invoke((MethodInvoker)delegate
                                    {
                                        button95.BackColor = Color.Green;
                                    });
                                }
                                else
                                {
                                    button95.Invoke((MethodInvoker)delegate
                                    {
                                        button95.BackColor = Color.Gainsboro;
                                    });
                                }
                                break;
                            }
                        case "10":
                            {
                                if (strRxStr.Contains("ON"))
                                {
                                    button94.Invoke((MethodInvoker)delegate
                                    {
                                        button94.BackColor = Color.Green;
                                    });
                                }
                                else
                                {
                                    button94.Invoke((MethodInvoker)delegate
                                    {
                                        button94.BackColor = Color.Gainsboro;
                                    });
                                }
                                break;
                            }
                        case "35":
                            {
                                if (strRxStr.Contains("ON"))
                                {
                                    button88.Invoke((MethodInvoker)delegate
                                    {
                                        button88.BackColor = Color.Green;
                                    });
                                }
                                else
                                {
                                    button88.Invoke((MethodInvoker)delegate
                                    {
                                        button88.BackColor = Color.Gainsboro;
                                    });
                                }
                                break;
                            }
                        case "11":
                            {
                                if (strRxStr.Contains("ON"))
                                {
                                    button93.Invoke((MethodInvoker)delegate
                                    {
                                        button93.BackColor = Color.Green;
                                    });
                                }
                                else
                                {
                                    button93.Invoke((MethodInvoker)delegate
                                    {
                                        button93.BackColor = Color.Gainsboro;
                                    });
                                }
                                break;
                            }
                        case "19":
                            {
                                if (strRxStr.Contains("ON"))
                                {
                                    button92.Invoke((MethodInvoker)delegate
                                    {
                                        button92.BackColor = Color.Green;
                                    });
                                }
                                else
                                {
                                    button92.Invoke((MethodInvoker)delegate
                                    {
                                        button92.BackColor = Color.Gainsboro;
                                    });

                                }
                                break;
                            }
                        case "30":
                            {
                                if (strRxStr.Contains("ON"))
                                {
                                    button91.Invoke((MethodInvoker)delegate
                                    {
                                        button91.BackColor = Color.Green;
                                    });
                                }
                                else
                                {
                                    button91.Invoke((MethodInvoker)delegate
                                    {
                                        button91.BackColor = Color.Gainsboro;
                                    });
                                }
                                break;
                            }
                        case "38":
                            {
                                if (strRxStr.Contains("ON"))
                                {
                                    button90.Invoke((MethodInvoker)delegate
                                    {
                                        button90.BackColor = Color.Green;
                                    });
                                }
                                else
                                {
                                    button90.Invoke((MethodInvoker)delegate
                                    {
                                        button90.BackColor = Color.Gainsboro;
                                    });
                                }
                                break;
                            }
                        case "37":
                            {
                                if (strRxStr.Contains("ON"))
                                {
                                    button89.Invoke((MethodInvoker)delegate
                                    {
                                        button89.BackColor = Color.Green;
                                    });
                                }
                                else
                                {
                                    button89.Invoke((MethodInvoker)delegate
                                    {
                                        button89.BackColor = Color.Gainsboro;
                                    });
                                }
                                break;
                            }
                        case "20":
                            {
                                if (strRxStr.Contains("ON"))
                                {
                                    button71.Invoke((MethodInvoker)delegate
                                    {
                                        button71.BackColor = Color.Green;
                                    });
                                }
                                else
                                {
                                    button71.Invoke((MethodInvoker)delegate
                                    {
                                        button71.BackColor = Color.Gainsboro;
                                    });
                                }
                                break;
                            }
                        case "39":
                            {
                                if (strRxStr.Contains("ON"))
                                {
                                    button28.Invoke((MethodInvoker)delegate
                                    {
                                        button28.BackColor = Color.Green;
                                    });
                                }
                                else
                                {
                                    button28.Invoke((MethodInvoker)delegate
                                    {
                                        button28.BackColor = Color.Gainsboro;
                                    });
                                }
                                break;
                            }
                        case "28":
                            {
                                if (strRxStr.Contains("ON"))
                                {
                                    button72.Invoke((MethodInvoker)delegate
                                    {
                                        button72.BackColor = Color.Green;
                                    });
                                }
                                else
                                {
                                    button72.Invoke((MethodInvoker)delegate
                                    {
                                        button72.BackColor = Color.Gainsboro;
                                    });
                                }
                                break;
                            }
                        // RELAY IN APP
                        case "1":
                            {
                                if (strRxStr.Contains("ON"))
                                {
                                    button55.Invoke((MethodInvoker)delegate
                                    {
                                        button55.BackColor = Color.Green;
                                    });
                                }
                                else
                                {
                                    button55.Invoke((MethodInvoker)delegate
                                    {
                                        button55.BackColor = Color.Gainsboro;
                                    });
                                }
                                break;
                            }

                        case "2":
                            {
                                if (strRxStr.Contains("ON"))
                                {
                                    button117.Invoke((MethodInvoker)delegate
                                    {
                                        button117.BackColor = Color.Green;
                                    });
                                }
                                else
                                {
                                    button117.Invoke((MethodInvoker)delegate
                                    {
                                        button117.BackColor = Color.Gainsboro;
                                    });
                                }
                                break;
                            }
                        case "3":
                            {
                                if (strRxStr.Contains("ON"))
                                {
                                    button118.Invoke((MethodInvoker)delegate
                                    {
                                        button118.BackColor = Color.Green;
                                    });
                                }
                                else
                                {
                                    button118.Invoke((MethodInvoker)delegate
                                    {
                                        button118.BackColor = Color.Gainsboro;
                                    });
                                }
                                break;
                            }
                        case "4":
                            {
                                if (strRxStr.Contains("ON"))
                                {
                                    button119.Invoke((MethodInvoker)delegate
                                    {
                                        button119.BackColor = Color.Green;
                                    });
                                }
                                else
                                {
                                    button119.Invoke((MethodInvoker)delegate
                                    {
                                        button119.BackColor = Color.Gainsboro;
                                    });
                                }
                                break;
                            }
                        case "12":
                            {
                                if (strRxStr.Contains("ON"))
                                {
                                    button120.Invoke((MethodInvoker)delegate
                                    {
                                        button120.BackColor = Color.Green;
                                    });
                                }
                                else
                                {
                                    button120.Invoke((MethodInvoker)delegate
                                    {
                                        button120.BackColor = Color.Gainsboro;
                                    });
                                }
                                break;
                            }
                        case "13":
                            {
                                if (strRxStr.Contains("ON"))
                                {
                                    button154.Invoke((MethodInvoker)delegate
                                    {
                                        button154.BackColor = Color.Green;
                                    });
                                }
                                else
                                {
                                    button154.Invoke((MethodInvoker)delegate
                                    {
                                        button154.BackColor = Color.Gainsboro;
                                    });
                                }
                                break;
                            }
                        case "14":
                            {
                                if (strRxStr.Contains("ON"))
                                {
                                    button122.Invoke((MethodInvoker)delegate
                                    {
                                        button122.BackColor = Color.Green;
                                    });
                                }
                                else
                                {
                                    button122.Invoke((MethodInvoker)delegate
                                    {
                                        button122.BackColor = Color.Gainsboro;
                                    });
                                }
                                break;
                            }
                        //case "15":
                        //    {
                        //        if (strRxStr.Contains("ON"))
                        //        {
                        //            button123.Invoke((MethodInvoker)delegate
                        //            {
                        //                button123.BackColor = Color.Green;
                        //            });
                        //        }
                        //        else
                        //        {
                        //            button123.Invoke((MethodInvoker)delegate
                        //            {
                        //                button123.BackColor = Color.Gainsboro;
                        //            });
                        //        }
                        //        break;
                        //    }
                        case "26":
                            {
                                if (strRxStr.Contains("ON"))
                                {
                                    button85.Invoke((MethodInvoker)delegate
                                    {
                                        button116.BackColor = Color.Green;
                                    });
                                }
                                else
                                {
                                    button85.Invoke((MethodInvoker)delegate
                                    {
                                        button116.BackColor = Color.Gainsboro;
                                    });
                                }
                                break;
                            }
                        case "18":
                            {
                                if (strRxStr.Contains("ON"))
                                {
                                    button26.Invoke((MethodInvoker)delegate
                                    {
                                        button26.BackColor = Color.Green;
                                    });
                                }
                                else
                                {
                                    button26.Invoke((MethodInvoker)delegate
                                    {
                                        button26.BackColor = Color.Gainsboro;
                                    });
                                }
                                break;
                            }
                    }

                }
                catch (Exception ex)
                {

                }
            }
        }

        private void button82_Click(object sender, EventArgs e)
        {
            frmSettings a = new frmSettings();
            a.ShowDialog();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            if (button26.BackColor == Color.Gainsboro)
            {
                //serialPort1.Write("APP-ON-" + TU_TU_PHAI_THO.ToString() + "\r\n");
                _ = Tudien_Server.SendMessageAsync("ON-" + RELAY_10.ToString());
            }
            else
            {
                //serialPort1.Write("APP-OFF-" + TU_TU_PHAI_THO.ToString() + "\r\n");
                _ = Tudien_Server.SendMessageAsync("OFF-" + RELAY_10.ToString());
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            if (button27.BackColor == Color.Gainsboro)
            {

                _ = PhongCho_Server.SendMessageAsync("SAN_KHAU-PROJECTOR_ON");
            }
            else
            {
                _ = PhongCho_Server.SendMessageAsync("SAN_KHAU-PROJECTOR_OFF");
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            if (button28.BackColor == Color.Gainsboro)
            {
                //serialPort1.Write("APP-ON-" + DEN_TIM_THO.ToString() + "\r\n");
                _ = Tudien_Server.SendMessageAsync("ON-" + NUT_15.ToString());
            }
            else
            {
                //serialPort1.Write("APP-OFF-" + DEN_TIM_THO.ToString() + "\r\n");
                _ = Tudien_Server.SendMessageAsync("OFF-" + NUT_15.ToString());
            }
        }

        private void button75_Click(object sender, EventArgs e)
        {

        }

        private void button62_Click(object sender, EventArgs e)
        {
            //if (button99.BackColor == Color.Gainsboro)
            if (button62.BackColor == Color.Gainsboro)
            {
                //serialPort1.Write("APP-ON-" + DEN_CHAO_VANG.ToString() + "\r\n");
                _ = Tudien_Server.SendMessageAsync("ON-" + DEN_DAU.ToString());
                Mp3.PlaySong(Mp3.SOUND_26);
            }
            else
            {
                //serialPort1.Write("APP-OFF-" + DEN_CHAO_VANG.ToString() + "\r\n");
                _ = Tudien_Server.SendMessageAsync("OFF-" + DEN_DAU.ToString());
            }

        }

        private void button103_Click(object sender, EventArgs e)
        {
            if (button103.BackColor == Color.Gainsboro)
            {
                string exampl = "";
                if (De_4_1 == true)
                {
                    exampl = "DE_4NG_1";
                }
                else if (De_4_2 == true)
                {
                    exampl = "DE_4NG_2";
                }
                else if (De_5_1 == true)
                {
                    exampl = "DE_5NG_1";
                }
                else if (De_5_2 == true)
                {
                    exampl = "DE_5NG_2";
                }
                else if (De_6_1 == true)
                {
                    exampl = "DE_6NG_1";
                }
                else if (De_6_2 == true)
                {
                    exampl = "DE_6NG_2";
                }
                else if (De_7_1 == true)
                {
                    exampl = "DE_7NG_1";
                }
                else if (De_7_2 == true)
                {
                    exampl = "DE_7NG_2";
                }
                else if (De_8_1 == true)
                {
                    exampl = "DE_8NG_1";
                }
                else if (De_8_2 == true)
                {
                    exampl = "DE_8NG_2";
                }
                _ = TiviSanKhau_Server.SendMessageAsync(exampl);
                button103.BackColor = Color.Green;
            }
            else
            {
                _ = TiviSanKhau_Server.SendMessageAsync("STOP");
                button103.BackColor = Color.Gainsboro;
            }

        }

        private void button104_Click(object sender, EventArgs e)
        {
            Mp3.PlaySong(Mp3.SOUND_39);
        }

        private void button67_Click(object sender, EventArgs e)
        {
            _ = DanTranh_Server.SendMessageAsync("RESET_PCB");
        }

        private void button80_Click(object sender, EventArgs e)
        {
            _ = Tudien_Server.SendMessageAsync("RESET_PCB");
        }

        private void button106_Click(object sender, EventArgs e)
        {
            _ = Dimmer_Server.SendMessageAsync("RESET_PCB");
        }

        private void btnWinHand_Click_1(object sender, EventArgs e)
        {
            _ = PhongCho_Server.SendMessageAsync("PHONG_CHO-HAND_CORRECT");
        }

        private void button105_Click(object sender, EventArgs e)
        {

        }


        public static int min = 29;
        public static int sec = 59;


        private void button73_Click(object sender, EventArgs e)
        {
            if (button73.BackColor == Color.Gainsboro)
            {
                //serialPort1.Write("APP-ON-" + DEN_TIM_THO.ToString() + "\r\n");
                _ = Tudien_Server.SendMessageAsync("ON-" + NUT_12.ToString());
            }
            else
            {
                //serialPort1.Write("APP-OFF-" + DEN_TIM_THO.ToString() + "\r\n");
                _ = Tudien_Server.SendMessageAsync("OFF-" + NUT_12.ToString());
            }

        }

        private void button116_Click(object sender, EventArgs e)
        {
            if (button116.BackColor == Color.Gainsboro)
            {
                //serialPort1.Write("APP-ON-" + TU_TU_PHAI_THO.ToString() + "\r\n");
                _ = Tudien_Server.SendMessageAsync("ON-" + RELAY_9.ToString());
            }
            else
            {
                //serialPort1.Write("APP-OFF-" + TU_TU_PHAI_THO.ToString() + "\r\n");
                _ = Tudien_Server.SendMessageAsync("OFF-" + RELAY_9.ToString());
            }
        }

        private void button72_Click(object sender, EventArgs e)
        {
            if (button72.BackColor == Color.Gainsboro)
            {
                //serialPort1.Write("APP-ON-" + TU_TU_PHAI_THO.ToString() + "\r\n");
                _ = Tudien_Server.SendMessageAsync("ON-" + NUT_22.ToString());
            }
            else
            {
                //serialPort1.Write("APP-OFF-" + TU_TU_PHAI_THO.ToString() + "\r\n");
                _ = Tudien_Server.SendMessageAsync("OFF-" + NUT_22.ToString());
            }
        }

        private void button71_Click(object sender, EventArgs e)
        {
            if (button71.BackColor == Color.Gainsboro)
            {
                //serialPort1.Write("APP-ON-" + TU_TU_PHAI_THO.ToString() + "\r\n");
                _ = Tudien_Server.SendMessageAsync("ON-" + NUT_8.ToString());
            }
            else
            {
                //serialPort1.Write("APP-OFF-" + TU_TU_PHAI_THO.ToString() + "\r\n");
                _ = Tudien_Server.SendMessageAsync("OFF-" + NUT_8.ToString());
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }



        // BUTTON RELAY

        private void button55_Click(object sender, EventArgs e)
        {
            if (button55.BackColor == Color.Gainsboro)
            {
                //serialPort1.Write("APP-ON-" + TU_TU_PHAI_THO.ToString() + "\r\n");
                _ = Tudien_Server.SendMessageAsync("ON-" + RELAY_1.ToString());
            }
            else
            {
                //serialPort1.Write("APP-OFF-" + TU_TU_PHAI_THO.ToString() + "\r\n");
                _ = Tudien_Server.SendMessageAsync("OFF-" + RELAY_1.ToString());
            }
        }

        private void button117_Click(object sender, EventArgs e)
        {
            if (button117.BackColor == Color.Gainsboro)
            {
                //serialPort1.Write("APP-ON-" + TU_TU_PHAI_THO.ToString() + "\r\n");
                _ = Tudien_Server.SendMessageAsync("ON-" + RELAY_2.ToString());
            }
            else
            {
                //serialPort1.Write("APP-OFF-" + TU_TU_PHAI_THO.ToString() + "\r\n");
                _ = Tudien_Server.SendMessageAsync("OFF-" + RELAY_2.ToString());
            }
        }

        private void button118_Click(object sender, EventArgs e)
        {
            if (button118.BackColor == Color.Gainsboro)
            {
                //serialPort1.Write("APP-ON-" + TU_TU_PHAI_THO.ToString() + "\r\n");
                _ = Tudien_Server.SendMessageAsync("ON-" + RELAY_3.ToString());
            }
            else
            {
                //serialPort1.Write("APP-OFF-" + TU_TU_PHAI_THO.ToString() + "\r\n");
                _ = Tudien_Server.SendMessageAsync("OFF-" + RELAY_3.ToString());
            }
        }

        private void button119_Click(object sender, EventArgs e)
        {
            if (button119.BackColor == Color.Gainsboro)
            {
                //serialPort1.Write("APP-ON-" + TU_TU_PHAI_THO.ToString() + "\r\n");
                _ = Tudien_Server.SendMessageAsync("ON-" + RELAY_4.ToString());
            }
            else
            {
                //serialPort1.Write("APP-OFF-" + TU_TU_PHAI_THO.ToString() + "\r\n");
                _ = Tudien_Server.SendMessageAsync("OFF-" + RELAY_4.ToString());
            }
        }

        private void button120_Click(object sender, EventArgs e)
        {
            if (button120.BackColor == Color.Gainsboro)
            {
                //serialPort1.Write("APP-ON-" + TU_TU_PHAI_THO.ToString() + "\r\n");
                _ = Tudien_Server.SendMessageAsync("ON-" + RELAY_5.ToString());
            }
            else
            {
                //serialPort1.Write("APP-OFF-" + TU_TU_PHAI_THO.ToString() + "\r\n");
                _ = Tudien_Server.SendMessageAsync("OFF-" + RELAY_5.ToString());
            }
        }

        private void button121_Click(object sender, EventArgs e)
        {
            if (button121.BackColor == Color.Gainsboro)
            {
                //serialPort1.Write("APP-ON-" + TU_TU_PHAI_THO.ToString() + "\r\n");
                _ = Tudien_Server.SendMessageAsync("ON-" + RELAY_6.ToString());
            }
            else
            {
                //serialPort1.Write("APP-OFF-" + TU_TU_PHAI_THO.ToString() + "\r\n");
                _ = Tudien_Server.SendMessageAsync("OFF-" + RELAY_6.ToString());
            }
        }

        private void button122_Click(object sender, EventArgs e)
        {
            if (button122.BackColor == Color.Gainsboro)
            {
                //serialPort1.Write("APP-ON-" + TU_TU_PHAI_THO.ToString() + "\r\n");
                _ = Tudien_Server.SendMessageAsync("ON-" + RELAY_7.ToString());
            }
            else
            {
                //serialPort1.Write("APP-OFF-" + TU_TU_PHAI_THO.ToString() + "\r\n");
                _ = Tudien_Server.SendMessageAsync("OFF-" + RELAY_7.ToString());
            }
        }

        //private void button123_Click(object sender, EventArgs e)
        //{
        //    if (button123.BackColor == Color.Gainsboro)
        //    {
        //        //serialPort1.Write("APP-ON-" + TU_TU_PHAI_THO.ToString() + "\r\n");
        //        _ = Tudien_Server.SendMessageAsync("ON-" + RELAY_8.ToString());
        //    }
        //    else
        //    {
        //        //serialPort1.Write("APP-OFF-" + TU_TU_PHAI_THO.ToString() + "\r\n");
        //        _ = Tudien_Server.SendMessageAsync("OFF-" + RELAY_8.ToString());
        //    }
        //}

        private void button129_Click(object sender, EventArgs e)
        {
            De_4_nguoi = !De_4_nguoi;
            if (De_4_nguoi == false)
            {
                button129.BackColor = Color.Gainsboro;
            }
            else
            {
                De_5_nguoi = false;
                De_6_nguoi = false;
                De_7_nguoi = false;
                De_8_nguoi = false;
                button129.BackColor = Color.Green;
                button130.BackColor = Color.Gainsboro;
                button131.BackColor = Color.Gainsboro;
                button132.BackColor = Color.Gainsboro;
                button133.BackColor = Color.Gainsboro;
            }

            if (button129.BackColor == Color.Gainsboro)
            {
                //serialPort1.Write("APP-ON-" + TU_TU_PHAI_THO.ToString() + "\r\n");
                _ = PhongCho_Server.SendMessageAsync("4_NGUOI_OFF");
            }
            else
            {
                //serialPort1.Write("APP-OFF-" + TU_TU_PHAI_THO.ToString() + "\r\n");
                _ = PhongCho_Server.SendMessageAsync("4_NGUOI_ON");
            }
        }

        private void button130_Click(object sender, EventArgs e)
        {
            De_5_nguoi = !De_5_nguoi;
            if (De_5_nguoi == false)
            {
                button130.BackColor = Color.Gainsboro;
            }
            else
            {
                De_4_nguoi = false;
                De_6_nguoi = false;
                De_7_nguoi = false;
                De_8_nguoi = false;
                button129.BackColor = Color.Gainsboro;
                button130.BackColor = Color.Green;
                button131.BackColor = Color.Gainsboro;
                button132.BackColor = Color.Gainsboro;
                button133.BackColor = Color.Gainsboro;
            }

            if (button130.BackColor == Color.Gainsboro)
            {
                //serialPort1.Write("APP-ON-" + TU_TU_PHAI_THO.ToString() + "\r\n");
                _ = PhongCho_Server.SendMessageAsync("5_NGUOI_OFF");
            }
            else
            {
                //serialPort1.Write("APP-OFF-" + TU_TU_PHAI_THO.ToString() + "\r\n");
                _ = PhongCho_Server.SendMessageAsync("5_NGUOI_ON");
            }
        }

        private void button131_Click(object sender, EventArgs e)
        {
            De_6_nguoi = !De_6_nguoi;
            if (De_6_nguoi == false)
            {
                button131.BackColor = Color.Gainsboro;
            }
            else
            {
                De_4_nguoi = false;
                De_5_nguoi = false;
                De_7_nguoi = false;
                De_8_nguoi = false;
                button129.BackColor = Color.Gainsboro;
                button130.BackColor = Color.Gainsboro;
                button131.BackColor = Color.Green;
                button132.BackColor = Color.Gainsboro;
                button133.BackColor = Color.Gainsboro;
            }

            if (button131.BackColor == Color.Gainsboro)
            {
                //serialPort1.Write("APP-ON-" + TU_TU_PHAI_THO.ToString() + "\r\n");
                _ = PhongCho_Server.SendMessageAsync("6_NGUOI_OFF");
            }
            else
            {
                //serialPort1.Write("APP-OFF-" + TU_TU_PHAI_THO.ToString() + "\r\n");
                _ = PhongCho_Server.SendMessageAsync("6_NGUOI_ON");
            }
        }

        private void button132_Click(object sender, EventArgs e)
        {

        }

        private void button133_Click(object sender, EventArgs e)
        {

        }

        private void button132_Click_1(object sender, EventArgs e)
        {
            De_7_nguoi = !De_7_nguoi;
            if (De_7_nguoi == false)
            {
                button132.BackColor = Color.Gainsboro;
            }
            else
            {
                De_4_nguoi = false;
                De_5_nguoi = false;
                De_6_nguoi = false;
                De_8_nguoi = false;
                button129.BackColor = Color.Gainsboro;
                button130.BackColor = Color.Gainsboro;
                button131.BackColor = Color.Gainsboro;
                button132.BackColor = Color.Green;
                button133.BackColor = Color.Gainsboro;
            }

            if (button132.BackColor == Color.Gainsboro)
            {
                //serialPort1.Write("APP-ON-" + TU_TU_PHAI_THO.ToString() + "\r\n");
                _ = PhongCho_Server.SendMessageAsync("7_NGUOI_OFF");
            }
            else
            {
                //serialPort1.Write("APP-OFF-" + TU_TU_PHAI_THO.ToString() + "\r\n");
                _ = PhongCho_Server.SendMessageAsync("7_NGUOI_ON");
            }
        }

        private void button133_Click_1(object sender, EventArgs e)
        {
            De_8_nguoi = !De_8_nguoi;
            if (De_8_nguoi == false)
            {
                button133.BackColor = Color.Gainsboro;
            }
            else
            {
                De_4_nguoi = false;
                De_5_nguoi = false;
                De_6_nguoi = false;
                De_7_nguoi = false;
                button129.BackColor = Color.Gainsboro;
                button130.BackColor = Color.Gainsboro;
                button131.BackColor = Color.Gainsboro;
                button132.BackColor = Color.Gainsboro;
                button133.BackColor = Color.Green;
            }

            if (button133.BackColor == Color.Gainsboro)
            {
                //serialPort1.Write("APP-ON-" + TU_TU_PHAI_THO.ToString() + "\r\n");
                _ = PhongCho_Server.SendMessageAsync("8_NGUOI_OFF");
            }
            else
            {
                //serialPort1.Write("APP-OFF-" + TU_TU_PHAI_THO.ToString() + "\r\n");
                _ = PhongCho_Server.SendMessageAsync("8_NGUOI_ON");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button47_Click(object sender, EventArgs e)
        {

        }

        private void button52_Click(object sender, EventArgs e)
        {

        }

        private void button134_Click(object sender, EventArgs e)
        {
            bat_dau_hanh_lang = !bat_dau_hanh_lang;

            if (bat_dau_hanh_lang == false)
            {
                //serialPort1.Write("APP-ON-" + TU_TU_PHAI_THO.ToString() + "\r\n");
                //_ = SanKhau_Server.SendMessageAsync("ON-" + RELAY_2.ToString());
                button134.BackColor = Color.Gainsboro;
            }
            else
            {
                //serialPort1.Write("APP-OFF-" + TU_TU_PHAI_THO.ToString() + "\r\n");
                _ = SanKhau_Server.SendMessageAsync("START_GAME");
                button134.BackColor = Color.Green;
                Mp3.PlaySong(Mp3.SOUND_47);

            }
        }

        private void groupBox8_Enter(object sender, EventArgs e)
        {

        }

        private void button127_Click(object sender, EventArgs e)
        {

        }

        private void button128_Click(object sender, EventArgs e)
        {

        }

        private void button140_Click(object sender, EventArgs e)
        {
            _ = PhongCho_Server.SendMessageAsync("PHONG_CHO-LANH_LEO_CHUAN_BI");
            Mp3.PauseBackground();
            Mp3.PlaySong(Mp3.SOUND_12); // Chuan bi tiet muc mua
            _ = frmMain.DanTranh_Server.SendMessageAsync("DAN_TRANH-Rem_dong");
            _ = Dimmer_Server.SendMessageAsync("Dimmer_trong_5s");
        }

        private void button141_Click(object sender, EventArgs e)
        {
            _ = PhongCho_Server.SendMessageAsync("PHONG_CHO-LANH_LEO_MUA");
            Mp3.PlaySong(Mp3.SOUND_1); // AM thanh lanh leo bat
                                       //  _ = frmMain.DanTranh_Server.SendMessageAsync("DAN_TRANH-Rem_mo");
            _ = frmMain.DanTranh_Server.SendMessageAsync("DAN_TRANH-Rem_moxx");
        }

        private void button142_Click(object sender, EventArgs e)
        {
            _ = PhongCho_Server.SendMessageAsync("PHONG_CHO-LANH_LEO_DOA");

        }

        private void button136_Click(object sender, EventArgs e)
        {

        }

        private void button137_Click(object sender, EventArgs e)
        {

        }

        bool StartSoundHuanChuong = false;
        int TimerHuanChuongCount = 0;
        private void button143_Click(object sender, EventArgs e)
        {
            //start game huan chuong

            //clear all btn huan chuong
            button68.Text = "-";
            button84.Text = "-";
            button105.Text = "-";
            button101.Text = "-";
            button108.Text = "-";

            //bat am thanh dan truyen huan chuong
            Mp3.PlaySong(Mp3.SOUND_30);
            StartSoundHuanChuong = true;
            TimerHuanChuongCount = 0;
            timerDanTranh.Start();
        }

        private void lbTimeCoundDown_Click(object sender, EventArgs e)
        {

        }

        private void button151_Click(object sender, EventArgs e)
        {
            De_8_1 = !De_8_1;
            if (De_8_1 == false)
            {
                button151.BackColor = Color.Gainsboro;
            }
            else
            {
                De_4_1 = false;
                De_4_2 = false;
                De_5_1 = false;
                De_5_2 = false;
                De_6_1 = false;
                De_6_2 = false;
                De_7_1 = false;
                De_7_2 = false;
                De_8_2 = false;
                button145.BackColor = Color.Gainsboro;
                button144.BackColor = Color.Gainsboro;
                button146.BackColor = Color.Gainsboro;
                button147.BackColor = Color.Gainsboro;
                button148.BackColor = Color.Gainsboro;
                button149.BackColor = Color.Gainsboro;
                button34.BackColor = Color.Gainsboro;
                button150.BackColor = Color.Gainsboro;
                button151.BackColor = Color.Green;
                button152.BackColor = Color.Gainsboro;
            }

            if (button151.BackColor == Color.Green)
            {
                _ = PhongCho_Server.SendMessageAsync("SANKHAU_8_1");
                _ = PhongCho_Server.SendMessageAsync("SAN_KHAU-CREATE_EXAMPLE-" + DAP_AN_DE_8_1.ToString());
            }
        }

        private void button144_Click(object sender, EventArgs e)
        {
            De_4_1 = !De_4_1;
            if (De_4_1 == false)
            {
                button144.BackColor = Color.Gainsboro;
            }
            else
            {
                De_4_2 = false;
                De_5_1 = false;
                De_5_2 = false;
                De_6_1 = false;
                De_6_2 = false;
                De_7_1 = false;
                De_7_2 = false;
                De_8_1 = false;
                De_8_2 = false;
                button144.BackColor = Color.Green;
                button145.BackColor = Color.Gainsboro;
                button146.BackColor = Color.Gainsboro;
                button147.BackColor = Color.Gainsboro;
                button148.BackColor = Color.Gainsboro;
                button149.BackColor = Color.Gainsboro;
                button34.BackColor = Color.Gainsboro;
                button150.BackColor = Color.Gainsboro;
                button151.BackColor = Color.Gainsboro;
                button152.BackColor = Color.Gainsboro;
            }

            if (button144.BackColor == Color.Green)
            {
                //serialPort1.Write("APP-OFF-" + TU_TU_PHAI_THO.ToString() + "\r\n");
                _ = PhongCho_Server.SendMessageAsync("SANKHAU_4_1");
                _ = PhongCho_Server.SendMessageAsync("SAN_KHAU-CREATE_EXAMPLE-" + DAP_AN_DE_4_1.ToString());
            }
        }

        private void button145_Click(object sender, EventArgs e)
        {
            De_4_2 = !De_4_2;
            if (De_4_2 == false)
            {
                button145.BackColor = Color.Gainsboro;
            }
            else
            {
                De_4_1 = false;
                De_5_1 = false;
                De_5_2 = false;
                De_6_1 = false;
                De_6_2 = false;
                De_7_1 = false;
                De_7_2 = false;
                De_8_1 = false;
                De_8_2 = false;
                button145.BackColor = Color.Green;
                button144.BackColor = Color.Gainsboro;
                button146.BackColor = Color.Gainsboro;
                button147.BackColor = Color.Gainsboro;
                button148.BackColor = Color.Gainsboro;
                button149.BackColor = Color.Gainsboro;
                button34.BackColor = Color.Gainsboro;
                button150.BackColor = Color.Gainsboro;
                button151.BackColor = Color.Gainsboro;
                button152.BackColor = Color.Gainsboro;
            }

            if (button145.BackColor == Color.Green)
            {
                //serialPort1.Write("APP-OFF-" + TU_TU_PHAI_THO.ToString() + "\r\n");
                _ = PhongCho_Server.SendMessageAsync("SANKHAU_4_2");
                _ = PhongCho_Server.SendMessageAsync("SAN_KHAU-CREATE_EXAMPLE-" + DAP_AN_DE_4_2.ToString());
            }
        }

        private void button146_Click(object sender, EventArgs e)
        {
            De_5_1 = !De_5_1;
            if (De_5_1 == false)
            {
                button146.BackColor = Color.Gainsboro;
            }
            else
            {
                De_4_1 = false;
                De_4_2 = false;
                De_5_2 = false;
                De_6_1 = false;
                De_6_2 = false;
                De_7_1 = false;
                De_7_2 = false;
                De_8_1 = false;
                De_8_2 = false;
                button145.BackColor = Color.Gainsboro;
                button144.BackColor = Color.Gainsboro;
                button146.BackColor = Color.Green;
                button147.BackColor = Color.Gainsboro;
                button148.BackColor = Color.Gainsboro;
                button149.BackColor = Color.Gainsboro;
                button34.BackColor = Color.Gainsboro;
                button150.BackColor = Color.Gainsboro;
                button151.BackColor = Color.Gainsboro;
                button152.BackColor = Color.Gainsboro;
            }

            if (button146.BackColor == Color.Green)
            {
                //serialPort1.Write("APP-OFF-" + TU_TU_PHAI_THO.ToString() + "\r\n");
                _ = PhongCho_Server.SendMessageAsync("SANKHAU_5_1");
                _ = PhongCho_Server.SendMessageAsync("SAN_KHAU-CREATE_EXAMPLE-" + DAP_AN_DE_5_1.ToString());
            }
        }

        private void button147_Click(object sender, EventArgs e)
        {
            De_5_2 = !De_5_2;
            if (De_5_2 == false)
            {
                button147.BackColor = Color.Gainsboro;
            }
            else
            {
                De_4_1 = false;
                De_4_2 = false;
                De_5_1 = false;
                De_6_1 = false;
                De_6_2 = false;
                De_7_1 = false;
                De_7_2 = false;
                De_8_1 = false;
                De_8_2 = false;
                button145.BackColor = Color.Gainsboro;
                button144.BackColor = Color.Gainsboro;
                button146.BackColor = Color.Gainsboro;
                button147.BackColor = Color.Green;
                button148.BackColor = Color.Gainsboro;
                button149.BackColor = Color.Gainsboro;
                button34.BackColor = Color.Gainsboro;
                button150.BackColor = Color.Gainsboro;
                button151.BackColor = Color.Gainsboro;
                button152.BackColor = Color.Gainsboro;
            }

            if (button147.BackColor == Color.Green)
            {
                //serialPort1.Write("APP-OFF-" + TU_TU_PHAI_THO.ToString() + "\r\n");
                _ = PhongCho_Server.SendMessageAsync("SANKHAU_5_2");
                _ = PhongCho_Server.SendMessageAsync("SAN_KHAU-CREATE_EXAMPLE-" + DAP_AN_DE_5_2.ToString());
            }
        }

        private void button148_Click(object sender, EventArgs e)
        {
            De_6_1 = !De_6_1;
            if (De_6_1 == false)
            {
                button148.BackColor = Color.Gainsboro;
            }
            else
            {
                De_4_1 = false;
                De_4_2 = false;
                De_5_1 = false;
                De_5_2 = false;
                De_6_2 = false;
                De_7_1 = false;
                De_7_2 = false;
                De_8_1 = false;
                De_8_2 = false;
                button145.BackColor = Color.Gainsboro;
                button144.BackColor = Color.Gainsboro;
                button146.BackColor = Color.Gainsboro;
                button147.BackColor = Color.Gainsboro;
                button148.BackColor = Color.Green;
                button149.BackColor = Color.Gainsboro;
                button34.BackColor = Color.Gainsboro;
                button150.BackColor = Color.Gainsboro;
                button151.BackColor = Color.Gainsboro;
                button152.BackColor = Color.Gainsboro;
            }

            if (button148.BackColor == Color.Green)
            {
                //serialPort1.Write("APP-OFF-" + TU_TU_PHAI_THO.ToString() + "\r\n");
                _ = PhongCho_Server.SendMessageAsync("SANKHAU_6_1");
                _ = PhongCho_Server.SendMessageAsync("SAN_KHAU-CREATE_EXAMPLE-" + DAP_AN_DE_6_1.ToString());
            }
        }

        private void button149_Click(object sender, EventArgs e)
        {
            De_6_2 = !De_6_2;
            if (De_6_2 == false)
            {
                button149.BackColor = Color.Gainsboro;
            }
            else
            {
                De_4_1 = false;
                De_4_2 = false;
                De_5_1 = false;
                De_5_2 = false;
                De_6_1 = false;
                De_7_1 = false;
                De_7_2 = false;
                De_8_1 = false;
                De_8_2 = false;
                button145.BackColor = Color.Gainsboro;
                button144.BackColor = Color.Gainsboro;
                button146.BackColor = Color.Gainsboro;
                button147.BackColor = Color.Gainsboro;
                button148.BackColor = Color.Gainsboro;
                button149.BackColor = Color.Green;
                button34.BackColor = Color.Gainsboro;
                button150.BackColor = Color.Gainsboro;
                button151.BackColor = Color.Gainsboro;
                button152.BackColor = Color.Gainsboro;
            }

            if (button149.BackColor == Color.Green)
            {
                //serialPort1.Write("APP-OFF-" + TU_TU_PHAI_THO.ToString() + "\r\n");
                _ = PhongCho_Server.SendMessageAsync("SANKHAU_6_2");
                _ = PhongCho_Server.SendMessageAsync("SAN_KHAU-CREATE_EXAMPLE-" + DAP_AN_DE_6_2.ToString());
            }
        }

        private void button34_Click(object sender, EventArgs e)
        {
            De_7_1 = !De_7_1;
            if (De_7_1 == false)
            {
                button34.BackColor = Color.Gainsboro;
            }
            else
            {
                De_4_1 = false;
                De_4_2 = false;
                De_5_1 = false;
                De_5_2 = false;
                De_6_1 = false;
                De_6_2 = false;
                De_7_2 = false;
                De_8_1 = false;
                De_8_2 = false;
                button145.BackColor = Color.Gainsboro;
                button144.BackColor = Color.Gainsboro;
                button146.BackColor = Color.Gainsboro;
                button147.BackColor = Color.Gainsboro;
                button148.BackColor = Color.Gainsboro;
                button149.BackColor = Color.Gainsboro;
                button34.BackColor = Color.Green;
                button150.BackColor = Color.Gainsboro;
                button151.BackColor = Color.Gainsboro;
                button152.BackColor = Color.Gainsboro;
            }

            if (button34.BackColor == Color.Green)
            {
                //serialPort1.Write("APP-OFF-" + TU_TU_PHAI_THO.ToString() + "\r\n");
                _ = PhongCho_Server.SendMessageAsync("SANKHAU_7_1");
                _ = PhongCho_Server.SendMessageAsync("SAN_KHAU-CREATE_EXAMPLE-" + DAP_AN_DE_7_1.ToString());
            }
        }

        private void button150_Click(object sender, EventArgs e)
        {
            De_7_2 = !De_7_2;
            if (De_7_2 == false)
            {
                button150.BackColor = Color.Gainsboro;
            }
            else
            {
                De_4_1 = false;
                De_4_2 = false;
                De_5_1 = false;
                De_5_2 = false;
                De_6_1 = false;
                De_6_2 = false;
                De_7_1 = false;
                De_8_1 = false;
                De_8_2 = false;
                button145.BackColor = Color.Gainsboro;
                button144.BackColor = Color.Gainsboro;
                button146.BackColor = Color.Gainsboro;
                button147.BackColor = Color.Gainsboro;
                button148.BackColor = Color.Gainsboro;
                button149.BackColor = Color.Gainsboro;
                button34.BackColor = Color.Gainsboro;
                button150.BackColor = Color.Green;
                button151.BackColor = Color.Gainsboro;
                button152.BackColor = Color.Gainsboro;
            }

            if (button150.BackColor == Color.Green)
            {
                //serialPort1.Write("APP-OFF-" + TU_TU_PHAI_THO.ToString() + "\r\n");
                _ = PhongCho_Server.SendMessageAsync("SANKHAU_7_2");
                _ = PhongCho_Server.SendMessageAsync("SAN_KHAU-CREATE_EXAMPLE-" + DAP_AN_DE_7_2.ToString());
            }
        }

        private void button152_Click(object sender, EventArgs e)
        {
            De_8_2 = !De_8_2;
            if (De_8_2 == false)
            {
                button152.BackColor = Color.Gainsboro;
            }
            else
            {
                De_4_1 = false;
                De_4_2 = false;
                De_5_1 = false;
                De_5_2 = false;
                De_6_1 = false;
                De_6_2 = false;
                De_7_1 = false;
                De_7_2 = false;
                De_8_1 = false;
                button145.BackColor = Color.Gainsboro;
                button144.BackColor = Color.Gainsboro;
                button146.BackColor = Color.Gainsboro;
                button147.BackColor = Color.Gainsboro;
                button148.BackColor = Color.Gainsboro;
                button149.BackColor = Color.Gainsboro;
                button34.BackColor = Color.Gainsboro;
                button150.BackColor = Color.Gainsboro;
                button151.BackColor = Color.Gainsboro;
                button152.BackColor = Color.Green;
            }

            if (button152.BackColor == Color.Green)
            {
                _ = PhongCho_Server.SendMessageAsync("SANKHAU_8_2");
                _ = PhongCho_Server.SendMessageAsync("SAN_KHAU-CREATE_EXAMPLE-" + DAP_AN_DE_8_2.ToString());
            }
        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void button47_Click_1(object sender, EventArgs e)
        {
            if (button47.BackColor == Color.Gainsboro)
            {
                //1. bật đèn nền
                _ = Tudien_Server.SendMessageAsync("ON_MAY_CHIEU");

                //2. chạy video
                _ = MayChieuSanKhau_Server.SendMessageAsync("VIDEO-1");

                button47.BackColor = Color.Green;
            }
            else
            {
                //1. tắt đèn nền
                _ = Tudien_Server.SendMessageAsync("OFF_MAY_CHIEU");

                //2. stop video
                _ = MayChieuSanKhau_Server.SendMessageAsync("STOP-1");

                button47.BackColor = Color.Gainsboro;
            }



        }

        int countChangeColor = 0;
        bool SetChangeColor = false;
        private void timer4_Tick(object sender, EventArgs e)
        {

        }

        private void button52_Click_1(object sender, EventArgs e)
        {
            //     _ = frmMain.DanTranh_Server.SendMessageAsync("DAN_TRANH-START_GAME");
            _ = DanTranh_Server.SendMessageAsync("DAN_TRANH-Rem_dong");
        }

        private void button155_Click(object sender, EventArgs e)
        {
            _ = frmMain.DanTranh_Server.SendMessageAsync("DAN_TRANH-Rem_moxx");
        }

        private void button156_Click(object sender, EventArgs e)
        {
            _ = PhongCho_Server.SendMessageAsync("PHONG_CHO-REMOTE_3C_TAT_UV");
        }

        private void button157_Click(object sender, EventArgs e)
        {
            _ = Tudien_Server.SendMessageAsync("BLYNK_DEN_VANG");
        }

        private void button158_Click(object sender, EventArgs e)
        {
            CONG_TAC = !CONG_TAC;
            frmMain.isPlayMusicDoaMa = true;
            if (frmMain.isPlayMusicDoaMa == true)
            {
                button158.BackColor = Color.Green;
            }
            if (CONG_TAC == false)
            {
                _ = frmMain.Dimmer_Server.SendMessageAsync("CONG_TAC_DOA_MA_OFF");
            }
            else
            {
                _ = frmMain.Dimmer_Server.SendMessageAsync("CONG_TAC_DOA_MA_ON");
            }

        }

        private void button154_Click(object sender, EventArgs e)
        {
            if (button154.BackColor != Color.Green)
            {
                //serialPort1.Write("APP-ON-" + TU_TU_PHAI_THO.ToString() + "\r\n");
                _ = Tudien_Server.SendMessageAsync("ON-" + RELAY_6.ToString());
            }
            else
            {
                //serialPort1.Write("APP-OFF-" + TU_TU_PHAI_THO.ToString() + "\r\n");
                _ = Tudien_Server.SendMessageAsync("OFF-" + RELAY_6.ToString());
            }
        }

        private void button159_Click(object sender, EventArgs e)
        {
            Den_roi_san_khau = !Den_roi_san_khau;
            if (Den_roi_san_khau == true)
            {
                //serialPort1.Write("APP-ON-" + TU_TU_PHAI_THO.ToString() + "\r\n");
                // _ = Tudien_Server.SendMessageAsync("ON-" + NUT_7.ToString());
                _ = Tudien_Server.SendMessageAsync("OFF-" + NUT_7.ToString());
                _ = Tudien_Server.SendMessageAsync("ON-" + NUT_6.ToString());
            }
            else
            {
                //serialPort1.Write("APP-OFF-" + TU_TU_PHAI_THO.ToString() + "\r\n");
                _ = Tudien_Server.SendMessageAsync("OFF-" + NUT_6.ToString());
                _ = Tudien_Server.SendMessageAsync("ON-" + NUT_7.ToString());

            }

            //if (button95.BackColor == Color.Gainsboro)
            //{
            //    //serialPort1.Write("APP-ON-" + TU_NGAN_PHAI_THO.ToString() + "\r\n");
            //    _ = Tudien_Server.SendMessageAsync("ON-" + NUT_6.ToString());
            //}
            //else
            //{
            //    //serialPort1.Write("APP-OFF-" + TU_NGAN_PHAI_THO.ToString() + "\r\n");
            //    _ = Tudien_Server.SendMessageAsync("OFF-" + NUT_6.ToString());
            //}
        }

        private void button31_Click(object sender, EventArgs e)
        {
            //sen dimmer
            Button btn = (Button)sender;
            string percent = btn.Text.Split('%')[0];
            _ = Dimmer_Server.SendMessageAsync("DIMMER-SET-" + percent);
        }

        int DataDimmer = 0;
        private void trackBar1_MouseUp(object sender, MouseEventArgs e)
        {
            if (trackBar1.Value != DataDimmer)
            {
                _ = Dimmer_Server.SendMessageAsync("DIMMER-SET-" + trackBar1.Value.ToString());
            }
        }

        private void button29_Click_1(object sender, EventArgs e)
        {
            //xac nhan
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            //scroll
            label1.Text = trackBar1.Value.ToString() + "%";
        }

        private void button41_Click(object sender, EventArgs e)
        {
            //show dap an ghe ngoi
            ShowAnswer a = new ShowAnswer();
            a.ShowDialog();
        }

        private void button160_Click(object sender, EventArgs e)
        {
            _ = SanKhau_Server.SendMessageAsync("DE_CAM_XUC_2_ON");
        }

        private void button161_Click(object sender, EventArgs e)
        {
            _ = SanKhau_Server.SendMessageAsync("DE_CAM_XUC_3_ON");
        }

        private void button163_Click(object sender, EventArgs e)
        {
            if (button163.BackColor == Color.Gainsboro)
            {
                _ = SanKhau_Server.SendMessageAsync("ON_DEN_SONG");
            }
            else
            {
                _ = SanKhau_Server.SendMessageAsync("OFF_DEN_SONG");
            }
        }

        private void button99_Click(object sender, EventArgs e)
        {
            _ = SanKhau_Server.SendMessageAsync("DE_CAM_XUC_1_ON");
        }

        private void button162_Click(object sender, EventArgs e)
        {
            _ = SanKhau_Server.SendMessageAsync("DE_CAM_XUC_4_ON");
        }

        private void button164_Click(object sender, EventArgs e)
        {
            Blynk_den_roi = !Blynk_den_roi;
            if (Blynk_den_roi == true)
            {
                _ = frmMain.Tudien_Server.SendMessageAsync("BLYNK_DEN_ROI_SAN_KHAU");
            }
            else
            {
                _ = frmMain.Tudien_Server.SendMessageAsync("NOT_BLYNK_DEN_ROI_SAN_KHAU");
            }
        }

        private void text_Dap_an_cam_xuc_TextChanged(object sender, EventArgs e)
        {

        }

        private void button98_Click(object sender, EventArgs e)
        {
            _ = SanKhau_Server.SendMessageAsync("WIN_GAME");
        }

        private void button59_Click(object sender, EventArgs e)
        {
            _ = PhongTho_Server.SendMessageAsync("PHONG_THO-START_GAME");
        }

        private void button53_Click_1(object sender, EventArgs e)
        {
            if (button53.BackColor != Color.Green)
            {
                _ = PhongTho_Server.SendMessageAsync("PHONG_THO-ON_NHANG_TRAI");
            }
            else
            {
                _ = PhongTho_Server.SendMessageAsync("PHONG_THO-OFF_NHANG_TRAI");
            }

        }

        private void button56_Click_1(object sender, EventArgs e)
        {
            if (button56.BackColor != Color.Green)
            {
                _ = PhongTho_Server.SendMessageAsync("PHONG_THO-ON_NHANG_GIUA");
            }
            else
            {
                _ = PhongTho_Server.SendMessageAsync("PHONG_THO-OFF_NHANG_GIUA");
            }
        }

        private void button57_Click_1(object sender, EventArgs e)
        {
            if (button57.BackColor != Color.Green)
            {
                _ = PhongTho_Server.SendMessageAsync("PHONG_THO-ON_NHANG_PHAI");
            }
            else
            {
                _ = PhongTho_Server.SendMessageAsync("PHONG_THO-OFF_NHANG_PHAI");
            }
        }

        private void button165_Click(object sender, EventArgs e)
        {
            _ = PhongTho_Server.SendMessageAsync("PHONG_THO-START_GAME_TU_LINH");
        }

        private void button170_Click(object sender, EventArgs e)
        {
            if (button170.BackColor != Color.Green)
            {
                _ = PhongTho_Server.SendMessageAsync("PHONG_THO-ON_CUA_TU_TRAI");
            }
            else
            {
                _ = PhongTho_Server.SendMessageAsync("PHONG_THO-OFF_CUA_TU_TRAI");
            }
        }

        private void button169_Click(object sender, EventArgs e)
        {
            if (button169.BackColor != Color.Green)
            {
                _ = PhongTho_Server.SendMessageAsync("PHONG_THO-ON_CUA_TU_PHAI");
            }
            else
            {
                _ = PhongTho_Server.SendMessageAsync("PHONG_THO-OFF_CUA_TU_PHAI");
            }
        }

        private void button168_Click(object sender, EventArgs e)
        {
            if (button168.BackColor != Color.Green)
            {
                _ = PhongTho_Server.SendMessageAsync("PHONG_THO-ON_DEN_DAU_TRAI");
            }
            else
            {
                _ = PhongTho_Server.SendMessageAsync("PHONG_THO-OFF_DEN_DAU_TRAI");
            }
        }

        private void button167_Click(object sender, EventArgs e)
        {
            if (button167.BackColor != Color.Green)
            {
                _ = PhongTho_Server.SendMessageAsync("PHONG_THO-ON_DEN_DAU_PHAI");
            }
            else
            {
                _ = PhongTho_Server.SendMessageAsync("PHONG_THO-OFF_DEN_DAU_PHAI");
            }
        }

        private void button166_Click(object sender, EventArgs e)
        {
            Stopwatch sw = Stopwatch.StartNew();

            //off den roi phong thoi
            _ = Tudien_Server.SendMessageAsync("OFF-" + NUT_18.ToString());
            sw.Start();
            while (sw.ElapsedMilliseconds < 100) ;
            sw.Stop();
            sw.Reset();

            //on den nen may chieu phong tho
            _ = Tudien_Server.SendMessageAsync("ON-" + NUT_13.ToString());
            sw.Start();
            while (sw.ElapsedMilliseconds < 100) ;
            sw.Stop();
            sw.Reset();

            //play video
            _ = MayChieuPhongTho_Server.SendMessageAsync("VIDEO-");

            //start count down
            CountTimerPhongTho = 0;
            NeedCheckTimerPlayVideoPhongTho = true;
            timerPhongTho.Start();
        }

        private void button30_Click_1(object sender, EventArgs e)
        {
            _ = PhongTho_Server.SendMessageAsync("PHONG_THO-WIN_GAME_TU_LINH");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button54_Click(object sender, EventArgs e)
        {
            Blynk_den_roi_hanh_lang = !Blynk_den_roi_hanh_lang;
            if (Blynk_den_roi_hanh_lang == true)
            {
                _ = Tudien_Server.SendMessageAsync("BLYNK_DEN_ROI_HANH_LANG");
            }
            else
            {
                _ = Tudien_Server.SendMessageAsync("NOT_BLYNK_DEN_ROI_HANH_LANG");
            }
        }

        public static bool NeedCheckTimerPlayVideoPhongTho = false;
        public static int CountTimerPhongTho = 0;
        public static int CountflashTivi = 0;
        private void timerPhongTho_Tick(object sender, EventArgs e)
        {
            //count timer when playvideo Phong Tho
            if (NeedCheckTimerPlayVideoPhongTho)
            {
                CountTimerPhongTho++;
                if (CountTimerPhongTho >= 100)
                {
                    timerPhongTho.Stop();

                    //stop video
                    _ = MayChieuPhongTho_Server.SendMessageAsync("STOP-" + NUT_18.ToString());
                    Thread.Sleep(50);

                    //tat den nen may chieu
                    _ = Tudien_Server.SendMessageAsync("OFF-" + NUT_13.ToString());
                    Thread.Sleep(50);

                    //on den roi tho
                    _ = Tudien_Server.SendMessageAsync("ON-" + NUT_18.ToString());

                    //set var
                    NeedCheckTimerPlayVideoPhongTho = false;
                }
            }

            if (NeedRunTiviGuongTrangDiem)
            {
                CountTimerPhongTho++;

                //1phut 41 thi dung (1 tick = 100ms -> 1phut 49 s là 109s = 109 * 1000 / 200 = 1090
                if (CountTimerPhongTho >= 490)
                {
                    timerPhongTho.Stop();
                    NeedRunTiviGuongTrangDiem = false;
                    //off trai
                    _ = Tudien_Server.SendMessageAsync("OFF-" + NUT_2.ToString());
                    Thread.Sleep(50);
                    //off phai
                    _ = Tudien_Server.SendMessageAsync("OFF-" + NUT_1.ToString());

                    Mp3.StopMusic();

                    //stop all video
                    _ = TiviTrangDiemTrai_Server.SendMessageAsync("STOP-");
                    _ = TiviTrangDiemPhai_Server.SendMessageAsync("STOP-");
                }
                else
                {

                    //1 phut 39s thi switch tivi 1phut 39 s là 99s = 99 * 1000 / 100 = 990
                    if (CountTimerPhongTho >= 482)
                    {
                        CountflashTivi++;
                        if (CountflashTivi % 2 == 0)
                        {
                            //on trai
                            _ = Tudien_Server.SendMessageAsync("ON-" + NUT_2.ToString());
                            Thread.Sleep(50);
                            //off phai
                            _ = Tudien_Server.SendMessageAsync("OFF-" + NUT_1.ToString());
                        }
                        else
                        {
                            //off trai
                            _ = Tudien_Server.SendMessageAsync("OFF-" + NUT_2.ToString());
                            Thread.Sleep(50);
                            //on phai
                            _ = Tudien_Server.SendMessageAsync("ON-" + NUT_1.ToString());
                        }
                    }
                }
            }

        }

        private void button138_Click(object sender, EventArgs e)
        {
            _ = frmMain.SanKhau_Server.SendMessageAsync("RESET_PCB");

            button163.BackColor = Color.Gainsboro;
            button134.BackColor = Color.Gainsboro;
            text_Dap_an_cam_xuc.Text = "";

        }

        private void button69_Click(object sender, EventArgs e)
        {
            if (button69.BackColor != Color.Green)
            {
                _ = TiviTrangDiemTrai_Server.SendMessageAsync("VIDEO_TRANG_DIEM-");
                button69.BackColor = Color.Green;
                _ = Tudien_Server.SendMessageAsync("ON-" + NUT_2.ToString());
            }
            else
            {
                _ = TiviTrangDiemTrai_Server.SendMessageAsync("STOP-");
                button69.BackColor = Color.Gainsboro;
                _ = Tudien_Server.SendMessageAsync("OFF-" + NUT_2.ToString());
            }
        }

        private void button29_Click_2(object sender, EventArgs e)
        {
            if (button29.BackColor != Color.Green)
            {
                _ = TiviTrangDiemPhai_Server.SendMessageAsync("VIDEO_TRANG_DIEM-");
                button29.BackColor = Color.Green;
                _ = Tudien_Server.SendMessageAsync("ON-" + NUT_1.ToString());
            }
            else
            {
                _ = TiviTrangDiemPhai_Server.SendMessageAsync("STOP-");
                button29.BackColor = Color.Gainsboro;
                _ = Tudien_Server.SendMessageAsync("OFF-" + NUT_1.ToString());
            }
        }

        bool NeedRunTiviGuongTrangDiem = false;
        private void button27_Click_1(object sender, EventArgs e)
        {
            if (button27.BackColor != Color.Green)
            {
                NeedRunTiviGuongTrangDiem = true;
                CountTimerPhongTho = 0;
                CountflashTivi = 0;

                //_ = TiviTrangDiemTrai_Server.SendMessageAsync("VIDEO_GUONG_TIVI-");
                //_ = TiviTrangDiemPhai_Server.SendMessageAsync("VIDEO_GUONG_TIVI-");

                _ = TiviTrangDiemTrai_Server.SendMessageAsync("VIDEO_TRANG_DIEM-");
                _ = TiviTrangDiemPhai_Server.SendMessageAsync("VIDEO_TRANG_DIEM-");
                Thread.Sleep(200);
                Mp3.PlaySong(Mp3.SOUND_48);

                //bat tivi trai
                _ = Tudien_Server.SendMessageAsync("OFF-" + NUT_2.ToString());
                Thread.Sleep(50);

                //off tivi phai
                _ = Tudien_Server.SendMessageAsync("ON-" + NUT_1.ToString());
                timerPhongTho.Interval = 200;
                timerPhongTho.Start();

            }
            else
            {
                //off all stop timer
                timerPhongTho.Stop();

                _ = TiviTrangDiemTrai_Server.SendMessageAsync("STOP-");
                button69.BackColor = Color.Gainsboro;
                _ = Tudien_Server.SendMessageAsync("OFF-" + NUT_2.ToString());


                _ = TiviTrangDiemPhai_Server.SendMessageAsync("STOP-");
                button29.BackColor = Color.Gainsboro;
                _ = Tudien_Server.SendMessageAsync("OFF-" + NUT_1.ToString());


            }
        }

        private void timerDanTranh_Tick(object sender, EventArgs e)
        {
            if (StartSoundHuanChuong)
            {
                TimerHuanChuongCount++;
                if (TimerHuanChuongCount >= 200)
                {
                    StartSoundHuanChuong = false;
                    timerDanTranh.Stop();
                    //het am thanh bat den trong tu - phat am thanh tin hieu xep huan chuong
                    _ = DanTranh_Server.SendMessageAsync("DAN_TRANH-Bat_den ");
                    Mp3.PlaySong(Mp3.SOUND_31);
                    Thread.Sleep(100);
                    //tat cua tu huan chuong phong san khau
                    _ = DanTranh_Server.SendMessageAsync("DAN_TRANH-Tat_tu_T");
                    Thread.Sleep(100);
                    //active mach huan chuong
                    _ = DanTranh_Server.SendMessageAsync("DAN_TRANH-Star_Cup");
                }

            }
        }

        private void button65_Click(object sender, EventArgs e)
        {
            //huan chuong thang
        }

        private void button67_Click_1(object sender, EventArgs e)
        {
            //huan chuong thua
        }

        private void button112_Click(object sender, EventArgs e)
        {
            _ = DanTranh_Server.SendMessageAsync("RESET_PCB");
        }

        private void button66_Click(object sender, EventArgs e)
        {
            // den tu huan chuong
            if (button66.BackColor != Color.Green)
            {
                _ = DanTranh_Server.SendMessageAsync("DAN_TRANH-Bat_den ");
            }
            else
            {
                _ = DanTranh_Server.SendMessageAsync("DAN_TRANH-Tat_den ");
            }
        }

        private void button111_Click(object sender, EventArgs e)
        {
            //tu huan chuong
            if (button111.BackColor == Color.Green)
            {
                _ = DanTranh_Server.SendMessageAsync("DAN_TRANH-Tat_tu_T");
            }
            else
            {
                _ = DanTranh_Server.SendMessageAsync("DAN_TRANH-Bat_tu_T");
            }
        }
    }
}
