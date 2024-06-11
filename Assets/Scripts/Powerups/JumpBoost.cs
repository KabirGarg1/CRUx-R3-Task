using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class JumpBoost : MonoBehaviour
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
            playerMovement.jumpForce *= 1.5f;
        }
    }
    private void Update()
    {
        if (time == 1f) timer += Time.deltaTime;
        if (timer >= countdown)
        {
            Time.timeScale = 1f;
            playerMovement.jumpForce /= 1.5f;
            timer = 0f;
            time = 0f;
            Destroy(this.gameObject);
        }
    }
}