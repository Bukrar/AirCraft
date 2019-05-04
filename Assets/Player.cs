using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("In ms^-1")] [SerializeField] float Speed = 4f;
    [Tooltip("In xRange")] [SerializeField] float xRange = 5f;
    [Tooltip("In yRange")] [SerializeField] float yRange = 2f;

    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float contrlPitchFactor = -20f;

    [SerializeField] float positionRawFactor = 5f;
    [SerializeField] float contrlRollFactor = -20f;
    
    //[SerializeField] float positionRollFactor = -5f;
    //[SerializeField] float contrlRollFactor = -5f;

    float xThrow, yThrow;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotation();
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("OnCollisionEnter");
    }

    private void OnTriggerEnter(Collider other)
    {
        print("OnTriggerEnter");
    }

    private void Rotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * contrlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;

        float yaw = transform.localPosition.x * positionRawFactor;

        float roll = xThrow * contrlRollFactor;
        //float yaw =0f;

        //float RollDueToPosition = transform.localPosition.x * positionRollFactor;
        //float RollDueToControlThrow = xThrow * contrlRollFactor;
        //float roll = RollDueToPosition + RollDueToControlThrow;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void Move()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * Speed * Time.deltaTime;
        float rawNewXpos = transform.localPosition.x + xOffset;
        float clampedXpos = Mathf.Clamp(rawNewXpos, -xRange, xRange);

        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * Speed * Time.deltaTime;
        float rawNewYpos = transform.localPosition.y + yOffset;
        float clamepdYpos = Mathf.Clamp(rawNewYpos, -yRange, yRange);
        transform.localPosition = new Vector3(clampedXpos,
            clamepdYpos, transform.localPosition.z);
    }
}
