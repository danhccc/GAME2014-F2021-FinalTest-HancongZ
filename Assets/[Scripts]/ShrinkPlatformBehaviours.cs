// GAME2014-FinalProject
// ShrinkPlatformBehaviours.cs
// Description: This script include player controls, abilities, sounds and platform support
// Name: Hancong Zhang
// Student ID: 101234068
// Short rivision history:
//      - Added Shrink platform moving up and down
//      - Added platform activate function, when player enter, decrease localscale on x
//      - Added platform deactivate function, when player exit, increase localscale on x until equal to original size

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkPlatformBehaviours : MonoBehaviour
{

    public Vector3 groundLevel;

    public bool isActive;
    private float originalSizeX;
    private float activeSizeX;
    public float shrinkRate;

    // Start is called before the first frame update
    void Start()
    {
        groundLevel = transform.position;
        originalSizeX = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        VerticleMovement();

        activeSizeX = transform.localScale.x;

        if (isActive)
        {
            PlayerEnter();
        }
        else
        {
            PlayerExit();
        }
    }

    // Platform moving up and down
    private void VerticleMovement()
    {
            transform.position = new Vector3(transform.position.x, groundLevel.y + Mathf.PingPong(Time.time, 1), 0.0f);
    }

    private void PlayerEnter()
    {
        transform.localScale -= transform.localScale * shrinkRate;
    }
    private void PlayerExit()
    {
        if (activeSizeX < originalSizeX)
        {
            transform.localScale += transform.localScale * shrinkRate;
        }
    }
}
