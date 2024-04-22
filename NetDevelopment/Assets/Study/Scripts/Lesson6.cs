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
        #region ֪ʶ��һ�ع˿ͻ�����Ҫ��������
        // 1.�����׽���Socket
        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        // 2.��Connect���������������
        try {
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
            socket.Connect(iPEndPoint);
        }
        catch (SocketException e) {
            if (e.ErrorCode == 10061) {
                print("�������ܾ�����");
            }
            else {
                print("���ӷ�����ʧ��"+e.ErrorCode);

            }
            return;
        }
        // 3.��Send��Receive��ط����շ�����
        byte[]receiveBytes = new byte[1024];
        int receiveNum = socket.Receive(receiveBytes);
        print("�յ���������������Ϣ��" + Encoding.UTF8.GetString(receiveBytes, 0, receiveNum));

        socket.Send(Encoding.UTF8.GetBytes("��ã�����iiicsj�Ŀͻ���"));
        // 4.��ShutDown�����ͷ�����
        socket.Shutdown(SocketShutdown.Both);
        // 5.�ر��׽���
        socket.Close();
        #endregion

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
