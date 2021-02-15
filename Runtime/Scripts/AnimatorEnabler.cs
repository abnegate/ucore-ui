using UnityEngine;

public class AnimatorEnabler : MonoBehaviour
{
    public void EnableAnimator()
    {
        var animator = GetComponent<Animator>();
        if (animator == null) {
            return;
        }
        animator.enabled = true;
    }
}
