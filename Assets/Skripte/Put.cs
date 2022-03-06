using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Put : MonoBehaviour
{
    [SerializeField] float brzinaKretanja;
    Vector3 pocetnaPozicija;

    private void Awake() {
        pocetnaPozicija = transform.position;
    }
    private void Update() {
        transform.Translate(new Vector3(0, 0, 1) * brzinaKretanja * Time.deltaTime);
        if (transform.position.z > 38.89f) {
            transform.position = pocetnaPozicija;
        }
    }
}
