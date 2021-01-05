using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingRodGrabbed : OVRGrabbable
{
    private Collider grabbedCollider;
    private bool fishRodGrabbed = false;
    public GameObject fishingRod;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        //If true set the variable to true
        if(fishRodGrabbed == true)
        {
            fishingRod.GetComponent<Fishing_Line_Animation>().RodGrabbed = true;
        }
    }
    //Override the Grab Begin Function to find the Gameobject that is being currently grabbed 
    public override void GrabBegin(OVRGrabber hand, Collider grabPoint)
    {
        base.GrabBegin(hand, grabPoint);
        grabbedCollider = grabPoint;

        if (grabbedCollider.gameObject.name == "Fishing_Rod")
        {
            fishRodGrabbed = true;
        }
    }
    //Overriding the Grab End function to set the bool value to false once the Fishing Rod is dropped
    public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
    {
        base.GrabEnd(linearVelocity, angularVelocity);
        fishRodGrabbed = false;
    }
}