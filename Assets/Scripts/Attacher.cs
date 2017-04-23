using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacher : MonoBehaviour {
    public GameObject AttachedGameObject;
    public Vector3 DetachOffset;
    public ResourceType AttachedResources;

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
        FoodContainer Food;
        if (parent != null && (Food = parent.GetComponent<FoodContainer>()) != null && 
            (Food.ContainedType == ResourceType.Nothing || Food.ContainedType == AttachedResources) &&
            parent.GetComponent<Attachable>() != null && parent.GetComponent<Attachable>().Attach) {
            AttachedGameObject = parent.gameObject;
        }
    }
}
