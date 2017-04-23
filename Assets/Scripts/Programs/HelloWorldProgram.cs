using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorldProgram : ComputerProgram {
    public override bool UpdateProgram(Computer host) {
        host.Println("Hello, world!");
        return true;
    }
}
