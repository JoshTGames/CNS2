using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace JoshGames.ProceduralAnimation{
    public class PAChain : MonoBehaviour{
        [Serializable] class ChainSettings{
            public float targetDist;
            public float smoothSpeed;

            public List<Transform> nodes;
            [HideInInspector] public List<Vector3> nodeVel, actualNodeVel;
        }
        [SerializeField] ChainSettings chainSettings;
        void Awake(){              
            for(int i = 0; i < chainSettings.nodes.Count; i++){
                chainSettings.nodeVel.Add(Vector3.zero);
                chainSettings.actualNodeVel.Add(Vector3.zero);
            }
        }
        void Update(){
            for(int i = 1; i < chainSettings.nodes.Count; i++){
                Vector3 curVel = chainSettings.nodeVel[i];
                Vector3 targetPos = chainSettings.nodes[i - 1].position + (chainSettings.nodes[i].position - chainSettings.nodes[i - 1].position).normalized * chainSettings.targetDist;
                Vector3 newPos = Vector3.SmoothDamp(chainSettings.nodes[i].position, targetPos, ref curVel, chainSettings.smoothSpeed);

                Vector3 vel = (chainSettings.nodes[i].position - chainSettings.actualNodeVel[i]);
                chainSettings.actualNodeVel[i] = vel;

                chainSettings.nodes[i].rotation = Quaternion.FromToRotation(transform.right, (chainSettings.nodes[i].position - chainSettings.nodes[i - 1].position));
                
                chainSettings.nodes[i].position = newPos;
                chainSettings.nodeVel[i] = curVel;
            }
        }
    }
}