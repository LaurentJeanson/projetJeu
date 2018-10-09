using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementPerso : MonoBehaviour {

    public float vitesse;

    private Rigidbody rb;
    private Animator anim;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        float deplaceHorizontal = Input.GetAxis("Horizontal");
        float deplaceVertical = Input.GetAxis("Vertical");
        float mouseInput = Input.GetAxis("Mouse X");

        Vector3 deplacement = new Vector3(deplaceHorizontal, 0f, deplaceVertical);
        Vector3 direction = new Vector3(0, mouseInput, 0);

        rb.AddForce(deplacement * vitesse);
        transform.Rotate(direction);

    }
}
