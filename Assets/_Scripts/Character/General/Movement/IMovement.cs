using UnityEngine;

public interface IMovement
{
    public float MoveSpeed { get; }
    public float RotationSpeed { get; }
    public float CurrentSpeed { get; }
    public Vector3 Velocity { get; }
    public bool Enabled { get; set; }
    public bool IsMoving { get; }
    public bool UseGravity { get; set; }

    public void Move(Vector2 input, bool rotate = true);
    public void Move(Vector3 direction, bool rotate = true);
    public void Rotate(Vector2 input);
    public void Rotate(Vector3 direction);
    public void Rotate(Vector3 direction, float speed);
}