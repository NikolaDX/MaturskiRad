using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZvukMotora : MonoBehaviour
{
    AudioSource izvorZvuka;

    [SerializeField] float minimalnaFrekvencija = 0.05f;
    [SerializeField] float maksimalnaFrekvencija = 2f;
    // Start is called before the first frame update
    void Start()
    {
        izvorZvuka = GetComponent<AudioSource>();
        izvorZvuka.pitch = minimalnaFrekvencija;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
