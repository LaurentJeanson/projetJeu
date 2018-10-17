using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptPauseActiver : MonoBehaviour {
    public GameObject PanelPause;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PanelPause.SetActive(true);
        }
    }
}
