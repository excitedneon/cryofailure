using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NewtonVR;

public class RandomSoundMaker : MonoBehaviour {
    public AudioSource Source;
    public AudioClip[] Clips;

    private NVRButton Button;

    void Start() {
        Button = GetComponent<NVRButton>();
    }

    void Update() {
        if (Button != null && Button.ButtonDown) {
            PlaySound();
        }
    }

    public void PlaySound() {
        Source.PlayOneShot(Clips[Random.Range(0, Clips.Length)]);
    }
}
