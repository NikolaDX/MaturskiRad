using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZvukMotora : MonoBehaviour
{
    AudioSource izvorZvuka;

    [SerializeField] float minimalnaFrekvencija = 0.05f;
    [SerializeField] float maksimalnaFrekvencija = 2f;
    [SerializeField] AutoKontroler autoSkripta;
    // Start is called before the first frame update
    void Start()
    {
        izvorZvuka = GetComponent<AudioSource>();
        izvorZvuka.pitch = minimalnaFrekvencija;
    }

    // Update is called once per frame
    void Update()
    {
        if (autoSkripta.rb.velocity.magnitude < minimalnaFrekvencija){
            izvorZvuka.pitch = minimalnaFrekvencija;
        }
        else if (autoSkripta.rb.velocity.magnitude > maksimalnaFrekvencija){
            izvorZvuka.pitch = maksimalnaFrekvencija;
        }
        else {
            izvorZvuka.pitch = autoSkripta.rb.velocity.magnitude;
        }
        
    }
}
 