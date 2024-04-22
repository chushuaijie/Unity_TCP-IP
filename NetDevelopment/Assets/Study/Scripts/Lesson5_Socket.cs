using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using UnityEngine;

public class Lesson5_Socket : MonoBehaviour {
    void Start() {
        #region Socket套接字作用
        /// <summary>
        ///  命名空间 System.Net.Socket
        ///  
        /// 类型：
        /// 1.流套接字 TCP
        /// 2.数据包套接字 UDP 不大于32KB
        /// </summary>
        /// 
        #endregion

        //Socket s = new Socket();
        //参数一：AddressFamily 网络寻址 枚举类型 决定寻址方案
        //常用 InterNetwork IPV4
        //常用 InterNetwork6 IPV6
        //其他 unix implink ipx Iso OSI netbios Atm

        //参数二 SocketType
        // 常用
        // 1.Dgram UDP 数据报
        // 2.Stream TCP
        // 了解 Raw 基础传输协议 Rdm 无连接 面向消息 可靠
        // seqpacket 排序字节流的面向连接且可靠的双向传输

        // 参数三 ProtocolType 协议类型枚举类型，决定套接字使用的通信协议
        //常用 TCP UDP
        // 了解 1.IP IP网际协议



        //三个参数常用搭配
        //2、3参数的常用搭配:
        //SocketType.Dgram+ProtocolType.UDP =UDP协议通信(常用，主要学习)
        //SocketType.Stream+ProtocolType.TCP =TCP协议通信(常用，主要学习)
        //SocketType.Raw+ProtocolType.Icmp =Internet控制报文协议(了解)套接字类型。
        //SocketType.Raw+ProtocolType.Raw=简单的IP包通信(了解)
        //我们必须掌握的
        //TCP流套接字
        //UDP数据报套接字
        // 
        Socket socketTcp = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
    Socket socketUdp = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

    #region Socket的常用属性
    #endregion
    // Start is called before the first frame update
   
        // 套接字连接状态
        if(socketTcp.Connected) { }
        // 套接字类型

        print(socketUdp.SocketType);
        // 套接字寻址方案

        print(socketUdp.AddressFamily);
        // 套接字协议类型
        print(socketUdp.ProtocolType);
        // 从网络中获取的准备读取的数据数据量
        print(socketUdp.Available);

        //获取本机EndPoint对象（注意IPEndPoint继承EndPoint）
        //socketTcp.LocalEndPoint as IPEndPoint
        // 获取远程EndPoint对象
        // socketTcp.RemoteEndPoint as IPEndPoint


        #region Socket的常用方法
        // 1.主要用于服务端
        // 1-1 绑定IP和端口
        IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
        socketTcp.Bind(ipPoint);
        // 1-2  设置了客户端连接的最大数量
        socketTcp.Listen(10);
        // 1-3  等待客户端连入
        socketTcp.Accept();


        // 2.主要用于客户端
        // 1-1:连接远程服务器
        socketTcp.Connect(IPAddress.Parse("118.12.123.11"), 8080);
        // 3.客户端服务端都会用的
        // 1-1 同步发送和接收数据
        //socketTcp.Send()
        //socketTcp.Receive()

        // 1-2 异步发送和接收数据
        //socketTcp.SyncSend()
        //socketTcp.BeginReceive()

        // 1-3 释放连接并关闭Socket，先于Close调用
        socketTcp.Shutdown(SocketShutdown.Both);
        // 1-4 关闭连接，释放所有Socket关联资源
        socketTcp.Close();
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
