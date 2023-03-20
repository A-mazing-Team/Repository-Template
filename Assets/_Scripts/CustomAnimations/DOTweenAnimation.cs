using UnityEngine;
using DG.Tweening;

public abstract class DOTweenAnimation : MonoBehaviour
{
    public Sequence Sequence { get; protected set; }

    protected void TryKillAndCreateNewSequence()
    {
        TryKillSequence();

        Sequence = DOTween.Sequence();
    }

    protected void TryKillSequence()
    {
        if (Sequence == null) return;

        Sequence.Kill();
    }

    protected void TryLoopSequence(AnimationLoopProperties properties)
    {
        if (Sequence == null) return;

        Sequence.SetLoops(properties.Loops, properties.Type);
    }
}