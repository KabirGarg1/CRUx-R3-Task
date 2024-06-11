using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    public float speed = 8f;
    private Vector3 direction;

    public float lifetime = 3f;

    // Start is called before the first frame update
    void Start()
    {
        direction = (PlayerHealthController.instance.transform.position - transform.position).normalized;

        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * (Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerHealthController.instance.DamagePlayer();

            Destroy(gameObject);
        }
    }
}
