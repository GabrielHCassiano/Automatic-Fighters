using UnityEngine;

public class AnimationsControl : MonoBehaviour
{
    private InputsControl inputsControl;
    private Rigidbody2D rb;
    private Animator animator;

    private StatusControl statusControl;


    public AnimationsControl(InputsControl inputsControl, Rigidbody2D rb, Animator animator, StatusControl statusControl)
    {
        this.inputsControl = inputsControl;
        this.rb = rb;
        this.animator = animator;
        this.statusControl = statusControl;
    }

    public void FlipLogic()
    {

    }

    public void AnimationsLogic()
    {
        animator.SetFloat("Horizontal", rb.linearVelocity.x);
        animator.SetFloat("Vertical", inputsControl.DirectionInput.y);
        animator.SetBool("In_Dash", statusControl.In_Dash);
        animator.SetBool("In_Low", statusControl.In_Low);
        animator.SetBool("In_Medium", statusControl.In_Medium);
        animator.SetBool("In_Heavy", statusControl.In_Heavy);
    }
}
