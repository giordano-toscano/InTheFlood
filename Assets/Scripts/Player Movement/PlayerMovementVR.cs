using UnityEngine;

public class PlayerMovementVR : MonoBehaviour
{
    public float speed = 5f; // a velocidade do personagem
    public Input inputManager; // o objeto que receberá os sinais do controle

    private void Update()
    {
        float horizontal = Input.GetAxis("Joystick Horizontal");
        float vertical = Input.GetAxis("Joystick Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }
}