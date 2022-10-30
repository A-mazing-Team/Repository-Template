using System;
using UnityEngine;
using DG.Tweening;

public class FadeAnimation : CustomAnimation
{
    [SerializeField] private CanvasGroup _fadeGroup;
    [SerializeField] [Range(0, 1)] float _targetFade;

    private float _originAlpha;

    private void Awake()
    {
        _originAlpha = _fadeGroup.alpha;
    }

    public override void Play(Action callback = null)
    {
        TryKillAndCreateNewSequence();

        Sequence.Append(
            _fadeGroup.DOFade(_targetFade, Properties.Duration)
            .SetEase(Properties.Ease, Properties.EaseOvershoot));

        PostProcessAnimation(callback);
    }

    public override void Stop()
    {
        TryKillSequence();
        _fadeGroup.alpha = _originAlpha;
    }
}
