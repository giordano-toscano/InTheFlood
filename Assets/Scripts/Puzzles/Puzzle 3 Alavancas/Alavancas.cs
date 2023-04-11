using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alavancas : MonoBehaviour
{
    bool turn = false;

    public bool canTurn = true;
    public GameObject bola;
    public Material bolaDesligado;
    public Material bolaLigado;
    public GameObject controlador;
   
    IEnumerator change()
    {
        yield return new WaitForSeconds(1f); //Dizer o tempo da animação
        canTurn = true;
        turn = !turn;
    }
     void OnMouseDown()
    {
        if (canTurn)
        {
            canTurn = false;
            if (!turn)
            {
                GetComponent<Animation>().Play("Sphere|Descer"); // animação de descer
                StartCoroutine(change());
            }
            else
            {
                GetComponent<Animation>().Play("Sphere|Subir");// animação de subir
                turn = !turn;
            }
        }
    }
}
