using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using NewtonVR;

public class GameStarter : Activatable {
    public Transform Player;

    public override void Activate() {
        Player.localPosition = new Vector3(-3, 0, 2);
    }
}
