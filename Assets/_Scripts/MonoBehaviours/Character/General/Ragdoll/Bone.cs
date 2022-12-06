using UnityEngine;

[RequireComponent(typeof(PhysicsBody))]
public class Bone : MonoBehaviour
{
    public PhysicsBody PhysicsBody { get; private set; }

    private void Awake()
    {
        PhysicsBody = GetComponent<PhysicsBody>();
    }
}
