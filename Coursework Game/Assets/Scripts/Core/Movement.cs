using UnityEngine;

namespace CourseworkGame.Core
{
    public class Movement : MonoBehaviour
    {
        [Header("Movement Settings")]
        [SerializeField] private MovementType movementType;
        [SerializeField] private float speed = 10f;

        [Header("Accelerometer Settings")]
        [SerializeField] private float maxAccelerationX = 0.5f;
        [SerializeField] private float maxAccelerationZ = 0.3f;
        private const float RightAccelerometerDeadZoneX = 0.1f;
        private const float LeftAccelerometerDeadZoneX = -0.1f;
        private const float RightAccelerometerDeadZoneZ = 0.05f;
        private const float LeftAccelerometerDeadZoneZ = -0.1f;

        [SerializeField] private Joystick joystick;
        private Rigidbody _rigidbody;
        private Transform _mainCameraTransform;

        private void Awake()
        {
            GlobalEventManager.OnFinish.AddListener(() =>
            {
                enabled = false;
                _rigidbody.velocity = Vector3.zero;
            });
            GlobalEventManager.OnDeath.AddListener(() =>
            {
                enabled = false;
            });
        }

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _mainCameraTransform = Camera.main.transform;
        }

        private void FixedUpdate()
        {
            switch (movementType)
            {
                case MovementType.Accelerometer:
                    MoveWithAccelerometer();
                    break;
                case MovementType.Joystick:
                    MoveWithJoystick();
                    break;
            }
        }

        private void MoveWithJoystick()
        {
            Move(Vector3.right * joystick.Horizontal + Vector3.forward * joystick.Vertical);
        }

        private void MoveWithAccelerometer()
        {
            Move(AdjustAcceleration(Input.acceleration));
        }

        private void Move(Vector3 direction)
        {
            if (direction == Vector3.zero) return;
            
            float targetRotationYAngle = Rotate(direction);
            Vector3 targetRotationDirection = GetTargetRotationDirection(targetRotationYAngle);
            
            _rigidbody.AddForce(targetRotationDirection * (Time.fixedDeltaTime * speed));
        }
        
        private Vector3 GetTargetRotationDirection(float targetAngle)
        {
            return Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        }

        private Vector3 AdjustAcceleration(Vector3 acceleration)
        {
            acceleration.x = acceleration.x switch
            {
                < RightAccelerometerDeadZoneX and > LeftAccelerometerDeadZoneX => acceleration.x = 0,
                _ => acceleration.x = Mathf.Clamp(acceleration.x, -maxAccelerationX, maxAccelerationX) / maxAccelerationX
            };
            acceleration.z = acceleration.z switch
            {
                < RightAccelerometerDeadZoneZ and > LeftAccelerometerDeadZoneZ => acceleration.z = 0,
                // + 0.2f потому что пользователь держит телефон немного под наклоном вперёд
                _ => acceleration.z = Mathf.Clamp(acceleration.z + 0.2f, -maxAccelerationZ, maxAccelerationZ) / maxAccelerationZ 
            };
            // Минус нужен для инвертирования наклона
            acceleration.z = -acceleration.z;
            acceleration.y = 0;

            return acceleration;
        }

        private float Rotate(Vector3 direction)
        {
            float directionAngle = GetDirectionAngle(direction);
            directionAngle = AddCameraDirectionAngle(directionAngle);

            return directionAngle;
        }

        private float GetDirectionAngle(Vector3 direction)
        {
            float directionAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

            if (directionAngle < 0f)
            {
                directionAngle += 360f;
            }

            return directionAngle;
        }

        private float AddCameraDirectionAngle(float angle)
        {
            angle += _mainCameraTransform.eulerAngles.y;

            if (angle > 360f)
            {
                angle -= 360f;
            }

            return angle;
        }

        public enum MovementType
        {
            Accelerometer,
            Joystick
        } 
    }
}