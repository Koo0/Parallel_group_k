using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Default : MonoBehaviour
{
    void Update()
    {
        Hoge();
    }
    void Hoge()
    {
            Debug.Log("投げた");
            playTask("hoge");
            Debug.Log("返ってきた");
    }

    void playTask(string str) //タスク部分
    {
        Thread.Sleep(3000);
        TaskNext(str);
    }

    private void TaskNext(string str)
    {
        Debug.Log(str);
    }
}
