using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour
{
    public int key_count = 0;
    public void OnPointerEnter()
    {
        key_count = 1;
    }
    public void OnPointerExit()
    {
        gameObject.SetActive(false);
    }
}
