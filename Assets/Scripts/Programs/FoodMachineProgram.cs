using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodMachineProgram : ComputerProgram {
    public Attacher Attacher;
    public float FillSpeed = 1f;
    public float Amount = 10f;

    public override bool UpdateProgram(Computer host) {
        // Fill attached stuff if possible
        FoodContainer FoodContainer;
        if (Attacher.AttachedGameObject != null && (FoodContainer = Attacher.AttachedGameObject.GetComponent<FoodContainer>()) != null) {
            if (FoodContainer.Capacity - FoodContainer.Contained > 0) {
                float FillAmt = Time.deltaTime * FillSpeed;
                if (FoodContainer.Contained + FillAmt > FoodContainer.Capacity) {
                    FillAmt = FoodContainer.Capacity - FoodContainer.Contained;
                }
                FoodContainer.Contained += FillAmt;
                Amount -= FillAmt;
            }
        }

        host.Println("Food Dispenser");
        host.Println("");
        host.Println("Food left: " + Mathf.Round(Amount * 10f) / 10f + " litres");
        return true;
    }
}
