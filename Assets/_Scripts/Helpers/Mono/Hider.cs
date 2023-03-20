using UnityEngine;

public class Hider : MonoBehaviour
{
    private void Awake()
    {
        gameObject.SetActive(false);
    }
}
