using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform character;
    public Vector3 offset;
    [Range(1,10)]
    public float smoothfactor;

    private void FixedUpdate()
    {
        Follow();
    }

    void Follow()
    {
        Vector3 targetposition = character.position + offset;
        Vector3 smoothposition = Vector3.Lerp(transform.position, targetposition, smoothfactor*Time.fixedDeltaTime);
        transform.position = smoothposition;
    }
}
