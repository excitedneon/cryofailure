using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedroomStartupProgram : ComputerProgram {
    public OpenableDoor BedroomDoor;

    private int Selection = 0;
    private int Selected = -1;
    private bool PoemRead = false;
    private float DoorOpenMoment;

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
                if (host.BtnOk.ButtonDown) {
                    Selected = 0;
                }
            }
            host.Println("MOTD");
        }
        if (Selection == 1) {
            host.Print("> ");
            if (host.BtnOk.ButtonDown) {
                Selected = 1;
                DoorOpenMoment = Time.time;
                BedroomDoor.Locked = !BedroomDoor.Locked;
            }
        }
        if (BedroomDoor.Locked) {
            host.Println("Unlock Door");
        } else {
            host.Println("Lock Door");
        }
        if (Selection == 2) {
            host.Print("> ");
            if (host.BtnOk.ButtonDown) {
                Selected = 2;
            }
        }
        host.Println("Help");
        host.Println("");
        if (Selected == 0) {
            host.Println("The rocket will free man from his");
            host.Println("remaining chains, the chains of");
            host.Println("gravity which still tie him to");
            host.Println("this planet. It will open to him");
            host.Println("the gates of heaven.");
            host.Println("");
            host.Println("               - Wemher von Braun");
        } else if (Selected == 1) {
            if (BedroomDoor.Locked) {
                host.Print("Locking door...");
            } else {
                host.Print("Unlocking door...");
            }
            if (Time.time - DoorOpenMoment > .35f) {
                host.Print(" Done!");
            }
            host.Println("");
        } else if (Selected == 2) {
            host.Println("Good morning, commander!");
            host.Println("");
            host.Println("I regret to inform you that the");
            host.Println("ship is 30 lightyears from your");
            host.Println("destination. This is unfortunate,");
            host.Println("as cryosleep was planned to end");
            host.Println("upon arrival. Re-entering");
            host.Println("cryosleep is not an option, as");
            host.Println("this vessel does not have the");
            host.Println("required equipment to do so.");
            host.Println("");
            host.Println("Welcome to RVS Progress.");
            host.Println("Enjoy your stay.");
        }
        return true;
    }
}
