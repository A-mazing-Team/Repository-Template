using UnityEngine;

[System.Serializable]
public struct RangeInt
{
    [SerializeField] public int min;
    [SerializeField] public int max;

    public RangeInt(int minValue, int maxValue)
    {
        min = minValue;
        max = maxValue;
    }

    public int RandomValue => Random.Range(min, max);
    public int Clamp(int value)
    {
        return Mathf.Clamp(value, min, max);
    }
}