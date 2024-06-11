using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePlayer : MonoBehaviour
{
    public float bounceAmount;

    public Animator anim;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            anim.SetTrigger("bounce");

            other.GetComponent<PlayerController>().BouncePlayer(bounceAmount);
        }
    }
}
