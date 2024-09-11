using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Sign_in_judge : MonoBehaviour
{
    //sql连接字符串：
    static string ConnetStr = "***";
    MySqlConnection conn = null;
    public GameObject Dialog;
    public GameObject Dialog_error;
    public GameObject Dialog_exist;
    public GameObject Dialog_psderror;

    // Start is called before the first frame update
    void Start()
    {
        Dialog = GameObject.Find("Dialog");
        Dialog_error = GameObject.Find("Dialog_error");
        Dialog_exist = GameObject.Find("Dialog_exist");
        Dialog_psderror = GameObject.Find("Dialog_psderror");

        Dialog.SetActive(false);
        Dialog_error.SetActive(false);
        Dialog_exist.SetActive(false);
        Dialog_psderror.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool If_empty()
    {
        GameObject obj_name = GameObject.Find("InputField_Name");
        GameObject obj_id = GameObject.Find("InputField_ID");
        GameObject obj_psd = GameObject.Find("InputField_Password");

        string name = obj_name.GetComponent<InputField>().text;
        string id = obj_id.GetComponent<InputField>().text;
        string psd = obj_psd.GetComponent<InputField>().text;


        if(name == "" || id == "" || psd == "")
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void judge()
    {
        GameObject obj_name = GameObject.Find("InputField_Name");
        GameObject obj_id = GameObject.Find("InputField_ID");
        GameObject obj_psd = GameObject.Find("InputField_Password");

        string name = obj_name.GetComponent<InputField>().text;
        string id = obj_id.GetComponent<InputField>().text;
        string psd = obj_psd.GetComponent<InputField>().text;

        if(!If_empty())
        {
            Dialog.SetActive(true);
        }
        else
        {
            //创建数据库连接
            conn = new MySqlConnection(ConnetStr);

            try
            {
                conn.Open();
                Debug.Log("连接成功");
            }
            catch (MySqlException ex)
            {
                //打印异常信息
                Debug.Log(ex.Message);
                Dialog_error.SetActive(true);
            }

            //查询
            string sql = "select count(*) from `unity_apollo_car_sign_up` where `姓名` like '" + name + "' and `学号` = " + id;
            MySqlCommand cmd = new MySqlCommand(sql,conn);
            if( Convert.ToInt32(cmd.ExecuteScalar()) > 0 )
            {
                string sql2 = "select count(*) from `unity_apollo_car_sign_up` where `姓名` like '" + name + "' and `学号` = " + id + " and `密码` = " + psd;
                MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
                if( Convert.ToInt32(cmd2.ExecuteScalar()) > 0)
                {
                    //将用户写入配置信息文件
                    INIParser ini = new INIParser();
                    ini.Open("C:/Baidu_Asse/" + "user.txt");
                    ini.WriteValue("Sign_message", "Name", name);
                    ini.WriteValue("Sign_message", "ID", id);
                    ini.WriteValue("Sign_message", "Time", 0);
                    ini.Close();

                    SceneManager.LoadScene("IN");
                }
                else
                {
                    Dialog_psderror.SetActive(true);
                }
            }
            else
            {
                Dialog_exist.SetActive(true);
            }
            conn.Close();
        }
    }
}
