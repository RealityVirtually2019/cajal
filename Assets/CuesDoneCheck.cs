using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CuesDoneCheck : MonoBehaviour {

    public AudioSource Audio;
    bool audioStarted = false;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponentsInChildren<cue>().All(c => c.TriggerCompleted))
        {
            if (!audioStarted)
            {
                Audio.Play();
                audioStarted = true;

                GetComponent<changeScene>().loadScene = true;
            }
        }
	}
}
