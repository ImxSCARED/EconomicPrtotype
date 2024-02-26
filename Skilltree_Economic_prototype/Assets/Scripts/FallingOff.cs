using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingOff : MonoBehaviour
{
    public float threshold;
    private void FixedUpdate()
    {
        if(transform.position.y < threshold)
        {
            transform.position = new Vector3(0f, 0.464f, 0f);
        }
    }
}
