using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacter", menuName = "Character/NewCharacter")]
public class CharacterBase : ScriptableObject
{
    //idealy there would be more stats to each character to scriptable objects become realy be useful
    public int maxHealth;
    public int attackDamage;    
}
