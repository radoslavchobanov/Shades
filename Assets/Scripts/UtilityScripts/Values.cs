using System;

public static class Values
{
    #region Stamina
    public const float defaultStaminaRegen = 15f; // stamina/per second when idle
    public const float defaultMinStamina = 0f;
    public const float defaultMaxStamina = 100f;
    public const float defaultStaminaRegenerateSpeed = 0.2f; // tick speed increasing when idle
    public const float defaultStaminaDegenerateSpeed = 0.2f; // tick speed decreasing when running
    public const float defaultStaminaDegenerateValue = 2f; // how much stamina it will burn per tick
    #endregion
}
