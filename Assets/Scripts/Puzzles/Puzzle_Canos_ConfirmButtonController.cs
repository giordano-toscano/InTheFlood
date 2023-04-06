using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_Canos_ConfirmButtonController : MonoBehaviour
{
    public int state = 0;
    public Animator animation;
    public GameObject button;
    public bool isPressed = false;
    public AudioSource som;

   

    public float delay = 3;
    float timer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (button.GetComponent<ObjectController>().isBeingGazed)
        {
            if (Input.GetButtonDown("Jump") || Google.XR.Cardboard.Api.IsTriggerPressed || Input.GetButtonDown("Fire1"))
            {
                state = (state + 1) % 3;
                state = (state == 0) ? 1 : state;
                animation.SetInteger("ButtonState", state);
                som.mute = false;
                som.Play();

            }
        }
        if (state == 1)
        {
            isPressed = true;
            timer += Time.deltaTime;
            if (timer > delay)
            {
                state = 2;
                animation.SetInteger("ButtonState", state);
                isPressed = false;
                timer = 0;
                som.mute = true;
            }
            

        }
    }
}
