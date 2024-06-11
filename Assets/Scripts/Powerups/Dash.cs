using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public float countdown;
    private float timer;
    private float time;


    private PlayerController playerMovement;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerMovement = collision.gameObject.GetComponent<PlayerController>();
            time = 1f;
            playerMovement.moveSpeed *= 2;
            playerMovement.anim.speed *= 2;

        }
    }
    private void Update()
    {
        if (time == 1f) timer += Time.deltaTime;
        if (timer >= countdown)
        {
            Time.timeScale = 1f;
            playerMovement.moveSpeed /= 2;
            playerMovement.anim.speed /= 2;
            timer = 0f;
            time = 0f;
            Destroy(this.gameObject);
        }
    }
}