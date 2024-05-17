using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

public class PlayerMove : MonoBehaviour
{
    private InputControl inputControl;
    private Rigidbody2D rb;
    private PlayerCombat playerCombat;

    private bool canMove = true;
    private bool canRun = false;

    [SerializeField] private Transform checkGround;

    private bool directionRight = true;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        inputControl = GetComponentInChildren<InputControl>();
        rb = GetComponent<Rigidbody2D>();
        playerCombat = GetComponent<PlayerCombat>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        canMove = OnGround();
        FlipDirection();
        MoveAnimation();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public Vector2 Velocity
    {
        get { return rb.velocity; }
        set { rb.velocity = value; }
    }

    public bool DirectionRight
    { 
        get { return directionRight; } 
        set { directionRight = value; }
    }

    public bool CanMove
    {
        get { return canMove; }
        set { canMove = value; }
    }

    public bool OnGround()
    {
        return Physics2D.BoxCast(checkGround.position, new Vector2(0.1f, 0.1f), 0, Vector2.down, LayerMask.GetMask("Ground"));
    }

    public void FlipDirection()
    {
        if (inputControl.Lt)
        {
            inputControl.Lt = false;
            directionRight = !directionRight;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }

        if (directionRight == false)
        {
            print("esquerda");
        }
        else
            print("direita");

    }

    public void Move()
    {
        if (canMove && !playerCombat.InAttack && !playerCombat.InStun)
        {
            if (inputControl.Move.x == 0)
                canRun = false;

            if (inputControl.CodeButton == "> > " || inputControl.CodeButton == "< < ")
                canRun = true;

            if (canRun == true)
                rb.velocity = new Vector2(inputControl.Move.x * 5, rb.velocity.y);
            else if (canRun == false)
                rb.velocity = new Vector2(inputControl.Move.x * 3, rb.velocity.y);
        }
    }

    public void MoveAnimation()
    {
        animator.SetFloat("Horizontal", rb.velocity.x);
    }
}
