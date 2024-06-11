using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] patrolPoints;
    private int currentPoint;

    public float moveSpeed;

    public float timeAtPoints;
    private float waitCounter;

    public Animator anim;

    public EnemyController theEC;

    public bool shouldChasePlayer;
    private bool isChasing;
    public float distanceToChasePlayer;
    private PlayerController thePlayer;

    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform t in patrolPoints)
        {
            t.SetParent(null);
        }

        waitCounter = timeAtPoints;

        if (anim == null)
        {
            anim = GetComponent<Animator>();
        }

        anim.SetBool("isMoving", true);

        if(shouldChasePlayer == true)
        {
            thePlayer = FindFirstObjectByType<PlayerController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (theEC.isDefeated == false)
        {
            if(shouldChasePlayer == true)
            {
                if(isChasing == false)
                {
                    if(Vector3.Distance(transform.position, thePlayer.transform.position) < distanceToChasePlayer)
                    {
                        isChasing = true;
                    }
                } else
                {
                    if (Vector3.Distance(transform.position, thePlayer.transform.position) > distanceToChasePlayer)
                    {
                        isChasing = false;
                    }
                }
            }

            if (shouldChasePlayer == false || (shouldChasePlayer == true && isChasing == false) )
            {

                transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currentPoint].position, moveSpeed * Time.deltaTime);

                if (Vector3.Distance(transform.position, patrolPoints[currentPoint].position) < .001f)
                {
                    waitCounter -= Time.deltaTime;

                    anim.SetBool("isMoving", false);

                    if (waitCounter <= 0)
                    {
                        currentPoint++;
                        if (currentPoint >= patrolPoints.Length)
                        {
                            currentPoint = 0;
                        }

                        waitCounter = timeAtPoints;

                        anim.SetBool("isMoving", true);

                        if (transform.position.x < patrolPoints[currentPoint].position.x)
                        {
                            transform.localScale = new Vector3(-1f, 1f, 1f);
                        }
                        else
                        {
                            transform.localScale = Vector3.one;
                        }
                    }
                }
            } else if(isChasing == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, thePlayer.transform.position, moveSpeed * Time.deltaTime);

                if(transform.position.x > thePlayer.transform.position.x)
                {
                    transform.localScale = Vector3.one;
                } else
                {
                    transform.localScale = new Vector3(-1f, 1f, 1f);
                }
            }
        }
    }
}
