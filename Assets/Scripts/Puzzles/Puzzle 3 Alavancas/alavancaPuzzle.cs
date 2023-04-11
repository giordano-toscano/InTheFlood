using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alavancaPuzzle : MonoBehaviour
{
    public GameObject[] Alavancas;
    public bool[] codigo;
    public int cont;
    public GameObject[] objCertos;
    bool[] nossoCodigo;
    public string[] funcoes;
    void Start()
    {
        nossoCodigo = new bool[codigo.Length];
    }
    void seCerto()
    {
        for(int i = 0; i <objCertos.Length; i++)
        {
            objCertos[i].GetComponent<codigoCerto>().SendMessage(funcoes[i]);
        }
    }
    void seErrado()
    {
        //Inserir o code da água subindo
    }
    public void receberSinal(GameObject go, bool estado)
    {
        for (int i = 0; i < Alavancas.Length; i++)
        {
            if (go == Alavancas[i])
            {
                nossoCodigo[i] = estado;
                break;
            }
        }
        verificar();
    }
    void verificar()
    {
        bool certo = true;
        for(int i = 0; i<codigo.Length; i++)
        {
            if (nossoCodigo[i] != codigo[i])
            {
                certo = false;
                cont++;
                break;
            }
        }
        if (certo)
        {
            foreach(GameObject a in Alavancas)
            {
                a.GetComponent<Alavancas>().canTurn = false;         
            }
        }
    }
}
