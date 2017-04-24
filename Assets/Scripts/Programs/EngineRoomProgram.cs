using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineRoomProgram : ComputerProgram {
    private int Progress = 0;
    private int Index = 0;
    private string[] FirstPhrases = new string[] {
        "This room is actually the\n" +
        "engine room, you can control most\n" +
        "internal parts of the ship\n" +
        "from here.",

        "Do you even know what those\n" +
        "buttons do?"
    };
    private string[] RandomPhrases = new string[] {
//      "###################################"
        "...",

        "I think that might have shortened\n" + 
        "this ship's lifespan by a few\n" +
        "centuries. Not that that matters.",

        "Please, think of the machinery!",
        "Please don't.",

        "There goes a sanitation module.",

        "Reminder: the Funroom is next\n" +
        "door.",

        "Please refrain from pressing\n" +
        "random buttons. You don't even\n" +
        "have a manual."
    };

    private void Print(Computer host, string text) {
        string[] Lines = text.Split('\n');
        foreach (string Line in Lines) {
            host.Println(Line);
        }
    }

    public override bool UpdateProgram(Computer host) {
        if (Progress < FirstPhrases.Length) {
            Print(host, FirstPhrases[Progress]);
        } else {
            Print(host, RandomPhrases[Index]);
        }
        return true;
    }

    public void Next() {
        if (Progress <= FirstPhrases.Length) {
            Progress++;
        }
        if (Progress >= FirstPhrases.Length) {
            Index = Random.Range(0, RandomPhrases.Length);
        }
    }
}
