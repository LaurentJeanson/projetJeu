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

    private void LateUpdate()
    {
        //rb.AddForce(new Vector3(0, -1000, 0));
    }

    void FixedUpdate()
    {
        float deplacementHorizontal = Input.GetAxis("Horizontal");
        float deplacementVertical = Input.GetAxis("Vertical");

        float vitesseHorizontal = -deplacementVertical * vitesseDeplacement;
        float vitesseVertical = deplacementHorizontal * vitesseDeplacement;

        //print(rb.velocity.y);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            
            rb.velocity = new Vector3(vitesseHorizontal, 0, vitesseVertical).normalized * 20;
            court = true;
        }
        else
        {
            //gameObject.GetComponent<Rigidbody>().velocity
            //rb.AddForce(new Vector3(0, -300, 0));
            rb.velocity = new Vector3(vitesseHorizontal, 0, vitesseVertical).normalized * 10;
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

        if (Physics.Raycast(camRay.origin, camRay.direction, out infoCollisionPerso, 5000, LayerMask.GetMask("Plancher")))
        {
            Vector3 pointARegarder = infoCollisionPerso.point;//(x, y, z)
            /*gameObject.*/
            transform.LookAt(pointARegarder);
            transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
        }

        RaycastHit hit;

        if (Physics.Raycast(gameObject.transform.position, Vector3.down, out hit))
        {
            if (hit.distance > 1)
            {
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - hit.distance, gameObject.transform.position.z), 12 * Time.deltaTime);
            }
        }
    }
}
