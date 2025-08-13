using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private InputsControl inputsControl;
    private Rigidbody2D rb;
    private Animator animator;

    private StatusControl statusControl;
    private MoveControl moveControl;
    private CombatControl combatControl;
    private AnimationsControl animationsControl;

    void Start()
    {
        inputsControl = GetComponentInChildren<InputsControl>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        statusControl = GetComponent<StatusControl>();
        moveControl = new MoveControl(inputsControl, rb, statusControl);
        combatControl = new CombatControl(inputsControl, statusControl);
        animationsControl = new AnimationsControl(inputsControl, rb, animator, statusControl);
    }

    void Update()
    {
        moveControl.DashLogic();
        moveControl.JumpLogic();
        combatControl.AttackLogic();
        animationsControl.FlipLogic();
        animationsControl.AnimationsLogic();
    }

    void FixedUpdate()
    {
        moveControl.MovementeLogic();
    }
}
