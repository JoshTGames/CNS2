using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PAVelocity : MonoBehaviour{
    Vector3 prvPos, newPos;
    public Vector3 Velocity{ get{ return newPos; } }
    void Update(){
        newPos = (transform.position - prvPos) / Time.deltaTime;
        prvPos = transform.position;        
    }
}
