using System;
using UnityEngine;

[Serializable]
public class Stamina : Attribute
{
    private float degenerateSpeed; // stanima/second (stamina per second) decreasing when running
    private float degenerateValue; // how much stamina it will burn per tick
    private float lastDegenerateTime;

    private float regenerateSpeed;
    private float lastRegenerateTime;

    public Stamina()
    {
        this.min = Values.defaultMinStamina;
        this.max = Values.defaultMaxStamina;
        this.regen = Values.defaultStaminaRegen;

        this.degenerateSpeed = Values.defaultStaminaDegenerateSpeed;
        this.degenerateValue = Values.defaultStaminaDegenerateValue;

        this.regenerateSpeed = Values.defaultStaminaRegenerateSpeed;

        this.current = this.max;
    }
    private void Degenerate()
    {
        if (current - degenerateValue < min)
            current = min;
        else current -= degenerateValue;

        lastDegenerateTime = Time.time;
    }
    public void StartDegenerate()
    {
        lastDegenerateTime = Time.time;
    }
    private bool ShouldDegenerate()
    {
        return Time.time - lastDegenerateTime >= degenerateSpeed;
    }
    public void UpdateDegenerate()
    {
        if (ShouldDegenerate())
        {
            Degenerate();
        }
    }

    private void Regenerate()
    {
        var valueToRegen = regen * regenerateSpeed;

        if (current + valueToRegen > max)
            current = max;
        else current += valueToRegen;

        lastRegenerateTime = Time.time;
    }
    public void StartRegenerate()
    {
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
