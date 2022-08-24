using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JoshGames.Stats;

namespace JoshGames.AI{
    public class AIModule : MonoBehaviour{
        [SerializeField] CharacterData stats;
        [SerializeField] PAVelocity paVel;
        Camera cam;        
        [SerializeField][Range(0, 100)] int lowHealthPercentage, lowFoodPercentage, lowWaterPercentage;        

        [SerializeField] Transform tempTarget;
        Vector3 moveSpeedVelRef; 
        float rotateSpeedVelRef;
        [SerializeField] float smoothingSpeed, smoothingRotateSpeed;

        #region  TEMPORARY
        [SerializeField] Transform[] tempTargets;
        Vector3 tempTargetPos;
        [SerializeField] float maxWanderDistance;
        bool getPos = true;
        #endregion

        BTNode topNode;

        BTNode CreateBehaviourTree(){
            if(!stats.Profile){ return null; }
            #region NODES HERE
            LowStat lowHp = new LowStat((stats.health / stats.Profile.health), lowHealthPercentage); // MOST LIKELY TRIGGER A FLEE
            LowStat lowFood = new LowStat((stats.food / stats.Profile.food), lowFoodPercentage); // WILL SEEK FOOD
            LowStat lowWater = new LowStat((stats.water / stats.Profile.water), lowWaterPercentage); // WILL SEEK WATER
            #endregion


            // BEHAVIOURS --
            // --



            BTSelector parentNode = new BTSelector(new List<BTNode>{/* PUT NODES HERE */}); // LAST NODE SHOULD BE A FALLBACK NODE WHICH IS REPEATABLE AKA NEVER RETURN FAILURE

            topNode = (topNode != null)? topNode : parentNode; 
            return parentNode;
        }


        private void Awake() {
            if(topNode == null){ topNode = CreateBehaviourTree(); } // Should mean that only one tree is generated
            cam = Camera.main;
        }

        private void Update() {
            if((tempTargetPos - transform.position).magnitude <= .5f && !getPos){ getPos = true; }
            if(getPos){
                getPos = false;
                
                Vector3 rndDir = new Vector3(
                    (float)Random.Range(-10,10)/10,
                    (float)Random.Range(-10,10)/10
                );
                
                tempTargetPos = transform.position + (rndDir * Random.Range(maxWanderDistance/2, maxWanderDistance));
                tempTargetPos = new Vector3(
                    Mathf.Clamp(tempTargetPos.x, tempTargets[0].position.x, tempTargets[1].position.x),
                    Mathf.Clamp(tempTargetPos.y, tempTargets[1].position.y, tempTargets[0].position.y)
                );                
            }
            

            Vector3 force = Seek.Run(transform.position, tempTargetPos, stats.speed, paVel.Velocity);
            //rB.velocity = force;
            Vector3 newPos = Vector3.SmoothDamp(transform.position, transform.position + force, ref moveSpeedVelRef, smoothingSpeed);
            transform.position = new Vector3(newPos.x, newPos.y);
            #region ROTATE TO VELOCITY
            Vector3 dir = transform.position - tempTargetPos;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            angle = Mathf.SmoothDampAngle(transform.rotation.eulerAngles.z, angle, ref rotateSpeedVelRef, smoothingRotateSpeed);  
            
            Quaternion newRot = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = newRot;
            #endregion
            
            if(topNode == null){ return; }
            switch(topNode.Evaluate()){
                case NodeState.SUCCESS:
                    break;
                case NodeState.RUNNING:
                    break;
                case NodeState.FAILURE:
                    break;
            }
        }
    
    
        private void OnDrawGizmosSelected() {     
            if(!Application.isPlaying){
                Gizmos.color = Color.red;
                Gizmos.DrawLine(transform.position, transform.position + (-transform.right * maxWanderDistance));
            } 
            else{
                Gizmos.color = Color.black;
                Gizmos.DrawLine(transform.position, tempTargetPos);
                Gizmos.DrawWireSphere(tempTargetPos, 1f);
            }    
        }
    }
}