using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScriptHopitDysto : MonoBehaviour {
	public GameObject CameraEvent;
	public GameObject CameraPerso;
    public GameObject texte;
    public GameObject panel;
    public GameObject textePerso;
    public GameObject panelTextPerso;
    public GameObject imageCerveauVide;
    public GameObject imageCerveauPlein;
    public GameObject contourMiniMap;
    public GameObject miniMap;
    public GameObject maskMiniMap;
    public GameObject Perso;
    public GameObject EventHopitalDysto;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		StartCoroutine(CineEventHopitalDysto ());
	}
	IEnumerator CineEventHopitalDysto(){
        yield return new WaitForSeconds(5);
        textePerso.SetActive(false);
        panelTextPerso.SetActive(false);
        yield return new WaitForSeconds (15);
		print (Time.time);
		CameraEvent.SetActive (false);
		//FauxPerso.SetActive (false);
		//Perso.SetActive (true);
		CameraPerso.SetActive (true);
        texte.SetActive(true);
        panel.SetActive(true);
        maskMiniMap.SetActive(true);
        miniMap.SetActive(true);
        contourMiniMap.SetActive(true);
        imageCerveauPlein.SetActive(true);
        imageCerveauVide.SetActive(true);
        Perso.SetActive(false);
        Destroy (EventHopitalDysto);
	}
}
