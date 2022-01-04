using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCaro
{
    public class Player  // thông tin người chơi 
    {
        private string name;  // để đóng gói thuộc tính ctrl +r +e;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private Image mark;
        public Image Mark
        {
            get { return mark; }
            set { mark= value; }
        }
        public Player (string name, Image mark) // PTTL  tạo danh sách các player để dễ quản lí 
        {
            this.Name = name; // this bieu thi cho lop hien tai
            this.Mark = mark;
        }

    }
}
