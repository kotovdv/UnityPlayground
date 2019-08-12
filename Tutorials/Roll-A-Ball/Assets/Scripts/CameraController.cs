﻿using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject player = default;

    private Vector3 _offset;

    private void Start()
    {
        _offset = transform.position - player.transform.position;
    }

    private void LateUpdate()
    {
        transform.position = player.transform.position + _offset;
    }
}