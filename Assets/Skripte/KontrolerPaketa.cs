using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KontrolerPaketa : MonoBehaviour
{
    public AutoKontroler autoSkripta;
    AutoUnos autoUnos;
    Vector3 pocetnaPozicija;
    public bool ispaoPaket;
    
    private void Awake() {
        pocetnaPozicija = transform.position;
        autoUnos = new AutoUnos();
        autoUnos.Enable();
        autoUnos.Auto.Povratak.performed += c => Povratak();
    }

    private void Update()
    {
        if (autoSkripta.procenatIstovara == 100)
        {
            transform.position = autoSkripta.pocetnaPozicija;
        }
        if (autoSkripta.transform.position.y < -10)
        {
            Povratak();
        }
    }

    private void Povratak(){
        transform.position = pocetnaPozicija;
        autoSkripta.pokupljenPaket = false;
    }

    private void OnCollisionEnter(Collision other) {
        if ((other.collider.tag == "Zemlja" || other.collider.tag == "Parking") && autoSkripta.pokupljenPaket && (autoSkripta.procenatIstovara != 100)){
            Povratak();
            autoSkripta.Povratak();
        }
    }
}
