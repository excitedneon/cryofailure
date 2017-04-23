using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatingMouth : MonoBehaviour {
    public float EatingSpeed;

    private FoodContainer Food;

    void Update() {
        if (Food != null && Food.Contained > 0) {
            Food.Contained -= Time.deltaTime * EatingSpeed;
            if (Food.Contained < 0) {
                Food.Contained = 0;
            }
        } else if (Food != null) {
            Food = null;
        }
    }

    void OnTriggerEnter(Collider other) {
        Transform Parent = other.transform.parent;
        if (Parent != null) {
            Food = Parent.GetComponent<FoodContainer>();
        }
    }

    void OnTriggerExit(Collider other) {
        Transform Parent = other.transform.parent;
        if (Food != null && Parent == Food.transform) {
            Food = null;
        }
    }
}
