using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameCaro
{
    public partial class GameCaro : Form
    {
        #region Properties  

        ChessBoardManager Banco;
        SocketManager socket;

        #endregion

        public GameCaro()
        {
            InitializeComponent();

            Control.CheckForIllegalCrossThreadCalls = false;

            Banco = new ChessBoardManager(panelBanco, textName, picBox);

            Banco.EGame += Banco_EGame1;
            Banco.PMark += Banco_PMark;

            proDemgio.Step = Const.stepcooldown;
            proDemgio.Maximum = Const.cooldown;
            proDemgio.Value = 0;
            timer1.Interval = Const.intervalcooldown;
            socket = new SocketManager();
            newGame();
        }

        #region Methods
        void endGame()
        {
            timer1.Stop();
            panelBanco.Enabled = false;
            undoToolStripMenuItem.Enabled = false;
            MessageBox.Show("Game over !!");
        }
        private void Banco_PMark(object sender , ButtonClickEvent e)
        {
            timer1.Start();
            panelBanco.Enabled = false;
            proDemgio.Value = 0;
            socket.Send(new SocketData((int)SocketCommand.SEND_POINT, "", e.ClickedPoint));
         
            undoToolStripMenuItem.Enabled = false;

              Listen();
        }
        private void Banco_EGame1(object sender, EventArgs e)
        {
            endGame();
            socket.Send(new SocketData((int)SocketCommand.END_GAME, "", new Point())); 
        }
        private void timer1_tick(object sender, EventArgs e)
        {
            proDemgio.PerformStep();

            if (proDemgio.Value >= proDemgio.Maximum)
            {
                endGame();
                socket.Send(new SocketData((int)SocketCommand.TIME_OUT, "", new Point()));
            }
        }
       
        void newGame()
        {
            proDemgio.Value = 0;
            timer1.Stop();
            undoToolStripMenuItem.Enabled = true;
            Banco.DrawBoard();
        }
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newGame();
            socket.Send(new SocketData((int)SocketCommand.NEW_GAME, "", new Point()));
            panelBanco.Enabled = true;
        }
        void Quit()
        {
            Application.Exit();
        }
        private void quitGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quit();
        }
        void Undo()
        {
            Banco.Undo();
            proDemgio.Value = 0;
        }
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Undo();
            socket.Send(new SocketData((int)SocketCommand.UNDO, "", new Point()));// thêm dòng lệnh này để sửa lỗi undo 2 bên
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Do you want to exit ", "Notification", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true; //  bỏ event đc gọi tới
            }
            else
            {
                try
                {
                    socket.Send(new SocketData((int)SocketCommand.QUIT, "", new Point()));
                }
                catch { }
            }
        }

        void Listen()
        {
            Thread listenThread = new Thread(() =>
            {
                try   
                {
                    SocketData data = (SocketData)socket.Receive();

                    ProcessData(data);
                        
                }
                catch (Exception e) { }
                
            });     
            listenThread.IsBackground = true;
            listenThread.Start();
        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            socket.IP = textIP.Text;

            if (!socket.ConnectServer())
            {
                socket.isServer = true;
                panelBanco.Enabled = true;
                socket.CreateServer();
            }
            else
            {
                socket.isServer = false;
                panelBanco.Enabled = false;
                Listen();
            }
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            textIP.Text = socket.GetLocalIPv4(NetworkInterfaceType.Wireless80211);
            if (string.IsNullOrEmpty(textIP.Text))
            {
                textIP.Text = socket.GetLocalIPv4(NetworkInterfaceType.Ethernet);
            }
        }// HÀM XỬ LÍ CÁC TRƯỜNG HỢP KHI THẮNG , THUA, HẾT THỜI GIAN, THOÁT GAME 
        private void ProcessData(SocketData data) 
            {
                switch (data.Command)
                {
                    case (int) SocketCommand.NOTIFY:
                        MessageBox.Show(data.Message);
                        break;

                    case (int) SocketCommand.NEW_GAME:
                        this.Invoke((MethodInvoker)(() =>
                        {
                            newGame();
                            panelBanco.Enabled = false;
                          }));
                        break;

                    case (int) SocketCommand.SEND_POINT:
                        this.Invoke((MethodInvoker)(() =>
                        {
                            proDemgio.Value = 0;
                            panelBanco.Enabled = true;
                            timer1.Start();
                            Banco.OtherPlayerMark(data.Point);
                            undoToolStripMenuItem.Enabled = true;
                         }));
                        break;
                    case (int) SocketCommand.UNDO:
                        Undo();
                        proDemgio.Value = 0;
                    break;
                    case (int) SocketCommand.END_GAME:
                        MessageBox.Show(" Ðã 5 con trên 1 hàng ");
                        break;
                    case (int) SocketCommand.TIME_OUT:
                        MessageBox.Show(" Hết thời gian ");
                        break;
                    case (int) SocketCommand.QUIT:
                        timer1.Stop();
                    MessageBox.Show(" Nguời chơi dã thoát ");
                        break;

                    default:
                        break;
                }
                 Listen();
            }
        #endregion
    }
}