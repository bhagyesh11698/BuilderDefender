using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using System;

public class BuildingManager : MonoBehaviour
{
    public static BuildingManager Instance { get; private set; }

    public event EventHandler<OnActiveBuildingTypeChangedEventArgs> OnActiveBuildingTypeChanged;

    public class OnActiveBuildingTypeChangedEventArgs: EventArgs
    {
        public BuildingTypeSO activebuildingType;

    }

    Camera mainCamera;
    BuildingTypeListSO buildingTypeList;
    BuildingTypeSO activebuildingType;


    private void Awake()
    {
        Instance = this;
        // Debug.Log(Resources.Load<BuildingTypeListSO>("BuildingTypeList")); //string can cause errors

        //Another way
        buildingTypeList = Resources.Load<BuildingTypeListSO>(typeof(BuildingTypeListSO).Name); // keep name same as script
    }

    private void Start()
    {
        mainCamera = Camera.main; // cached camera

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) // 0 for left mouse button
        {
            if (activebuildingType != null)
            {
                Instantiate(activebuildingType.prefab, UtilsClass.GetMouseWorldPosition(), Quaternion.identity);
            }
        }
    }

    public void SetActiveBuildingType(BuildingTypeSO buildingType)
    {
        activebuildingType = buildingType;
        OnActiveBuildingTypeChanged?.Invoke(this, 
            new OnActiveBuildingTypeChangedEventArgs {activebuildingType = activebuildingType });
    }

    public BuildingTypeSO GetActiveBuildingType()
    {
        return activebuildingType;
    }
}
