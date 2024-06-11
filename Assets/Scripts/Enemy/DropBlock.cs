using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBlock : MonoBehaviour
{
    private Transform player;

    public float activationRange = .5f;

    public float fallSpeed, raiseSpeed;

    public Transform dropPoint;

    private bool activated;

    private Vector3 startPoint;

    public float waitToFall, waitToRaise;
    private float fallCounter, raiseCounter;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        player = PlayerHealthController.instance.transform;

        dropPoint.SetParent(null);

        startPoint = transform.position;

        fallCounter = waitToFall;
        raiseCounter = waitToRaise;
    }

    // Update is called once per frame
    void Update()
    {
        if(activated == false && transform.position == startPoint)
        {
            if(Mathf.Abs(transform.position.x - player.position.x) <= activationRange)
            {
                activated = true;

                anim.SetTrigger("blink");
            }
        }

        if(activated == true)
        {
            if (fallCounter > 0)
            {
                fallCounter -= Time.deltaTime;
            }
            else
            {

                transform.position = Vector3.MoveTowards(transform.position, dropPoint.position, fallSpeed * Time.deltaTime);

                if (transform.position == dropPoint.position)
                {
                    ActivateHit();
                }
            }
        } else
        {
            if (raiseCounter > 0)
            {
                raiseCounter -= Time.deltaTime;
            }
            else
            {

                if (transform.position != startPoint)
                {
                    transform.position = Vector3.MoveTowards(transform.position, startPoint, raiseSpeed * Time.deltaTime);
                }
            }
        }
    }

    void ActivateHit()
    {
        activated = false;

        fallCounter = waitToFall;
        raiseCounter = waitToRaise;

        anim.SetTrigger("hit");
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            ActivateHit();

            PlayerHealthController.instance.DamagePlayer();
        }
    }
}
