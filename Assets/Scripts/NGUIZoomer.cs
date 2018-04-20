using System.Collections;
using System.Collections.Generic;
using TouchScript.Gestures.TransformGestures;
using UnityEngine;

public class NGUIZoomer : MonoBehaviour
{

    [SerializeField] TransformGesture gesture;
    [SerializeField] UIWidget scaledWidget;

    public int maxWidth = 3333;
    public float zoomSpeed = 1.5f;

    private float deltaMagnitude = 0;
    private int minWidth;

    void Start()
    {
        gesture.Transformed += Gesture_Transformed;
        minWidth = scaledWidget.width;
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
}
