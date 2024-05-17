using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.U2D.Aseprite;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class PlayerCombat : MonoBehaviour
{
    private InputControl inputControl;
    private PlayerMove playerMove;

    private bool canAttack = true;
    private bool inAttack = false;
    private bool inStun = false;
    private bool attack;

    private int advantageHit;
    private int advantageBlock;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        inputControl = GetComponentInChildren<InputControl>();
        playerMove = GetComponent<PlayerMove>();
        animator = GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    public bool InAttack
    { 
        get { return inAttack; } 
        set {  inAttack = value; } 
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

    public void Attack()
    {

        if(inputControl.Button3 && canAttack)
        {
            canAttack = false;
            inAttack = true;
            playerMove.Velocity = new Vector2(0, playerMove.Velocity.y);
            animator.SetBool("LightAttack", true);
            print("Light Attack");
        }
        else
            animator.SetBool("LightAttack", false);

        if (inputControl.Button2 && canAttack)
        {
            canAttack = false;
            inAttack = true;
            playerMove.Velocity = new Vector2(0, playerMove.Velocity.y);
            animator.SetBool("HeavyAttack", true);
            print("Heavy Attack");
        }
        else
            animator.SetBool("HeavyAttack", false);

    }

    public void ResetAttack()
    {
        print("a");
        StartCoroutine(AttackCooldown());
    }

    public IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(0.1f);
        inAttack = false;
        canAttack = true;
    }

    public int AdvantageChar(Enemy enemy)
    {
        return enemy.AdvantageHit;
    }

    public IEnumerator Stun(int frames)
    {
        inStun = true;
        animator.SetBool("Damage", true);
        yield return WaitFor.Frames(frames);
        print("End-Stun");
        animator.SetBool("Damage", false);
        ResetAttack();
        inStun = false;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Hitbox"))
        {
            var clip = collision.GetComponentInParent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip;
            var state = collision.GetComponentInParent<Animator>().GetCurrentAnimatorStateInfo(0);
            int frame  = (int)(state.normalizedTime * (clip.length * clip.frameRate)) + 1;
            int advantage = AdvantageChar(collision.GetComponentInParent<Enemy>());
            StopAllCoroutines();
            print("Enemy-Collider");
            StartCoroutine(WaitFor.Frames((int)(clip.length * clip.frameRate) - frame + advantage));
        }
    }

    public static class WaitFor
    {
        public static IEnumerator Frames(int frameCount)
        {
            print(frameCount);
            while (frameCount > 0)
            {
                print("s");
                frameCount--;
                yield return null;
            }
        }
    }

}
