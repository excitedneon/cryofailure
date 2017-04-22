using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NewtonVR;

public class Computer : MonoBehaviour {
    public TextFace TextFace;
    public NVRButton BtnUp;
    public NVRButton BtnDown;
    public NVRButton BtnLeft;
    public NVRButton BtnRight;
    public NVRButton BtnOk;
    public NVRButton BtnCancel;

    private int State = 0;

    void Update() {
        if (BtnUp.ButtonWasPushed) {
            State++;
        }
        if (BtnDown.ButtonWasPushed) {
            State--;
        }
        TextFace.Text = Render();
    }

    private string Render() {
        string result = 
            "SpaceOS 3000\n" +
            "************\n" +
            "\n" +
            "[CAPT]: Hello, world!\n" +
            "[CAPT]: Current status: " + State;
        return result;
    }
}
