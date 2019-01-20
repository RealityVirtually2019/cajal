using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cue : MonoBehaviour {

    public int CueNumber;
    public GameObject[] ActivateItems;
    public GameObject[] DeactivateItems;
    public AudioSource Audio;

    private bool activated = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Activate()
    {
        if (!activated)
        {
            activated = true;

            foreach (var go in ActivateItems)
            {
                go.SetActive(true);
            }

            foreach (var go in DeactivateItems)
            {
                go.SetActive(false);
            }

            if (Audio != null) Audio.Play();
        }
        
    }
}
