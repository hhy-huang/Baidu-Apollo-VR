using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class Enter : MonoBehaviour
{
    string path;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Enter_in()
    {
        ProcessStartInfo psi = new ProcessStartInfo();
        psi.FileName = @"C:\Baidu_Asse\Baidu_Asse.exe";
        psi.UseShellExecute = false;
        psi.WorkingDirectory = @"C:\Baidu_Asse";
        psi.CreateNoWindow = true;
        Process.Start(psi);
    }
}
