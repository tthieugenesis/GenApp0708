using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThanVong
{
    public class TcpServerConnection
    {
        private readonly string serverIp;
        private readonly int serverPort;
        private TcpClient tcpClient;
        private NetworkStream networkStream;
        private CancellationTokenSource cancellationTokenSource;
        private bool isConnected;
        private string nameConnect;



        public TcpServerConnection(string ip, int port, string name)
        {
            serverIp = ip;
            serverPort = port;
            nameConnect = name;
        }

        public async Task ConnectAsync()
        {
            tcpClient = new TcpClient();

            while (!isConnected)
            {
                try
                {
                    await tcpClient.ConnectAsync(serverIp, serverPort);
                    isConnected = true;
                    networkStream = tcpClient.GetStream();
                    if (serverIp == frmMain.PhongChoIpAdd)
                    {
                        frmMain.btnConnectPcb1.BackColor = Color.Green;
                    }
                    if (serverIp == frmMain.DimmerIpAdd)
                    {
                        frmMain.btnConnectDimmer.BackColor = Color.Green;
                    }
                    if (serverIp == frmMain.SanKhauIpAdd)
                    {
                        frmMain.button136.BackColor = Color.Green;
                    }
                    if (serverIp == frmMain.TuDienIpAdd)
                    {
                        frmMain.button82.BackColor = Color.Green;
                    }
                    if (serverIp == frmMain.PhongThoIpAdd)
                    {
                        frmMain.button60.BackColor = Color.Green;
                    }
                    if (serverIp == frmMain.DanTranhIpAdd)
                    {
                        frmMain.button123.BackColor = Color.Green;
                    }
                    if (serverIp == frmMain.MayChieuSanKhauIpAdd)
                    {
                        //frmMain.button111.BackColor = Color.Green;
                    }
                    Log.Info($"Connected to server {serverIp}:{serverPort}");
                }
                catch (Exception ex)
                {
                    Log.Info($"Failed to connect to server: {ex.Message}");
                    await Task.Delay(1000); // Wait for 5 seconds before retrying
                }
            }

            cancellationTokenSource = new CancellationTokenSource();
            _ = ReceiveMessagesAsync(cancellationTokenSource.Token);
        }

        public async Task DisconnectAsync()
        {
            if (isConnected)
            {
                cancellationTokenSource?.Cancel();
                await networkStream.FlushAsync();
                networkStream.Close();
                tcpClient.Close();
                isConnected = false;
                if (serverIp == frmMain.PhongChoIpAdd)
                {
                    frmMain.btnConnectPcb1.BackColor = Color.Transparent;
                }

                if (serverIp == frmMain.DimmerIpAdd)
                {
                    frmMain.btnConnectDimmer.BackColor = Color.Transparent;
                }
                if (serverIp == frmMain.SanKhauIpAdd)
                {
                    frmMain.button47.BackColor = Color.Transparent;
                }
                if (serverIp == frmMain.TuDienIpAdd)
                {
                    frmMain.button82.BackColor = Color.Transparent;
                }
                if (serverIp == frmMain.PhongThoIpAdd)
                {
                    frmMain.button60.BackColor = Color.Transparent;
                }
                if (serverIp == frmMain.DanTranhIpAdd)
                {
                    frmMain.button123.BackColor = Color.Transparent;
                }
                Log.Info(nameConnect + ": Disconnected from server.");
            }
        }

        public async Task SendMessageAsync(string message)
        {
            if (!isConnected)
            {
                Log.Info(nameConnect + " Not connected to the server.");
                return;
            }
            message = "APP-" + message + "\r\n";
            byte[] data = Encoding.UTF8.GetBytes(message);

            try
            {
                await networkStream.WriteAsync(data, 0, data.Length);
                await networkStream.FlushAsync();
                if (message.Contains("NAME") == false)
                {
                    frmMain.richTextBox1.Text += "App Send: " + message;
                    frmMain.richTextBox1.SelectionStart = frmMain.richTextBox1.Text.Length;
                    frmMain.richTextBox1.ScrollToCaret();
                    Log.Info($"Sent message: {message}");
                }

            }
            catch (Exception ex)
            {
                Log.Info($"Failed to send message: {ex.Message}");
                await ReconnectAsync();
            }
        }

        private async Task ReceiveMessagesAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    byte[] buffer = new byte[4096];
                    int bytesRead = await networkStream.ReadAsync(buffer, 0, buffer.Length, cancellationToken);

                    if (bytesRead > 0)
                    {
                        string receivedMessage = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                        Log.Info($"Received message: {receivedMessage}");
                        if (!receivedMessage.Contains("NAME"))
                        {
                            frmMain.richTextBox1.Text += "App Receiver: " + receivedMessage;
                            frmMain.richTextBox1.SelectionStart = frmMain.richTextBox1.Text.Length;
                            frmMain.richTextBox1.ScrollToCaret();
                            HandleMessgReceiver(receivedMessage);
                        }

                        // Handle the received message as needed
                    }
                    else
                    {
                        await DisconnectAsync();
                        await ReconnectAsync();
                    }
                }
                catch (Exception ex)
                {
                    Log.Info($"Error while receiving message: {ex.Message}");
                    await ReconnectAsync();
                }
            }
        }

        private async Task ReconnectAsync()
        {
            Log.Info("Attempting to reconnect...");

            await DisconnectAsync();
            await ConnectAsync();
        }

        public void HandleMessgReceiver(string message)
        {
            if (message.Contains("PHONG_CHO"))
            {
                PhongCho_Class.GetFrame(message);
            }
            else if (message.Contains("DIMMER"))
            {
                Dimmer_Class.HandMessage(message);
            }
            else if (message.Contains("SAN_KHAU"))
            {
                SanKhau_Class.GetFrame(message);
            }
            else if (message.Contains("TU_DIEN"))
            {
                TuDien_Class.GetFrame(message);
            }
            else if (message.Contains("PHONG_THO"))
            {
                PhongTho_Class.GetFrame(message);
            }
            else if (message.Contains("DAN_TRANH"))
            {
                DanTranh_Class.GetFrame(message);
            }
            else if (message.Contains("MAY_CHIEU"))
            {
                MayChieu_Class.GetFrame(message);
            }
        }
    }
}
