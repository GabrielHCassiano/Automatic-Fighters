using System.Collections;
using UnityEngine;

public class StatusControl : MonoBehaviour
{

    [SerializeField] private float speed_Move;
    [SerializeField] private float speed_Dash;

    [SerializeField] private bool can_Move;
    [SerializeField] private bool can_Dash;
    [SerializeField] private bool can_Jump;
    [SerializeField] private bool can_Attack;

    private bool in_Dash = false;
    private bool in_Low = false;
    private bool in_Medium = false;
    private bool in_Heavy = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed_Move = 6;
        //speed_Dash = 8;

        can_Move = true;
        can_Dash = true;
        can_Jump = true;
        can_Attack = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetBaseAttack()
    {
        in_Low = false;
        in_Medium = false;
        in_Heavy = false;
    }

    public void ResetCanAttack()
    {
        can_Attack = true;
        can_Move = true;
        can_Dash = true;
    }

    public IEnumerator CooldownDash(Rigidbody2D rb, float direction)
    {
        can_Dash = false;
        can_Move = false;
        in_Dash = true;

        if (direction > 0)
        {
            rb.linearVelocity = new Vector2(24 * direction, rb.linearVelocity.y);
            yield return new WaitForSeconds(0.24f);
        }
        else
        {
            rb.linearVelocity = new Vector2(16 * direction, rb.linearVelocity.y);
            yield return new WaitForSeconds(0.52f);
        }

        rb.linearVelocity = Vector2.zero;
        in_Dash = false;
        can_Dash = true;
        can_Move = true;
    }

    public float Speed_Move
    {
        get { return speed_Move; }
        set { speed_Move = value; }
    }

    public bool Can_Move
    { 
        get { return can_Move; } 
        set { can_Move = value; }
    }

    public bool Can_Dash
    {
        get { return can_Dash; }
        set { can_Dash = value; }
    }

    public bool Can_Jump
    {
        get { return can_Jump; }
        set { can_Jump = value; }
    }

    public bool Can_Attack
    {
        get { return can_Attack; }
        set { can_Attack = value; }
    }

    public bool In_Dash
    {
        get { return in_Dash; }
        set { in_Dash = value; }
    }
    public bool In_Low
    {
        get { return in_Low; }
        set { in_Low = value; }
    }
    public bool In_Medium
    {
        get { return in_Medium; }
        set { in_Medium = value; }
    }
    public bool In_Heavy
    {
        get { return in_Heavy; }
        set { in_Heavy = value; }
    }
}
