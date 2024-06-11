using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform thePlatform;

    public Transform[] movePoints;
    private int currentPoint;

    public float moveSpeed;
    void Update()
    {
        thePlatform.position = Vector3.MoveTowards(
            thePlatform.position,
            movePoints[currentPoint].position,
            moveSpeed * Time.deltaTime);

        if(thePlatform.position == movePoints[currentPoint].position)
        {
            currentPoint++;

            if(currentPoint >= movePoints.Length)
            {
                currentPoint = 0;
            }
        }
    }
}
