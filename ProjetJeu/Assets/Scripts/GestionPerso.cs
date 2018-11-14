using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GestionPerso : MonoBehaviour {

    public float vieTotale;
    private float vieActuelle;

    public Image viePerso;

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

        if (Input.GetMouseButtonDown(0))
        {
            peutTirer = false;

            RaycastHit infoCollisionTir;

            if (Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out infoCollisionTir, 5000))
            {
                gameObject.GetComponent<LineRenderer>().enabled = true;
                gameObject.GetComponent<LineRenderer>().SetPosition(0, gameObject.transform.position + new Vector3(0, 3, 0));
                gameObject.GetComponent<LineRenderer>().SetPosition(1, infoCollisionTir.point);


                if (infoCollisionTir.collider.gameObject.tag == "ennemi")
                {
                    infoCollisionTir.collider.gameObject.GetComponent<Ennemis>().Touche();
                }

                Invoke("EnleverLigne", 0.1f);
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
        if (!Ennemis.touchePerso)
        {
            CancelInvoke("AttaquePerso");
        }
    }

    void EnleverLigne()
    {
        gameObject.GetComponent<LineRenderer>().enabled = false;
    }
}
