using System.Collections.Generic;
namespace JoshGames.AI{
    public class BTSequence : BTNode{
        protected List<BTNode> nodes = new List<BTNode>();

        public BTSequence(List<BTNode> _nodes){ this.nodes = _nodes; }
        public override NodeState Evaluate(){
            bool isAnyRunning = false;
            foreach(BTNode node in nodes){
                switch(node.Evaluate()){
                    case NodeState.RUNNING:
                        isAnyRunning = true;
                        break;
                    case NodeState.SUCCESS:
                        break;
                    case NodeState.FAILURE:
                        return NodeState.FAILURE; // IF ANY NODES IN A SEQUENCE FAIL EVERYTHING IN THE SEQUENCE FAILS
                }
            }
            return (isAnyRunning)? NodeState.RUNNING : NodeState.SUCCESS; 
        }
    }
}