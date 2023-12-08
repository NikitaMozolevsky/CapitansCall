using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed1to2 : MonoBehaviour
{

    [SerializeField] private GameObject speedUpTo3;

    [SerializeField] private GameObject speedDownTo1;

    public void OnClick()
    {
        speedDownTo1.SetActive(true);
        speedUpTo3.SetActive(true);
        gameObject.SetActive(false);
        SpeedController.Instance.SetSpeedLevel(SpeedController.SpeedLevel.SECOND);
    }

    
}
