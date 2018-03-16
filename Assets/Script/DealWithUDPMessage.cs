//*********************❤*********************
// 
// 文件名（File Name）：	DealWithUDPMessage.cs
// 
// 作者（Author）：			LoveNeon
// 
// 创建时间（CreateTime）：	Don't Care
// 
// 说明（Description）：	接受到消息之后会传给我，然后我进行处理
// 
//*********************❤*********************

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealWithUDPMessage : MonoBehaviour {
    public enum myenum{ message1,message2,message3,nothing}

    //public FocusByUDP focusByUDPClass;//根据UDP数据处理相机移动的类
    private string dataTest;
    public delegate void foo();
    public static event foo EventA;
    public static event foo EventB;
    public static event foo EventC;
    public void OnEnable()
    {
      
        EventA += EA;
        EventA += WADA;
        EventB += EB;
        EventC += EC;
    }

    public void OnDisable()
    {
        EventA -= EA;
        EventA -= WADA;
        EventB -= EB;
        EventC -= EC;
    }
    /// <summary>
    /// 消息处理
    /// </summary>
    /// <param name="_data"></param>
    public void MessageManage(string _data)
    {
        dataTest = _data;
        Debug.Log(dataTest);
        //    focusByUDPClass.CameraFocusON(_data);


        switchcase(Myenum(_data));
    }

    myenum Myenum(string dataTest) {
        if (dataTest == "1")
        {
            return myenum.message1;
        }
        if (dataTest == "2") {
            return myenum.message2;
        }
        if (dataTest == "3")
        {
            return myenum.message3;
        }
        return myenum.nothing;
    }

    void switchcase(myenum _myenum) {

        switch (_myenum)
        {
            case myenum.message1:
                doEA();
                break;
            case myenum.message2:
                doEB();
                break;
            case myenum.message3:
                doEC();
                break;
            case myenum.nothing:
                break;
            default:
                break;
        }
    }
    
    public void doEA()
    {
        if (EventA != null)
        {
            EventA();
        }
    }

    public void doEB()
    {
        if (EventB != null)
        {
            EventB();
        }
    }
    public void doEC()
    {
        if (EventC != null)
        {
            EventC();
        }
    }



    public void EA() {
        Debug.Log("EVENT A BEEN DOING");
    }

    public void WADA() {
        Debug.Log("WADA DOING");
    }

    public void EB()
    {
        Debug.Log("EVENT B BEEN DOING");
    }
    public void EC()
    {
        Debug.Log("EVENT C BEEN DOING");
    }

    private void Update()
    {
       if(Input.GetMouseButtonDown(0)) {
            EventA -= WADA;
        }
       // Debug.Log("数据：" + dataTest);  
    }

}
