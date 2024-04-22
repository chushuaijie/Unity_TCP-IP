using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using UnityEngine;

public class Lesson5_Socket : MonoBehaviour {
    void Start() {
        #region Socket�׽�������
        /// <summary>
        ///  �����ռ� System.Net.Socket
        ///  
        /// ���ͣ�
        /// 1.���׽��� TCP
        /// 2.���ݰ��׽��� UDP ������32KB
        /// </summary>
        /// 
        #endregion

        //Socket s = new Socket();
        //����һ��AddressFamily ����Ѱַ ö������ ����Ѱַ����
        //���� InterNetwork IPV4
        //���� InterNetwork6 IPV6
        //���� unix implink ipx Iso OSI netbios Atm

        //������ SocketType
        // ����
        // 1.Dgram UDP ���ݱ�
        // 2.Stream TCP
        // �˽� Raw ��������Э�� Rdm ������ ������Ϣ �ɿ�
        // seqpacket �����ֽ��������������ҿɿ���˫����

        // ������ ProtocolType Э������ö�����ͣ������׽���ʹ�õ�ͨ��Э��
        //���� TCP UDP
        // �˽� 1.IP IP����Э��



        //�����������ô���
        //2��3�����ĳ��ô���:
        //SocketType.Dgram+ProtocolType.UDP =UDPЭ��ͨ��(���ã���Ҫѧϰ)
        //SocketType.Stream+ProtocolType.TCP =TCPЭ��ͨ��(���ã���Ҫѧϰ)
        //SocketType.Raw+ProtocolType.Icmp =Internet���Ʊ���Э��(�˽�)�׽������͡�
        //SocketType.Raw+ProtocolType.Raw=�򵥵�IP��ͨ��(�˽�)
        //���Ǳ������յ�
        //TCP���׽���
        //UDP���ݱ��׽���
        // 
        Socket socketTcp = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
    Socket socketUdp = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

    #region Socket�ĳ�������
    #endregion
    // Start is called before the first frame update
   
        // �׽�������״̬
        if(socketTcp.Connected) { }
        // �׽�������

        print(socketUdp.SocketType);
        // �׽���Ѱַ����

        print(socketUdp.AddressFamily);
        // �׽���Э������
        print(socketUdp.ProtocolType);
        // �������л�ȡ��׼����ȡ������������
        print(socketUdp.Available);

        //��ȡ����EndPoint����ע��IPEndPoint�̳�EndPoint��
        //socketTcp.LocalEndPoint as IPEndPoint
        // ��ȡԶ��EndPoint����
        // socketTcp.RemoteEndPoint as IPEndPoint


        #region Socket�ĳ��÷���
        // 1.��Ҫ���ڷ����
        // 1-1 ��IP�Ͷ˿�
        IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
        socketTcp.Bind(ipPoint);
        // 1-2  �����˿ͻ������ӵ��������
        socketTcp.Listen(10);
        // 1-3  �ȴ��ͻ�������
        socketTcp.Accept();


        // 2.��Ҫ���ڿͻ���
        // 1-1:����Զ�̷�����
        socketTcp.Connect(IPAddress.Parse("118.12.123.11"), 8080);
        // 3.�ͻ��˷���˶����õ�
        // 1-1 ͬ�����ͺͽ�������
        //socketTcp.Send()
        //socketTcp.Receive()

        // 1-2 �첽���ͺͽ�������
        //socketTcp.SyncSend()
        //socketTcp.BeginReceive()

        // 1-3 �ͷ����Ӳ��ر�Socket������Close����
        socketTcp.Shutdown(SocketShutdown.Both);
        // 1-4 �ر����ӣ��ͷ�����Socket������Դ
        socketTcp.Close();
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
