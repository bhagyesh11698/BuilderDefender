using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(menuName ="ScriptableObjects/BuildingType")]
public class BuildingTypeSO : ScriptableObject
{
    public string nameString;
    public Transform prefab;
    public ResourceGeneratorData resourceGeneratorData;
    
}
