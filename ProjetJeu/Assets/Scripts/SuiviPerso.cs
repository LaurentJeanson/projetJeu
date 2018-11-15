//////////////////////////////////////////
////Philippe Thibeault////////////////////
//////////////////////////////////////////
////Dernière modification : 2018-11-14////
//////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/***********************************************/
/*Script pour que la caméra suive le personnage*/
/***********************************************/
public class SuiviPerso : MonoBehaviour
{

    public GameObject Cible;
    public Vector3 Distance;
	
	// Update is called once per frame
	void Update ()
    {
        //On met la caméra à une distance spécifique par rapport au personnage et on lui dit de le regarder
        transform.position = Cible.transform.position + Distance;
        transform.LookAt(Cible.transform.position);
    }
}
