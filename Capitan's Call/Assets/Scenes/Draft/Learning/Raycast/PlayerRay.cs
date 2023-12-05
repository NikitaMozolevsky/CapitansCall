using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerRay : MonoBehaviour
{
    public Transform pointer;
    public Selectable currentSelectable;
    
    private void LateUpdate()
    {
        /*Ray ray1 = new Ray();
        ray1.origin = transform.position;
        ray1.origin = transform.forward;*/
        Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(transform.position, transform.forward * 100, Color.cyan);

        RaycastHit raycastHit;
        if (Physics.Raycast(ray2, out raycastHit))
        {
            Debug.Log("Hit something");
            pointer.position = raycastHit.point;

            Selectable selectable = raycastHit.collider.GetComponent<Selectable>();
            if (selectable)
            {
                if (currentSelectable && currentSelectable != selectable)
                {
                    selectable.Deselect();
                    currentSelectable = null;
                }
                currentSelectable = selectable;
                selectable.Select();
            }
            else
            {
                if (currentSelectable)
                {
                    currentSelectable.Deselect();
                    currentSelectable = null;
                }
            }
        }
        else
        {
            currentSelectable.Deselect();
            currentSelectable = null;
        }
    }
}
