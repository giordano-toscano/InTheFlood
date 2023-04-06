using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public GameObject flashlightOn;
    public GameObject flashlightOff;
    public GameObject flashlightCorrect;
    public GameObject flashlightIncorrect;
    private bool isOn;
    public string mode = "off";
    public float delayForIncorrect = 3;
    float timerForIncorrect;

    public float delay = 0.2f;
    float timer;

    private void Start()
    {
        GameObject parent = gameObject.transform.parent.gameObject;
        Puzzle_Canos_GeneralController parentScript = parent.GetComponent<Puzzle_Canos_GeneralController>();
        /*switch (gameObject.transform.name) 
        {
            case "Cano1":
                mode = parentScript.lightModes[0];
                break;
            case "Cano2":
                mode = parentScript.lightModes[1];
                break;
            case "Cano3":
                mode = parentScript.lightModes[2];
                break;
        }*/
        

        if (mode.Equals("off"))
        {
            off();
        }else if (mode.Equals("on"))
        {
            on();
        }
        
    }

    public void Update()
    {
           
        if (mode.Equals("flickering"))
        {
            flickering();
        }
    }

    public void flickering()
    {

        timer += Time.deltaTime;
        if (timer > delay)
        {
            if (isOn)
            {
                off();
            }
            //if its off turn it on
            else
            {
                on();
            }
            // and set the boolean to whatever it isn't (if true it'll go false, if false it'll go true)
            isOn = !isOn;
            timer -= delay;
        }

    }

    public void off()
    {

        flashlightOff.SetActive(true);
        flashlightOn.SetActive(false);
        flashlightCorrect.SetActive(false);
        flashlightIncorrect.SetActive(false);
    }

    public void on()
    {
        flashlightOn.SetActive(true);
        flashlightOff.SetActive(false);
        flashlightCorrect.SetActive(false);
        flashlightIncorrect.SetActive(false);
    }
    public void correct()
    {
        mode = "off";
        flashlightOn.SetActive(false);
        flashlightOff.SetActive(false);
        flashlightIncorrect.SetActive(false);
        flashlightCorrect.SetActive(true);
    }

    /*public void incorrect()
    {
        string originalMode = mode;
        mode = "off";
        flashlightOn.SetActive(false);
        flashlightOff.SetActive(false);
        flashlightCorrect.SetActive(false);
        flashlightIncorrect.SetActive(true);

        if (mode.Equals("off"))
        {
            timerForIncorrect += Time.deltaTime;
            if (timerForIncorrect > delayForIncorrect)
            {
                mode = originalMode;
                flashlightIncorrect.SetActive(false);
                if (mode.Equals("off"))
                {
                    off();
                }
                else if (mode.Equals("on"))
                {
                    on();
                }
                timerForIncorrect = 0;
            }
        }

    }*/


}
