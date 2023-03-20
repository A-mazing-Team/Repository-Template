using System;
using UnityEngine;
using DG.Tweening;

public abstract class CustomAnimation : DOTweenAnimation
{
    [SerializeField] private string _name;  // Для удобства, чтобы не путаться между анимациями в инспекторе

    [Header("Base Properties")]
    [SerializeField] private AnimationProperties _properties;
    [SerializeField] private bool _playOnEnable;
    [SerializeField] private bool _loop;
    [SerializeField] private AnimationLoopProperties _loopProperties;

    public AnimationProperties Properties => _properties;
    public bool PlayOnEnable => _playOnEnable;
    public bool Loop => _loop;
    public AnimationLoopProperties LoopProperties => _loopProperties;

    protected virtual void OnEnable()
    {
        if (_playOnEnable) Play();
    }

    public abstract void Play(Action callback = null);
    public abstract void Stop();

    protected void PostProcessAnimation(Action callback)
    {
        if (callback != null) Sequence.OnComplete(() => callback());
        if (LoopProperties.Delays != 0) Sequence.SetDelay(LoopProperties.Delays);
        if (Loop) TryLoopSequence(LoopProperties);
    }
}