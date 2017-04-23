using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NewtonVR;

public class PlayerMovement : MonoBehaviour {
    public Transform Head;
    public NVRHand[] Hands;
    public Transform[] MovementIndicators;
    public float CooldownPeriod;
    public float TeleportRange;

    private NVRHand LastJumpHand = null;

    void Update() {
        if (LastJumpHand != null && !LastJumpHand.Inputs[NVRButtons.Touchpad].IsPressed) {
            LastJumpHand = null;
        }
        for (int i = 0; i < Hands.Length; i++) {
            if (Hands[i].CurrentHandState == HandState.Uninitialized) {
                continue;
            }

            Vector3 Forward = Hands[i].transform.forward;
            Ray HandRay = new Ray(Hands[i].transform.position, Forward.normalized);
            RaycastHit Hit;
            Physics.Raycast(HandRay, out Hit);
            if (Hands[i].Inputs[NVRButtons.Touchpad].IsTouched && Hit.collider != null && 
                    (Hit.point - Hands[i].transform.position).magnitude < TeleportRange &&
                    Hit.normal.y == 1) {
                UpdateMovementIndicator(i, Hit);
                if (LastJumpHand != Hands[i] && Hands[i].Inputs[NVRButtons.Touchpad].IsPressed) {
                    Move(Hit);
                    LastJumpHand = Hands[i];
                }
            } else {
                HideMovementIndicator(i);
            }
        }
	}

    private void UpdateMovementIndicator(int index, RaycastHit Hit) {
        MovementIndicators[index].gameObject.SetActive(true);
        MovementIndicators[index].position = Hit.point;
    }

    private void HideMovementIndicator(int index) {
        MovementIndicators[index].gameObject.SetActive(false);
    }

    private void Move(RaycastHit hit) {
        Vector3 NewPos = transform.position;
        NewPos += hit.point - Head.position;
        NewPos.y = transform.position.y;
        transform.position = NewPos;
    }
}
