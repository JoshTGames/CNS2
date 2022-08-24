using System.Collections.Generic;

namespace JoshGames.AI{
    public class BTSelector : BTNode{
        protected List<BTNode> nodes = new List<BTNode>();

        public BTSelector(List<BTNode> _nodes){ this.nodes = _nodes; }
        public override NodeState Evaluate(){            
            foreach(BTNode node in nodes){
                switch(node.Evaluate()){
                    case NodeState.RUNNING:                        
                        return NodeState.RUNNING;
                    case NodeState.SUCCESS:
                        return NodeState.SUCCESS;
                    case NodeState.FAILURE:
                        break;                       
                }
            }
            return NodeState.FAILURE;
        }
    }
}