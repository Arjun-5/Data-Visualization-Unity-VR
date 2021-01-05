using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UmbrellaOpen : OVRGrabbable
{
    private bool enableAnimation = false;
    private Collider grabbedCollider;
    
    public override void GrabBegin(OVRGrabber hand, Collider grabPoint)
    {
        base.GrabBegin(hand, grabPoint);
        
        //Copy the collider details in grabPoint to grabbedCollider - Not really Required need to remove it and test the next line with just grabpoint
        grabbedCollider = grabPoint;
        
        //When the Umbrella Gameobject is grabbed by the Hand set the enableAnimation variable to True
        if(grabbedCollider.gameObject.name == "Umbrella_Anim")
        {
            enableAnimation = true;
        }
    }

    private void Update()
    {
        /*When the enableAnimation Variable is True and the X button from the OVR controller is pressed play the 
         Umbrella Opening Animation and the audio source*/
        if(enableAnimation == true && OVRInput.GetDown(OVRInput.Button.Three))
        {
            GetComponent<Animator>().enabled = true;
            GetComponent<AudioSource>().Play();
        }
    }
}
