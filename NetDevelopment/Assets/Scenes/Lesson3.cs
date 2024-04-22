using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class PlayerInfo {
    public int lev;
    public string name;
    public short atk;
    public bool sex;

    public byte[] GetBytes() {
        int indexNum = sizeof(int) +
                           sizeof(int) +// name字符串的长度
                           Encoding.UTF8.GetBytes(name).Length +
                           sizeof(short) +
                           sizeof(bool);
        byte[] playerBytes = new byte[indexNum];
        int index = 0;
        BitConverter.GetBytes(lev).CopyTo(playerBytes, index);
        index += sizeof(int);

        byte[] strBytes = Encoding.UTF8.GetBytes(name);
        int num = strBytes.Length;

        BitConverter.GetBytes(num).CopyTo(playerBytes, index);
        index += sizeof(int);

        strBytes.CopyTo(playerBytes, index);
        index += num;

        BitConverter.GetBytes(atk).CopyTo(playerBytes, index);
        index += sizeof(short);

        BitConverter.GetBytes(sex).CopyTo(playerBytes, index);
        index += sizeof(bool);
        return playerBytes;

    }

}
public class Lesson3 : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

        #region 非字符串类型转字节数组
        // BitConvert
        byte[] bytes = BitConverter.GetBytes(1);

        #endregion
        #region 字符串类型转字节数组
        byte[] bytes1 = Encoding.UTF8.GetBytes("今天早上");
        #endregion
        #region 类对象转化为二进制
        PlayerInfo info = new PlayerInfo();
        info.lev = 10;
        info.name = "iiicsj";
        info.atk = 88;
        info.sex = false;

        // 计算容器容量
        int indexNum = sizeof(int) +
                        sizeof(int) +// name字符串的长度
                        Encoding.UTF8.GetBytes(info.name).Length +
                        sizeof(short) +
                        sizeof(bool);

        // 声明一个装载信息的字节数组容器    
        byte[] playerBytes = new byte[indexNum];

        // 将字节信息放入容器
        int index = 0;
        BitConverter.GetBytes(info.lev).CopyTo(playerBytes, index);
        index += sizeof(int);

        byte[] strBytes = Encoding.UTF8.GetBytes(info.name);
        int num = strBytes.Length;

        BitConverter.GetBytes(num).CopyTo(playerBytes, index);
        index += sizeof(int);

        strBytes.CopyTo(playerBytes, index);
        index += num;

        BitConverter.GetBytes(info.atk).CopyTo(playerBytes, index);
        index += sizeof(short);

        BitConverter.GetBytes(info.sex).CopyTo(playerBytes, index);
        index += sizeof(bool);

        #endregion

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
