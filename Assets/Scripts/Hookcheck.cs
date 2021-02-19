using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hookcheck : MonoBehaviour
{
    public GameObject Player;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if ( other.CompareTag("Hookable")) 
        {
            Player.GetComponent<Grapple>().hooked = true;
            Player.GetComponent<Grapple>().hookedObj = other.gameObject;
        }
    }
}
