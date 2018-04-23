using System.Collections;
using System.Collections.Generic;
using TouchScript.Gestures.TransformGestures;
using UnityEngine;
using UnityEngine.UI;

public class Zoomer : MonoBehaviour
{

    [SerializeField] RectTransform scaledTransform;
    [SerializeField] ScrollRect scrollRect;
    [SerializeField] RectTransform middlePoint;

    public float minScaleVelue = 0.3f;
    public float maxScaleVelue = 5;
    [Tooltip("Defines impact on camera shifting it's position towards touches middle point")]
    public float zoomMotionAffect = 0.5f;

    private float deltaMagnitude = 0;
    private float previousDelta = 0;
    private float currentDelta = 0;
    private float scaleFactor = 0;
    private Vector2 touchesMiddlePoint;

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 1)
        {
            scrollRect.enabled = false;
            if (previousDelta == 0)
            {
                previousDelta = Vector2.Distance(Input.touches[0].position, Input.touches[1].position);
            }
            else
            {
                currentDelta = Vector2.Distance(Input.touches[0].position, Input.touches[1].position);
                scaleFactor = currentDelta / previousDelta;
                scaledTransform.localScale *= scaleFactor;
                touchesMiddlePoint = Camera.main.ScreenToWorldPoint((Input.touches[0].position + Input.touches[1].position) / 2);
                middlePoint.position = touchesMiddlePoint;
                scaledTransform.position = Vector3.MoveTowards(scaledTransform.position, middlePoint.position, zoomMotionAffect);
                //scaledTransform.position += middlePoint.position * zoomMotionAffect;
                previousDelta = currentDelta;
            }
        }
        else
        {
            scrollRect.enabled = true;
            previousDelta = 0;
        }
    }
}
