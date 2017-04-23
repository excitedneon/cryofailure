using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampToggler : MonoBehaviour {
    public GameObject Lamp;
    public OpenableDoor Door;

    void OnTriggerEnter(Collider other) {
        if (other.tag.Equals("MainCamera")) {
            Lamp.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.tag.Equals("MainCamera")) {
            Lamp.SetActive(false);
            if (Door.Open) Door.Activate();
        }
    }
}
