using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
namespace TeachTcpServer
{
    class Program {
        static void Main(string[] args) {
            #region 回顾服务端需要做的事情
            // 1.创建套接字Socket
            Socket socketTcp = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            // 2.用Bind()方法将套接字与本地地址绑定
            try {
                IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
                socketTcp.Bind(ipPoint);

            }
            catch (Exception e) {
                Console.WriteLine("绑定失败"+e.Message);
                return;
            }
           
            // 3.用Listen  方法监听
            socketTcp.Listen(1024);
            Console.WriteLine("服务端绑定监听结束，等待客户端连入" );

            // 4.用Accept方法等待客户端连接
            // 5.建立连接，Accept返回套接字
            Socket socketClient = socketTcp.Accept();
            Console.WriteLine("有客户端连入");
            // 6.用Send和Receive方法收发数据
            // 发送
            socketClient.Send(Encoding.UTF8.GetBytes("欢迎连入服务器"));
            // 接受
            byte[] result = new byte[1024];
            int receiveNum = socketClient.Receive(result);
            Console.WriteLine("接受到了{0}发来的消息：{1}",socketClient.RemoteEndPoint.ToString(),Encoding.UTF8.GetString(result,0,receiveNum));
            // 7.用shutdown方法释放连接
            socketClient.Shutdown(SocketShutdown.Both);
            // 8.关闭连接
            socketClient.Close();
            #endregion

            #region 实现服务端基本逻辑

            #endregion
            Console.WriteLine("按任意键退出");
            Console.ReadKey();
        }
    }

}