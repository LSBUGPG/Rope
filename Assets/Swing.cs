using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour
{
    HingeJoint joint;
    public Rigidbody dog;

    void Start()
    {
//        joint = GetComponent<HingeJoint>();    
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            joint = gameObject.AddComponent<HingeJoint>();
            dog.transform.position = dog.transform.position + Vector3.up;
            joint.connectedBody = dog; 
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Destroy(joint);
            joint = null;
        }
    }
}
