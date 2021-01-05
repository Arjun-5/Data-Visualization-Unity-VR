using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishing_Line_Animation : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animationSource;
    public bool animationPlayed;
    public GameObject lineRender;
    public Transform lrSource;
    public Transform lrDestination;
    public GameObject fishingReelAudio;

    AudioSource throwingRod;
    AudioSource fishingReel;
    
    private AnimatorClipInfo[] clipInfo;
    float clipLength;
    float count;

    public GameObject enableTrigger;
    private BoxCollider colliderTriger;
    public bool RodGrabbed;

    void Start()
    {
        //Assign the Audio Source
        throwingRod = GetComponent<AudioSource>();
        fishingReel = fishingReelAudio.GetComponent<AudioSource>();
        count = 0;
        animationPlayed = false;

        //Get the Animation Component
        animationSource = GetComponent<Animator>();
        clipInfo = animationSource.GetCurrentAnimatorClipInfo(0);
        clipLength = clipInfo[0].clip.length;
        colliderTriger = enableTrigger.GetComponent<BoxCollider>();
        RodGrabbed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey(KeyCode.E) && animationPlayed == false) || (OVRInput.GetDown(OVRInput.Button.One) && animationPlayed == false ))//&& RodGrabbed == true))
        {
            //Play the Animation
            animationSource.enabled = true;
            
            /* Set the animation timer back to 0 so that it can be looped back again 
            to play from the First when the concerned buttons are pressed */
            animationSource.Play("Throw_Fish_Line", -1, 0);

            //Plays the audio for Tthrowing Rod and Fishing Reel
            throwingRod.Play();
            fishingReel.Play();
            animationPlayed = true;
        }
        if(animationPlayed == true)
        {
            if (count > clipLength)
                checkAnimationStatus();
            else
                count++;
        }
    }
    void checkAnimationStatus()
    {
        //Enable the Draw Fishing Line script once the animation has been played
        lineRender.GetComponent<DrawFishingLine>().enabled = true;
        colliderTriger.isTrigger = true;
        animationPlayed = false;
    }
}
