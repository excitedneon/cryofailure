using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NewtonVR;

public class RandomSoundMaker : MonoBehaviour {
    public AudioSource Source;
    public AudioClip[] Clips;
    public float PitchRandomizationAmount = 0f;

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
        Source.pitch = 1f + Random.Range(-PitchRandomizationAmount, PitchRandomizationAmount);
        Source.PlayOneShot(Clips[Random.Range(0, Clips.Length)]);
    }
}
