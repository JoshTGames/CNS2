namespace JoshGames.AI{
    public abstract class BTNode{
        protected NodeState state;
        public NodeState State{ get { return state; } }
        public abstract NodeState Evaluate();
    }
    

    public enum NodeState{
        FAILURE,
        SUCCESS,
        RUNNING
    }
}