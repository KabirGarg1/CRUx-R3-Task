using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMove : MonoBehaviour
{

    [SerializeField] private GameObject[] waypoint;
    private int currentwaypointindex=0;

    void Update()
    {
        if (Vector2.Distance(waypoint[currentwaypointindex].transform.position, transform.position) < .1)
        {
            currentwaypointindex++;
            if(currentwaypointindex >= waypoint.Length) { currentwaypointindex = 0; }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoint[currentwaypointindex].transform.position, Time.deltaTime * 2f);
    }
}
