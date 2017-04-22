using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextFace : MonoBehaviour {
    public MeshRenderer Renderer;
    public int MaterialIndex;
    public string Text {
        get {
            return text;
        }
        set {
            if (text != value) {
                text = value;
                Texture2D NewTexture = TextGenerator.GetTextTexture(text);
                if (NewTexture != null) {
                    Renderer.materials[MaterialIndex].SetTexture("_EmissionMap", NewTexture);
                }
            }
        }
    }

    private string text = "";
}
