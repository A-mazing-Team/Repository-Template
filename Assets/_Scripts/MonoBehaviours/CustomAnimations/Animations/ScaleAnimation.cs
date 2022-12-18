using System;
using UnityEngine;
using DG.Tweening;

public class ScaleAnimation : CustomAnimation
{
    [SerializeField] private Transform _scalingTransform;
    [SerializeField] private Vector3 _originScale;
    [SerializeField] private Vector3 _targetScale;

    public override void Play(Action callback = null)
    {
        TryKillAndCreateNewSequence();

        _scalingTransform.localScale = _originScale;

        Sequence.Append(
            _scalingTransform.DOScale(_targetScale, Properties.Duration)
            .SetEase(Properties.Ease, Properties.EaseOvershoot));

        PostProcessAnimation(callback);
    }

    public override void Stop()
    {
        TryKillSequence();
    }
}
