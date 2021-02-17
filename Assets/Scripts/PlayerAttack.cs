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

    int atkType = 0;
    bool timerOn;
    bool isAttacking = false;
    float timer = 0f;
    float timerPeriod = 1f;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.RightControl) || Input.GetKeyDown(KeyCode.LeftControl))
        {
            timerOn = true;
            isAttacking = true;
            timer = 0;
            atkType++;
            switch (atkType)
            {
                case 0:
                    anim.SetTrigger("attack1");
                    break;
                case 1:
                    anim.SetTrigger("attack2");
                    break;
                case 2:
                    Debug.Log("attack3");
                    break;
                default:

                    break;

            }

            //anim.SetTrigger("attack1");
            //camAnim.SetTrigger("Shake");


            //Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
            /*
            for (int i = 0; i < enemiesToDamage; i++)
            {
                enemiesToDamage[i].GetComponent<Enemy>().health -= damage;      
            */

        }

        if(Input.GetKeyUp(KeyCode.RightControl) || Input.GetKeyUp(KeyCode.LeftControl))
        {
            isAttacking = false;
        }

        if (timer > timerPeriod)
        {
            isAttacking = false;
            timerOn = false;
        }

        if (timerOn) timer += Time.deltaTime;

        if (atkType > 3 || timer > timerPeriod)
        {
            atkType = 0;
        }

        //timeBtwAttack -= Time.deltaTime;
        Debug.Log(timeBtwAttack);
        anim.SetBool("isAttacking", isAttacking);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(attackPos.position, attackRange);
    } 
}
