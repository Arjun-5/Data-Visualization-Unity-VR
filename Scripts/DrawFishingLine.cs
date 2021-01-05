using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawFishingLine : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private float counter;
    private float dist;

    public Transform origin;
    public Transform destination;

    public float drawLineSpeed = 6f;
    public bool createLine;
    public bool fishCaught;
    private Vector3 endPositionOffset;
    // Start is called before the first frame update
    void Start()
    {
        initialize();
    }
    public void initialize()
    {
        lineRenderer = GetComponent<LineRenderer>();
        
        //Set the Line Width and Height
        lineRenderer.startWidth = .01f;
        lineRenderer.endWidth = .01f;

        //Setting the Destination and Origin for the Line Renderer
        dist = Vector3.Distance(origin.position, destination.position);
        createLine = false;
        endPositionOffset = destination.position;
        fishCaught = false;
    }
    // Update is called once per frame
    void Update()
    {
        if(fishCaught == false)
        {
            if (createLine == false)
            {
               //Line generation with Animation over time
                if (counter < dist)
                {
                    lineRenderer.SetPosition(0, origin.position);
                    counter += .1f / drawLineSpeed;
                    float x = Mathf.Lerp(0, dist, counter);

                    Vector3 pointA = origin.position;
                    Vector3 pointB = destination.position;

                    Vector3 pointAlongLine = x * Vector3.Normalize(pointB - pointA) + pointA;
                    lineRenderer.SetPosition(1, pointAlongLine);
                        
                    if (lineRenderer.GetPosition(1) == pointB)
                    {
                        createLine = true;
                    }
                }              
            }
            else
            {
                //Change and render the destination of the Line Render 
                Vector3 newEndPosition = destination.position;
                if (newEndPosition != endPositionOffset)
                {
                    lineRenderer.SetPosition(1, newEndPosition);
                }
            }
        }
        else
        {
            if(createLine == false)
            {
                lineRenderer.SetPosition(0,origin.position);
                lineRenderer.SetPosition(1, destination.position);
            }
            else
            {
                Vector3 newEndPosition = destination.position;
                if (newEndPosition != endPositionOffset)
                {
                    lineRenderer.SetPosition(1, newEndPosition);
                }
            }
        }
    }
}
