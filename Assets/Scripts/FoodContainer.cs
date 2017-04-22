using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodContainer : MonoBehaviour {
    public Transform Fillable;
    public Vector3 EmptyScale;
    public Vector3 FullScale;
    public float Capacity = 1;
    public float Contained = 0;

    void Update() {
        Fillable.localScale = Vector3.Lerp(EmptyScale, FullScale, Contained / Capacity);
        GetComponent<Attachable>().Attach = Contained < Capacity;
    }
}
