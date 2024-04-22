using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class Lesson6 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 知识点一回顾客户端需要做的事情
        // 1.创建套接字Socket
        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        // 2.用Connect方法与服务器相连
        try {
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
            socket.Connect(iPEndPoint);
        }
        catch (SocketException e) {
            if (e.ErrorCode == 10061) {
                print("服务器拒绝连接");
            }
            else {
                print("连接服务器失败"+e.ErrorCode);

            }
            return;
        }
        // 3.用Send和Receive相关方法收发数据
        byte[]receiveBytes = new byte[1024];
        int receiveNum = socket.Receive(receiveBytes);
        print("收到服务器发来的消息：" + Encoding.UTF8.GetString(receiveBytes, 0, receiveNum));

        socket.Send(Encoding.UTF8.GetBytes("你好，我是iiicsj的客户端"));
        // 4.用ShutDown方法释放连接
        socket.Shutdown(SocketShutdown.Both);
        // 5.关闭套接字
        socket.Close();
        #endregion

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
