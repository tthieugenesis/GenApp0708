using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThanVong
{
     public static   class PhongCho_Class
    {
         public static    void GetFrame(string message)
        {
            try {
                string data = message.Split('-')[1];
                //if (data == "HAND_CORRECT")
                //{
                //    //set text
                //    frmMain.btnWinHand.BackColor = Color.Yellow;
                //    frmMain.btnWinHand.Text = "Đặt tay đúng";
                //    Mp3.PlaySong(Mp3.SOUND_2);
                //    _ = frmMain.Tudien_Server.SendMessageAsync("OFF-" + frmMain.DEN_CHAO_VANG.ToString());
                //    _ = frmMain.Tudien_Server.SendMessageAsync("ON-" + frmMain.DEN_CHO_TIM.ToString());
                //    //Mp3.PlayBackground(Mp3.SOUND_3);
                //    //play bg2
                //}
                if(data == "FULL SEAT DONE"){
                   _= frmMain.TiviSanKhau_Server.SendMessageAsync("STOP"); // ??

                    //tat tivi
                    _ = frmMain.Tudien_Server.SendMessageAsync("OFF-" + frmMain.NUT_3.ToString());
                    Mp3.PauseBackground();

                    _ = frmMain.PhongCho_Server.SendMessageAsync("PHONG_CHO-LANH_LEO_CHUAN_BI");
                    
                    Mp3.PlaySong(Mp3.SOUND_12); // Chuan bi tiet muc mua

                    _ = frmMain.DanTranh_Server.SendMessageAsync("DAN_TRANH-Rem_dong");

                    _ = frmMain.Dimmer_Server.SendMessageAsync("Dimmer_trong_5s");

                }
                if (data == "START_GAME")
                {
                    frmMain.btnStartHand.BackColor = Color.Green;
                }
                //else if (data == "WIN_GAME")
                //{

                //    frmMain.btnWinHand.BackColor = Color.Green;
                //    frmMain.btnWinHand.Text = "Thắng game";
                //    Mp3.PlaySong(Mp3.SOUND_5);


                //    //MO CUA SAN KHAU
                //}
                else if (data == "MO_CUA_SAN_KHAU")
                {
                    //frmMain.serialPort1.Write("APP-ON-1\r\n");
                    _ = frmMain.Tudien_Server.SendMessageAsync("OFF-" + frmMain.TU_CHO_SAN_KHAU.ToString());
                    _ = frmMain.PhongCho_Server.SendMessageAsync("SAN_KHAU-UV_ON");
                }
                if (data == "Time travel")
                {
                    Mp3.PlaySong(Mp3.SOUND_9);
                    //play bg2

                    _ = frmMain.Tudien_Server.SendMessageAsync("BLYNK_DEN_VANG");
                }
                if (data == "Stop music")
                {
                    Mp3.StopMusic();
                    _ = frmMain.Tudien_Server.SendMessageAsync("NOT_BLYNK_DEN_VANG");
                }

                else if (data == "Rem_mo")
                {
                    // _ = frmMain.DanTranh_Server.SendMessageAsync("DAN_TRANH-Rem_mo");
                    _ = frmMain.DanTranh_Server.SendMessageAsync("DAN_TRANH-Rem_moxx");
                }
                else if (data == "Rem_dong")
                {
                    _ = frmMain.DanTranh_Server.SendMessageAsync("DAN_TRANH-Rem_dong");
                }
                else if (data == "bat_den_roi_san_khau")
                {
                    _ = frmMain.Tudien_Server.SendMessageAsync("ON-" + frmMain.NUT_7.ToString());
                }
                else if (data == "tat_den_roi_san_khau")
                {
                    _ = frmMain.Tudien_Server.SendMessageAsync("OFF-" + frmMain.NUT_7.ToString());
                }
                else if (data == "am_thanh_ma_mi")
                {
                    Mp3.PlaySong(Mp3.SOUND_13);
                    _ = frmMain.Tudien_Server.SendMessageAsync("BLYNK_DEN_ROI_SAN_KHAU");
                }
                else if (data == "BAT DEN TIM")
                {
                    _ = frmMain.Tudien_Server.SendMessageAsync("OFF-" + frmMain.NUT_14.ToString());// Bat den tim
                   // Mp3.PlaySong(Mp3.SOUND_8);
                }
                else if (data == "BAT_DT_LAY_VE")
                {
                    Mp3.PlaySong(Mp3.SOUND_8); // Bat DT lay ve
                }
                else if (data == "MA_SAN_KHAU")
                {
                    Mp3.PlaySong(Mp3.SOUND_14);
                    //play bg2
                }
                else if(data == "PROTECT_SAN_KHAU_ON")
                {
                    //1. Bat den nen
                    //     _ = frmMain.Tudien_Server.SendMessageAsync("TU_DIEN-ON_MAY_CHIEU");

                    Mp3.PauseBackground();
                    _ = frmMain.Tudien_Server.SendMessageAsync("ON-" + frmMain.NUT_4.ToString());
                    //2. chạy video
                    _ = frmMain.MayChieuSanKhau_Server.SendMessageAsync("VIDEO-1");
                    
                }

                else if (data == "PHAT_VIDEO_XONG")
                {
                    //1. tat den nen
                    _ = frmMain.Tudien_Server.SendMessageAsync("OFF-" + frmMain.NUT_4.ToString());

                    //2. stop video
                    _ = frmMain.MayChieuSanKhau_Server.SendMessageAsync("STOP");

                    //_ = frmMain.Tudien_Server.SendMessageAsync("ON-" + frmMain.NUT_7.ToString());

                    Mp3.playBG.controls.play();
                    Mp3.backGroundisPlaying = true;
                    //Mp3.PlaySong(Mp3.SOUND_13);
                }
                else if(data == "bat_den_long_san_khau")
                {
                    _ = frmMain.Dimmer_Server.SendMessageAsync("DIMMER-SET-90");
                   
                }
                //else if (data == "bat_den_roi_ghe_ngoi")
                //{
                //    _ = frmMain.Tudien_Server.SendMessageAsync("ON-" + frmMain.NUT_6.ToString());

                //}
                //else if (data == "tat_den_roi_ghe_ngoi")
                //{
                //    _ = frmMain.Tudien_Server.SendMessageAsync("OFF-" + frmMain.NUT_6.ToString());
                //   // _ = frmMain.Tudien_Server.SendMessageAsync("OFF-" + frmMain.NUT_7.ToString());

                //}
                else if (data == "BLYNK_DEN_VANG")
                {
                    _ = frmMain.Tudien_Server.SendMessageAsync("BLYNK_DEN_VANG");

                }
                else if (data == "NOT_BLYNK_DEN_VANG")
                {
                    _ = frmMain.Tudien_Server.SendMessageAsync("NOT_BLYNK_DEN_VANG");

                }
                else if (data == "ON_UV")
                {
                    frmMain.button50.Invoke((MethodInvoker)delegate
                    {
                        frmMain.button50.BackColor = Color.Green;
                    });
                  //  frmMain.button50.BackColor = Color.Green;
                }
                else if (data == "OFF_UV")
                {
                    frmMain.button50.Invoke((MethodInvoker)delegate
                    {
                        frmMain.button50.BackColor = Color.Gainsboro;
                    });
                }
                else if (data == "TU_QUAY_VE_ON")
                {
                    frmMain.button49.Invoke((MethodInvoker)delegate
                    {
                        frmMain.button49.BackColor = Color.Gainsboro;
                    });
                }
                else if (data == "TU_QUAY_VE_OFF")
                {
                    frmMain.button49.Invoke((MethodInvoker)delegate
                    {
                        frmMain.button49.BackColor = Color.Green;
                    });
                }
                else if (data == "CHAM_MAT_NA_HY")
                {
                    frmMain.button174.Invoke((MethodInvoker)delegate
                    {
                        frmMain.button174.BackColor = Color.Green;
                    });
                }
                else if (data == "CHUA_CHAM_MAT_NA_HY")
                {
                    frmMain.button174.Invoke((MethodInvoker)delegate
                    {
                        frmMain.button174.BackColor = Color.Gainsboro;
                    });
                }
                else if (data == "CHAM_MAT_NA_O")
                {
                    frmMain.button173.Invoke((MethodInvoker)delegate
                    {
                        frmMain.button173.BackColor = Color.Green;
                    });
                }
                else if (data == "CHUA_CHAM_MAT_NA_O")
                {
                    frmMain.button173.Invoke((MethodInvoker)delegate
                    {
                        frmMain.button173.BackColor = Color.Gainsboro;
                    });
                }
                else if (data == "CHAM_MAT_NA_AI")
                {
                    frmMain.button175.Invoke((MethodInvoker)delegate
                    {
                        frmMain.button175.BackColor = Color.Green;
                    });
                }
                else if (data == "CHUA_CHAM_MAT_NA_AI")
                {
                    frmMain.button175.Invoke((MethodInvoker)delegate
                    {
                        frmMain.button175.BackColor = Color.Gainsboro;
                    });
                }
                else if (data == "CHAM_MAT_NA_NO")
                {
                    frmMain.button172.Invoke((MethodInvoker)delegate
                    {
                        frmMain.button172.BackColor = Color.Green;
                    });
                }
                else if (data == "CHUA_CHAM_MAT_NA_NO")
                {
                    frmMain.button172.Invoke((MethodInvoker)delegate
                    {
                        frmMain.button172.BackColor = Color.Gainsboro;
                    });
                }

            } catch (Exception e) {
                Log.Error(e.ToString());
            }

            
        }

    }
}
