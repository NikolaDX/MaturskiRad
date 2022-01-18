using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KontrolerStrelice : MonoBehaviour
{
    [SerializeField] Transform paket;
    [SerializeField] Transform parking;
    public AutoKontroler autoSkripta;

    private void Update() {
        
        if (autoSkripta.pokupljenPaket){
            Vector3 pozicijaParkinga = parking.position;
            pozicijaParkinga.y = transform.position.y;
            transform.LookAt(pozicijaParkinga);
        }
        else{
            Vector3 pozicijaPaketa = paket.position;
            pozicijaPaketa.y = transform.position.y;
            transform.LookAt(pozicijaPaketa);
        }
        
    }

}
