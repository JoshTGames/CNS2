using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


namespace JoshGames.Stats{
    public class CharacterData : MonoBehaviour{
        #region ASSIGNED STATS
        [SerializeField] CharacterStats profile;
        public CharacterStats Profile{ get{ return profile; } }
        [Tooltip("Every X seconds, variables that can drain, will drain!")] public float tickDuration;

        [Header("Realtime stats -- You don't have to touch these")]
        public float health;
        public float food = 100;
        public float water = 100;
        public float speed;
        public float damage;
        public int threatLevel;
        public CharacterStats.Trait behaviour;
        public CharacterStats.Diet diet;
        public List<CharacterStats.Buff> buffs = new List<CharacterStats.Buff>();
        public List<CharacterStats.Debuff> debuffs = new List<CharacterStats.Debuff>();
        #endregion

        float drainCooldown;

        private void Start() {
            if(!profile){ return; }

            health = profile.health;
            speed = profile.speed;
            damage = profile.damage;
            threatLevel = profile.threatLevel;
            behaviour = profile.behaviour;
            diet = profile.diet;
            buffs = profile.buffs.ToList();            
        }
    
        private void Update() {
            if(drainCooldown <= 0 && profile){
                drainCooldown = tickDuration;
                food -= profile.foodDrainPerTick;
                water -= profile.waterDrainPerTick;
            }
            drainCooldown -= (drainCooldown >0)? Time.deltaTime: 0;
        }
    }
}