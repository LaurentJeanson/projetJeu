///////////////////////////////////////////////
////// Carolanne Legault //////////////////////
///////////////////////////////////////////////
////// Dernière modification: 2018-11-28 //////
///////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompteurEnnemis : MonoBehaviour {

    public int nbEnnemis = 0; // Le nombre d'ennemis au départ
    private Text Compteur; // Montrer combien d'ennemis il reste
    
    void Start () {

        // Définir le compteur
        Compteur = GameObject.Find("Compteur").GetComponent<Text>();

        /*Compte ennemis présent dans la scène*/
        nbEnnemis = GameObject.FindGameObjectsWithTag("ennemi").Length;
        
        // Affiche le décompte des ennemis restants dans l'écran de jeu
        Compteur.text = "Ennemis : " + nbEnnemis;

	}

  
    void Update () {
		





	}
}
