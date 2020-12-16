using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class BuildingManager : MonoBehaviour
{
    BuildingTypeSO buildingType;
    BuildingTypeListSO buildingTypeList;

    Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main; // cached camera

        // Debug.Log(Resources.Load<BuildingTypeListSO>("BuildingTypeList")); //string can cause errors

        //Another way
        buildingTypeList = Resources.Load<BuildingTypeListSO>(typeof(BuildingTypeListSO).Name); // keep name same as script
        buildingType = buildingTypeList.list[0];
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 0 for left mouse button
        {
            Instantiate(buildingType.prefab,GetMouseWorldPosition(),Quaternion.identity);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            buildingType = buildingTypeList.list[0];
        }       
        if (Input.GetKeyDown(KeyCode.Y))
        {
            buildingType = buildingTypeList.list[1];
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

}
