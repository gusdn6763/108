using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum SlimeStatus
{
    Idle,
    Attack,
    Move,
};

public class SlimeController : MonoBehaviour
{
    [SerializeField] private Canvas can;
    [SerializeField] private Text text;
    private AudioSource audiod;
    private Animator animator;
    public Transform player;
    public SlimeStatus slimeStatus = SlimeStatus.Move;
    //test
    public float attackDist;
    public float speed;
    public bool isAttack = false;
    public bool check = false;

    private void Awake()
    {
        player = Player.instance.transform;
        can.renderMode = RenderMode.WorldSpace;
        can.worldCamera = Camera.main;
        animator = GetComponent<Animator>();
        audiod = GetComponent<AudioSource>();
    }

    private void Start()
    {
        StartCoroutine(SlimeAction());
        StartCoroutine(CheckState());
    }

    IEnumerator CheckState()
    {
        yield return new WaitForSeconds(0.3f);

        while (true)
        {
            float dist = Vector3.Distance(player.position, transform.position);
            if (dist <= attackDist)
            {
                slimeStatus = SlimeStatus.Attack;
            }
            else
            {
                slimeStatus = SlimeStatus.Move;
            }
            yield return (0.3f);
        }
    }

    IEnumerator SlimeAction()
    {
        while(true)
        {
            Vector3 targetPosition = new Vector3(Player.instance.transform.position.x, transform.position.y, Player.instance.transform.position.z);
            transform.LookAt(targetPosition);
            switch (slimeStatus)
            {
                case SlimeStatus.Move:
                    transform.Translate(Vector3.forward * speed * Time.deltaTime);
                    animator.SetBool("Move", true);
                    isAttack = false;
                    animator.SetBool("Attack", isAttack);
                    break;
                case SlimeStatus.Attack:
                    animator.SetBool("Move", false);
                    if (isAttack == false)
                    {
                        isAttack = true;
                        animator.SetBool("Attack", isAttack);
                    }
                    break;
            }
            yield return new WaitForSeconds(0.3f);
        }
    }
    public void AttackSound()
    {
        audiod.Play();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(check)
        {
            if(other.CompareTag("Weapon"))
            {
                print("ºÎ¼­Áü");
                text.color= new Color(255, 0, 0, 255);
                Destroy(this.gameObject, 3f);
            }
        }
    }
}
