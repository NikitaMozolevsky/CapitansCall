using Cinemachine;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CameraConrtol
{
    public class StopCinemachIfNonClickedPanel : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public CinemachineFreeLook cinemachineFreeLook;
        public const float XStartMaxSpeed = 300;
        public const float _YStartMaxSpeed = 2;
        public float timeToDecrease = 2.0f;
        public float inertiaMultiplier = 2.0f;
        public bool isClicked = false;
        private Coroutine _decreaseSpeedCoroutine;
        private Vector3 _lastInputPosition;

        private void Start()
        {
            cinemachineFreeLook.m_XAxis.m_MaxSpeed = 0;
            cinemachineFreeLook.m_YAxis.m_MaxSpeed = 0;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            isClicked = true;
            cinemachineFreeLook.m_XAxis.m_MaxSpeed = XStartMaxSpeed;
            cinemachineFreeLook.m_YAxis.m_MaxSpeed = _YStartMaxSpeed;

            if (Input.touchCount > 0)
            {
                _lastInputPosition = Input.touches[0].position;
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            isClicked = false;
            cinemachineFreeLook.m_XAxis.m_MaxSpeed = 0;
            cinemachineFreeLook.m_YAxis.m_MaxSpeed = 0;
            /*decreaseSpeedCoroutine = StartCoroutine(DecreaseSpeedOverTime(timeToDecrease));*/
        }

        /*IEnumerator DecreaseSpeedOverTime(float duration)
    {
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            float inertiaFactor = 1.0f;

            // If the button is not pressed, consider inertia
            if (!isClicked)
            {
                if (Input.touchCount > 0)
                {
                    Vector3 currentInputPosition = Input.touches[0].position;
                    float inputDelta = (currentInputPosition - lastInputPosition).magnitude;
                    inertiaFactor = 1.0f + inputDelta * inertiaMultiplier;
                    lastInputPosition = currentInputPosition;
                }
            }

            // Use Mathf.Lerp for gradual speed reduction with inertia
            _cinemachineFreeLook.m_XAxis.m_MaxSpeed = Mathf.Lerp(_XStartMaxSpeed, 0, elapsedTime / duration) * inertiaFactor;
            _cinemachineFreeLook.m_YAxis.m_MaxSpeed = Mathf.Lerp(_YStartMaxSpeed, 0, elapsedTime / duration) * inertiaFactor;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure that values are exactly 0 at the end
        _cinemachineFreeLook.m_XAxis.m_MaxSpeed = 0;
        _cinemachineFreeLook.m_YAxis.m_MaxSpeed = 0;

        decreaseSpeedCoroutine = null; // Coroutine is finished
    }*/
    }
}