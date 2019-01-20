using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CuesDoneCheck : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponentsInChildren<cue>().All(c => c.TriggerCompleted))
        {
            GetComponent<AudioSource>().Play();
            GetComponent<changeScene>().loadScene = true;
        }
	}
}
