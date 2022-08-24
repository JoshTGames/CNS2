using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JoshGames.Stats;

namespace JoshGames.AI{
    public class AIModule : MonoBehaviour{

        static BTNode topNode;
        public static BTNode AI{ 
            get{ return (topNode != null)? topNode : CreateBehaviourTree(); } 
        }


        static BTNode CreateBehaviourTree(){
            #region NODES HERE
            #endregion

            // BEHAVIOURS --
            // --



            BTSelector parentNode = new BTSelector(new List<BTNode>{/* PUT NODES HERE */}); // LAST NODE SHOULD BE A FALLBACK NODE WHICH IS REPEATABLE AKA NEVER RETURN FAILURE

            topNode = (topNode != null)? topNode : parentNode; 
            return parentNode;
        }


        private void Awake() {
            topNode = CreateBehaviourTree();    
        }
    }
}