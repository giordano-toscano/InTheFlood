using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementWASDImproved : MonoBehaviour
{

    public Rigidbody RB3D;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetKey("w"))
        {
            RB3D.AddForce(0, 0, 50);
        }

        if (Input.GetKey("a"))
        {
            RB3D.AddForce(-50, 0, 0);
        }

        if (Input.GetKey("d"))
        {
            RB3D.AddForce(50, 0, 0);
        }

        if (Input.GetKey("s"))
        {
            RB3D.AddForce(0, 0, -50);
        }
    }
}