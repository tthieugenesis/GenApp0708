using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThanVong
{
    public static class Mp3
    {
        static string excelFilePath = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + "\\SOUND";
        public static string SOUND_0 = excelFilePath + @"\all\1. Than thoai fix 11_50.mp3";
        public static string SOUND_1 = excelFilePath + @"\all\2. Lạnh lẽo 1.mp3";
        public static string SOUND_2 = excelFilePath + @"\all\3. Outtro Final 2 (FULL).mp3";
        public static string SOUND_3 = excelFilePath + @"\all\4. BG 1 MIX FINAL 1.mp3";
        public static string SOUND_4 = excelFilePath + @"\all\5. DT THIEP MOI.mp3";
        public static string SOUND_5 = excelFilePath + @"\all\6. DT PUZZLE 1.mp3";
        public static string SOUND_6 = excelFilePath + @"\all\7. Background 2.mp3";
        public static string SOUND_7 = excelFilePath + @"\all\8. Background 3.mp3";
        public static string SOUND_8 = excelFilePath + @"\all\9. DT LẤY VÉ.mp3";
        public static string SOUND_9 = excelFilePath + @"\all\10. Time Travel.mp3";
        public static string SOUND_10 = excelFilePath + @"\all\11. Ma ghe.mp3";
        public static string SOUND_11 = excelFilePath + @"\all\12. DT GHE NGOI.mp3";
        public static string SOUND_12 = excelFilePath + @"\all\13. Chuan bi mua.mp3";
        public static string SOUND_13 = excelFilePath + @"\all\14. Ma mi.mp3";
        public static string SOUND_14 = excelFilePath + @"\all\15. Ma san khau.mp3";
        public static string SOUND_15 = excelFilePath + @"\all\16. Gap ly quan.mp3";
        public static string SOUND_16 = excelFilePath + @"\all\17. Thu tuyet menh.mp3";
        public static string SOUND_17 = excelFilePath + @"\all\18. Ma treo co.mp3";
        public static string SOUND_18 = excelFilePath + @"\all\19. MA XỒ RA.mp3";
        public static string SOUND_19 = excelFilePath + @"\all\20. DT CAM XUC.mp3";
        public static string SOUND_20 = excelFilePath + @"\all\21. ĐỀ 1.mp3";
        public static string SOUND_21 = excelFilePath + @"\all\22. ĐỀ 2.mp3";
        public static string SOUND_22 = excelFilePath + @"\all\23. ĐỀ 3.mp3";
        public static string SOUND_23 = excelFilePath + @"\all\24. ĐỀ 4.mp3";
        public static string SOUND_24 = excelFilePath + @"\all\25. Dẫm sai.mp3";
        public static string SOUND_25 = excelFilePath + @"\all\26. Dẫm đúng.mp3";
        public static string SOUND_26 = excelFilePath + @"\all\27. Thắng 1 cảm xúc.mp3";
        public static string SOUND_27 = excelFilePath + @"\all\28. CHIEN THANG MACH CAM XUC.mp3";
        public static string SOUND_28 = excelFilePath + @"\all\29. JUMPSCARE CHAI TOC.mp3";
        public static string SOUND_29 = excelFilePath + @"\all\30. DT TRANG DIEM.mp3";
        public static string SOUND_30 = excelFilePath + @"\all\31. DT HUAN CHUONG.mp3";
        public static string SOUND_31 = excelFilePath + @"\all\32. SAP XEP HUAN CHUONG.mp3";
        public static string SOUND_32 = excelFilePath + @"\all\33. DAT HUAN CHUONG.mp3";
        public static string SOUND_33 = excelFilePath + @"\all\34. Thua Huân Chương.mp3";
        public static string SOUND_34 = excelFilePath + @"\all\35. Thắng Huân Chương.mp3";
        public static string SOUND_35 = excelFilePath + @"\all\36. DT TO NGHE LINH HON.mp3";
        public static string SOUND_36 = excelFilePath + @"\all\37. Am thanh nen tu linh.mp3";
        public static string SOUND_37 = excelFilePath + @"\all\38. CHAM SAI TU LINH.mp3";
        public static string SOUND_38 = excelFilePath + @"\all\39. Cham dung RFID.mp3";
        public static string SOUND_39 = excelFilePath + @"\all\40. DT TO NGHE GIAC HON.mp3";
        public static string SOUND_40 = excelFilePath + @"\all\41. GIAC HON.mp3";
        public static string SOUND_41 = excelFilePath + @"\all\42. Bắt đầu chơi đàn.mp3";
        public static string SOUND_42 = excelFilePath + @"\all\43. Thắng đàn.mp3";
        public static string SOUND_43 = excelFilePath + @"\all\44. DT TỔ NGHỀ LINH HỒN.mp3";
        public static string SOUND_44 = excelFilePath + @"\all\45. Đánh đàn sai.mp3";
        public static string SOUND_45 = excelFilePath + @"\all\46. Thắng đàn.mp3";
        public static string SOUND_47 = excelFilePath + @"\all\47. Am thanh ma di.mp3";
        public static string SOUND_48 = excelFilePath + @"\all\48. Nha_ma_demo.mp3";

        public static string DAN_TRANH_1 = excelFilePath + @"\dan_tranh\1. ho.m4a";
        public static string DAN_TRANH_2 = excelFilePath + @"\dan_tranh\2. liu.m4a";
        public static string DAN_TRANH_3 = excelFilePath + @"\dan_tranh\3. xang.m4a";
        public static string DAN_TRANH_4 = excelFilePath + @"\dan_tranh\4. xe.m4a";
        public static string DAN_TRANH_5 = excelFilePath + @"\dan_tranh\5. cong.m4a";


        public static WMPLib.WindowsMediaPlayer playBG = new WMPLib.WindowsMediaPlayer();
        public static WMPLib.WindowsMediaPlayer playSound = new WMPLib.WindowsMediaPlayer();
        public static WMPLib.WindowsMediaPlayer playTuLinh = new WMPLib.WindowsMediaPlayer();
        public static WMPLib.WindowsMediaPlayer danTranh1 = new WMPLib.WindowsMediaPlayer();
        public static WMPLib.WindowsMediaPlayer danTranh2 = new WMPLib.WindowsMediaPlayer();
        public static WMPLib.WindowsMediaPlayer danTranh3 = new WMPLib.WindowsMediaPlayer();
        public static WMPLib.WindowsMediaPlayer danTranh4 = new WMPLib.WindowsMediaPlayer();
        public static WMPLib.WindowsMediaPlayer danTranh5 = new WMPLib.WindowsMediaPlayer();
        public static WMPLib.WindowsMediaPlayer danTranhWin = new WMPLib.WindowsMediaPlayer();

        public static bool backGroundisPlaying = false;
        public static bool bPlayCutsen = false;
        public static void PlaySong(string song)
        {
            playSound.URL = song;
            playSound.settings.volume = 60;
            playSound.controls.play();
        }
        public static void PlayTuLinh(string song)
        {
            playTuLinh.URL = song;
            playTuLinh.controls.play();
        }

        public static void DanTranh_1_Play()
        {
            danTranh1.URL = DAN_TRANH_1;
            danTranh1.controls.play();
        }
        public static void DanTranh_Win_Play()
        {
            danTranhWin.URL = SOUND_35;
            danTranhWin.controls.play();
        }

        public static void DanTranh_2_Play()
        {
            danTranh2.URL = DAN_TRANH_2;
            danTranh2.controls.play();
        }

        public static void DanTranh_3_Play()
        {
            danTranh3.URL = DAN_TRANH_3;
            danTranh3.controls.play();
        }

        public static void DanTranh_4_Play()
        {
            danTranh4.URL = DAN_TRANH_4;
            danTranh4.controls.play();
        }
        public static void DanTranh_5_Play()
        {
            danTranh5.URL = DAN_TRANH_5;
            danTranh5.controls.play();
        }

        public static void DanTranh_6_Play()
        {
            danTranh5.URL = DAN_TRANH_5;
            danTranh5.controls.play();
        }

        public static void DanTranh_7_Play()
        {
            danTranh5.URL = DAN_TRANH_5;
            danTranh5.controls.play();
        }
        public static void DanTranh_8_Play()
        {
            danTranh5.URL = DAN_TRANH_5;
            danTranh5.controls.play();
        }


        public static void PlayBackground(string song)
        {
            playBG.URL = song;
            playBG.controls.play();
            backGroundisPlaying = true;
         
        }

        public static void StopBackground()
        {
            playBG.controls.stop();
            backGroundisPlaying = false;
        }

        public static void StopMusic()
        {
            playSound.controls.stop();
            backGroundisPlaying = true;
        }

        public static void PauseBackground()
        {
            Mp3.playBG.controls.pause();
            Mp3.backGroundisPlaying = false;
        }

        //public static void PauseMusic(string song)
        //{
        //    playBG.URL = song;
        //    playBG.controls.play();
        //    backGroundisPlaying = true;
        //}
    }
}
