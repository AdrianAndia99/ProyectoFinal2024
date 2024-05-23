using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public Animator doorAnimator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            doorAnimator.SetTrigger("Open");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == ("Player"))
        {
            doorAnimator.SetTrigger("Close");
        }
    }
}