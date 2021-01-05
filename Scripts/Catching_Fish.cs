using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Catching_Fish : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject fishGameObject;
    private GameObject LineObject;
    public bool hit;
    public bool fishCaught;
    public bool task_Complete;

    public Slider HitSlider;

    public GameObject timerCount;
    public GameObject hitCount;
    private BoxCollider triggerManipulation;
    void Start()
    {
        LineObject = GameObject.Find("LineRenderer");
        triggerManipulation = GetComponent<BoxCollider>();
        hit = false;
        task_Complete = false;
        fishCaught = false;
    }
    // Update is called once per frame
    void Update()
    {
        if(hit == true)
        {
           if(task_Complete == false)
                changeAttachLine();
            else
            {
                taskComplete();
                changeAttachLine();
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //Perform the following only when the Gameobject that enters the Trigger is tagged with name 'Fish'
        if (other.tag == "Fish")
        {
            hit = true;
            HitSlider.GetComponent<FillHit>().enabled = true;
            fishCaught = true;
            fishGameObject = other.gameObject;
            triggerManipulation.isTrigger = false;
        }
    }
    void changeAttachLine()
    {
        //gameObject.transform.SetParent(fishGameObject.transform);
        fishGameObject.GetComponent<Moving_Fish>().is_Moving = false;
        fishGameObject.GetComponent<Moving_Fish>().caughtFishName = fishGameObject;
        fishGameObject.GetComponent<Moving_Fish>().speed = 4;

        //Change the LineRenderer Destination Once a fish is Caught
        LineObject.GetComponent<DrawFishingLine>().destination = fishGameObject.transform.Find("Point_To_Attach").transform;

        //Call the Initialize method in the Draw Fishing Line script
        LineObject.GetComponent<DrawFishingLine>().initialize();
        LineObject.GetComponent<DrawFishingLine>().fishCaught = true;
       // hitCount.GetComponent<FillHit>().enabled = true;
        //timerCount.GetComponent<SliderGame>().enabled = true;
        hit = false;
    }
    void taskComplete()
    {
        fishGameObject.GetComponent<Moving_Fish>().fishCaught = true;
    }
}