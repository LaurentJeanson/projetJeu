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

    public static bool peutTirer = true;
    private bool estDansZone;

	// Use this for initialization
	void Start ()
    {
        vieActuelle = vieTotale;
	}
	
	// Update is called once per frame
	void Update ()
    {
        viePerso.fillAmount = vieActuelle / vieTotale;

        if (Input.GetMouseButtonDown(0) && peutTirer)
        {
            var clone = Instantiate(particuleTir);
            clone.transform.position = transform.position + new Vector3(0, 0.5f, 0);
            clone.transform.localEulerAngles = transform.localEulerAngles;
            clone.SetActive(true);
            peutTirer = false;
            StartCoroutine("AttenteTir");
            StartCoroutine(DetruireParticule(clone));
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
