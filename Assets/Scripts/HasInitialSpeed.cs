using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasInitialSpeed : MonoBehaviour
{
    Rigidbody selfRigidBody;
    
    public Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        selfRigidBody = GetComponent<Rigidbody>();
        selfRigidBody.velocity = velocity;
    }
}
