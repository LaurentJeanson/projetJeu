using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptReprendre : MonoBehaviour {
    public GameObject PanelPause;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
    }
    public void FermerPanel () {
        PanelPause.SetActive(false);
    }
}
