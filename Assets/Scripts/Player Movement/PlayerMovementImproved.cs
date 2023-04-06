using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementImproved : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 4f;
    public float gravity = -9.81f;
    public float jump = 1f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    float horizontal = 0;
    float vertical = 0;
    public GameObject text;
    public Camera playerCam;
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;
        MovePlayer();
        BtnPressed();
    }

    private void MovePlayer()
    {
        horizontal = -Input.GetAxisRaw("Vertical");
        vertical = -Input.GetAxisRaw("Horizontal");

#if UNITY_EDITOR
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        speed = 4f;
#endif
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + playerCam.transform.eulerAngles.y;
            controller.Move((Quaternion.Euler(0, angle, 0) * Vector3.forward) * Time.deltaTime * speed);
        }
    }
    private void BtnPressed()
    {
        if (Google.XR.Cardboard.Api.IsTriggerPressed || Input.GetButtonDown("Fire1"))
        {
            text.SetActive(true);
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            text.SetActive(false);
        }
    }
}
