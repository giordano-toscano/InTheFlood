using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pontuacao : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI screen;
    public static float minutes;
    public static float seconds;
    public static float calculo;
    // Start is called before the first frame update
    void Start()
    {
        if (minutes == 4)
        {
            calculo = 800;
        }
        else if (minutes == 3)
        {
            calculo = 600;
        }
        else if (minutes == 2)
        {
            calculo = 400;
        }
        else if (minutes == 1)
        {
            calculo = 200;
        }
        else
        {
            calculo = 100;
        }

        calculo = calculo + seconds * 2;
        screen.text = calculo.ToString("F0");
    }
}
