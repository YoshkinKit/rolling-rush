using UnityEngine;
using UnityEngine.InputSystem;
using Gyroscope = UnityEngine.InputSystem.Gyroscope;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    
    private Rigidbody _rigidbody;
    
    private void Awake()
    {
        InputSystem.AddDevice<Accelerometer>();
        InputSystem.AddDevice<Gyroscope>();
        InputSystem.EnableDevice(Accelerometer.current);
        InputSystem.EnableDevice(Gyroscope.current);
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        var acceleration = Accelerometer.current.acceleration.ReadValue();

        Debug.Log(acceleration);
        
        _rigidbody.velocity += new Vector3(acceleration.x, 0, -acceleration.z) * (Time.deltaTime * speed);
    }
}
