using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ResourceGenerator : MonoBehaviour
{
    ResourceGeneratorData resourceGeneratorData;
    float timer;
    float timerMax;

    private void Awake()
    {
        resourceGeneratorData = GetComponent<BuildingTypeHolder>().buildingType.resourceGeneratorData;
        timerMax = resourceGeneratorData.timerMax;
    }
    private void Start()
    {
        Collider2D[] collider2DArray = Physics2D.OverlapCircleAll(transform.position, resourceGeneratorData.resourceDetectoinRadius);

        int nearbyResourceAmount = 0;
        foreach (Collider2D collider2D in collider2DArray)
        {
            ResourceNode resourceNode = collider2D.GetComponent<ResourceNode>();
            if (resourceNode != null)
            {
                //It's a resource Node
                if (resourceNode.resourceType == resourceGeneratorData.resourceType)
                {
                    //Same Type
                    nearbyResourceAmount++;
                }
            }

        }
        nearbyResourceAmount = Mathf.Clamp(nearbyResourceAmount, 0, resourceGeneratorData.maxResourceAmount);
        if (nearbyResourceAmount == 0)
        {
            // no resources are near by
            // Disable resource generator
            enabled = false;
        }
        else
        {
            timerMax = (resourceGeneratorData.timerMax / 2f) +
                resourceGeneratorData.timerMax *
                (1 - (float)nearbyResourceAmount / resourceGeneratorData.maxResourceAmount);
        }
        Debug.Log("nearbyResourceAmount: " + nearbyResourceAmount + "; TimerMax: " + timerMax);
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer += timerMax;

            ResourceManager.Instance.AddResource(resourceGeneratorData.resourceType, 1);
        }
    }
}
