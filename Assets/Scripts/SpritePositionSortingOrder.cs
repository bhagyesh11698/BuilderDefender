using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class SpritePositionSortingOrder : MonoBehaviour
{
    [SerializeField] bool runOnce;
    [SerializeField] float positionOffsetY;

    SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void LateUpdate()
    {
        float precisionMultiplier = 5f;
        spriteRenderer.sortingOrder = (int)(-(transform.position.y + positionOffsetY) * precisionMultiplier);
        if (runOnce)
        {
            Destroy(this);
        }
    }
}
