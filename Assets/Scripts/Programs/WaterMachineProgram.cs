using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMachineProgram : ComputerProgram {
    public override bool UpdateProgram(Computer host) {
        host.Println("Water Dispenser");
        host.Println("");
        host.Println("Water left: 0 litres");
        return true;
    }
}
