using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController
{

    private Animator _animator;
    private const float _transitionDuration = 0.1f;

    public static readonly int Idle = Animator.StringToHash("Idle");
    public static readonly int Climb = Animator.StringToHash("Climb");
    public static readonly int Victory = Animator.StringToHash("Victory");

    public PlayerAnimationController(Animator animator)
    {
        _animator = animator;
    }

    public void PlayAnim(int animHash, float transitionTime = _transitionDuration)
    {
        _animator.CrossFade(animHash, _transitionDuration);
    }
}
