using UnityEngine;
using System;

[Serializable]
public class Health : Attribute
{
    private float degenerateValue; // how much energy it will burn per shoot/attack

    private float regenerateSpeed;
    private float lastRegenerateTime = 0f;
    
    public Health()
    {
        this.min = Values.defaultMinHealth;
        this.max = Values.defaultMaxHealth;
        this.regen = Values.defaultHealthRegen;

        this.regenerateSpeed = Values.defaultHealthRegenerateSpeed;

        this.current = this.max;
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
