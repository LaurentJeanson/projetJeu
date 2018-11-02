using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationEnnemis : MonoBehaviour {
    
    public GameObject EnnemiBleu;
    public GameObject EnnemiJaune;
    public GameObject EnnemiMauve;
    public GameObject EnnemiOrange;
    public GameObject EnnemiRouge;
    public GameObject EnnemiVert;

	// Use this for initialization
	void Start () {
        InvokeRepeating("CreationEnnemiBleuEtVert", 0, 8);
        InvokeRepeating("CreationEnnemiRougeEtOrange", 0, 10);
        InvokeRepeating("CreationEnnemiJauneEtMauve", 0, 6);
		
	}
	
	// Update is called once per frame
	void CreationEnnemiBleuEtVert () {
        var test = Random.Range(0,2);
        GameObject ennemi;
        
        if (test == 0)
        {
            ennemi = EnnemiBleu;

        } else {
            ennemi = EnnemiVert;
        }

        ennemi.SetActive(true);
        GameObject leClone = Instantiate(ennemi);
		
	}
    
    void CreationEnnemiJauneEtMauve () {
        var test = Random.Range(0,2);
        GameObject ennemi;
        
        if (test == 0)
        {
            ennemi = EnnemiJaune;

        } else {
            ennemi = EnnemiMauve;
        }

        ennemi.SetActive(true);
        GameObject leClone = Instantiate(ennemi);
		
	}
    
    void CreationEnnemiRougeEtOrange () {
        var test = Random.Range(0,2);
        GameObject ennemi;
        
        if (test == 0)
        {
            ennemi = EnnemiRouge;

        } else {
            ennemi = EnnemiOrange;
        }

        ennemi.SetActive(true);
        GameObject leClone = Instantiate(ennemi);
		
	}
}
