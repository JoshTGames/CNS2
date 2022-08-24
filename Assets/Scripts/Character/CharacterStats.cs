using UnityEngine;
using System;

namespace JoshGames.Stats{
    [CreateAssetMenu(fileName = "CharacterProfile", menuName = "ScriptableObjects/Character/Create CharacterProfile")]
    public class CharacterStats : ScriptableObject{
        [Header("Character BASE Stats")]
        public float health;
        public float speed;
        public float damage;
        
        [Header("Extras")]
        [Tooltip("This will dictate what type of threat a character is to other characters. If high enough, this will scare other characters")] public int threatLevel;
        public Trait behaviour;
        public Buff[] buffs;

        [Serializable] public enum Trait{
                                                                                                                                NONE,
            [Tooltip("ALWAYS FLEE FROM TARGETS -- OF EQUAL OR HIGHER THREAT LEVEL")]                                             PASSIVE_FLEE, 
            [Tooltip("ONLY FLEE WHEN HARMED")]                                                                                   PASSIVE, 
            [Tooltip("FLEE FROM TARGETS OF HIGHER THREAT LEVEL / ATTACK TARGET OF EQUAL OR LESS THREAT LEVEL || - WHEN HARMED")] NEUTRAL,
            [Tooltip("ALWAYS ATTACK TARGETS OF LOWER OR EQUAL THREAT LEVEL")]                                                    HOSTILE,        
        }
        [Serializable] public enum Buff{
            NONE,
            INF_AMMO,
            DBL_DMG,
            FIRE_PROOF,
            STUN_PROOF,
            PHYSICAL_RESISTANCE,
            RANGE_RESISTANCE
        }  

        [Serializable] public enum Debuff{
            NONE,            
        }    
    }
}