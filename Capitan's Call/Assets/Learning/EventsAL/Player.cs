using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Шаблон методов которые ничего не возвращают и не принимают
    public delegate void MyDelegat();
    // Другой шаблон
    public delegate int MyDelegat2(float a, float b);
    // Делегат на который подписываются события
    public event MyDelegat myEvent;
    // Создание делегата и евента одной строкой
    public static Action<string> myEvent2;
    public static Func<string> MyEventFunc;
    
    // GameManager будет ожидать данное событие
    public Action onTouched;
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("I hit it!");
        myEvent2?.Invoke("Ayf!");
        onTouched?.Invoke(); // Вызовет ошибку т.к. никто не подписан
        Debug.Log(MyEventFunc?.Invoke()); // Вывод того что возвращает метод
        /*if (myEvent2 != null)
        {
            myEvent2.Invoke();    
        }
        else
        {
            Debug.Log("myEvent has null events");
        }

        if (onTouched != null)
        {
            onTouched.Invoke(); // Вызовет ошибку т.к. нет подписчиков    
        }
        else
        {
            Debug.Log("onTouched has null events");
        }*/
    }
}
