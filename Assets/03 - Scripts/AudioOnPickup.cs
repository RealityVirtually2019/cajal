using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioOnPickup : OVRGrabbable {



    public override void GrabBegin(OVRGrabber hand, Collider grabPoint)
    {
        Debug.Log("start Grabbing");
        base.GrabBegin(hand, grabPoint);
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
