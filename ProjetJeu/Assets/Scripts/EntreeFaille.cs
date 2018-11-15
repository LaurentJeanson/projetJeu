//////////////////////////////////////////
////Philippe Thibeault////////////////////
//////////////////////////////////////////
////Dernière modification : 2018-11-14////
//////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntreeFaille : MonoBehaviour
{

    //Caméra à animer pour la cinématique
    public Camera cam;

    //Lorsque le personnage entre dans la faille
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Jouer l'animation et charger la prochaine scène
            cam.GetComponent<Animation>().Play();
            StartCoroutine("LoadScene");
        }
    }

    //Charger la scène à la fin de l'animation
    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(2.3f);
        SceneManager.LoadScene(5);
    }
}
