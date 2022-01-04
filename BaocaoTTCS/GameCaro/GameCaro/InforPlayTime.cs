using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCaro
{
    public class InforPlayTime
    {
        private Point point; // biến giữ gái trị tọa độ của mỗi điểm được đánh 
        public Point Point
        {
            get { return point; }
            set { point = value; }
        }
        private int curPlayer;
        public int CurPlayer // biến người chơi hiện tại
        {
            get { return curPlayer; }
            set { curPlayer = value; }
        }
        public InforPlayTime(Point point, int curPlayer)  //Hàm cho biết lượt chơi hiện tại
        {
            this.Point = point;
            this.CurPlayer = curPlayer;
        }
    }
}