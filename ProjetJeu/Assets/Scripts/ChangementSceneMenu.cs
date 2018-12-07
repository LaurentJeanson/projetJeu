/////////////////////////////////////
//Nejma Hamadi//////////////////////
////////////////////////////////////
//Dernière modification : 2018-11-14
////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangementSceneMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Lorsque le joueur aura cliqué sur le bouton JOUER, il le ramenera au jeu

    public void allerJeu()
    {
        SceneManager.LoadScene("SceneJeu");
    }

    //Lorsque le joueur aura cliqué sur le bouton INSTRUCTIONS, il le ramenera au instructions du jeu

    public void allerJeuInstructions()
    {
        SceneManager.LoadScene("interfaceInstructions");
    }

    //Lorsque le joueur aura gagné ou perdu il pourra retourner au menu principal

    public void allerMenuJeu()
    {
        SceneManager.LoadScene("menuPrincipal");
    }

    public void AllerCinematique()
    {
        SceneManager.LoadScene("SceneCinematiqueDebut");
    }
}
