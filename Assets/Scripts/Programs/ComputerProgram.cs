using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ComputerProgram : MonoBehaviour {
    public abstract bool UpdateProgram(Computer host);
}
