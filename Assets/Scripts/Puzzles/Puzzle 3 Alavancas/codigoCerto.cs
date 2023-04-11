using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class codigoCerto : MonoBehaviour
{
    void abrirPorta()
    {
        GetComponent<openDoor>().enabled = true;
    }
}
