using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "Enemy",menuName = "New", order = 0)]
public class Enemy : ScriptableObject
{
    public string enemyName;
    public int life;
    public float speed;
    public Color enemyColor;
    public TrashType enemyType;
}
