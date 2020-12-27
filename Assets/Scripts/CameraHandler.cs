using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;


public class CameraHandler : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;
    private float orthographicSize;
    private float targerOrthographicSize;

    private void Start()
    {
        orthographicSize = cinemachineVirtualCamera.m_Lens.OrthographicSize;
        targerOrthographicSize = orthographicSize;

    }

    private void Update()
    {
        HandleMovement();
        HandleZoom();

    }

    void HandleMovement()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        // normalized will make sure that it does not move too fast
        Vector2 moveDir = new Vector2(x, y).normalized;
        float moveSpeed = 5f;

        //-- Make Movement
        transform.position += (Vector3)moveDir * moveSpeed * Time.deltaTime;
        //either make it vector 3 or change moveDir to vector 3
    }

    void HandleZoom()
    {
        //-- Zoom in / out
        float zoomAmount = 2f;
        // - will invert mouse scrolling functionality
        targerOrthographicSize += -Input.mouseScrollDelta.y * zoomAmount;

        float minOrthographicSize = 10;
        float maxOrthographicSize = 30;
        targerOrthographicSize = Mathf.Clamp(targerOrthographicSize, minOrthographicSize, maxOrthographicSize);

        float zoomSpeed = 5f;
        orthographicSize = Mathf.Lerp(orthographicSize, targerOrthographicSize, Time.deltaTime);

        cinemachineVirtualCamera.m_Lens.OrthographicSize = orthographicSize;
    }


}
