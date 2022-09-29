using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    private Transform target;
    public PlayerCamera Init(Transform target)
    {
        this.target = target;

        return this;
    }

    private void FixedUpdate()
    {
        Camera.main.transform.position = target.position + new Vector3(0,0,-10);
    }
}
