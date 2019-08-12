using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpRotator : MonoBehaviour
{
    private const float RotationSpeed = 135F;

    private void Update()
    {
        transform.rotation *= Quaternion.AngleAxis(RotationSpeed * Time.deltaTime, new Vector3(0, 1));
    }
}