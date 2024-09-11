using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text_Name : MonoBehaviour
{
    private InputField SelfInputField;

    // Start is called before the first frame update
    void Start()
    {
        //获取当前的input field
        SelfInputField = this.GetComponent<InputField>();

        //当输入的类型为password时
        SelfInputField.asteriskChar = '*';


        //
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //方法：当文本框的内容发生改变时，执行该方法
    public void InputFieldValueChanged(string currentValue)
    {
        print(currentValue);
    }
}
