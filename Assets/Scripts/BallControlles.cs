using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallControlles : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _xMin, _xMax, _yMin, _yMax;
    [SerializeField] private float _tilt;

    private Quaternion _calibrationQuaternion;
    private Rigidbody _rigibody;

    private void Start()
    {
        _rigibody = GetComponent<Rigidbody>();
        CalibrateAccelerometr();
    }

    private void CalibrateAccelerometr()
    {
        Vector3 accelerationSnapshot = Input.acceleration;
        Quaternion rotateQuaternion = Quaternion.FromToRotation(new Vector3(0.0f, 0.0f, -1.0f), accelerationSnapshot);
        _calibrationQuaternion = rotateQuaternion;
        _calibrationQuaternion = Quaternion.Inverse(rotateQuaternion);
    }

    private Vector3 FixAcceleration(Vector3 acceleration)
    {
        Vector3 fixedAcceleration = _calibrationQuaternion * acceleration;
        return fixedAcceleration;
    }

    private void FixedUpdate()
    {
        Vector3 accelerationRaw = Input.acceleration;
        Vector3 acceleration = FixAcceleration(accelerationRaw);

        _rigibody.rotation = Quaternion.Euler(0f, 0f, _rigibody.velocity.x * -_tilt);
        _rigibody.velocity = new Vector3(acceleration.x,acceleration.y, 0f) * _speed;

        _rigibody.position = new Vector3(Mathf.Clamp(_rigibody.position.x, _xMin, _xMax), Mathf.Clamp(_rigibody.position.y, _yMin, _yMax),0);
    }
}
