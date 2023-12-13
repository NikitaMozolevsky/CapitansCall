using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private void ConsoleMessage(string text)
    {
        Debug.Log($"{text} Cube hit the ground");
    }

    private void OnEnable()
    {
        Player.myEvent2 += ConsoleMessage;
        Player.MyEventFunc += ConsoleMessageFunc;
        Player.MyEventFunc += ConsoleMessageFunc2;
    }

    private string ConsoleMessageFunc()
    {
        return "FuncAuf";
    }
    private string ConsoleMessageFunc2()
    {
        return "FuncAuf2";
    }

    private void OnDisable()
    {
        Player.myEvent2 -= ConsoleMessage;
        Player.MyEventFunc += ConsoleMessageFunc;
    }
}
