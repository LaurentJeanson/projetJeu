using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptVolume : MonoBehaviour {
    public Slider mySlider;
    public GameObject Musique;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Musique.GetComponent<AudioSource>().volume = mySlider.value;
    }
}
