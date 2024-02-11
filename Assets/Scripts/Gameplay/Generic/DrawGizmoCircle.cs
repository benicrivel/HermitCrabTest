using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DrawGizmoCircle : MonoBehaviour
{
    [SerializeField]
    private float radius = 1f;
    [SerializeField]
    private Color gizmoColor = Color.white;
#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        Handles.color = gizmoColor;

        Vector3 center = transform.position;
        Handles.DrawWireDisc(center, Vector3.back, radius);
    }
#endif
}
