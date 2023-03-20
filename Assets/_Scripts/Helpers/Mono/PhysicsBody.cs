using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PhysicsBody : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Collider _collider;

    public Rigidbody Rigidbody
    {
        get
        {
            if (_rigidbody == null) _rigidbody = GetComponent<Rigidbody>();
            return _rigidbody;
        }
    }

    public Collider Collider
    {
        get
        {
            if (_collider == null)
            {
                if (TryGetComponent(out _collider) == false) 
                    Debug.LogWarning($"[PhysicsBody] There is no any Collider at {gameObject.name} object");
            }

            return _collider;
        }
    }
}
