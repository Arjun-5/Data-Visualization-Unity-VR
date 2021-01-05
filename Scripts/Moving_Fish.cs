using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Fish : MonoBehaviour
{
    public Transform[] destination;
    public Transform[] finalDestination;
    public bool is_Moving = false;
    public float speed = 5.0f;

    private Transform newTarget;
    private Transform newFinalDestination;

    public bool fishCaught;
    private int count;
    private bool stopMovement;
    // public Transform Target;
    public GameObject caughtFishName;

    Vector3 direction; 
    Quaternion rotation;


    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        fishCaught = false;
        stopMovement = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(stopMovement == false)
        {
            if (is_Moving == false)
            {
                if (fishCaught == false)
                {
                    newTarget = destination[Random.Range(0, destination.Length)];
                    is_Moving = true;
                }
                else
                {
                    newFinalDestination = finalDestination[count];
                    is_Moving = true;
                    print(count);
                }
            }
            if(fishCaught == false)
            {
                direction = newTarget.position - transform.position;
                rotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Lerp(transform.localRotation, rotation, speed * Time.deltaTime);

                transform.position = Vector3.MoveTowards(transform.position, newTarget.position, speed * Time.deltaTime);
                if (transform.position == newTarget.position)
                {
                    is_Moving = false;
                }
            }
            else
            {
                direction = newFinalDestination.position - transform.position;
                rotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Lerp(transform.localRotation, rotation, speed * Time.deltaTime);

                transform.position = Vector3.MoveTowards(transform.position, newFinalDestination.position, speed * Time.deltaTime);
                if (transform.position == newFinalDestination.position)
                {
                    is_Moving = false;
                    count++;
                }
                if (count > 4)
                {
                    stopMovement = true;
                    caughtFishName.GetComponent<Animator>().enabled = false;
                }
                
            }
           
        }
    }
}
