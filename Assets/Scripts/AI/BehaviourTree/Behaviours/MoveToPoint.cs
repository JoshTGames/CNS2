using UnityEngine;
namespace JoshGames.AI{
    public class MoveToPoint : BTNode{        
        Vector3 targetPos;
        Rigidbody2D rB;        
        public MoveToPoint(Rigidbody2D _rB, Vector3 _targetPos){
            this.rB = _rB;
            this.targetPos = _targetPos;            
        }

        public override NodeState Evaluate(){ 
            return NodeState.FAILURE;//(stat * 100 <= threshold) ? NodeState.SUCCESS : NodeState.FAILURE; 
        }
    }
}