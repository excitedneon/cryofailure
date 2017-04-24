using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NewtonVR;
using System;

public class RandomSoundMaker : Activatable {
    public AudioSource Source;
    public AudioClip[] Clips;
    public float PitchRandomizationAmount = 0f;
    public float SoundCooldown = -1f;

    private NVRButton Button;
    private float LastTime = 0;

    void Start() {
        Button = GetComponent<NVRButton>();
    }

    void Update() {
        if ((Button != null && Button.ButtonDown) ||
            (SoundCooldown > 0 && Time.time - LastTime > SoundCooldown)) {
            PlaySound();
            LastTime = Time.time + SoundCooldown;
        }
    }

    public override void Activate() {
        PlaySound();
    }

    public void PlaySound() {
        Source.pitch = 1f + UnityEngine.Random.Range(-PitchRandomizationAmount, PitchRandomizationAmount);
        Source.PlayOneShot(Clips[UnityEngine.Random.Range(0, Clips.Length)]);
    }
}
