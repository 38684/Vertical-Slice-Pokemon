using System;

public class DataStructures
{
    [Serializable]
    public struct Stats
    {
        public int health;
        public int attack;
        public int defense;
        public int specialAttack;
        public int specialDefense;
        public int speed;
    }

    public struct IndividualValues
    {
        public int health;
        public int attack;
        public int defense;
        public int specialAttack;
        public int specialDefense;
        public int speed;
    }

    public struct EffortValues
    {
        public int health;
        public int attack;
        public int defense;
        public int specialAttack;
        public int specialDefense;
        public int speed;
    }

    [Serializable]
    public struct Moves
    {
        public int power;
        public int powerPoint;
        public int accuracy;
        public bool isSpecial; // if not special then is physical
        public bool healthDrain;
        public Types type;
    }

    public enum Types
    {
        Electric,
        Grass,
        Poison,
        Fairy
    }
}
