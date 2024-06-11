using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public Checkpoint[] allCP;

    private Checkpoint activeCP;
    public Vector3 respawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        allCP = FindObjectsByType<Checkpoint>(FindObjectsSortMode.None);

        foreach (Checkpoint cp in allCP)
        {
            cp.cpMan = this;
        }

        respawnPosition = FindFirstObjectByType<PlayerController>().transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            DeactivateAllCheckpoints();
        }
    }

    public void DeactivateAllCheckpoints()
    {
        foreach(Checkpoint cp in allCP)
        {
            cp.DeactivateCheckpoint();
        }
    }

    public void SetActiveCheckpoint(Checkpoint newActiveCP)
    {
        DeactivateAllCheckpoints();

        activeCP  = newActiveCP;

        respawnPosition = newActiveCP.transform.position;
    }
}
