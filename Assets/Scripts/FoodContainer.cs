using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodContainer : MonoBehaviour {
    public Transform Fillable;
    public MeshRenderer Renderer;
    public Vector3 EmptyScale;
    public Vector3 FullScale;
    public float Capacity = 1;
    public float Contained = 0;
    public float Heat = 0;
    public ResourceType ContainedType = ResourceType.Nothing;

    void Update() {
        Fillable.localScale = Vector3.Lerp(EmptyScale, FullScale, Contained / Capacity);
        GetComponent<Attachable>().Attach = Contained < Capacity;
        if (ContainedType != ResourceType.Nothing && Contained == 0) {
            ContainedType = ResourceType.Nothing;
        } else if (ContainedType == ResourceType.Food) {
            Renderer.material.color = new Color(Heat * 0.7f + Contained / Capacity * 0.3f, 
                Contained / Capacity * 0.7f, Contained / Capacity * 0.3f);
        } else if (ContainedType == ResourceType.Water) {
            Renderer.material.color = new Color(Contained / Capacity * 0.3f, 
                Contained / Capacity * 0.3f, Contained / Capacity * 0.9f);
        } else if (ContainedType == ResourceType.Nothing) {
            Renderer.material.color = new Color(0.4f, 0.4f, 0.4f);
        }
    }
}
