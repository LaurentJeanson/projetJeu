/////////////////////////////////////
//Nejma Hamadi//////////////////////
////////////////////////////////////
//Dernière modification : 2018-10-10
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
        SceneManager.LoadScene("SampleScene");
    }

    public void allerJeuInstructions()
    {
        SceneManager.LoadScene("interfaceInstructions");
    }
}
