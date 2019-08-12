using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private static float VerticalMovement => Input.GetAxis("Vertical");
    private static float HorizontalMovement => Input.GetAxis("Horizontal");

    [SerializeField] private PlayerModel playerModel;

    private void FixedUpdate()
    {
        var direction = new Vector3(HorizontalMovement, 0, VerticalMovement);

        playerModel.Rigidbody.AddForce(direction * PlayerModel.Speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        var otherGameObject = other.gameObject;
        if (!otherGameObject.CompareTag("Collectible")) return;

        playerModel.CollectibleCount++;
        otherGameObject.SetActive(false);
    }
}