using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NewtonVR;

public class Computer : MonoBehaviour {
    public AudioClip Boop;
    public TextFace TextFace;
    public ComputerProgram StartupProgram;
    public NVRButton BtnUp;
    public NVRButton BtnDown;
    public NVRButton BtnLeft;
    public NVRButton BtnRight;
    public NVRButton BtnOk;
    public NVRButton BtnCancel;
    public int FontSize = 28;

    private RandomSoundMaker Beeper;
    private Stack<ComputerProgram> ProgramStack = new Stack<ComputerProgram>();
    private Queue<string> Buffer = new Queue<string>();
    private string CurrentUnFlushedLine = "";
    private string LastText = "";

    void Start() {
        ProgramStack.Push(StartupProgram);
        AudioSource Source = gameObject.AddComponent<AudioSource>();
        Source.playOnAwake = false;
        Source.spatialBlend = 1.0f;
        Source.minDistance = 0.1f;
        Source.maxDistance = 1.2f;
        Beeper = gameObject.AddComponent<RandomSoundMaker>();
        Beeper.Source = Source;
        Beeper.Clips = new AudioClip[]{ Boop };
        Beeper.PitchRandomizationAmount = 0.15f;
    }

    void Update() {
        Println("<b>SpaceOS 3000</b>");
        Println("");
        if (!ProgramStack.Peek().UpdateProgram(this)) {
            ProgramStack.Pop();
        }
        TextFace.FontSize = FontSize;
        string Text = Render();
        if (!Text.Equals(LastText)) {
            Beeper.PlaySound();
            LastText = Text;
        }
        TextFace.Text = Text;
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
