using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TelaDerrota : MonoBehaviour
{
    int rand;
    public void TentarNovamente()
    {
        rand = Random.Range(1, 4); //Fase1-01 = 1, Fase1-02 = 2, Fase1-03 = 3
        SceneManager.LoadScene(rand);
    }

    public void VoltarAoMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
