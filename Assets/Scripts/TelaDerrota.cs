using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TelaDerrota : MonoBehaviour
{
    public void TentarNovamente()
    {
        
        SceneManager.LoadScene("SampleScene");
    }

    public void VoltarAoMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
