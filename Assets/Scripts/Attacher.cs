using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacher : MonoBehaviour {
    public GameObject AttachedGameObject;
    public Vector3 DetachOffset;

    void Update() {
        if (AttachedGameObject == null) {
            return;
        }

        if (!AttachedGameObject.GetComponent<Attachable>().Attach) {
            Vector3 NewPos = AttachedGameObject.transform.position;
            NewPos += DetachOffset;
            AttachedGameObject.transform.position = NewPos;
            AttachedGameObject.GetComponent<Rigidbody>().velocity = new Vector3();
            AttachedGameObject = null;
            return;
        }
        AttachedGameObject.transform.position = transform.position;
        AttachedGameObject.transform.rotation = transform.rotation;
    }

    void OnTriggerEnter(Collider other) {
        Transform parent = other.transform.parent;
        if (parent != null && parent.GetComponent<Attachable>() != null && parent.GetComponent<Attachable>().Attach) {
            AttachedGameObject = parent.gameObject;
        }
    }
}
