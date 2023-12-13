using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable : MonoBehaviour
{
    public bool isSelected = false;

    public void Select()
    {
        GetComponent<Renderer>().material.color = Color.yellow;
    }

    public void Deselect()
    {
        GetComponent<Renderer>().material.color = Color.gray;
    }
    
}
