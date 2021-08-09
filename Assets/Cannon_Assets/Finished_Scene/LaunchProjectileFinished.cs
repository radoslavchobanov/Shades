using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchProjectileFinished : MonoBehaviour
{
    public GameObject projectile;
    public float launchVelocity = 700f;

    void Update()
    {
        if (Player.singleton.CurrentState == PlayerState.State.Attacking)
        {
            GameObject ball = Instantiate(projectile, transform.position, transform.rotation);

            ball.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * launchVelocity);
        }
    }
}
