using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class Puzzle_Canos_GeneralController : MonoBehaviour
{
    public string[] resolution;
    //public string[] resolution2 = {"right", "down", "up"};
    //public string[] resolution3 = {"down", "up", "right"};
    public string[] lightModes = { "flickering", "off", "on"};
    public GameObject confirmButton;
    public GameObject pipe1;
    public GameObject pipe2;
    public GameObject pipe3;
    public string concluido = "Ainda nao";
    void Start()
    {
        //var children = Array.FindAll(GetComponentsInChildren<Transform>(), child => child != this.transform);
        Random r = new Random();
        lightModes = lightModes.OrderBy(x => r.Next()).ToArray();
        GameObject flashlight1 = gameObject.transform.Find("Cano1").Find("Flashlight1").gameObject;
        GameObject flashlight2 = gameObject.transform.Find("Cano2").Find("Flashlight2").gameObject;
        GameObject flashlight3 = gameObject.transform.Find("Cano3").Find("Flashlight3").gameObject;
        flashlight1.GetComponent<Flashlight>().mode = lightModes[0];
        flashlight2.GetComponent<Flashlight>().mode = lightModes[1];
        flashlight3.GetComponent<Flashlight>().mode = lightModes[2];
        flashlight1.SetActive(true);
        flashlight2.SetActive(true);
        flashlight3.SetActive(true);
        resolution = new string[3];
        for(int i = 0; i < lightModes.Length; i++)
        {
            switch (lightModes[i])
            {
                case "flickering":
                    resolution[i] = "right";
                    break;
                case "on":
                    resolution[i] = "up";
                    break;
                case "off":
                    resolution[i] = "down";
                    break;
            }
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (confirmButton.GetComponent<Puzzle_Canos_ConfirmButtonController>().isPressed)
        {
            string pipe1FinalPosition = pipe1.GetComponent<Puzzle_Canos_CanoController>().currentPosition;
            string pipe2FinalPosition = pipe2.GetComponent<Puzzle_Canos_CanoController>().currentPosition;
            string pipe3FinalPosition = pipe3.GetComponent<Puzzle_Canos_CanoController>().currentPosition;
            GameObject flashlight1 = gameObject.transform.Find("Cano1").Find("Flashlight1").gameObject;
            GameObject flashlight2 = gameObject.transform.Find("Cano2").Find("Flashlight2").gameObject;
            GameObject flashlight3 = gameObject.transform.Find("Cano3").Find("Flashlight3").gameObject;
            if (pipe1FinalPosition.Equals(resolution[0]) && pipe2FinalPosition.Equals(resolution[1]) && pipe3FinalPosition.Equals(resolution[2]))
            {
               
                flashlight1.GetComponent<Flashlight>().correct();
                flashlight2.GetComponent<Flashlight>().correct();
                flashlight3.GetComponent<Flashlight>().correct();
                concluido = "RESPOSTA CORRETA";
            }
            else
            {
                /*flashlight1.GetComponent<Flashlight>().incorrect();
                flashlight2.GetComponent<Flashlight>().incorrect();
                flashlight3.GetComponent<Flashlight>().incorrect();*/
                concluido = "RESPOSTA ERRADA";
            }
            
        }
        
    }
}
