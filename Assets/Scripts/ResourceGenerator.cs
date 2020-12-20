using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ResourceGenerator : MonoBehaviour
{
    BuildingTypeSO buildingType;
    float timer;
    float timerMax;

    private void Awake()
    {
        buildingType = GetComponent<BuildingTypeHolder>().buildingType;
        timerMax = buildingType.resourceGeneratorData.timerMax;
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer += timerMax;
            Debug.Log(buildingType.resourceGeneratorData.resourceType.nameString);

            ResourceManager.Instance.AddResource(buildingType.resourceGeneratorData.resourceType, 1);
        }
    }
}
