using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodInformationProgram : ComputerProgram {
    public FoodMachineProgram FoodMachine;
    public FoodMachineProgram WaterMachine;

    private int Selection = 0;
    private int Selected = -1;

    public override bool UpdateProgram(Computer host) {
        if (host.BtnUp.ButtonDown && Selection > 0) {
            Selection--;
        }
        if (host.BtnDown.ButtonDown && Selection < 3) {
            Selection++;
        }
        if (Selection == 0) {
            host.Print("> ");
            if (host.BtnOk.ButtonDown) {
                Selected = 0;
            }
        }
        host.Println("Help");
        if (Selection == 1) {
            host.Print("> ");
            if (host.BtnOk.ButtonDown) {
                Selected = 1;
            }
        }
        host.Println("Help/Food");
        if (Selection == 2) {
            host.Print("> ");
            if (host.BtnOk.ButtonDown) {
                Selected = 2;
            }
        }
        host.Println("Help/Medical");
        if (Selection == 3) {
            host.Print("> ");
            if (host.BtnOk.ButtonDown) {
                Selected = 3;
            }
        }
        host.Println("Status");
        host.Println("");
        if (Selected == 0) {
            host.Println("Welcome to the infirmary, here");
            host.Println("you can find food and medical");
            host.Println("supplies.");
            host.Println("");
            host.Println("Feel free to ask questions!");
        } else if (Selected == 1) {
            host.Println("You can pick up one of the");
            host.Println("containers stored on the rack to");
            host.Println("the right. Those can be filled at ");
            host.Println("the Nutritional Resource");
            host.Println("Dispensers behind you.");
            host.Println("");
            host.Println("Enjoy your meal!");
        } else if (Selected == 2) {
            host.Println("Medical supplies are in the locker");
            host.Println("to the left.");
            host.Println("");
            host.Println("Stay healthy!");
        } else if (Selected == 3) {
            host.Println("Current status:");
            host.Println("- Food left in storage: " + FoodMachine.ContainedAmountFormatted() + " liters");
            host.Println("- Water left in storage: " + WaterMachine.ContainedAmountFormatted() + " liters");
            int FoodDays = (int) (FoodMachine.Contained * 2);
            int WaterDays = (int) (WaterMachine.Contained * 0.75f);
            host.Println("- Estimated days until the end: ");
            host.Println("    " + (FoodDays < WaterDays ? WaterDays : FoodDays));
            host.Println("- Expected cause of death:");
            if (FoodDays < WaterDays) {
                host.Println("    Starvation");
            } else {
                host.Println("    Dehydration");
            }
        }
        return true;
    }
}
