using System.Collections;
using System.Collections.Generic;
using TouchScript.Gestures.TransformGestures;
using UnityEngine;

public class NGUIZoomer : MonoBehaviour
{

    [SerializeField] TransformGesture gesture;
    [SerializeField] UIWidget scaledWidget;
    [SerializeField] Camera zommedCamera;
    [SerializeField] UIPanel panel;

    public int maxWidth = 3333;
    private float deltaMagnitude = 0;
    private int minWidth;

    public float zoomSpeed = 1.5f;
    private float maxZoom = 1;
    public float minZoom = 0.1f;
    private Vector2 startPanelSize;

    void Start()
    {
        gesture.Transformed += CameraZooming;
        minWidth = scaledWidget.width;
        startPanelSize = new Vector2(panel.baseClipRegion.z, panel.baseClipRegion.w);
        Debug.Log(startPanelSize);
    }

    private void Gesture_Transformed(object sender, System.EventArgs e)
    {
        scaledWidget.width = (int)((float)scaledWidget.width * gesture.DeltaScale);
        if (scaledWidget.width > maxWidth)
        {
            scaledWidget.width = maxWidth;
        }
        else if (scaledWidget.width < minWidth)
        {
            scaledWidget.width = minWidth;
        }
    }

    private void CameraZooming(object sender, System.EventArgs e)
    {
        zommedCamera.orthographicSize /= gesture.DeltaScale;
        //zommedCamera.orthographicSize = zommedCamera.orthographicSize > maxZoom ? maxZoom : zommedCamera.orthographicSize < minZoom ? minZoom : zommedCamera.orthographicSize;
        if (zommedCamera.orthographicSize > maxZoom)
        {
            zommedCamera.orthographicSize = maxZoom;
            panel.baseClipRegion = new Vector4(panel.baseClipRegion.x, panel.baseClipRegion.y, startPanelSize.x, startPanelSize.y);
        }
        else if (zommedCamera.orthographicSize < minZoom)
        {
            zommedCamera.orthographicSize = minZoom;
        }
        else
            panel.baseClipRegion /= gesture.DeltaScale;
    }

}
