using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_Physics : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    Rigidbody RBody;
    void Start()
    {
        RBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        RBody.MovePosition(target.transform.position);
    }
}
