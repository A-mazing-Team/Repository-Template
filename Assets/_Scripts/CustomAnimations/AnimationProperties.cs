using UnityEngine;
using DG.Tweening;
using System;

[Serializable]
public class AnimationProperties
{
    [SerializeField] private float _duration;
    [SerializeField] private Ease _ease = Ease.Linear;
    [SerializeField] private float _easeOvershoot = 1.7f;

    public float Duration { get => _duration; set => _duration = value; }
    public Ease Ease { get => _ease; set => _ease = value; }
    public float EaseOvershoot { get => _easeOvershoot; set => _easeOvershoot = value; }
}

[Serializable]
public class AnimationLoopProperties
{
    [SerializeField] private int _loops = -1;
    [SerializeField] private LoopType _type = LoopType.Yoyo;
    [SerializeField] [Min(0)] private float _delays;

    public int Loops { get => _loops; set => _loops = value; }
    public LoopType Type { get => _type; set => _type = value; }
    public float Delays { get => _delays; set => _delays = value; }
}
