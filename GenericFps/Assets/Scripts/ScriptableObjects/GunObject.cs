using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[CreateAssetMenu(fileName = "Gun", menuName = "GenericFPS/Gun")]
public class GunObject : ScriptableObject
{
    public float damage;
    public float range;
    public float fireRate;
    public float force;
}
