using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Put : MonoBehaviour
{
    [SerializeField] float brzinaKretanja;
    [SerializeField] GameObject[] tockovi;
    [SerializeField] float brzinaRotacijeTockova;
    Vector3 pocetnaPozicija;

    private void Awake() {
        pocetnaPozicija = transform.position;
    }
    private async void Update() {
        transform.Translate(new Vector3(0, 0, 1) * brzinaKretanja * Time.deltaTime);
        if (transform.position.z > 38.89f) {
            transform.position = pocetnaPozicija;
        }
        for (int i = 0; i < tockovi.Length; i++){
            tockovi[i].transform.Rotate(Vector3.right * brzinaRotacijeTockova * Time.deltaTime);
        }
    }
}
