// GAME2014-FinalProject
// ShrinkPlatformBehaviours.cs
// Description: This script include player controls, abilities, sounds and platform support
// Name: Hancong Zhang
// Student ID: 101234068
// Short rivision history:
//      - Added Shrink platform moving up and down

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkPlatformBehaviours : MonoBehaviour
{

    public Vector3 groundLevel;

    // Start is called before the first frame update
    void Start()
    {
        groundLevel = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        VerticleMovement();
    }

    // Platform moving up and down
    private void VerticleMovement()
    {
            transform.position = new Vector3(transform.position.x, groundLevel.y + Mathf.PingPong(Time.time, 1), 0.0f);
    }
}
