using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float countdown;
    private float timer;
    public float timeSlow;
    private float time;
    

    private PlayerController playerMovement;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerMovement = collision.gameObject.GetComponent<PlayerController>();
            Time.timeScale = 1/timeSlow;
            time = 1f;
            playerMovement.moveSpeed *= timeSlow;
            playerMovement.anim.speed *= timeSlow;
            playerMovement.knockbackLength *= timeSlow;
            playerMovement.theRB.gravityScale *= timeSlow;
            
        }
    }
    private void Update()
    {
        if (time == 1f) timer += Time.deltaTime;
        if (timer >= (countdown/timeSlow))
        {
            Time.timeScale = 1f;
            playerMovement.moveSpeed /= timeSlow;
            playerMovement.anim.speed /= timeSlow;
            playerMovement.knockbackLength /= timeSlow;
            playerMovement.theRB.gravityScale /= timeSlow;
            timer = 0f;
            time = 0f;
            Destroy(this.gameObject);
        }
    }
}
