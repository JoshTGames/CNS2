using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JoshGames.ProceduralAnimation{
    public class PAPSToBody : MonoBehaviour{
        ParticleSystem ps;
        [SerializeField] Transform body;
        private void Start() { ps = GetComponent<ParticleSystem>(); }
        void Update(){
            ParticleSystem.ShapeModule shape = ps.shape;
            shape.scale = new Vector3(shape.scale.x,(body.position- transform.position ).magnitude,shape.scale.z);
            shape.position = (body.position - transform.position)/2;
            Quaternion rot = Quaternion.FromToRotation(transform.up, (body.position - transform.position));       
            shape.rotation = rot.eulerAngles;
        }
    }
}