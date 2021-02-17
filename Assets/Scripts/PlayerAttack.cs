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
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwAttack <= 0)
        {
            if (Input.GetKeyDown(KeyCode.RightControl) || Input.GetKeyDown(KeyCode.LeftControl))
            {
                anim.SetTrigger("attack1");
                //anim.SetTrigger("attack1");
                //camAnim.SetTrigger("Shake");
                timeBtwAttack += 1;

                //Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                /*
                for (int i = 0; i < enemiesToDamage; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().health -= damage;      
                */

            }

        }
        else
        {
            if (Input.GetKeyDown(KeyCode.RightControl) || Input.GetKeyDown(KeyCode.LeftControl))
            {
                anim.SetTrigger("attack2");
                //anim.SetTrigger("attack1");
                //camAnim.SetTrigger("Shake");
                Debug.Log("second");
                //Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                /*
                for (int i = 0; i < enemiesToDamage; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().health -= damage;      
                */
            }

        }

        //timeBtwAttack -= Time.deltaTime;
        Debug.Log(timeBtwAttack);

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
