using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Pot : MealPlate
{
    protected override void Update()
    {
        base.Update();
        foreach (var ingredient in ingredients)
        {
            ingredient.Cooking();
        }
    }
}
