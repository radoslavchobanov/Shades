using System;

[Serializable]
public class Stamina : Attribute
{
    private const float defaultMinStamina = 0;
    private const float defaultMaxStamina = 10;
    private const float defaultStaminaRegen = 5;

    public Stamina()
    {
        this.min = defaultMinStamina;
        this.max = defaultMaxStamina;
        this.regen = defaultStaminaRegen;

        this.current = this.max;
    }
}
