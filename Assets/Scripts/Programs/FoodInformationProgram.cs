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
            host.Println("Welcome to the infirmary, here you can find");
            host.Println("supplies you might require to live.");
            host.Println("");
            host.Println("Feel free to ask questions!");
        } else if (Selected == 1) {
            host.Println("You can pick up one of the containers stored on");
            host.Println("the rack to the right. Those can be filled at");
            host.Println("the Nutritional Resource Dispensers behind you.");
            host.Println("");
            host.Println("Enjoy your meal!");
        } else if (Selected == 2) {
            host.Println("Medical supplies are in the locker to the left.");
            host.Println("");
            host.Println("Stay healthy!");
        } else if (Selected == 3) {
            host.Println("Current status:");
            host.Println("- Food left in storage: " + FoodMachine.ContainedAmountFormatted() + " liters.");
            host.Println("- Water left in storage: " + WaterMachine.ContainedAmountFormatted() + " liters.");
            int FoodDays = (int) (FoodMachine.Contained * 2);
            int WaterDays = (int) (WaterMachine.Contained * 0.75f);
            host.Println("- Estimated days until all is lost: " + (FoodDays < WaterDays ? WaterDays : FoodDays) + ".");
            host.Print("- Expected cause of death: ");
            if (FoodDays < WaterDays) {
                host.Println(" starvation.");
            } else {
                host.Println(" dehydration.");
            }
        }
        return true;
    }
}
