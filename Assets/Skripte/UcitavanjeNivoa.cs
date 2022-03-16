using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UcitavanjeNivoa : MonoBehaviour
{
    [SerializeField] Image zavesa;
    [SerializeField] int nivo;
    public AutoKontroler autoSkripta;
    float a = 1;

    void Start()
    {
        PlayerPrefs.SetInt("nivo", nivo);
        a = 1;
    }

    void Update()
    {
        zavesa.color = new Color(0, 0, 0, a);
        if (autoSkripta.procenatIstovara == 100)
        {
            a += Time.deltaTime;
            if (a > 1)
            {
                a = 1;
            }
        }
        else
        {
            a -= Time.deltaTime;
            if (a < 0)
            {
                a = 0;
            }
        }
        if (autoSkripta.procenatIstovara == 100 && a == 1)
        {
            UcitajNivo();
        }
    }

    public void UcitajNivo(){
        SceneManager.LoadScene("Nivo" + (PlayerPrefs.GetInt("nivo") + 1).ToString());
    }

    public void Izlazak(){
        Application.Quit();
    }
}
