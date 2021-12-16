// GAME2014-FinalProject
// ShrinkPlatformBehaviours.cs
// Description: This script include player controls, abilities, sounds and platform support
// Name: Hancong Zhang
// Student ID: 101234068
// Short rivision history:
//      - Added Shrink platform moving up and down
//      - Added platform activate function, when player enter, decrease localscale on x
//      - Added platform deactivate function, when player exit, increase localscale on x until equal to original size
//      - Added shrinking and resetting SFX
//      - Added checker to prevent playing multiple sound at once

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkPlatformBehaviours : MonoBehaviour
{


    [Header("Shrinking/Resetting")]
    public bool isActive;
    private float originalSizeX;
    private float activeSizeX;
    public float shrinkRate;
    public Vector3 groundLevel;

    [Header("Audio")]
    [SerializeField]
    private AudioSource shrinkingSFX;
    public bool playingShrink;
    [SerializeField]
    private AudioSource resettingSFX;
    public bool playingReset;

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
            PlayShrinkingSFX();
        }
        else
        {
            PlayerExit();
            if (activeSizeX < originalSizeX)
            {
                PlayResettingSFX();
            }
            else
            {
                resettingSFX.Stop();
            }
        }

        if (shrinkingSFX.isPlaying && !resettingSFX.isPlaying)
        {
            playingShrink = true;
        }
        else if (resettingSFX.isPlaying && !shrinkingSFX.isPlaying)
        {
            playingReset = true;
        }
    }

    // Platform moving up and down
    private void VerticleMovement()
    {
            transform.position = new Vector3(transform.position.x, groundLevel.y + Mathf.PingPong(Time.time * 0.5f, 1), 0.0f);
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

    private void PlayShrinkingSFX()
    {
        if (!shrinkingSFX.isPlaying && !resettingSFX.isPlaying)
        {
            shrinkingSFX.Play();
        }
        else if (resettingSFX.isPlaying)
        {
            resettingSFX.Stop();
            shrinkingSFX.Play();
        }
    }

    private void PlayResettingSFX()
    {
        if (!shrinkingSFX.isPlaying && !resettingSFX.isPlaying)
        {
            resettingSFX.Play();
        }
        else if (shrinkingSFX.isPlaying)
        {
            shrinkingSFX.Stop();
            resettingSFX.Play();
        }
       
    }
}
