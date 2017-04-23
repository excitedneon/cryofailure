using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NewtonVR;

public class ActButton : MonoBehaviour {
    public NVRButton Activator;
    public Activatable Activatable;

    void Update () {
		if (Activatable != null && Activator != null && Activator.ButtonDown) {
            Activatable.Activate();
        }
	}

    public void Press() {
        Debug.Log("Pressed!");
        if (Activatable != null) {
            Debug.Log("Activated!");
            Activatable.Activate();
        }
    }
}
