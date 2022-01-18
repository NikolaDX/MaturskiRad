using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIKontroler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI istovarTekst;
    [SerializeField] TextMeshProUGUI nivoTekst;
    public AutoKontroler autoSkripta;

    void Update()
    {
        istovarTekst.text = "ISTOVAR: " + Mathf.Round(autoSkripta.procenatIstovara) + "%";
        nivoTekst.text = "NIVO: " + PlayerPrefs.GetInt("nivo") + "/20";
    }
}
