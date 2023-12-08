using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed3to2 : MonoBehaviour
{

    [SerializeField] private GameObject speedDownTo1;
    [SerializeField] private GameObject speedUpTo3;

    public void OnClick()
    {
        speedDownTo1.SetActive(true);
        speedUpTo3.SetActive(true);
        gameObject.SetActive(false);
        SpeedController.Instance.SetSpeedLevel(SpeedController.SpeedLevel.SECOND);
    }
}
