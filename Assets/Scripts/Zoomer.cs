using System.Collections;
using System.Collections.Generic;
using TouchScript.Gestures.TransformGestures;
using UnityEngine;

public class Zoomer : MonoBehaviour
{

    [SerializeField] TransformGesture gesture;
    [SerializeField] Transform scaledTransform;
    public float minScaleVelue = 0.3f;
    public float maxScaleVelue = 5;
    public float zoomSpeed = 1.5f;

    private float deltaMagnitude = 0;
    // Use this for initialization
    void Start()
    {
        gesture.Transformed += Gesture_Transformed;
    }


    private void Gesture_Transformed(object sender, System.EventArgs e)
    {
        scaledTransform.localScale *= gesture.DeltaScale /** zoomSpeed*/;
        if (scaledTransform.localScale.x > maxScaleVelue)
        {
            scaledTransform.localScale = new Vector3(maxScaleVelue, maxScaleVelue, maxScaleVelue);
        }
        else if (scaledTransform.localScale.x < minScaleVelue)
        {
            scaledTransform.localScale = new Vector3(minScaleVelue, minScaleVelue, minScaleVelue);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
