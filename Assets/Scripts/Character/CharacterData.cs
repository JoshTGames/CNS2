using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


namespace JoshGames.Stats{
    public class CharacterData : MonoBehaviour{
        #region ASSIGNED STATS
        [SerializeField] CharacterStats profile;
        public CharacterStats Profile{ get{ return profile; } }

        [Header("Realtime stats -- You don't have to touch these")]
        public float health;
        public float speed;
        public float damage;
        public int threatLevel;
        public CharacterStats.Trait behaviour;
        public List<CharacterStats.Buff> buffs = new List<CharacterStats.Buff>();
        public List<CharacterStats.Debuff> debuffs = new List<CharacterStats.Debuff>();
        #endregion
        private void Start() {
            if(!profile){ return; }

            health = profile.health;
            speed = profile.speed;
            damage = profile.damage;
            threatLevel = profile.threatLevel;
            behaviour = profile.behaviour;
            buffs = profile.buffs.ToList();            
        }
    }
}