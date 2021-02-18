using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputBufferTest : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public int atkType = 0;
    public float timerPeriod = .25f;

    bool timerOn;
    bool isAttacking = false;
    float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //check for previous x amount of seconds and see if there was any button triggers in that time period
        if (Input.GetKeyDown(KeyCode.RightControl) || Input.GetKeyDown(KeyCode.LeftControl))
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
                //anim.SetTrigger("attack1");
                spriteRenderer.color = Color.red;
                break;
            case 2:
                //anim.SetTrigger("attack1");
                //anim.SetTrigger("attack2");
                spriteRenderer.color = Color.green;
                break;
            case 3:
                //anim.SetTrigger("attack1");
                //anim.SetTrigger("attack2");
                //anim.SetTrigger("attack3");
                spriteRenderer.color = Color.blue;
                break;
            default:
                spriteRenderer.color = Color.white;
                break;

        }
        if (timer >= timerPeriod)
        {
            isAttacking = false;
            timerOn = false;
        }

        if (timerOn) timer += Time.deltaTime;

        if (atkType > 3 || timer > timerPeriod)
        {
            atkType = 0;
        }


    }

}
