/*
 * Cristopher Argueta
 * Final, Night-Knight
 * Torchlight.cs
 * adjusts light intensity based on player movement
 * */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torchlight : MonoBehaviour
{
    public float intensity = 1f;
    public float range = 5f;

    private Light torchLight;

    void Start()
    {
        torchLight = GetComponent<Light>();
        torchLight.intensity = intensity;
        torchLight.range = range;
    }

    void Update()
    {
        // Set torch position to player position
        transform.position = new Vector3(PlayerMovement.instance.transform.position.x, PlayerMovement.instance.transform.position.y, transform.position.z);

        // Update torch rotation to follow player rotation
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, PlayerMovement.instance.transform.eulerAngles.z));

        // Update torchlight intensity based on player movement speed
        float movementSpeed = PlayerMovement.instance.GetMovementSpeed();
        torchLight.intensity = intensity + movementSpeed;

        // Update torchlight range based on player movement speed
        torchLight.range = range + movementSpeed;
    }
}

