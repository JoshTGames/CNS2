using System.Collections.Generic;

namespace JoshGames.AI{
    public class BTInverter : BTNode{
        protected BTNode node;

        public BTInverter(BTNode _node){ this.node = _node; }
        public override NodeState Evaluate(){     
            switch(node.Evaluate()){
                case NodeState.RUNNING:                        
                    return NodeState.RUNNING;
                case NodeState.SUCCESS:
                    return NodeState.FAILURE;
                case NodeState.FAILURE:
                    return NodeState.SUCCESS;                       
            }       
            
            return NodeState.FAILURE;
        }
    }
}