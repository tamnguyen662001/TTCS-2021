using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameCaro
{
    public class ChessBoardManager
    {
        #region Properties  

        private Panel banco;
        public Panel Banco
        {
            get { return banco; }
            set { banco = value; }
        }

        private List<Player> player;
        public List<Player> Player
        {
            get { return player; }
            set { player = value; }
        }

        private int curPlayer;
        public int CurPlayer  //  biến lưu lươt của người đang chơi 
        {
            get { return curPlayer; }
            set { curPlayer = value; }
        }

        private TextBox textName;
        public TextBox TextName
        {
            get { return textName; }
            set { textName = value; }
        }

        private PictureBox picBox;
        public PictureBox PicBox
        {
            get { return picBox; }
            set { picBox = value; }
        }
        private List<List<Button>> matrix;
        public List<List<Button>> Matrix
        {
            get { return matrix; }
            set { matrix = value; }
        }


        private event EventHandler<ButtonClickEvent> pMark;
        public event EventHandler<ButtonClickEvent> PMark
        {
            add
            {
                pMark += value;
            }
            remove
            {
                pMark -= value;
            }
        }
        private event EventHandler eGame;
        public event EventHandler EGame
        {
            add
            {
                eGame += value;
            }
            remove
            {
                eGame -= value;
            }
        }
        private Stack<InforPlayTime> playTime;
        public Stack<InforPlayTime> PlayTime
        {
            get { return playTime; }
            set { playTime = value; }
        }

        #endregion

        #region Initialize
        public ChessBoardManager(Panel banco, TextBox textName, PictureBox picBox)  // PTTL  có tham số khai báo và gán giá trị cho phương thức vẽ bàn cờ
        {
            this.Banco = banco;
            this.TextName = textName; 
            this.PicBox = picBox;
            this.player = new List<Player>() // khai báo  list danh sách người chơi
            {
                new Player (" P1 ",Image.FromFile(Application.StartupPath + "\\Resources\\pic31.png")),
                new Player (" P2 ",Image.FromFile(Application.StartupPath + "\\Resources\\pic41.jpg"))
            };
        }
        #endregion
        #region Methods
        public void DrawBoard() // hàm vẽ bàn cờ
        {
            Banco.Enabled = true;

            Banco.Controls.Clear();

            PlayTime = new Stack<InforPlayTime>();

            CurPlayer = 0;//  để xác định người chơi trước
            ChangePlayer(); // Gọi hàm chuyển người chơi , chuyển kí tự , tên người chơi

            Matrix = new List<List<Button>>(); //tao mot hang moi de luu

            Button old = new Button() { Width = 0, Location = new Point(0, 0) }; // tạo button mới

            for (int i = 0; i <= Const.boardh; i++)  //boar
            {
                Matrix.Add(new List<Button>());
                for (int j = 0; j <= Const.boardw; j++)
                {
                    Button btn = new Button() // tạo đối tượng button
                    {
                        Width = Const.chessw,
                        Height = Const.chessh,
                        Location = new Point(old.Location.X + old.Width, old.Location.Y),
                        BackgroundImageLayout = ImageLayout.Stretch,// sửa kích thước của ảnh cho bằng đúng kích thước button hiển thị
                        Tag = i.ToString()  // xac dinh index
                    };
                    btn.Click += Btn_Click;
                    Banco.Controls.Add(btn);
                    Matrix[i].Add(btn);
                    old = btn;
                }

                    old.Location = new Point(0, old.Location.Y + Const.chessh); // xuống dòng và trả lại tọa độ 00 để trở lại đầu hàng
                    old.Width = 0;
                    old.Height = 0; 

            }
        }
        void Btn_Click(Object sender, EventArgs e)
        {
            Button btn = sender as Button; // ép kiểu cho sender gửi even đi 
                                           // đổi hình cho ô đó thành x o khi đc click vào
            if (btn.BackgroundImage != null)

                return; // Nếu button đã được đặt cờ thì không thực hiện đặt cờ được

            Mark(btn);

            PlayTime.Push(new InforPlayTime(ChessPoint(btn), curPlayer));

            CurPlayer = CurPlayer == 1 ? 0 : 1; // bắt đầu thực hiện việc đỏi người chơi
            ChangePlayer();

            if (pMark != null)
            {
                pMark(this, new ButtonClickEvent(ChessPoint(btn)));
            }
            if (isEndGame(btn))
            {
                endGame();
            }
        }
        public void OtherPlayerMark(Point point)  
        {
            Button btn = Matrix[point.Y][point.X];

            if (btn.BackgroundImage != null)
                return;

            Mark(btn);

            PlayTime.Push(new InforPlayTime(ChessPoint(btn), CurPlayer));

            CurPlayer = CurPlayer == 1 ? 0 : 1;
            ChangePlayer();
            

            if (isEndGame(btn))
            {
                endGame();
            }
        }
        public bool Undo()
        {
            if (PlayTime.Count <= 0)
                return false;

            bool isUndo1 = UndoAStep();
            bool isUndo2 = UndoAStep();

            InforPlayTime oldPoint = PlayTime.Peek();
            CurPlayer = oldPoint.CurPlayer == 1 ? 0 : 1;

            return isUndo1 && isUndo2;// thực hiện việc undo 2 lần cho 2 mà hình người chơi
        }

        private bool UndoAStep()
        {
            if (PlayTime.Count <= 0)
                return false;

            InforPlayTime oldPoint = PlayTime.Pop(); //xác định được điểm đặt quân cờ cuối cùng từ stack chứa lượt chơi
                                                        
            Button btn = Matrix[oldPoint.Point.Y][oldPoint.Point.X]; // từ đó lấy được button cần undo, thu hồi quân cờ đã được đặt

            btn.BackgroundImage = null;

            if (PlayTime.Count <= 0)
            {
                CurPlayer = 0;
            }
            else
            {
                oldPoint = PlayTime.Peek();
            }

            ChangePlayer(); 

            return true;
        } 
        private void Mark(Button btn)
        {
            btn.BackgroundImage = Player[CurPlayer].Mark;
        }
        private void ChangePlayer()
        {
            TextName.Text = Player[CurPlayer].Name;
            PicBox.Image = Player[CurPlayer].Mark;
        }
        private Point ChessPoint(Button btn)
        {

            int ver = Convert.ToInt32(btn.Tag); // lấy tọa độ y điểm đặt cờ  kết thúc 
            int hor = Matrix[ver].IndexOf(btn); // lay toa do x điểm đặt cờ kết thúc
            Point p = new Point(hor, ver);

            return p;
        }
        public void endGame()
        {
            if (eGame != null)
                eGame(this, new EventArgs());
        }
        #region process WinLose
        private bool isEndGameHor(Button btn)
        {
            
            Point p = ChessPoint(btn);
            int top = 0;
            for (int i = p.Y; i >= 0; i--) // đếm số điểm giống bên trái 
            {
                if (Matrix[i][p.X].BackgroundImage == btn.BackgroundImage)  // nếu 2 kí tự cờ của chúng giống nhau
                {
                    top++;
                }
                else
                {
                    break;
                }

            }
            int bottom = 0;
            for (int i = p.Y + 1; i < Const.boardh; i++) // đếm số điểm giống bên trái 
            {
            
                if (Matrix[i][p.X].BackgroundImage == btn.BackgroundImage)
                {
                    bottom++;
                }
                else
                {
                    break;
                }
            }
            return top + bottom == 5;
        }
        private bool isEndGameVer(Button btn)
        {
            Point p = ChessPoint(btn);
            int left = 0;
            for (int i = p.X; i >= 0; i--) // đếm số điểm giống bên trái 
            {

                if (Matrix[p.Y][i].BackgroundImage == btn.BackgroundImage)
                {
                    left++;
                }
                else
                {
                    break;
                }
            }
            int right = 0;
            for (int i = p.X + 1; i < Const.boardw; i++) // đếm số điểm giống bên trái 
            {

                if (Matrix[p.Y][i].BackgroundImage == btn.BackgroundImage)
                {
                    right++;
                }
                else
                {
                    break;
                }
            }
            return left + right == 5;
            
        }
        private bool isEndGameMainDia(Button btn)
        {

            Point p = ChessPoint(btn);
            int top = 0;
            for (int i = 0; i <= p.X ; i++)  
            {

                if (p.X - i < 0 || p.Y - i < 0)
                    break;
                if (Matrix[p.Y-i][p.X-i].BackgroundImage == btn.BackgroundImage)
                {
                    top++;
                }
                else
                {
                    break;
                }
            }
            int bottom = 0;

            for (int i =  1; i <= Const.boardw - p.X; i++) 
            {

                if (p.Y + i >= Const.boardh || p.X + i >= Const.boardw)
                    break;
                if (Matrix[p.X+i][p.Y+i].BackgroundImage == btn.BackgroundImage)
                {
                    bottom++;
                }
                else
                {
                    break;
                }
            }
            return top + bottom == 5;
        }
        private bool isEndGameSubDia(Button btn)
        {
            Point p = ChessPoint(btn);
            int top = 0;
            for (int i = 0; i <= p.X; i++) 
            {

                if (p.X + i > Const.boardw || p.Y - i < 0)
                    break;
                if (Matrix[p.Y - i][p.X + i].BackgroundImage == btn.BackgroundImage)
                {
                    top++;
                }
                else
                {
                    break;
                }
            }
            int bottom = 0;

            for (int i = 1; i <= Const.boardw - p.X; i++) 
            {

                if (p.Y + i >= Const.boardh || p.X - i < 0) 
                    break;
                if (Matrix[p.Y + i][p.X - i].BackgroundImage == btn.BackgroundImage)
                {
                    bottom++;
                }   
                else
                {
                    break;
                }
            }
            return top + bottom == 5;
        }
        private bool isEndGame(Button btn)
        {
            return isEndGameHor(btn) || isEndGameVer(btn) || isEndGameMainDia(btn) || isEndGameSubDia(btn);
        }
        #endregion
       
        #endregion

    }

    public class ButtonClickEvent : EventArgs //claas  mới thêm
    {
        private Point clickedPoint;

        public Point ClickedPoint
        {
            get { return clickedPoint; }
            set { clickedPoint = value; }
        }

        public ButtonClickEvent(Point point)
        {
            this.ClickedPoint = point;
        }
    }

}