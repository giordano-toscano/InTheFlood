using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderScript : MonoBehaviour

{
	public Transform chController;
	bool inside = false;
	public float speedUpDown = 3f; //3.2f
	public PlayerMovementImproved FPSInput;

	void Start()
	{
		FPSInput = GetComponent<PlayerMovementImproved>();
		inside = false;
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Ladder")
		{
			FPSInput.enabled = false;
			inside = !inside;
		
		}
	}
	
	void OnTriggerExit(Collider col)
	{
		if (col.gameObject.tag == "Ladder")
		{
			FPSInput.enabled = true;
			inside = !inside;
		}
	}

	void Update()
	{

		if (inside == true && Input.GetKey(KeyCode.W))
		{
			chController.transform.position += (Vector3.up * speedUpDown) * Time.deltaTime;
		}

		/*if (inside == true && Input.GetKey(KeyCode.S))
		{
			chController.transform.position += Vector3.down / speedUpDown;
		}*/
	}

}