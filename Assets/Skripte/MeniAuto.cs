using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeniAuto : MonoBehaviour
{
    [SerializeField] float brzinaRotacije;
    private void Update() {
        if (transform.rotation.y > 2f){
            transform.Rotate(new Vector3(0, .01f, 0f) * brzinaRotacije * Time.deltaTime);
        }
        else if (transform.rotation.y < -2f){
            transform.Rotate(new Vector3(0, -.01f, 0f) * brzinaRotacije * Time.deltaTime);
        }
    }
}
