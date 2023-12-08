using UnityEngine;
using UnityEngine.EventSystems;

namespace Draft
{
    public class TouchField : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [HideInInspector]
        public Vector2 TouchDist;
        [HideInInspector]
        public Vector2 pointerOld;
        [HideInInspector]
        protected int PointerId;
        [HideInInspector]
        public bool Pressed;

        // Update is called once per frame
        void Update()
        {
            if (Pressed)
            {
                if (PointerId >= 0 && PointerId < Input.touches.Length)
                {
                    TouchDist = Input.touches[PointerId].position - pointerOld;
                    pointerOld = Input.touches[PointerId].position;
                }
                else
                {
                    TouchDist = new Vector2(Input.mousePosition.x, Input.mousePosition.y) - pointerOld;
                    pointerOld = Input.mousePosition;
                }
            }
            else
            {
                TouchDist = new Vector2();
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Pressed = true;
            PointerId = eventData.pointerId;
            pointerOld = eventData.position;
        }


        public void OnPointerUp(PointerEventData eventData)
        {
            Pressed = false;
        }

    }
}