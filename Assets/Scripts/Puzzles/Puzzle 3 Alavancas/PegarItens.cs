using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegarItens : MonoBehaviour
{
    public GameObject pickupItem;
    public float pickupDistance = 3.0f;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isPickedUp)
            {
                Drop();
            }
            else
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.forward, out hit, pickupDistance))
                {
                    if (hit.collider.gameObject == pickupItem)
                    {
                        Pickup();
                    }
                }
            }
        }
    }
private bool isPickedUp = false;

    void Pickup()
    {
        isPickedUp = true;
        pickupItem.SetActive(false);
        pickupItem.transform.parent = transform;
    }

    void Drop()
    {
        isPickedUp = false;
        pickupItem.transform.parent = null;
        pickupItem.SetActive(true);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !isPickedUp)
        {
            Pickup();
        }
    }
}
