using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack = 0;
    public float startTimeBtwAttack;
    //public Animator camAnim;
    //public Transform attackPos;
    public float attackRange;
    public LayerMask whatIsEnemies;
    public int damage;
    public Animator anim;
    public int atkType = 0;
    public float timerPeriod = .25f;
    public float atkCdTimerPeriod = .25f;

    bool timerOn;
    bool isAttacking = false;
    bool attack1Active = false;
    bool attack2Active = false;
    bool attack3Active = false;
    float timer = 0f;
    float atkCdTimer;
    // Start is called before the first frame update
    void Start()
    {
        atkCdTimer = atkCdTimerPeriod;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.RightControl) || Input.GetKeyDown(KeyCode.LeftControl) && atkCdTimer >= atkCdTimerPeriod)
        {
            timerOn = true;
            isAttacking = true;
            timer = 0;
            atkType++;
            Debug.Log(atkType);
        }


        switch (atkType)
        {
            case 1:
                attack1Active = true;
                break;
            case 2:
                attack2Active = true;
                break;
            case 3:
                attack3Active = true;
                Debug.Log("attack3");
                break;
            default:

                break;

        }

        if (timer >= anim.GetCurrentAnimatorStateInfo(0).length && isAttacking)
        {
            atkCdTimer = 0;
            isAttacking = false;
            timerOn = false;

        }

        if (timerOn) timer += Time.deltaTime;

        if (atkCdTimer < atkCdTimerPeriod)
        {
            atkCdTimer += Time.deltaTime;
        }

        if (atkType > 3 || timer >= anim.GetCurrentAnimatorStateInfo(0).length)
        {
            if (isAttacking)
            {
                atkType = 0;
                atkCdTimer = 0;
                attack1Active = false;
                attack2Active = false;
                attack3Active = false;
            }
        }

        anim.SetBool("isAttacking", isAttacking);
        anim.SetBool("attack1Active", attack1Active);
        anim.SetBool("attack2Active", attack2Active);
        anim.SetBool("attack3Active", attack3Active);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
