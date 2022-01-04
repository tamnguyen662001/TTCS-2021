using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameCaro
{
    public class SocketManager
    {
        #region Client
        Socket client;
        public bool ConnectServer()  // hàm kết nối cliet với server 
        {
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse(IP), PORT);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                client.Connect(iep);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Server
        Socket server;
        public void CreateServer()
        {
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse(IP), PORT);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.Bind(iep);
            server.Listen(20); //  đợi kết nối với client trong 20s

            Thread acceptClient = new Thread(() => // tạo 1 luồng khác thực hiện việc chấp nhập kêt nối
            {
               client = server.Accept();//  chấp nhận kết nối
            });
            acceptClient.IsBackground = true;
            acceptClient.Start();
        }

        #endregion

        #region Both
        public string IP = "127.0.0.1";
        public int PORT = 9999;
        public const int BUFFER = 1024;
        public bool isServer = true;
        public bool Send(object data) // gửi dữ liệu từ server và client 
        {
            byte[] sendData = SerializeData(data);
            
                return SendData(client, sendData);
            
        }
        public object Receive() // hàm nhận thông tin
        {
            byte[] receiveData = new byte[BUFFER];

            bool isOk = ReceiveData(client, receiveData);

            return DeserializeData(receiveData);
        }
        private bool SendData(Socket target, byte[] data) 
         {
            return target.Send(data) == 1 ? true : false;
        }
        private bool ReceiveData(Socket target, byte[] data)// không dùng từ khóa ref do mảng byte đc dùng tham chiếu
        {
            return target.Receive(data) == 1 ? true : false;
        }

        //  nén đối tượng thành mảng byte[]
        public byte[] SerializeData (Object o)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf1 = new BinaryFormatter();
            bf1.Serialize(ms, o);
            return ms.ToArray();
        }
        //giải nén mảng byte thành một đối tượng để nhận và hiểu được thông tin
        public object DeserializeData(byte[] theByteArray)
        {

            MemoryStream ms = new MemoryStream(theByteArray);
            BinaryFormatter bf1 = new BinaryFormatter();
            ms.Position = 0;
            return bf1.Deserialize(ms);
        }
        //  lấy ra giá trị IP4 của card mạng đang sử dụng
        public string GetLocalIPv4 (NetworkInterfaceType _type)
        {
            string output = "";
            foreach(NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (item.NetworkInterfaceType == _type && item.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                    {
                        if(ip.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            output = ip.Address.ToString();
                        }
                    }
                }
            }
            return output;
        }
        #endregion
    }
}
