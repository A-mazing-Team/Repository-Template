using System;
using UnityEngine;
using DG.Tweening;

public class FadeAnimation : CustomAnimation
{
    [SerializeField] private CanvasGroup _fadeGroup;
    [SerializeField] [Range(0, 1)] float _originFade;
    [SerializeField] [Range(0, 1)] float _targetFade;

    public override void Play(Action callback = null)
    {
        TryKillAndCreateNewSequence();

        _fadeGroup.alpha = _originFade;

        Sequence.Append(
            _fadeGroup.DOFade(_targetFade, Properties.Duration)
            .SetEase(Properties.Ease, Properties.EaseOvershoot));

        PostProcessAnimation(callback);
    }

    public override void Stop()
    {
        TryKillSequence();
    }
}
