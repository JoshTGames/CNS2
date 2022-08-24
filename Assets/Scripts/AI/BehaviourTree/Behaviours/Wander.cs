using UnityEngine;
namespace JoshGames.AI{
    public class Wander : BTNode{        
        Rigidbody2D rB;        
        Vector3 targetPos;
        float radius;

        public Wander(Rigidbody2D _rB, Vector3 _targetPos, float _radius){
            this.rB = _rB;
            this.targetPos = _targetPos;            
            this.radius = _radius;
        }

        public override NodeState Evaluate(){ 
            return NodeState.FAILURE;//(stat * 100 <= threshold) ? NodeState.SUCCESS : NodeState.FAILURE; 
        }
    }
}