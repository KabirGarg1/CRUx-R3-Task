using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healthToAdd;

    public GameObject pickupEffect;

    public bool giveFullHealth;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (PlayerHealthController.instance.currentHealth != PlayerHealthController.instance.maxHealth)
            {
                if (giveFullHealth == true)
                {
                    PlayerHealthController.instance.AddHealth(PlayerHealthController.instance.maxHealth);
                }
                else
                {

                    PlayerHealthController.instance.AddHealth(healthToAdd);
                }


                Destroy(gameObject);
                Instantiate(pickupEffect, transform.position, transform.rotation);

                AudioManager.instance.PlaySFX(10);
            }
        }
    }
}
