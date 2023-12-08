using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed1to0 : MonoBehaviour
{

    [SerializeField] private GameObject speedUpTo1;
    [SerializeField] private GameObject speedUpTo2;

    public void OnClick()
    {
        speedUpTo1.SetActive(true);
        speedUpTo2.SetActive(false);
        gameObject.SetActive(false);
        SpeedController.Instance.SetSpeedLevel(SpeedController.SpeedLevel.ANCHOR);
    }
}
