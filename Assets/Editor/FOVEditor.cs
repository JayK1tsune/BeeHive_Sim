using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FieldOfView))]
public class FOVEditor : Editor
{

    private void OnSceneGUI()
    {
        FieldOfView fov = (FieldOfView)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(fov.transform.position, Vector3.up, Vector3.forward, 360, fov.viewRadius);

        Vector3 viewAngle01 = DirectionFromAngle(fov.transform.eulerAngles.y, -fov.viewAngle / 2);
        Vector3 viewAngle02 = DirectionFromAngle(fov.transform.eulerAngles.y, fov.viewAngle / 2);

        Handles.color = Color.yellow;
        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngle01 * fov.viewRadius);
        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngle02 * fov.viewRadius);

        
        if (fov.canSeeBee)
        {
            Handles.color = Color.green;
            Handles.DrawLine(fov.transform.position, fov.currentWasp.transform.position);
        }

    }

    private Vector3 DirectionFromAngle(float eulery,float angleInDegrees)
    {
        angleInDegrees += eulery;
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));

    }
}
