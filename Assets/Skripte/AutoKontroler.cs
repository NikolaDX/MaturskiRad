using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AutoKontroler : MonoBehaviour
{
    float vreme; 
    bool istovarUToku = false;
    [SerializeField] float ubrzanje;
    [SerializeField] float ugaoSkretanja;
    [SerializeField] Transform prikolica;
    [SerializeField] WheelCollider[] tockovi;
    [SerializeField] Transform[] modeliTockova;
    [SerializeField] LayerMask parkingSloj;
    public bool pokupljenPaket = false;
    [Range(0, 100)] public float procenatIstovara;
    [SerializeField] AudioSource zvuk;
    [SerializeField] AudioSource zvuk1;
    [SerializeField] AudioSource zvuk2;
    
    public Rigidbody rb;

    public Vector3 pocetnaPozicija;
    AutoUnos autoUnos;
    float horizontalniUnos;
    float vertikalniUnos;
    public float ubrzanjeMotora;
    bool zvukPusten = false;
    bool bubnjevi = false;

    private void Start()
    {
        procenatIstovara = 0;
    }
    

    private void Awake() {
        PodesavanjeAuta();   
        UcitavanjeKontrola();
    }

    private void FixedUpdate() 
    {
        KretanjeAutomobila();  
    }

    private void Update() 
    {
        ubrzanjeMotora = tockovi[2].motorTorque;
        AnimacijaTockova();
        if (istovarUToku)
        {
            Istovar();
            if (!bubnjevi){
                zvuk2.Play();
                bubnjevi = true;
            }
            if (procenatIstovara == 100){
                bubnjevi = false;
                zvuk2.Stop();
            }
        }
        else{
            if (bubnjevi){
                bubnjevi = false;
                zvuk2.Stop();
            }
        }
        if (transform.position.y < -10)
        {
            Povratak();
        }
        IstovarZavrsen();
    }

    private void PodesavanjeAuta()
    {
        rb = GetComponent<Rigidbody>();
        pocetnaPozicija = transform.position;
    }
    
    private void UcitavanjeKontrola()
    {
        autoUnos = new AutoUnos();
        autoUnos.Enable();
        autoUnos.Auto.HorizontalnoKretanje.performed += c => horizontalniUnos = c.ReadValue<float>();
        autoUnos.Auto.VertikalnoKretanje.performed += c => vertikalniUnos = c.ReadValue<float>();
        autoUnos.Auto.HorizontalnoKretanje.canceled += c => horizontalniUnos = 0;
        autoUnos.Auto.VertikalnoKretanje.canceled += c => vertikalniUnos = 0;
        autoUnos.Auto.Povratak.performed += c => Povratak();
    }

    private void KretanjeAutomobila()
    {
        tockovi[2].motorTorque = vertikalniUnos * ubrzanje;
        tockovi[3].motorTorque = vertikalniUnos * ubrzanje;
        tockovi[0].steerAngle = horizontalniUnos * ugaoSkretanja;
        tockovi[1].steerAngle = horizontalniUnos * ugaoSkretanja;
    }

    private void AnimacijaTockova()
    {
        for (int i = 0; i < tockovi.Length; i++)
        {
            AnimacijaTocka(tockovi[i], modeliTockova[i]);
        }
    }

    private void AnimacijaTocka(WheelCollider tocak, Transform modelTocka)
    {
        Vector3 pos;
        Quaternion rot;
        tocak.GetWorldPose(out pos, out rot);
        modelTocka.position = pos;
        modelTocka.rotation = rot;
    }

    public void Povratak()
    {
        transform.position = pocetnaPozicija;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        rb.velocity = Vector3.zero;
        procenatIstovara = 0;
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Paket" && !pokupljenPaket)
        {
            other.transform.position = prikolica.position;
            pokupljenPaket = true;
            zvuk.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Parking") && pokupljenPaket)
        {
            istovarUToku = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Parking"))
        {
            istovarUToku = false;
        }
    }

    private void Istovar()
    {
        procenatIstovara += 20 * Time.deltaTime;
        if (procenatIstovara > 100)
        {
            procenatIstovara = 100;
        }
    }

    void IstovarZavrsen(){
        if (procenatIstovara == 100 && !zvukPusten){
            zvuk1.Play();
            zvukPusten = true;
        }
    }

}
