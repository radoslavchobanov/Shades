using System;

public static class Values
{
    #region Health
    public const float defaultHealthRegen = 5f; // health/per second
    public const float defaultMinHealth = 0f;
    public const float defaultMaxHealth = 100f;
    public const float defaultHealthRegenerateSpeed = 0.3f; // tick speed
    #endregion

    #region Stamina
    public const float defaultStaminaRegen = 15f; // stamina/per second when idle
    public const float defaultMinStamina = 0f;
    public const float defaultMaxStamina = 100f;
    public const float defaultStaminaRegenerateSpeed = 0.2f; // tick speed, increasing when idle
    public const float defaultStaminaDegenerateSpeed = 0.2f; // tick speed decreasing when running
    public const float defaultStaminaDegenerateValue = 2f; // how much stamina it will burn per tick
    #endregion

    #region Energy
    public const float defaultEnergyRegen = 25f; // energy/per second when not shooting
    public const float defaultMinEnergy = 0f;
    public const float defaultMaxEnergy = 100f;
    public const float defaultEnergyRegenerateSpeed = 0.1f; // tick speed, increasing when not shooting
    public const float defaultEnergyDegenerateValue = 15f; // how much energy it will burn per shoot/attack
    #endregion
}
