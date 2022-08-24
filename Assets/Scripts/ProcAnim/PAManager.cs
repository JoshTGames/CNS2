using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace JoshGames.ProceduralAnimation{
    [RequireComponent(typeof(PAVelocity))] public class PAManager : MonoBehaviour{
        PAVelocity paVel;
        float lastStep, stepDuration;
        float timeBTWStep = 1f, actualDstBTWStep = .5f;

        
        [SerializeField] Leg[] legs;
        [Tooltip("Every x leg will step")][SerializeField] int legOffset;       
        int curLegOffset;

        void FindStepPos(Leg leg){
            leg.desiredPos = transform.TransformPoint(leg.sleepPos);            
            leg.targetPos =  leg.desiredPos;            
            lastStep = Time.time;
        }
        void StepCalc(Vector3 vel){
            timeBTWStep = actualDstBTWStep / vel.magnitude;            

            if(Time.time > lastStep + (timeBTWStep / legOffset)){     
                stepDuration = Mathf.Min(.5f, timeBTWStep);           
                
                #region PLANTING FEET
                for(int i = curLegOffset; i < legs.Length; i+= legOffset){                   
                    legs[i].isPlanted = true;
                }
                curLegOffset = (curLegOffset + 1) % legOffset;
                #endregion
                
                for(int i = curLegOffset; i < legs.Length; i+= legOffset){
                    FindStepPos(legs[i]);   
                    legs[i].isPlanted = false;
                }
            }
        }

        private void Start() {
            paVel = GetComponent<PAVelocity>();
            float distFromBody = 0;
            foreach(Leg leg in legs){ 
                leg.sleepPos = transform.position - leg.legObj.position; 
                leg.targetPos = transform.TransformPoint(leg.sleepPos);
                distFromBody += leg.sleepPos.magnitude;
            }
            distFromBody /= legs.Length * 2;
            actualDstBTWStep = distFromBody;
        }


        private void Update() {
            foreach(Leg leg in legs){ leg.Step(lastStep, stepDuration); } // VISUALS
        }
        private void FixedUpdate() {
            StepCalc(paVel.Velocity);
        }
        [Serializable] private class Leg{
            public string name;
            public Transform legObj;

            #region HIDDEN
            [HideInInspector] public Vector3 sleepPos, offsetPos, desiredPos, targetPos;
            [HideInInspector] public Quaternion targetRot;
            [HideInInspector] public bool isPlanted;
            #endregion
        
            public void Step(float lastStep, float stepDuration){
                float stepComp = Mathf.Clamp01((Time.time - lastStep) / stepDuration);                
                legObj.position = Vector3.Lerp(legObj.position, targetPos, stepComp);
            }
        }
    }
}