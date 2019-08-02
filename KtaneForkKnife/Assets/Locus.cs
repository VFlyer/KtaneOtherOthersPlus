using UnityEngine;

sealed class Locus
    {
    public int index;
    public string visibleName;
    public bool condition;
    }
sealed class Ok
{
    public float[] rates;
    public float USD;
    public string date;
}
sealed class Weapon
{
    public string name;
    public string rarity;
    public Sprite sprite;
    public int attackDMG;
    public double reloadTime;
    public int[] spawnNumbers;
}
sealed class Opponent
{
    public string name;
    public Sprite sprite;
    public int attackDMG;
    public int health;
    public int[] spawnNumbers;
}
sealed class Emote
{
    public string ok;
    public Sprite sprite;
    public bool weaponCondition;
    public bool opponentCondition;
}
sealed class Okay
{
    public string publicName;
    public bool condition;
}