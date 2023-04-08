using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    int rand;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject creditos;
    [SerializeField] private GameObject rank;
    public void Iniciar()
    {
        rand = Random.Range(1, 4); //Fase1-01 = 1, Fase1-02 = 2, Fase1-03 = 3
        SceneManager.LoadScene(rand);
    }

    public void AbrirCreditos()
    {
        menu.SetActive(false);
        creditos.SetActive(true);
    }

    public void FecharCreditos()
    {
        menu.SetActive(true);
        creditos.SetActive(false);
    }

    public void AbrirRank()
    {
        menu.SetActive(false);
        rank.SetActive(true);
    }

    public void FecharRank()
    {
        menu.SetActive(true);
        rank.SetActive(false);
    }

    public void Sair()
    {
        Application.Quit();
    }
}
