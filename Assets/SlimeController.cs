using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SlimeStatus
{
    Idle,
    Attack,
    Move,
};

public class SlimeController : MonoBehaviour
{
    private Animator animator;
    public Transform player;
    public SlimeStatus slimeStatus = SlimeStatus.Idle;
    //test
    public float attackDist;
    public bool isAttack = false;
    public Coroutine slimeCoroutine;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        slimeCoroutine = StartCoroutine(SlimeAction());
    }

    IEnumerator SlimeAction()
    {
        while(true)
        {
            switch(slimeStatus)
            {
                case SlimeStatus.Idle:
                    break;

                case SlimeStatus.Move:
                    float dist = Vector3.Distance(player.position, transform.position);
                    animator.SetBool("aa", true);
                    if (dist <= attackDist)
                    {
                        slimeStatus = SlimeStatus.Attack;
                    }
                    break;
                case SlimeStatus.Attack:
                    if (isAttack)
                    {
                        animator.SetTrigger("Attack");
                        isAttack = true;
                    }
                    break;
            }
            yield return new WaitForSeconds(0.3f);
        }
    }
    public void Move()
    {
        slimeStatus = SlimeStatus.Move;
    }
}
