using Cinemachine;
using UnityEngine;

namespace CourseworkGame.Cam
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private RectTransform joystickRect;
        [SerializeField] private float sensitivity = 0.1f;

        private CinemachineVirtualCamera _virtualCamera;
        private Camera _mainCamera;
        private Vector2 _lookInput;

        private void Start()
        {
            _virtualCamera = GetComponent<CinemachineVirtualCamera>();
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            _lookInput = Vector2.zero;
            
            foreach (var touch in Input.touches)
            {
                if (!IsTouchingJoystick(touch.position))
                {
                    _lookInput += touch.deltaPosition * sensitivity;
                }
            }

            if (_lookInput != Vector2.zero)
            {
                CinemachinePOV pov = _virtualCamera.GetCinemachineComponent<CinemachinePOV>();
                if (pov != null)
                {
                    pov.m_HorizontalAxis.Value += _lookInput.x;
                    pov.m_VerticalAxis.Value -= _lookInput.y;
                }
            }
        }
        
        private bool IsTouchingJoystick(Vector2 touchPosition)
        {
            return RectTransformUtility.RectangleContainsScreenPoint(joystickRect, touchPosition, _mainCamera);
        }
    }
}