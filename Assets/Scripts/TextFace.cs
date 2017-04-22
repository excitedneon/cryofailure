using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextFace : MonoBehaviour {
    public MeshRenderer Renderer;
    public string Text {
        get {
            return text;
        }
        set {
            if (text != value) {
                text = value;
                Texture2D NewTexture = TextGenerator.GetTextTexture(text);
                if (NewTexture != null) {
                    Renderer.material.SetTexture("_MainTex", NewTexture);
                }
            }
        }
    }

    private string text = "";
}
