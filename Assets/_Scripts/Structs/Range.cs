using UnityEngine;

[System.Serializable]
public struct Range
{
    [SerializeField] public float min;
    [SerializeField] public float max;

    public Range(float minValue, float maxValue)
    {
        min = minValue;
        max = maxValue;
    }

    public float RandomValue => Random.Range(min, max);
}