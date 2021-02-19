using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hookcheck : MonoBehaviour
{
    public GameObject player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hookable") 
        {
            // setting the players componets to make sure that when it hits a hookable its setting it true and moving towards the object
            player.GetComponent<Grapple>().hooked = true;
            player.GetComponent<Grapple>().hookedObj = other.gameObject;
        }
    }
}
