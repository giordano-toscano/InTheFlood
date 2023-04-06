using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_Canos_CanoController : MonoBehaviour
{
    public string[] states = { "left", "up", "right", "down" };
    public int stateIndex = 0;
    public int handlePosition = 0;
    public string currentPosition = "left";
    public GameObject pipeHandle;
    public Animator animation;
    public AudioSource som;


    void Start()
    {
        pipeHandle  = this.transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (pipeHandle.GetComponent<ObjectController>().isBeingGazed)
        {
            if (Input.GetButtonDown("Jump") || Google.XR.Cardboard.Api.IsTriggerPressed || Input.GetButtonDown("Fire1"))
            {
                stateIndex = (stateIndex + 1) % 7;
                stateIndex = (stateIndex == 0) ? 1 : stateIndex;
                animation.SetInteger("CanoPuzzleState", stateIndex);
                som.Play();
                

            }
        }
        handlePosition = (stateIndex > 3) ? stateIndex - (2*stateIndex - 6) : stateIndex;
        currentPosition = states[handlePosition];
    }
}
