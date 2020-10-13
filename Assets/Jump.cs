using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public HingeJoint ropePrefab;
    public Transform pivot;
    Rigidbody physics;
    public float jumpForce = 5.0f;
    bool swinging = false;

    void Start()
    {
        physics = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!swinging && Input.GetMouseButtonDown(0))
        {
            StartCoroutine(JumpSwing());
        }
    }

    IEnumerator JumpSwing()
    {
        swinging = true;
        // jump
        physics.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        yield return null;
        // wait until we start to fall
        yield return new WaitUntil(() => physics.velocity.y < 0.0f);
        // create a rope
        HingeJoint rope = Instantiate(ropePrefab, transform.position + Vector3.up * 0.5f, Quaternion.identity);
        rope.axis = Vector3.forward;
        rope.anchor = rope.transform.InverseTransformPoint(pivot.position);
        HingeJoint joint = gameObject.AddComponent<HingeJoint>();
        joint = GetComponent<HingeJoint>();
        joint.connectedBody = rope.GetComponent<Rigidbody>();
        joint.axis = Vector3.forward;
        // wait until we let go of the mouse
        yield return new WaitUntil(() => !Input.GetMouseButton(0));
        Destroy(joint);
        Destroy(rope.gameObject);
        swinging = false;
    }
}
