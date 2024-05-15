using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private InputControl inputControl;
    private Rigidbody2D rb;

    private bool canMove = true;
    private bool canRun = false;

    [SerializeField] private Transform checkGround;

    // Start is called before the first frame update
    void Start()
    {
        inputControl = GetComponentInChildren<InputControl>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        canMove = OnGround();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public bool OnGround()
    {
        return Physics2D.BoxCast(checkGround.position, new Vector2(0.1f, 0.1f), 0, Vector2.down, LayerMask.GetMask("Ground"));
    }

    public void Move()
    {
        if (canMove)
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
}
