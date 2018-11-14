using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptPrendreArme : MonoBehaviour {
    public GameObject FusilDeco;
    public GameObject FusilPerso;
    public GameObject particules;
    public GameObject texte;
    public GameObject panel;
    public GameObject texte2;
    public GameObject panel2;
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
            texte2.SetActive(true);
            panel2.SetActive(true);
        }
    }
}
