using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodMachineProgram : ComputerProgram {
    public Attacher Attacher;
    public float FillSpeed = 1f;
    public float Contained = 10f;
    public ResourceType ContainedType;

    public override bool UpdateProgram(Computer host) {
        // Fill attached stuff if possible
        FoodContainer FoodContainer;
        if (Attacher.AttachedGameObject != null && 
            (FoodContainer = Attacher.AttachedGameObject.GetComponent<FoodContainer>()) != null &&
            (FoodContainer.ContainedType == ResourceType.Nothing || FoodContainer.ContainedType == ContainedType) &&
            FoodContainer.Capacity - FoodContainer.Contained > 0 &&
            Contained > 0) {
            float FillAmt = Time.deltaTime * FillSpeed;
            if (FillAmt > Contained) {
                FillAmt = Contained;
            }
            if (FillAmt > 0) {
                FoodContainer.ContainedType = ContainedType;
            }
            if (FoodContainer.Contained + FillAmt > FoodContainer.Capacity) {
                FillAmt = FoodContainer.Capacity - FoodContainer.Contained;
            }
            FoodContainer.Contained += FillAmt;
            Contained -= FillAmt;
        }


        if (ContainedType == ResourceType.Food) host.Print("Food");
        if (ContainedType == ResourceType.Water) host.Print("Water");
        host.Println(" Dispenser");
        host.Println("");
        if (ContainedType == ResourceType.Food) host.Print("Food");
        if (ContainedType == ResourceType.Water) host.Print("Water");
        host.Println(" left: " + ContainedAmountFormatted() + " liters");
        return true;
    }

    public string ContainedAmountFormatted() {
        return "" + Mathf.Round(Contained * 10f) / 10f;
    }
}
