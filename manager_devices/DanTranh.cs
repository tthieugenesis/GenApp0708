using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThanVong
{
    public static class DanTranh_Class
    {
        public static void GetFrame(string message)
        {
            try
            {
                if (message.Contains("Cup_Win_Game"))
                {
                    Mp3.PlaySong(Mp3.SOUND_34);
                    frmMain.button65.BackColor = Color.Green;
                    _ = frmMain.Tudien_Server.SendMessageAsync("OFF-" + frmMain.NUT_9.ToString());
                }
                else if (message.Contains("Cup_Lose_Game"))
                {
                    Mp3.PlaySong(Mp3.SOUND_33);
                    frmMain.button67.BackColor = Color.Green;
                }
                //data cup: DAN_TRANH-RFID-2-2-DONE (2 truoc slot tren tu, 2 sau: thu tu cua cup

                else if (message.Contains("RFID"))
                {
                    try
                    {
                        string slot = message.Split('-')[2];
                        string indexCup = message.Split('-')[3];

                        //play am thanh
                        Mp3.PlaySong(Mp3.SOUND_32);

                        //show UI
                        switch (slot)
                        {
                            case "1":
                                {
                                    frmMain.button68.Text = (int.Parse(indexCup) / 2).ToString();
                                    break;
                                }
                            case "2":
                                {
                                    frmMain.button84.Text = (int.Parse(indexCup) / 2).ToString();
                                    break;
                                }
                            case "3":
                                {
                                    frmMain.button105.Text = (int.Parse(indexCup) / 2).ToString();
                                    break;
                                }
                            case "4":
                                {
                                    frmMain.button101.Text = (int.Parse(indexCup) / 2).ToString();
                                    break;
                                }
                            case "5":
                                {
                                    frmMain.button108.Text = (int.Parse(indexCup) / 2).ToString();
                                    break;
                                }

                        }
                    }
                    catch { }


                }
                else if (message.Contains("Bat_den "))
                {
                    frmMain.button66.BackColor = Color.Green;
                }
                else if (message.Contains("Tat_den"))
                {
                    frmMain.button66.BackColor = Color.Gainsboro;
                }
                else if (message.Contains("Tat_tu_T"))
                {
                    frmMain.button111.BackColor = Color.Gainsboro;
                }
                else if (message.Contains("Bat_tu_T"))
                {
                    frmMain.button111.BackColor = Color.Green;
                }

            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }


        }

    }
}
