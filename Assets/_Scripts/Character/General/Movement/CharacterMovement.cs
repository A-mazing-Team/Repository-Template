using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour, IMovement
{
    #region Variables
    [Header("Speed")]
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _rotationSpeed = 100f;

    [Header("Gravity")]
    [SerializeField] private float _gravity = -12f;
    [SerializeField] private float _groundedGravity = -2f;
    [SerializeField] private bool _useGravity = true;
    #endregion

    private Vector3 _currentPosition;
    private Vector3 _lastPosition;

    #region Properties
    public CharacterController CharacterController { get; private set; }
    public float MoveSpeed => _moveSpeed;
    public float RotationSpeed => _rotationSpeed;
    public float CurrentSpeed { get; private set; }
    public Vector3 Velocity => CharacterController.velocity;
    public bool Enabled { get => CharacterController.enabled; set => CharacterController.enabled = value; }
    public bool IsMoving => CurrentSpeed > 0.1f;
    public bool UseGravity { get => _useGravity; set => _useGravity = value; }
    #endregion

    private void Awake()
    {
        CharacterController = GetComponent<CharacterController>();
        _lastPosition = transform.position;
    }

    public void Move(Vector2 input, bool rotate = true)
    {
        Vector3 direction = new Vector3(input.x, 0, input.y);
        Move(direction, rotate);
    }

    public void Move(Vector3 direction, bool rotate = true)
    {
        if (Enabled == false) return;

        CharacterController.Move(direction.normalized * Time.deltaTime * MoveSpeed);
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
    private void Update()
    {
        if (Enabled == false) return;

        TryApplyGravity();
        CalculateSpeed();
    }

    private float _gravitySpeed;
    private void TryApplyGravity()
    {
        if (UseGravity == false) return;

        _gravitySpeed = CharacterController.isGrounded ? _groundedGravity : _gravity;

        CharacterController.Move(new Vector3(0, _gravitySpeed, 0) * Time.deltaTime);
    }

    private void CalculateSpeed()
    {
        _currentPosition = transform.position;
        CurrentSpeed = (_currentPosition - _lastPosition).magnitude / Time.deltaTime;
        _lastPosition = _currentPosition;
    }
}