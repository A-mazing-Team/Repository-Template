using DG.Tweening;
using System;
using UnityEngine;

public class UIMoveAnimation : CustomAnimation
{
    [SerializeField] private RectTransform _animatingRect;
    [SerializeField] private Vector2 _originAnchoredPosition;
    [SerializeField] private Vector2 _targetAnchoredPosition;

    public override void Play(Action callback = null)
    {
        TryKillAndCreateNewSequence();

        _animatingRect.anchoredPosition = _originAnchoredPosition;

        Sequence.Append(
            _animatingRect.DOAnchorPos(_targetAnchoredPosition, Properties.Duration)
            .SetEase(Properties.Ease, Properties.EaseOvershoot)
            );
    }

    public override void Stop()
    {
        TryKillSequence();

        _animatingRect.anchoredPosition = _targetAnchoredPosition;
    }
}
