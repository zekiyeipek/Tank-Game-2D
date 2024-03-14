using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShootBehaviour : AIBehaviour
{
    public float fieldOfVisionForShooting = 60;
    public bool targetInFOV = false;
    public override void PerformAction(TankController tank, AIDetector detector)
    {
        if(TargetInFOV(tank, detector))
        {
            tank.HandleMoveBody(Vector2.zero);
            tank.HandleShoot();
        }  
        tank.HandleTurretMovement(detector.Target.position);
    }

    private bool TargetInFOV(TankController tank, AIDetector detector)
    {
        targetInFOV = false ;
        var direction = detector.Target.position - tank.aimTurret.transform.position;
        if(Vector2.Angle(tank.aimTurret.transform.right, direction) < fieldOfVisionForShooting / 2)
        {
            targetInFOV = true;
            return true;
        }
        return false;
    }
}
