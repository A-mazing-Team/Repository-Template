using UnityEngine;

public class RigidbodyMovement : MonoBehaviour, IMovement
{
    #region Variables
    [Header("Speed")]
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _rotationSpeed = 100f;
    #endregion

    #region Properties
    public Rigidbody Rigidbody { get; private set; }
    public Collider Collider { get; private set; }
    public float MoveSpeed => _moveSpeed;
    public float RotationSpeed => _rotationSpeed;
    public float CurrentSpeed => Rigidbody.velocity.magnitude;
    public Vector3 Velocity => Rigidbody.velocity;
    public bool Enabled
    {
        get => Rigidbody.isKinematic == false && Collider.isTrigger == false;
        set
        {
            Rigidbody.isKinematic = enabled == false;
            Collider.isTrigger = enabled == false;
        }
    }
    public bool IsMoving => CurrentSpeed > 0.1f;
    public bool UseGravity { get => Rigidbody.useGravity; set => Rigidbody.useGravity = value; }
    #endregion

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        Collider = GetComponent<Collider>();
    }

    public void Move(Vector2 input, bool rotate = true)
    {
        Vector3 direction = new Vector3(input.x, 0, input.y);
        Move(direction, rotate);
    }

    public void Move(Vector3 direction, bool rotate = true)
    {
        if (Enabled == false) return;

        Rigidbody.velocity = direction * MoveSpeed;
        if (rotate) Rotate(direction);
    }

    public void Rotate(Vector2 input)
    {
        Vector3 direction = new Vector3(input.x, 0, input.y);
        Rotate(direction);
    }

    public void Rotate(Vector3 direction)
    {
        Rotate(direction, RotationSpeed);
    }

    public void Rotate(Vector3 direction, float speed)
    {
        if (Enabled == false) return;

        float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

        Quaternion targetRotation = Quaternion.Euler(transform.rotation.x,
                angle,
                transform.rotation.z);

        transform.rotation = Quaternion.Lerp(transform.rotation,
            targetRotation,
            Time.deltaTime * speed);
    }
}