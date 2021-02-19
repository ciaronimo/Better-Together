using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{
    public GameObject hook;
    public GameObject hookHolder;

    public float hookTravelSpeed;
    public float playerTravelSpeed;

    public static bool fired;
    public bool hooked;
    public GameObject hookedObj;

    public float maxDistance;
    private float currentDistance;
    private bool grounded;

    private void Update()
    {
        // button to fire the grapple
        if (Input.GetMouseButtonDown(0) && fired == false) 
        {
            fired = true;
        }
        if (fired)
        {
            // rope that follows the grapple
            LineRenderer rope = hook.GetComponent<LineRenderer>();
            rope.SetVertexCount(2);
            rope.SetPosition(0, hookHolder.transform.position);
            rope.SetPosition(1, hook.transform.position);
        }
        if (fired == true && hooked == false) 
        {
            //this fires the grapple and checks the distance
            hook.transform.Translate(Vector3.right * Time.deltaTime * hookTravelSpeed );
            currentDistance = Vector3.Distance(transform.position, hook.transform.position);

            //returns hook
            if (currentDistance >= maxDistance)
            {
                ReturnHook();
            }
        }
        if (hooked == true && fired == true) 
        {
            // makes player move towards the hookable object
            hook.transform.parent = hookedObj.transform;
            transform.position = Vector3.MoveTowards(transform.position, hook.transform.position, Time.deltaTime * playerTravelSpeed);
            float distanceToHook = Vector3.Distance(transform.position, hook.transform.position);

            // this is the issue that i think isnt letting the player go towards the object as its a rigidbody and the player has a rigidbody2d
            this.GetComponent<Rigidbody>().useGravity = false;

            if (distanceToHook < 1) 
            {

                if(grounded == false) 
                {
                    // this is making the player push up and forwards onto the platform at the end of flight 

                    this.transform.Translate(Vector3.forward * Time.deltaTime * 17f);
                    this.transform.Translate(Vector3.up * Time.deltaTime * 18f);
                }
                StartCoroutine("climb");
                
            }
            else 
            {
                // checks to make sure that gravity is set when not hooked to obj and resetting hook to hookholder
                hook.transform.parent = hookHolder.transform;
                this.GetComponent<Rigidbody>().useGravity = true;
            };
        }
    }

    IEnumerator climb() 
    
    {
        // delaying the returnhook so player can get onto object
        yield return new WaitForSeconds(0.1f);
        ReturnHook();
    }
    void ReturnHook()
    {
        //returning the hook at the end of max distance and preforming checks to make sure it cant go anyfarther
        hook.transform.rotation = hookHolder.transform.rotation;
        hook.transform.position = hookHolder.transform.position;
        fired = false;
        hooked = false;

        // resets the line renderer to make sure there is no tail after it hits the object
        LineRenderer rope = hook.GetComponent<LineRenderer>();
        rope.SetVertexCount(0);

    }

    void CheckIfGrounded()
    {

        // checking to make sure that your on the ground so you cant fire while in the air more then once 
        RaycastHit hit;
        float distanance = 1f;

        Vector3 dir = new Vector3(0, -1);

        if(Physics.Raycast(transform.position , dir, out hit, distanance)) 
        {
            grounded = true;
        }
        else 
        {
            grounded = false;
        };
    }
}
