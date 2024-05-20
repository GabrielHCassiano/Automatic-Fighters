using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static PlayerCombat;
using static UnityEngine.Rendering.DebugUI;

public class EnemyCombat : MonoBehaviour
{
    private EnemyStatus enemyStatus;
    private Rigidbody2D rb;
    private GameObject player;

    [SerializeField] private bool directionRight;

    private bool canAttack = true;
    private bool inAttack = false;

    private bool inStun = false;

    private bool enterBlock = false;
    private bool inBlock = false;

    private int advantageHit;
    private int advantageBlock;

    [SerializeField] private BoxCollider2D hurtBox;
    [SerializeField] private BoxCollider2D hitBox;
    [SerializeField] private BoxCollider2D hitBoxBlock;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        enemyStatus = GetComponent<EnemyStatus>();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        HitBox();
        Combat();
        MoveAnimation();
    }

    private void FixedUpdate()
    {
        EnemyMove();
    }

    public bool EnterBlock
    {
        get { return enterBlock; }
        set { enterBlock = value; }
    }

    public bool InBlock
    { 
        get { return inBlock; } 
        set { inBlock = value; }
    }

    public bool DirectionRight
    {
        get { return directionRight; }
        set { directionRight = value; }
    }
    public int AdvantageHit
    {
        get { return advantageHit; }
        set { advantageHit = value; }
    }

    public int AdvantageBlock
    {
        get { return advantageBlock; }
        set { advantageBlock = value; }
    }

    public void HitBox()
    {
        hitBoxBlock.gameObject.SetActive(hitBox.gameObject.activeSelf);
        hitBoxBlock.offset = hitBox.offset;
        hitBoxBlock.size = hitBox.size;
    }

    public void HitMove(bool directionRight)
    {
        if (inBlock)
        {
            if (directionRight == true)
                rb.velocity = new Vector2(1f, rb.velocity.y);
            else
                rb.velocity = new Vector2(-1f, rb.velocity.y);
        }
        else
        {
            if (directionRight == true)
                rb.velocity = new Vector2(10f, rb.velocity.y);
            else
                rb.velocity = new Vector2(-10f, rb.velocity.y);
        }
    }

    public void EnemyMove()
    {
        if (!inAttack && !inStun)
        {
            if (directionRight)
                rb.velocity = new Vector2(1.2f, rb.velocity.y);
            else
                rb.velocity = new Vector2(-1.2f, rb.velocity.y);
        }
    }
    public void MoveAnimation()
    {
            animator.SetFloat("Horizontal", rb.velocity.x);
    }

    public void Combat()
    {
        float distacia = (player.transform.position.x - transform.position.x) * transform.localScale.x;

        //print(distacia);

        Flip(distacia);

        if (distacia <= 1.5f && canAttack)
        {
            Random.InitState((int)System.DateTime.Now.Ticks);

            int randomAttack = Random.Range(0, 3);

            if (randomAttack == 0 || randomAttack == 1)
            {
                canAttack = false;
                inAttack = true;
                rb.velocity = Vector2.zero;
                animator.SetBool("LightAttack", true);
            }
            else
            {
                canAttack = false;
                inAttack = true;
                rb.velocity = Vector2.zero;
                animator.SetBool("HeavyAttack", true);
            }
        }
        else
        {
            animator.SetBool("LightAttack", false);
            animator.SetBool("HeavyAttack", false);
        }

    }


    public void Flip(float direcion)
    {
        if (direcion < 0)
        {
            directionRight = !directionRight;
            transform.localScale = new Vector3(transform.localScale.x * -1, 1, 1);
        }
    }

    public void ResetAttack()
    {
        StartCoroutine(AttackCooldown());
    }

    public IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(0.8f);
        inAttack = false;
        canAttack = true;
    }

    public int AdvantageChar(PlayerCombat playerCombat)
    {
        if (inBlock)
        {
            return playerCombat.AdvantageBlock;
        }
        else
        {
            return playerCombat.AdvantageHit;
        }
    }

    public IEnumerator Stun(int frames)
    {
        inStun = true;
        animator.SetBool("Damage", true);
        yield return WaitFor.Frames(frames);
        animator.SetBool("Damage", false);
        ResetAttack();
        inStun = false;

    }

    public void GravityMove(bool directionRight)
    {
        if (inBlock)
        {
            if (directionRight == true)
                rb.velocity = new Vector2(-8f, rb.velocity.y);
            else
                rb.velocity = new Vector2(8f, rb.velocity.y);
        }
        else
        {
            if (directionRight == true)
                rb.velocity = new Vector2(-25f, rb.velocity.y);
            else
                rb.velocity = new Vector2(25f, rb.velocity.y);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Gravity"))
        {
            var clip = collision.GetComponentInParent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip;
            var state = collision.GetComponentInParent<Animator>().GetCurrentAnimatorStateInfo(0);
            int frame = (int)(state.normalizedTime * (clip.length * clip.frameRate)) + 1;
            int advantage = AdvantageChar(collision.GetComponentInParent<PlayerCombat>());
            StopAllCoroutines();
            print("Gravity");
            GravityMove(collision.GetComponentInParent<PlayerMove>().DirectionRight);
            enemyStatus.Damage(collision.GetComponentInParent<PlayerStatus>());
            StartCoroutine(Stun(((int)(clip.length * clip.frameRate) - frame + advantage)));
        }
        else
            transform.parent = null;

        if (collision.gameObject.layer == LayerMask.NameToLayer("Hitbox") && collision.GetComponentInParent<Rigidbody2D>().CompareTag("Player"))
        {
            var clip = collision.GetComponentInParent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip;
            var state = collision.GetComponentInParent<Animator>().GetCurrentAnimatorStateInfo(0);
            int frame = (int)(state.normalizedTime * (clip.length * clip.frameRate)) + 1;
            int advantage = AdvantageChar(collision.GetComponentInParent<PlayerCombat>());
            StopAllCoroutines();
            print("Player-Collider");
            HitMove(collision.GetComponentInParent<PlayerMove>().DirectionRight);
            enemyStatus.Damage(collision.GetComponentInParent<PlayerStatus>());
            StartCoroutine(Stun(((int)(clip.length * clip.frameRate) - frame + advantage)));
        }
    }
}
