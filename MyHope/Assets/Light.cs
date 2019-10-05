﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{
    private Vector3 mousePosition;
    public float moveSpeed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition = transform.parent.transform.InverseTransformPoint(mousePosition);
        mousePosition.x = Mathf.Clamp(mousePosition.x, -1f, 1f);
        mousePosition.y = Mathf.Clamp(mousePosition.y, -1, 1f);

        Vector3 relativePos = transform.position - transform.parent.position;

        // the second argument, upwards, defaults to Vector3.up
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        transform.GetChild(2).rotation = rotation;
        transform.localPosition = Vector2.Lerp(transform.localPosition, mousePosition, moveSpeed);
    }
}