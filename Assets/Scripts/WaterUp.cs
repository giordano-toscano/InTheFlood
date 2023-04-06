using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterUp : MonoBehaviour
{
    Rigidbody rig;
    public float speed;
    public float alt;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            Vector3 Pos = new Vector3(0, alt, 0);
            rig.velocity = Pos * speed;
            this.gameObject.GetComponent<AudioSource>().Play(0);
        }

        if(this.gameObject.GetComponent<Transform>().position.y >= -6)
        {
            rig.position = new Vector3(0, -6, 0);
        }

    }
}
