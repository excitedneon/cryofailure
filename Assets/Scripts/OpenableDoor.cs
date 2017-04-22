using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenableDoor : Activatable {
    public Transform DoorRoot;
    public bool Open;

    void Update() {
        float TargetScale = 1;
        if (Open) {
            TargetScale = 0.01f;
        }
        if (DoorRoot.localScale.y - TargetScale != 0 && DoorRoot.localScale.y - TargetScale > 0.05f) {
            DoorRoot.localScale = new Vector3(1, Mathf.Lerp(DoorRoot.localScale.y, TargetScale, Time.deltaTime * 5f), 1);
        } else if (DoorRoot.localScale.y - TargetScale != 0) {
            DoorRoot.localScale = new Vector3(1, TargetScale, 1);
        }
    }

    public override void Activate() {
        Open = !Open;
    }
}
