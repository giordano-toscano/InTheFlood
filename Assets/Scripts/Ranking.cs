using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ranking : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI first;
    [SerializeField] private TextMeshProUGUI second;
    [SerializeField] private TextMeshProUGUI third;
    float novoNum;
    float primeiro;
    float segundo;
    float terceiro;
    // Start is called before the first frame update
    void Start()
    {
        novoNum = Pontuacao.calculo;
        if (novoNum > primeiro)
        {
            primeiro = novoNum;
            segundo = primeiro;
            terceiro = segundo;
        }
        else if (novoNum > segundo)
        {
            segundo = novoNum;
            terceiro = segundo;
        }
        else if (novoNum > terceiro)
        {
            terceiro = novoNum;
        }

        first.text = "1) " + primeiro.ToString("F0");
        second.text = "2) " + segundo.ToString("F0");
        third.text = "3) " + terceiro.ToString("F0");
    }
}
