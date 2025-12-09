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
        public string name;
        public int powerPoint;
        public int power;
        public int accuracy;
        public moveCategory category;
        public Types type;
    }

    public enum moveCategory
    {
        Physical,
        Special,
        Status
    }

    public enum Types
    {
        Electric,
        Grass,
        Poison,
        Fairy
    }
}
