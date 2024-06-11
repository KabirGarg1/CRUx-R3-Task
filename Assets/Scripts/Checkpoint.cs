using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private bool isActive;
    public Animator anim;

    [HideInInspector]
    public CheckpointManager cpMan;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && isActive == false)
        {
            cpMan.SetActiveCheckpoint(this);

            anim.SetBool("flagActive", true);

            isActive = true;

            AudioManager.instance.PlaySFX(3);
        }
    }

    public void DeactivateCheckpoint()
    {
        anim.SetBool("flagActive", false);
        isActive = false;
    }
}
