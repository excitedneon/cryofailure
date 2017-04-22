using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NewtonVR;

public class Computer : MonoBehaviour {
    public TextFace TextFace;
    public ComputerProgram StartupProgram;
    public NVRButton BtnUp;
    public NVRButton BtnDown;
    public NVRButton BtnLeft;
    public NVRButton BtnRight;
    public NVRButton BtnOk;
    public NVRButton BtnCancel;

    private Stack<ComputerProgram> ProgramStack = new Stack<ComputerProgram>();
    private Queue<string> Buffer = new Queue<string>();
    private string CurrentUnFlushedLine = "";

    void Start() {
        ProgramStack.Push(StartupProgram);
    }

    void Update() {
        Println("<b>SpaceOS 3000</b>");
        Println("");
        if (!ProgramStack.Peek().UpdateProgram(this)) {
            ProgramStack.Pop();
        }
        TextFace.Text = Render();
    }

    public void StartProgram(ComputerProgram program) {
        ProgramStack.Push(program);
    }

    public void Print(string text) {
        CurrentUnFlushedLine += text;
    }

    public void Println(string text = "") {
        Buffer.Enqueue(CurrentUnFlushedLine + text);
        CurrentUnFlushedLine = "";
    }

    private string Render() {
        string result = "";
        while (Buffer.Count > 0) {
            result += Buffer.Dequeue() + "\n";
        }
        return result;
    }
}
