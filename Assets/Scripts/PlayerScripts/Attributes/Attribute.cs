using System;
using UnityEngine;

public class Attribute
{
    public Attribute() {}
    public Attribute(float min, float max, float regen)
    {
        this.min = min;
        this.max = max;
        this.regen = regen;
    }

    [SerializeField] public float current;

    [SerializeField] protected float min;
    [SerializeField] protected float max;
    [SerializeField] protected float regen; // per second

    public void SetMaxValue(float val)
    {
        this.max = val;
    }
    public void IncreaseMaxValue(float val)
    {
        this.max += val;
    }
    public void DecreaseMaxValue(float val)
    {
        this.max -= val;
    }
    public float GetMinValue()
    {
        return this.min;
    }
    public float GetMaxValue()
    {
        return this.max;
    }
    public float GetCurrentRegen()
    {
        return this.regen;
    }
}
