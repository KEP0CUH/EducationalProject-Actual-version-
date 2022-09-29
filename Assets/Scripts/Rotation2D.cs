using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation2D : MonoBehaviour
{
    [SerializeField] [Range(0,6.28f)] private float angleInRadians = 6.28f;
    [SerializeField] [Range(0, 360f)] private float angleInDegrees = 360f;

    [Range(0, 6.28f)]private float syncAngle = 6.28f;                        // Угол синхронизации ползунков.

    private void OnValidate()
    {
        SynchronizeAngleSliders();
    }
    private void SynchronizeAngleSliders()
    {
        if (syncAngle != angleInRadians)
        {
            angleInDegrees = angleInRadians * 180 / 3.14f;
            syncAngle = angleInRadians;
        }
        if (syncAngle * 180 / 3.14f != angleInDegrees)
        {
            angleInRadians = angleInDegrees * 3.14f / 180;
            syncAngle = angleInRadians;
        }
    }

    private void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.R))
        {
            var x = +transform.position.x * Mathf.Cos(angleInRadians)
                    - transform.position.y * Mathf.Sin(angleInRadians);
            var y = transform.position.x * Mathf.Sin(angleInRadians)
                    + transform.position.y * Mathf.Cos(angleInRadians);
            this.transform.localPosition = new Vector3(x,y,0);
        }
    }
}
