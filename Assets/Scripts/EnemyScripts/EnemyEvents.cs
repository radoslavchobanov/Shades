using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EnemyEvents
{
    public static UnityEvent PlayerEntersVisionRange = new UnityEvent();
    public static UnityEvent PlayerLeavesVisionRange = new UnityEvent();

    public static UnityEvent PlayerEntersAttackRange = new UnityEvent();
    public static UnityEvent PlayerLeavesAttackRange = new UnityEvent();

}
