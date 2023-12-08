using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed2to1 : MonoBehaviour
{

    [SerializeField] private GameObject speedDownTo0;
    [SerializeField] private GameObject speedUpTo2;
    [SerializeField] private GameObject speedUpTo3;

    public void OnClick()
    {
        speedDownTo0.SetActive(true);
        speedUpTo2.SetActive(true);
        speedUpTo3.SetActive(false);
        gameObject.SetActive(false);
        SpeedController.Instance.SetSpeedLevel(SpeedController.SpeedLevel.FIRST);
    }
}
