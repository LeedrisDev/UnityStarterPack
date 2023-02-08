using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject character;
    public float timeOffset;
    public Vector3 positionOffset;
    
    private Vector3 speed;
    
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, 
            character.transform.position + positionOffset, ref speed, timeOffset);
    }
}
