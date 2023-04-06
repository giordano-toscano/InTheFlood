using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    public bool gazedAtFloor = false;

    public void OnPointerEnter()
    {
        gazedAtFloor = true;
    }
    public void OnPointerExit()
    {
        gazedAtFloor = false;
    }

}
