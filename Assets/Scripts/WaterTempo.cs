using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class WaterTempo : MonoBehaviour
{
    bool already;
    bool already2;
    bool already3;
    bool already4;
    float subiu = 0;
    public static bool protegidoEscada;
    public bool protegidoCilindro;
    float inicial = -3.54f;
    float final = 0.4f;
    int cont = 3;
    float speed = 0.3f;
    private float timeSec;
    private float timeMin;
    [SerializeField] private TextMeshProUGUI sec_txt;
    [SerializeField] private TextMeshProUGUI min_txt;
    bool fimFase = false;

    // Start is called before the first frame update
    void Start()
    {
        timeMin = 14f;
        Time.timeScale = 1f;
        already = false;
        already2 = false;
        already3 = false;
        already4 = false;
        protegidoEscada = false;
        protegidoCilindro = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (fimFase == false)
        {
            timeSec -= Time.deltaTime;

            if (timeSec <= 0f && timeMin <= 0f)
            {
                fimFase = true;
            }
            else if (timeSec < 0f)
            {
                timeSec = 59f;
                timeMin--;
            }
            else if (timeSec >= 0f && timeSec <= 9.5f)
            {
                sec_txt.text = ":0" + timeSec.ToString("F0");
                min_txt.text = timeMin.ToString("F0");
                if ((timeMin == 11 || timeMin == 8 || timeMin == 5 || timeMin == 2) && timeSec <= 5f && timeSec >= 4)
                {
                    gameObject.GetComponent<AudioSource>().Play();
                    sec_txt.text = ":0" + timeSec.ToString("F0");
                    min_txt.text = timeMin.ToString("F0");
                }
            }
            else if (timeMin < 11f && subiu < 10 && already == false)
            {
                subiu = WaterControl();
            }
            else if (subiu >= 10f && already == false)
            {
                if (gameObject.transform.position.y != inicial)
                {
                    WaterDOWN();
                    sec_txt.text = ":" + timeSec.ToString("F0");
                    min_txt.text = timeMin.ToString("F0");
                }
                else
                {
                    if (protegidoCilindro == true)
                    {
                        protegidoCilindro = false;
                        //Destroy GameObject Cilindro e muda de cor o simbolo
                    }
                    gameObject.GetComponent<AudioSource>().Play();
                    already = true;
                    subiu = 0;
                }
            }
            else if (timeMin < 8f && subiu < 10 && already2 == false)
            {
                subiu = WaterControl();
            }
            else if (subiu >= 10f && already2 == false)
            {
                if (gameObject.transform.position.y != inicial)
                {
                    WaterDOWN();
                    sec_txt.text = ":" + timeSec.ToString("F0");
                    min_txt.text = timeMin.ToString("F0");
                }
                else
                {
                    if (protegidoCilindro == true)
                    {
                        protegidoCilindro = false;
                        //Destroy GameObject Cilindro e muda de cor o simbolo
                    }
                    gameObject.GetComponent<AudioSource>().Play();
                    already2 = true;
                    subiu = 0;
                }
            }
            else if (timeMin < 5f && subiu < 10 && already3 == false)
            {
                subiu = WaterControl();
            }
            else if (subiu >= 10f && already3 == false)
            {
                if (gameObject.transform.position.y != inicial)
                {
                    WaterDOWN();
                    sec_txt.text = ":" + timeSec.ToString("F0");
                    min_txt.text = timeMin.ToString("F0");
                }
                else
                {
                    if (protegidoCilindro == true)
                    {
                        protegidoCilindro = false;
                        //Destroy GameObject Cilindro e muda de cor o simbolo
                    }
                    gameObject.GetComponent<AudioSource>().Play();
                    already3 = true;
                    subiu = 0;
                }
            }
            else if (timeMin < 2f && subiu < 10 && already4 == false)
            {
                subiu = WaterControl();
            }
            else if (subiu >= 10f && already4 == false)
            {
                if (gameObject.transform.position.y != inicial)
                {
                    WaterDOWN();
                    sec_txt.text = ":" + timeSec.ToString("F0");
                    min_txt.text = timeMin.ToString("F0");
                }
                else
                {
                    if (protegidoCilindro == true)
                    {
                        protegidoCilindro = false;
                        //Destroy GameObject Cilindro e muda de cor o simbolo
                    }
                    gameObject.GetComponent<AudioSource>().Play();
                    already4 = true;
                    subiu = 0;
                }
            }
            else
            {
                sec_txt.text = ":" + timeSec.ToString("F0");
                min_txt.text = timeMin.ToString("F0");
            }

            if (cont == 1)
            {
                Time.timeScale = 1.1f;
            }
            else if (cont == 2)
            {
                Time.timeScale = 1.3f;
            }
            else if (cont >= 3)
            {
                Time.timeScale = 1.4f;
            }
        }
        else
        {
            SceneManager.LoadScene("Derrota");
        }
        Pontuacao.minutes = timeMin;
        Pontuacao.seconds = timeSec;
    }

    void WaterUP()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(140.74f, final, -1.49f), speed * Time.deltaTime);
    }

    void WaterDOWN()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(140.74f, inicial, -1.49f), speed * Time.deltaTime);
    }

    float WaterControl()
    {
        if (gameObject.transform.position.y == final)
        {
            subiu += Time.deltaTime;
            sec_txt.text = ":" + timeSec.ToString("F0");
            min_txt.text = timeMin.ToString("F0");
            if (subiu >= 2 && protegidoEscada == false && protegidoCilindro == false)
            {
                fimFase = true;
            }
        }
        else
        {
            WaterUP();
            sec_txt.text = ":" + timeSec.ToString("F0");
            min_txt.text = timeMin.ToString("F0");
        }
        return subiu;
    }
}
