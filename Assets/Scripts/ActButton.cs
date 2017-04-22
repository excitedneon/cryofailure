using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NewtonVR;

public class ActButton : MonoBehaviour {
    public NVRButton Activator;
    public Activatable Activatable;
    
    void Update () {
		if (Activator.ButtonDown) {
            Activatable.Activate();
        }
	}
}
