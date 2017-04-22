using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedroomStartupProgram : ComputerProgram {
    private int Selection = 0;
    private bool PoemRead = false;

    public override bool UpdateProgram(Computer host) {
        if (host.BtnUp.ButtonDown && (!PoemRead && Selection > 0 || PoemRead && Selection > 1)) {
            Selection--;
        }
        if (host.BtnDown.ButtonDown && Selection < 2) {
            Selection++;
        }
        if (!PoemRead) {
            if (Selection == 0) {
                host.Print("> ");
            }
            host.Println("Poem of the Day");
        }
        if (Selection == 1) {
            host.Print("> ");
        }
        host.Println("Open Door");
        if (Selection == 2) {
            host.Print("> ");
        }
        host.Println("Help");
        return true;
    }
}
