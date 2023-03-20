using UnityEngine;

public class TargetFrameRate : MonoBehaviour
{
    [SerializeField] private int _targetFrameRate;

    private void Start()
    {
        Application.targetFrameRate = _targetFrameRate;
    }
}
