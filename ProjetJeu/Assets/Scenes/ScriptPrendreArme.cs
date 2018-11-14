using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptPrendreArme : MonoBehaviour {
    public GameObject FusilDeco;
    public GameObject FusilPerso;
    public GameObject particules;
    public GameObject texte;
    public GameObject panel;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            particules.SetActive(false);
            FusilDeco.SetActive(false);
            FusilPerso.SetActive(true);
            texte.SetActive(false);
            panel.SetActive(false);
        }
    }
}
