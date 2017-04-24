using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenableDoor : Activatable {
    public AudioClip DoorOpen;
    public AudioClip DoorLocked;
    public Transform DoorRoot;
    public bool Open;
    public bool Locked = false;

    private AudioSource Source;

    void Start() {
        Source = gameObject.AddComponent<AudioSource>();
        Source.playOnAwake = false;
        Source.spatialBlend = 1.0f;
        Source.minDistance = 0.1f;
        Source.maxDistance = 5f;
    }

    void Update() {
        float TargetScale = 1;
        if (Open) {
            TargetScale = 0.01f;
        }
        if (DoorRoot.localScale.y - TargetScale != 0 && Mathf.Abs(DoorRoot.localScale.y - TargetScale) > 0.05f) {
            DoorRoot.localScale = new Vector3(1, Mathf.Lerp(DoorRoot.localScale.y, TargetScale, Time.deltaTime * 5f), 1);
        } else if (DoorRoot.localScale.y - TargetScale != 0) {
            DoorRoot.localScale = new Vector3(1, TargetScale, 1);
        }
    }

    public override void Activate() {
        if (!Locked) {
            Open = !Open;
            Source.PlayOneShot(DoorOpen);
        } else {
            Source.PlayOneShot(DoorLocked);
        }
    }
}
