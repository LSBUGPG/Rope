using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This renders the rope from the end to the joint
public class Rope : MonoBehaviour
{
    LineRenderer rope;
    HingeJoint joint;

    void Start()
    {
        rope = GetComponent<LineRenderer>();        
        joint = GetComponent<HingeJoint>();
    }

    void Update()
    {
        rope.SetPosition(0, Vector3.zero);
        rope.SetPosition(1, joint.anchor);
    }
}
