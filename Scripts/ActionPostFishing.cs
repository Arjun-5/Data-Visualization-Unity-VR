using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionPostFishing : OVRGrabbable
{
    // Start is called before the first frame update
    private GameObject LineObject;
    public GameObject FishRod;
    private Collider grabbedCollider;
    private bool reDrawLine = false;
    public Slider resetSlider; 

    private void Awake()
    {
        LineObject = GameObject.Find("LineRenderer");
    }
    public override void GrabBegin(OVRGrabber hand, Collider grabPoint)
    {
        base.GrabBegin(hand, grabPoint);
        grabbedCollider = grabPoint;

        if (grabbedCollider.gameObject.tag == "Fish")
        {
            reDrawLine = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
     if(reDrawLine == true)
        {
            LineObject.GetComponent<DrawFishingLine>().destination = FishRod.transform.Find("FinalPoint").transform;
            reDrawLine = false;
            resetSlider.GetComponent<Slider>().value = 0;
         }   
    }
}