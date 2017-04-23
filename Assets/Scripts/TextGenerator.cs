using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextGenerator : MonoBehaviour {
    private static TextGenerator Generator;
    private static Hashtable GeneratedTextures = new Hashtable();

    public Camera GenerationCamera;
    public TextMesh TextMesh;

    void Start() {
        Generator = this;
    }

    private Texture2D GenerateText(string text, int fontSize) {
        TextMesh.text = text;
        TextMesh.fontSize = fontSize;
        GenerationCamera.Render();

        Texture2D Result = new Texture2D(512, 512, TextureFormat.RGB24, false);
        RenderTexture Previous = RenderTexture.active;
        RenderTexture.active = GenerationCamera.activeTexture;
        Result.ReadPixels(new Rect(0, 0, 512, 512), 0, 0);
        Result.Apply();
        RenderTexture.active = Previous;
        return Result;
    }

    public static Texture2D GetTextTexture(string text, int fontSize = 28) {
        if (Generator == null) {
            return null;
        }
        if (!GeneratedTextures.ContainsKey(text)) {
            GeneratedTextures[text] = Generator.GenerateText(text, fontSize);
        }
        return (Texture2D)GeneratedTextures[text]; 
    }
}
