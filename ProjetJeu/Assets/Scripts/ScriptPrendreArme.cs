using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Scripte créé par Laurent Jeanson

public class ScriptPrendreArme : MonoBehaviour {
	// GameObject des object
    public GameObject FusilDeco;
    public GameObject FusilPerso;
    public GameObject particules;
	// GameObject des UI
    public GameObject texte;
    public GameObject panel;
    public GameObject texte2;
    public GameObject panel2;
	// GameObject des autres objets
    public GameObject ennemi;
    public GameObject spawnEnnemi;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
		// Si l'objet est en contact avec le joueur, les particules, le faux fusil et le texte du tutoriel se désactivent
		// Le vrai fusil s'active avec un autre texte de tutoriel
        if (other.gameObject.tag == "Player")
        {
            particules.SetActive(false);
            FusilDeco.SetActive(false);
            FusilPerso.SetActive(true);
            texte.SetActive(false);
            panel.SetActive(false);
            texte2.SetActive(true);
            panel2.SetActive(true);

			// Un ennemi est instantié lorsque l'arme est pris

            var clone = Instantiate(ennemi);
            clone.transform.position = spawnEnnemi.transform.position;
            clone.SetActive(true);
            print(ennemi.transform.position);
            print(spawnEnnemi.transform.position);
        }
    }
}
