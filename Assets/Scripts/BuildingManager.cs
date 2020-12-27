using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;


public class BuildingManager : MonoBehaviour
{
    public static BuildingManager Instance { get; private set; }

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
                Instantiate(activebuildingType.prefab, GetMouseWorldPosition(), Quaternion.identity);
            }
        }
    }

    Vector3 GetMouseWorldPosition()
    {
        //Debug.Log(Input.mousePosition); // displays location of mouse - Left Bottom will be 0 0

        // to make centre as 0,0 change it to world space camera
        //Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        //this will show z as -10 

        // set z to 0
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0f;

        return mouseWorldPosition;
    }

    public void SetActiveBuildingType(BuildingTypeSO buildingType)
    {
        activebuildingType = buildingType;
    }

    public BuildingTypeSO GetActiveBuildingType()
    {
        return activebuildingType;
    }
}
