using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTime : MonoBehaviour
{
    public GameObject canvas;
    public GameObject agua;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            agua.SetActive(true);
            canvas.SetActive(true);
        }
    }
}
