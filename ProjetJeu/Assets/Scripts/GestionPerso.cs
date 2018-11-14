using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GestionPerso : MonoBehaviour {

    public float vieTotale;
    private float vieActuelle;

    public float vitesseTir;

    public Image viePerso;
    public GameObject particuleTir;
    public GameObject fusil;

    public static bool peutTirer = true;
    private bool estDansZone;

    private Animator anim;

    // Use this for initialization
    void Start ()
    {
        vieActuelle = vieTotale;
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!DeplacementPerso.estMort)
        {
            viePerso.fillAmount = vieActuelle / vieTotale;


            if (Input.GetMouseButtonDown(0) && peutTirer)
            {
                var clone = Instantiate(particuleTir);
                clone.transform.position = fusil.transform.position;
                clone.transform.localEulerAngles = transform.localEulerAngles;
                anim.SetBool("Tir", true);
                clone.SetActive(true);
                peutTirer = false;
                StartCoroutine("AttenteTir");
                StartCoroutine(DetruireParticule(clone));
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ennemi" && estDansZone == false)
        {
            estDansZone = true;
            Ennemis.touchePerso = true;
            InvokeRepeating("AttaquePerso", 0, Ennemis.vitesseAttaque);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "ennemi")
        {
            estDansZone = false;
            Ennemis.touchePerso = false;
            CancelInvoke("AttaquePerso");
        }
    }

    void AttaquePerso()
    {
        vieActuelle -= Ennemis.degatEnnemi;
        if (vieActuelle <= 0)
        {
            DeplacementPerso.estMort = true;
        }
        if (!Ennemis.touchePerso)
        {
            CancelInvoke("AttaquePerso");
        }
    }

    IEnumerator AttenteTir()
    {
        yield return new WaitForSeconds(vitesseTir);
        peutTirer = true;
    }

    IEnumerator DetruireParticule(GameObject particule)
    {
        yield return new WaitForSeconds(2);
        Destroy(particule);
    }
}
