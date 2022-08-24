using JoshGames.Stats;
namespace JoshGames.AI{
    public class LowStat : BTNode{        
        float stat, threshold;
        
        public LowStat(float value, float _threshold){
            this.stat = value;
            this.threshold = _threshold;
        }

        public override NodeState Evaluate(){ return (stat * 100 <= threshold) ? NodeState.SUCCESS : NodeState.FAILURE; }
    }
}