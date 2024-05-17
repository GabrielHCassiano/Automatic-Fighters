using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerCombat;

public class Enemy : MonoBehaviour
{

    private int advantageHit;
    private int advantageBlock;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public int AdvantageChar(PlayerCombat playerCombat)
    {
        return playerCombat.AdvantageHit;
    }

    public IEnumerator Stun(int frames)
    {
        animator.SetBool("Damage", true);
        yield return WaitFor.Frames(frames);
        print("Stun");
        animator.SetBool("Damage", false);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Hitbox"))
        {
            var clip = collision.GetComponentInParent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip;
            var state = collision.GetComponentInParent<Animator>().GetCurrentAnimatorStateInfo(0);
            int frame = (int)(state.normalizedTime * (clip.length * clip.frameRate)) + 1;
            int advantage = AdvantageChar(collision.GetComponentInParent<PlayerCombat>());
            StopAllCoroutines();
            print("Player-Collider");
            StartCoroutine(WaitFor.Frames((int)(clip.length * clip.frameRate) - frame + advantage));
        }
    }
}
