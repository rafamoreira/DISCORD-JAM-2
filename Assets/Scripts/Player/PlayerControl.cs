using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
    public float speed = 10;
    Rigidbody rbd;
    
    // Start is called before the first frame update
    void Start() {
        rbd = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        rbd.AddForce(speed, 0, 0 , ForceMode.Impulse);
    }
}
