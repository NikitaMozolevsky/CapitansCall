using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed2to3 : MonoBehaviour
{

    [SerializeField] private GameObject speedDownTo2;
    [SerializeField] private GameObject speedDownTo1;

    public void OnClick()
    {
        speedDownTo2.SetActive(true);
        speedDownTo1.SetActive(false);
        gameObject.SetActive(false);
        SpeedController.Instance.SetSpeedLevel(SpeedController.SpeedLevel.THIRD);
    }
}
