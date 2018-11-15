using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Scripte créé par Laurent Jeanson

public class GestionArmeEvenrt : MonoBehaviour {
    public GameObject Texte;
    public GameObject Panel;
    public GameObject Texte2;
    public GameObject Panel2;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	// Lorsque le joueur appuie sur ENTER, les textes du tutoriel se désactive
	// et d'autre textes apparaient pour montrer un autre tutoriel sur la gestion de vie
	void Update () {
        if (Input.GetKey(KeyCode.Return))
        {
            Texte.SetActive(false);
            Panel.SetActive(false);
            Texte2.SetActive(true);
            Panel2.SetActive(true);
            StartCoroutine(Cerveautexte());
        }
    }

	//Le nombre de temps que le tutoriel de la vie va durée est de 10 secondes 

    IEnumerator Cerveautexte()
    {
        print(Time.time);
        yield return new WaitForSeconds(10);
        print(Time.time);
        Texte2.SetActive(false);
        Panel2.SetActive(false);
    }
}
