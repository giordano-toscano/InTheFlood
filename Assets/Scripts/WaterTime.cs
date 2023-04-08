using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class WaterTime : MonoBehaviour
{
    bool already;
    bool already2;
    float subiu = 0;
    public bool protegidoEscada;
    public bool protegidoCilindro;
    public int cont = 0;
    float speed = 0.3f;
    private float timeSec;
    private float timeMin;
    [SerializeField] private TextMeshProUGUI sec_txt;
    [SerializeField] private TextMeshProUGUI min_txt;
    bool fimFase = false;

    // Start is called before the first frame update
    void Start()
    {
        timeMin = 5f;
        Time.timeScale = 1f;
        already = false;
        already2 = false;
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
                if ((timeMin == 3 || timeMin == 1) && timeSec <= 5f && timeSec >= 4)
                {
                    gameObject.GetComponent<AudioSource>().Play();
                    sec_txt.text = ":0" + timeSec.ToString("F0");
                    min_txt.text = timeMin.ToString("F0");
                }
            }
            else if (timeMin < 3f && subiu < 10 && already == false)
            {
                if (gameObject.transform.position.y == -1.0f)
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
            }
            else if (subiu >= 10f && already == false)
            {
                if (gameObject.transform.position.y != -3.1f)
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
            else if (timeMin < 1f && subiu < 10 && already2 == false)
            {
                if (gameObject.transform.position.y == -1.0f)
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
            }
            else if (subiu >= 10f && already2 == false)
            {
                if (gameObject.transform.position.y != -3.1f)
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
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, -1.0f, 0), speed * Time.deltaTime);
    }

    void WaterDOWN()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, -3.1f, 0), speed * Time.deltaTime);
    }
}

