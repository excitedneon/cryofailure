using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineRoomComputerActivator : Activatable {
    public EngineRoomProgram Program;

    public override void Activate() {
        Program.Next();
    }
}
