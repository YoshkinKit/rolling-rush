using UnityEngine;

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

    private void Awake()
    {
        GlobalEventManager.OnFinish.AddListener(() =>
        {
            enabled = false;
        });
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
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
        Move(Vector3.forward * joystick.Vertical + Vector3.right * joystick.Horizontal);
    }

    private void MoveWithAccelerometer()
    {
        Move(AdjustAcceleration(Input.acceleration));
    }

    private void Move(Vector3 direction)
    {
        _rigidbody.AddForce(direction * (speed * Time.fixedDeltaTime));
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

    public enum MovementType
    {
        Accelerometer,
        Joystick
    } 
}