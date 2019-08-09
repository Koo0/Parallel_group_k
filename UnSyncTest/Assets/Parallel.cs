using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks; //こいつを入れると使えます
using System.Threading;

public class Parallel : MonoBehaviour
{
    public int testCount = 0;
    // Start is called before the first frame update
    void Update()
    {
        if (testCount < 5)
        {
            Hoge();
            testCount ++;
        }
    }
    void Hoge()
    {
        Debug.Log("投げた");
        Task.Run(() => playTask("hoge"));
        Debug.Log("返ってきた");
    }

    void playTask(string str) //タスク部分
    {
        Thread.Sleep(5000);
        TaskNext(str);
    }   

    private void TaskNext(string str)
    {
        Debug.Log(str);
    }
}
