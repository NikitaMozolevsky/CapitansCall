using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed0to1 : MonoBehaviour
{ // Поднимает скорость с 0 до 1, должен убрать увеличение скорости с 0 до 1, и включить 

    [SerializeField] private GameObject speedUpTo2;
    [SerializeField] private GameObject speedDownTo0;

    public void OnClick()
    {
        speedDownTo0.SetActive(true);
        speedUpTo2.SetActive(true);
        gameObject.SetActive(false);
        SpeedController.Instance.SetSpeedLevel(SpeedController.SpeedLevel.FIRST);
    }
}
