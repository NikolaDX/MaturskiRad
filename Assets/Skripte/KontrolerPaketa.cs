using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KontrolerPaketa : MonoBehaviour
{
    public AutoKontroler autoSkripta;
    [SerializeField] AudioSource zvuk;
    AutoUnos autoUnos;
    Vector3 pocetnaPozicija;
    Rigidbody rb;
    public bool ispaoPaket;
    
    private void Awake() {
        pocetnaPozicija = transform.position;
        rb = GetComponent<Rigidbody>();
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
        rb.velocity = Vector3.zero;
        autoSkripta.pokupljenPaket = false;
    }

    private void OnCollisionEnter(Collision other) {
        if ((other.collider.tag == "Zemlja" || other.collider.tag == "Parking") && autoSkripta.pokupljenPaket && (autoSkripta.procenatIstovara != 100)){
            Povratak();
            autoSkripta.Povratak();
        }
    }
}
