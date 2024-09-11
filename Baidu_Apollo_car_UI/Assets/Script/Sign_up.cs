using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Sign_up : MonoBehaviour
{
    //sql连接字符串：
    static string ConnetStr = "***";
    MySqlConnection conn = null;
    public GameObject Dialog_already_exist;
    public GameObject Dialog_empty;

    // Start is called before the first frame update
    void Start()
    {
        Dialog_already_exist = GameObject.Find("Dialog_already_exist");
        Dialog_empty = GameObject.Find("Dialog_empty");

        Dialog_already_exist.SetActive(false);
        Dialog_empty.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }


    //读取text box的注册内容并写入数据库
    public void Read_Text_Insert()
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
        }

        //读取
        GameObject obj_input_name = GameObject.Find("InputField_sign_name");
        GameObject obj_input_id = GameObject.Find("InputField_sign_id");
        GameObject obj_input_pwd = GameObject.Find("InputField_sign_password");

        string Name = obj_input_name.GetComponent<InputField>().text;
        string Id = obj_input_id.GetComponent<InputField>().text;
        string Password = obj_input_pwd.GetComponent<InputField>().text;

        //写入

        string sql = "insert into unity_apollo_car_sign_up(姓名,学号,密码) values('" + Name + "','" + Id + "','" + Password + "')";
        MySqlCommand cmd = new MySqlCommand(sql, conn);

        //查询
        string sql_find = "select count(*) from `unity_apollo_car_sign_up` where `姓名` like '" + Name + "' and `学号` = " + Id;
        MySqlCommand cmd_find = new MySqlCommand(sql_find, conn);

        if (Name == "" || Id == "" || Password == "")
        {
            Dialog_empty.SetActive(true);
        }
        else
        {
            if (Convert.ToInt32(cmd_find.ExecuteScalar()) > 0)
            {
                Dialog_already_exist.SetActive(true);
            }
            else
            {
                if (cmd.ExecuteNonQuery() == 1)
                {
                    SceneManager.LoadScene("Sign_up_success");
                    conn.Close();
                }
                else
                {
                    SceneManager.LoadScene("Main");
                    conn.Close();
                }
            }
        }
        /*
         * string sql2 = "SELECT * FROM `unity_apollo_car_sign_up` WHERE `姓名` LIKE '" + Name + "' AND `学号` = " + Id + " AND `密码` = " + Password;
         * MySqlCommand cmd2 = new MySqlCommand(sql2,conn);
         * Debug.Log(cmd2.ExecuteNonQuery());
         */
    }
}
