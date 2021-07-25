using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct RoamingMovementVars
{
    public bool arrived;
    public bool finishedIdle;
    public float roamingMovementSpeed;
    public bool isIdle; // if the enemy will idle or not
    public float idleDuration; // the time the enemy will stay in idle state
    public float idleStartTime; // when the current idle started
    public Vector3 roamStartPoint;
    public Vector3 destinationPoint; // random generated point in some range where we want to move the enemy
    
    public Vector3 destionationDirection; // direction of the destinationPoint

    public bool ShouldIdleOrNot() // randomly returns a true or false
    {
        return Random.Range(0, 2) == 1;
    }
    public float GetIdleDuration()
    {
        return Random.Range(1f, 4f);
    }
}