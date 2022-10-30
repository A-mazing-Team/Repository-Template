using System;
using UnityEngine;
using DG.Tweening;

public class ScaleAnimation : CustomAnimation
{
    [SerializeField] private Transform _scalingTransform;
    [SerializeField] private float _scaleMultiplyer;

    private Vector3 _originScale;

    private void Awake()
    {
        _originScale = _scalingTransform.localScale;
    }

    public override void Play(Action callback = null)
    {
        TryKillAndCreateNewSequence();

        Sequence.Append(
            _scalingTransform.DOScale(_originScale * _scaleMultiplyer, Properties.Duration)
            .SetEase(Properties.Ease, Properties.EaseOvershoot));

        PostProcessAnimation(callback);
    }

    public override void Stop()
    {
        TryKillSequence();
        _scalingTransform.localScale = _originScale;
    }
}
