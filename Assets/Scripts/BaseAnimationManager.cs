using System;
using System.Collections;
using UnityEngine;
public class BaseAnimationManager : MonoBehaviour
{
    public Animator animatorController;
    protected string currentAnimation;
    protected Coroutine transitionRoutine, animationRoutine;
    protected bool isTransitioning;

    protected virtual void OnEnable() => isTransitioning = false;

    public virtual AnimationObject PlayAnimation(string animationName, Animator animator = null, bool startOnCurrentFrame = false, Action onEnd = null)
    {
        return PlayAnimation(new AnimationObject(animationName, startOnCurrentFrame, animator, onEnd));
    }

    public virtual AnimationObject PlayAnimation(AnimationObject animation)
    {
        if (isTransitioning)
        {
            return null;
        }

        ForcePlayAnimation(animation);
        return animation;
    }

    public virtual void StopTransition()
    {
        if (!isTransitioning)
            return;

        isTransitioning = false;
        if (transitionRoutine != null)
            StopCoroutine(transitionRoutine);
    }

    public virtual void PlayAnimationTransition(string animationName, bool startOnCurrentFrame = false, string nextAnim = null, Action onEnd = null, Animator animator = null)
    {
        PlayAnimationTransition(new AnimationObject(animationName, startOnCurrentFrame, animator), new AnimationObject(nextAnim));
    }

    public virtual void PlayAnimationTransition(AnimationObject transition, AnimationObject nextAnimation)
    {
        StopTransition();
        transitionRoutine = StartCoroutine(AnimationTransition(transition, nextAnimation));
    }

    public virtual float GetCurrentAnimationLength(Animator animator = null, int layer = 0, int clip = 0)
    {
        var _animator = animator ? animator : animatorController;
        return _animator.GetCurrentAnimatorClipInfo(layer)[clip].clip.length;
    }

    public virtual string GetCurrentAnimationName(Animator animator = null, int layer = 0, int clip = 0) => currentAnimation;

    public virtual float GetCurrentAnimatorTime(Animator animator = null, int layer = 0)
    {
        // adapted from https://stackoverflow.com/questions/52722206/unity3d-get-animator-controller-current-animation-time
        var _animator = animator ? animator : animatorController;
        AnimatorStateInfo animState = _animator.GetCurrentAnimatorStateInfo(layer);
        return animState.normalizedTime % 1;
    }

    ///<summary> This method plays the given animation overriding the current one, should be used carefully! </summary>
    public virtual void ForcePlayAnimation(AnimationObject animation)
    {
        if (string.IsNullOrEmpty(animation.AnimationName) || animation.AnimationName == currentAnimation)
            return;


        currentAnimation = animation.AnimationName;

        var _animator = GetAnimator(animation.Animator);

        if (animationRoutine != null)
            StopCoroutine(animationRoutine);
        animationRoutine = StartCoroutine(AnimationCoroutine(animation));
    }

    protected IEnumerator AnimationCoroutine(AnimationObject animObj)
    {
        var animator = GetAnimator(animObj.Animator);
        animator.Play(currentAnimation, 0, animObj.StartOnCurrentFrame ? GetCurrentAnimatorTime(animator) : 0.0f);

        yield return new WaitUntil(() => !animator.GetCurrentAnimatorStateInfo(0).IsName(animObj.AnimationName));
        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.99f);
        animObj.OnEnd?.Invoke();
    }

    protected IEnumerator AnimationTransition(AnimationObject transition, AnimationObject nextAnim)
    {
        if (transition == null || nextAnim == null)
            yield return null;

        isTransitioning = true;
        ForcePlayAnimation(transition);
        yield return new WaitUntil(() => GetAnimator(transition.Animator).GetCurrentAnimatorStateInfo(0).IsName(transition.AnimationName));
        yield return new WaitUntil(() => GetAnimator(transition.Animator).GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.99f);
        if (!string.IsNullOrEmpty(nextAnim.AnimationName))
            ForcePlayAnimation(nextAnim);
        isTransitioning = false;
    }

    protected virtual Animator GetAnimator(Animator anim)
    {
        return anim ? anim : animatorController;
    }
}

public class AnimationObject
{
    public string AnimationName;
    // public float duration;
    public bool StartOnCurrentFrame;
    public Animator Animator;
    public Action OnEnd;
    public AnimationObject(string animationName, bool startOnCurrentFrame = false, Animator animator = null, Action onEnd = null)
    {
        this.AnimationName = animationName;
        this.OnEnd = onEnd;
        this.StartOnCurrentFrame = startOnCurrentFrame;
        this.Animator = animator;
    }

    public AnimationObject OnComplete(Action endAction)
    {
        this.OnEnd = endAction;
        return this;
    }

    public AnimationObject SetStartOnCurrentFrame(bool value)
    {
        this.StartOnCurrentFrame = value;
        return this;
    }

    public AnimationObject SetAnimator(Animator animator)
    {
        this.Animator = animator;
        return this;
    }

}
