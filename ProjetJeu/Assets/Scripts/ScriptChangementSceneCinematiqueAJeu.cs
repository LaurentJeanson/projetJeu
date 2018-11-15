using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
/**************************************************/
/**Dernière modification : 2018-11-14 *************/
/**************************************************/
/**Fait par Nejma Hamadi***************************/
/**************************************************/

public class ScriptChangementSceneCinematiqueAJeu : MonoBehaviour {

    public GameObject videoPlayer;

	// Use this for initialization
	void Start () {
        videoPlayer.GetComponent<VideoPlayer>().loopPointReached += allerCinematiqueAJeu;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void allerCinematiqueAJeu(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene("SceneJeu");
    }
}
