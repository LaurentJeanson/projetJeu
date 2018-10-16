using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementPerso : MonoBehaviour
{

    private Rigidbody rb;
    private Animator anim;
    private bool court = false;

    public float vitesseDeplacement;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float deplacementHorizontal = Input.GetAxis("Horizontal");
        float deplacementVertical = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.velocity = new Vector3(deplacementHorizontal, 0, deplacementVertical).normalized * vitesseDeplacement * 2f;
            court = true;
        }
        else
        {
            //gameObject.GetComponent<Rigidbody>().velocity
            rb.velocity = new Vector3(deplacementHorizontal, 0, deplacementVertical).normalized * vitesseDeplacement;
            court = false;
        }

        if (rb.velocity.magnitude > 0 && !court)
        {
            //gameObject.GetComponent<Animator>().setBool(...);
            anim.SetBool("Marche", true);
            anim.SetBool("Court", false);
        }
        else if (rb.velocity.magnitude > 0 && court)
        {
            anim.SetBool("Marche", false);
            anim.SetBool("Court", true);
        }
        else //if(rb.velocity.magnitude == 0)
        {
            anim.SetBool("Marche", false);
            anim.SetBool("Court", false);
        }

        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit infoCollisionPerso;

        if (Physics.Raycast(camRay.origin, camRay.direction, out infoCollisionPerso, 5000))
        {
            Vector3 pointARegarder = infoCollisionPerso.point;//(x, y, z)
            /*gameObject.*/
            transform.LookAt(pointARegarder);
            transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
        }
    }
}
