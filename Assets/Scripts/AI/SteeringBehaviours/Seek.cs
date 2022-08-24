using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JoshGames.AI{
    public class Seek{
        static public Vector3 Run(Vector3 thisPosition, Vector3 targetPosition, float maxSpeed, Vector3 currentVelocity){
            Vector3 targetVel = (targetPosition - thisPosition).normalized;
            targetVel *= maxSpeed;
            targetVel -= currentVelocity;            
            return targetVel;
        }
    }
}