using UnityEngine;
using System;

[Serializable]
public class Energy : Attribute
{
    private float degenerateValue; // how much energy it will burn per shoot/attack

    private float regenerateSpeed;
    private float lastRegenerateTime = 0f;
    
    public Energy()
    {
        this.min = Values.defaultMinEnergy;
        this.max = Values.defaultMaxEnergy;
        this.regen = Values.defaultEnergyRegen;

        this.degenerateValue = Values.defaultEnergyDegenerateValue;

        this.regenerateSpeed = Values.defaultEnergyRegenerateSpeed;

        this.current = this.max;
    }
    public void UpdateDegenerate()
    {
        if (current - degenerateValue < min)
            current = min;
        else current -= degenerateValue;
    }
    private void Regenerate()
    {
        var valueToRegen = regen * regenerateSpeed;

        if (current + valueToRegen > max)
            current = max;
        else current += valueToRegen;

        lastRegenerateTime = Time.time;
    }
    private bool ShouldRegenerate()
    {
        if (current >= max)
            return false;
        return Time.time - lastRegenerateTime >= regenerateSpeed; // per second
    }
    public void UpdateRegenerate()
    {
        if (ShouldRegenerate())
        {
            Regenerate();
        }
    }
}
