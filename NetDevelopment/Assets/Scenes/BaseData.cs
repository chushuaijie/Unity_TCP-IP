using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public abstract class BaseData 
{
    // Start is called before the first frame update
    /// <summary>
    /// 用于子类重写的 获取字节数组容器大小的方法
    /// </summary>
    /// <returns></returns>
    public abstract int GetBytesNum();

    /// <summary>
    /// 把成员变量序列化为对应的字节数组
    /// </summary>
    /// <returns></returns>
    public abstract byte[] writing();

    /// <summary>
    /// 把二进制字节数组反序列化到成员变量中
    /// </summary>
    /// <param name="bytes"></param>
    public abstract int Reading(byte[] bytes, int beginIndex = 0);

    protected void WriteInt(byte[] bytes, int value,ref int index) {
        BitConverter.GetBytes(value).CopyTo(bytes, index);
        index += sizeof(int);
    }
    protected void WriteShort(byte[] bytes, short value, ref int index) {
        BitConverter.GetBytes(value).CopyTo(bytes, index);
        index += sizeof(short);
    }
    protected void WriteLong(byte[] bytes, long value, ref int index) {
        BitConverter.GetBytes(value).CopyTo(bytes, index);
        index += sizeof(long);
    }
    protected void WriteFloat(byte[] bytes, float value, ref int index) {
        BitConverter.GetBytes(value).CopyTo(bytes, index);
        index += sizeof(float);
    }
    protected void WriteByte(byte[] bytes, byte value, ref int index) {
        bytes[index] = value;
        index += sizeof(byte);
    }
    protected void WriteBool(byte[] bytes, bool value, ref int index) {
        BitConverter.GetBytes(value).CopyTo(bytes, index);
        index += sizeof(bool);
    }
    protected void WriteString(byte[] bytes, string value, ref int index) {
        byte[] strBytes = Encoding.UTF8.GetBytes(value);
        //BitConverter.GetBytes(strBytes.Length).CopyTo(bytes, index);
        //index += sizeof(int);
        WriteInt(bytes, strBytes.Length, ref index);

        strBytes.CopyTo(bytes, index);
        index += strBytes.Length;
    }
    protected void WriteData(byte[] bytes,BaseData data, ref int index) {
        data.writing().CopyTo(bytes, index);
        index += data.GetBytesNum();
    }
    /// <summary>
    /// 根据字节数组读取整型
    /// </summary>
    /// <param name="bytes">字节数组</param>
    /// <param name="index">开始读取的索引数</param>
    /// <returns></returns>
    protected int ReadInt(byte[] bytes,ref int index) {
        int value = BitConverter.ToInt32(bytes, index);
        index += sizeof(int);
        return value;
    }
    protected short ReadShort(byte[] bytes, ref int index) {
        short value = BitConverter.ToInt16(bytes, index);
        index += sizeof(short);
        return value;
    }
    protected long ReadLong(byte[] bytes, ref int index) {
        long value = BitConverter.ToInt64(bytes, index);
        index += sizeof(long);
        return value;
    }
    protected float ReadFloat(byte[] bytes, ref int index) {
        float value = BitConverter.ToSingle(bytes, index);
        index += sizeof(float);
        return value;
    }
    protected float ReadByte(byte[] bytes, ref int index) {
        byte value =bytes[index];
        index += sizeof(byte);
        return value;
    }
    protected bool ReadBool(byte[] bytes, ref int index) {
        bool value = BitConverter.ToBoolean(bytes, index);
        index += sizeof(bool);
        return value;
    }


    protected string ReadString(byte[] bytes, ref int index) {
        // 先读取长度
        int length = ReadInt(bytes, ref index);
        //再读取内容
        string value = Encoding.UTF8.GetString(bytes, index,length);
        index += length;
        return value;
    }
    protected T ReadData<T>(byte[] bytes, ref int index) where T:BaseData,new() {
        
        T value = new T();
       index += value.Reading(bytes,index);
        return value;
    }

}
