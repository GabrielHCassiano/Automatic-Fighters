using System.Collections;
using UnityEngine;


public class PlayerCombat : MonoBehaviour
{
    private InputControl inputControl;
    private PlayerMove playerMove;
    private PlayerStatus playerStatus;

    private bool canAttack = true;
    private bool inAttack = false;
    private bool inStun = false;
    private bool attack;

    private bool enterBlock = false;
    private bool inBlock = false;
    private bool hitBlock = false;

    private bool inParry;

    private int advantageHit;
    private int advantageBlock;

    [SerializeField] private BoxCollider2D hurtBox;
    [SerializeField] private BoxCollider2D hitBox;
    [SerializeField] private BoxCollider2D hitBoxBlock;
    [SerializeField] private BoxCollider2D blockCollider;
    [SerializeField] private GameObject effectBlock;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        inputControl = GetComponentInChildren<InputControl>();
        playerMove = GetComponent<PlayerMove>();
        playerStatus = GetComponent<PlayerStatus>();
        animator = GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        UserItem();
        SpecialAttack();
        Attack();
    }

    public bool InAttack
    { 
        get { return inAttack; } 
        set {  inAttack = value; } 
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

    public bool HitBlock
    {
        get { return hitBlock; }
        set { hitBlock = value; }
    }


    public bool InStun
    {
        get { return inStun; }
        set { inStun = value; }
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

    public BoxCollider2D BlockCollider
    {
        get { return blockCollider; }
        set { blockCollider = value; }
    }

    public BoxCollider2D HurtBox
    {
        get { return hurtBox; }
        set { hurtBox = value; }
    }

    public void UserItem()
    {
        if (inputControl.Button1 && playerStatus.ItemQ > 0 && canAttack)
        {
            canAttack = false;
            animator.SetBool("User", true);
        }
        else
            animator.SetBool("User", false);
    }

    public void UserCoca()
    {
        playerStatus.ItemQ -= 1;
    }

    public void UpLife()
    {
        playerStatus.Life += 5;
    }

    public void Attack()
    {
        //blockCollider.gameObject.SetActive(inBlock);

        if (inputControl.Rt && canAttack)
        {
            canAttack = false;
            enterBlock = true;
            playerMove.Velocity = new Vector2(0, playerMove.Velocity.y);
            animator.SetBool("Block", true);
            print("Block");
        }

        if (!inputControl.Rt && inBlock)
        {
            inBlock = false;
            enterBlock = false;
            animator.SetBool("Block", false);
            print("ofBlock");
            ResetAttack();
        }


        if (inputControl.LightAttack && canAttack)
        {
            canAttack = false;
            inAttack = true;
            inputControl.LightAttack = false;
            playerMove.Velocity = new Vector2(0, playerMove.Velocity.y);
            animator.SetBool("LightAttack", true);
            print("Light Attack");
        }
        else
            animator.SetBool("LightAttack", false);

        if (inputControl.HeavyAttack && canAttack)
        {
            canAttack = false;
            inAttack = true;
            inputControl.HeavyAttack = false;
            playerMove.Velocity = new Vector2(0, playerMove.Velocity.y);
            animator.SetBool("HeavyAttack", true);
            print("Heavy Attack");
        }
        else
            animator.SetBool("HeavyAttack", false);

    }

    public void SpecialAttack()
    {
        if (inputControl.CodeButton == "V \\V > X " && canAttack && playerMove.DirectionRight)
        {
            canAttack = false;
            inAttack = true;
            inputControl.CodeButton = "";
            playerMove.Velocity = new Vector2(0, playerMove.Velocity.y);
            animator.SetBool("Special", true);
            print("Special Attack");
        }
        else if (inputControl.CodeButton == "V /V < X " && canAttack && !playerMove.DirectionRight)
        {
            canAttack = false;
            inAttack = true;
            inputControl.CodeButton = "";
            playerMove.Velocity = new Vector2(0, playerMove.Velocity.y);
            animator.SetBool("Special", true);
            print("Special Attack");
        }
        else
            animator.SetBool("Special", false);
    }

    public void SetBlock()
    {
        inBlock = true;
    }

    public void ResetAttack()
    {
        StartCoroutine(AttackCooldown());
    }

    public IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(0.1f);
        inAttack = false;
        canAttack = true;
    }

    public int AdvantageChar(EnemyCombat enemy, Collider2D collider)
    {
        if (inBlock)
        {
            effectBlock.SetActive(true);
            return enemy.AdvantageBlock;
        }
        else
        {
            return enemy.AdvantageHit;
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
        effectBlock.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            playerStatus.Coins += 1;
            Destroy(collision.gameObject);
            //collision.gameObject.SetActive(false);
        }

        if (collision.CompareTag("Coca"))
        {
            playerStatus.ItemQ += 1;
            Destroy(collision.gameObject);
            //collision.gameObject.SetActive(false);
        }

        if (collision.CompareTag("Bonus1"))
        {
            playerStatus.Bonus1 += 1;
            Destroy(collision.gameObject);
            //collision.gameObject.SetActive(false);
        }

        if (collision.CompareTag("Bonus2"))
        {
            playerStatus.Bonus2 += 1;
            Destroy(collision.gameObject);
            //collision.gameObject.SetActive(false);
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Hitbox") && collision.GetComponentInParent<Rigidbody2D>().CompareTag("Enemy"))
        {
            var clip = collision.GetComponentInParent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip;
            var state = collision.GetComponentInParent<Animator>().GetCurrentAnimatorStateInfo(0);
            int frame  = (int)(state.normalizedTime * (clip.length * clip.frameRate)) + 1;
            int advantage = AdvantageChar(collision.GetComponentInParent<EnemyCombat>(), collision);
            StopAllCoroutines();
            print("Enemy-Collider");
            playerMove.HitMove(collision.GetComponentInParent<EnemyCombat>().DirectionRight, collision);
            playerStatus.Damage(collision.GetComponentInParent<EnemyStatus>(), collision);
            StartCoroutine(Stun(((int)(clip.length * clip.frameRate) - frame + advantage)));
        }
    }

    public static class WaitFor
    {
        public static IEnumerator Frames(int frameCount)
        {
            print(frameCount);
            while (frameCount > 0)
            {
                frameCount--;
                yield return null;
            }
        }
    }

}
