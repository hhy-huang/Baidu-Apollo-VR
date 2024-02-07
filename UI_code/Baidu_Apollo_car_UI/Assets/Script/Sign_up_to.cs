using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sign_up_to : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Switch_to_main()
    {
        SceneManager.LoadScene("Main");
    }

    public void Switch_to_success()
    {
        SceneManager.LoadScene("Sign_up_success");
    }
}
