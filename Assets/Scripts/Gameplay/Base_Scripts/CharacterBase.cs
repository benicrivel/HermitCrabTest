using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacter", menuName = "Character/NewCharacter")]
public class CharacterBase : ScriptableObject
{
    //idealy there would be more stats to each character to scriptable objects become realy be useful
    //also the class uses protected variables in case different base classes are needed in the future
    [SerializeField]
    protected int maxHealth;
    [SerializeField]
    protected int attackDamage;    

    public int GetMaxHealth()
    {
        return maxHealth;
    }

    public int GetAttackDamage()
    {
        return attackDamage;
    }
}
