using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform player;
    public GameObject floor;
    public Vector3 dir;
    public float move = 0.11f;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(floor.GetComponent<Floor>().gazedAtFloor == true)
        {
            dir = player.TransformVector(new Vector3(0, 0, move).normalized);
        }
    }

    private void FixedUpdate()
    {
        if (floor.GetComponent<Floor>().gazedAtFloor == true)
        {
            rb.MovePosition(rb.position + dir * 2 * Time.fixedDeltaTime);
        }
    }
}
