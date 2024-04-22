using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class TestInfo : BaseData {
    public short lev;
    public Player p;
    public int hp;
    public string name;
    public bool sex;
    public override int GetBytesNum() {
        return sizeof(short) + p.GetBytesNum() + sizeof(int) + sizeof(int) + Encoding.UTF8.GetBytes(name).Length+sizeof(bool);
    }

    public override int Reading(byte[] bytes, int beginIndex = 0) {
        int index = beginIndex;
        lev = ReadShort(bytes, ref index);
        p = ReadData<Player>(bytes, ref index);
        hp = ReadInt(bytes, ref index);
        name = ReadString(bytes, ref index);
        sex = ReadBool(bytes, ref index);
        return index-beginIndex;
    }

    public override byte[] writing() {
        int index = 0;
        byte[] bytes = new byte[GetBytesNum()];
        WriteShort(bytes,lev,ref index);
        WriteData(bytes, p, ref index);
        WriteInt(bytes, hp, ref index);
        WriteString(bytes, name, ref index);
        WriteBool(bytes, sex, ref index);
        return bytes;
    }

}
public class Player : BaseData {

    public int atk;
  
    public override int GetBytesNum() {
        return 4;
    }

    public override int Reading(byte[] bytes, int beginIndex = 0) {
        
        int index = beginIndex;
        atk = ReadInt(bytes, ref index);
    
        return index - beginIndex;
    }
  

    public override byte[] writing() {
        int index = 0;
        byte[] bytes = new byte[GetBytesNum()];
        WriteInt(bytes, atk, ref index);
        return bytes;
    }
}

public class Test : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start() {
        TestInfo info = new TestInfo();
        info.lev = 87;

        info.p = new Player();
        info.p.atk = 77;
        info.hp = 100;
        info.name = "iiicsj";
        info.sex = false;

        byte[] bytes = info.writing();

        TestInfo info1 = new TestInfo();
        info1.Reading(bytes);
        print(info1.lev);
        print(info1.p.atk);
        print(info1.hp);
        print(info1.name);
        print(info1.sex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
