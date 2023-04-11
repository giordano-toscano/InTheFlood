using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openDoor : MonoBehaviour
{
    public GameObject UIcounter;
    public Animator anim;
    public bool isOpen = false;

    public void OnPointerEnter()
    {
        if (isOpen == true)
        {
            anim.Play("Door_Open");
            StartCoroutine(CloseDoorAutomatic());
        }

    }
    IEnumerator CloseDoorAutomatic()
    {
        yield return new WaitForSeconds(20);
        anim.Play("Door_Close");
        isOpen = false;
    }
}
