using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InteractWithMenu : MonoBehaviour
{
    [SerializeField] private LayerMask ui;
    GameObject hitObj;
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 5000, ui))
        {
            hitObj = hit.transform.gameObject;
            hitObj.GetComponent<MeshRenderer>().material.color = Color.red;

            if (!Input.GetButtonDown("Fire1")) return;
            Button b = hit.collider.gameObject.GetComponent<Button>();
            if (b != null)
            {
                b.onClick.Invoke();
            }
        }
        else
        {
            if (hitObj != null)
            {
                hitObj.GetComponent<MeshRenderer>().material.color = Color.white;
                hitObj = null;
            }
        }


    }



}
