using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Main_to_welcome : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Switch_to_in()
    {
        GameObject obj_name = GameObject.Find("InputField_Name");
        GameObject obj_ID = GameObject.Find("InputField_ID");
        GameObject obj_Psd = GameObject.Find("InputField_Password");

        string name = obj_name.GetComponent<InputField>().text;
        string ID = obj_ID.GetComponent<InputField>().text;
        string Psd = obj_Psd.GetComponent<InputField>().text;

        Debug.Log(name);
        SceneManager.LoadScene("IN");
        //SceneManager.LoadScene("IN");
    }

    public void Switch_to_Sign_up()
    {
        SceneManager.LoadScene("Sign_up");
    }



}
