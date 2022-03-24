using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Data/Base Data")]
public class PlayerData : ScriptableObject
{

    [Header("Movement")]
    public float movementSpeed = 10f;
    
    [Header("Attack Speed")]
    public float attackSpeed = 0.5f;
    
    
    

}
