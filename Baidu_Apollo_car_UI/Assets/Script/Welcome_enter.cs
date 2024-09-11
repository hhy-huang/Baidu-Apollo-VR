using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Welcome_enter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //当前按钮被点击后要执行的操作：
    public void Event_Button_Click()//声明为public才能在Unity函数集中找到该函数
    {
        print("该按钮被触发");
    }
}
