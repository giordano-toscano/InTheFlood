using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TelaVitoria : MonoBehaviour
{
    int rand;
    public void ProximaFase()
    {
        rand = Random.Range(1, 4); //Fase2-01, Fase2-02, Fase2-03, só precisa mudar os indices
        SceneManager.LoadScene(rand);
    }

    public void VoltarAoMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}

