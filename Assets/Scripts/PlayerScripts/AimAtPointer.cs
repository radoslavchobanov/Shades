﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAtPointer : MonoBehaviour
{
    private void Update() 
    {
        gameObject.transform.LookAt(GetPointerPosByGroundPlane());
    }

    private Vector3 GetPointerPosByGroundPlane() // returns the mouse pointer point on the ground
    {
        Vector3 hitPoint = new Vector3();

        // this creates a horizontal plane passing through this object's center
        var plane = new Plane(Vector3.up, transform.position);
        // create a ray from the mousePosition
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // plane.Raycast returns the distance from the ray start to the hit point
        float distance;
        if (plane.Raycast(ray, out distance))
        {
            // some point of the plane was hit - get its coordinates
            hitPoint = ray.GetPoint(distance);
            // use the hitPoint to aim your cannon
        }

        return hitPoint;
    }
}
