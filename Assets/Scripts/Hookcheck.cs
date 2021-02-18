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
            player.GetComponent<Grapple>().hooked = true;
            player.GetComponent<Grapple>().hookedObj = other.gameObject;
        }
    }
}
