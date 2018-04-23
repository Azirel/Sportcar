using System.Collections;
using System.Collections.Generic;
using TouchScript.Gestures.TransformGestures;
using UnityEngine;
using UnityEngine.UI;

public class Zoomer : MonoBehaviour
{

    [SerializeField] RectTransform scaledTransform;
    [SerializeField] ScrollRect scrollRect;
    public float minScaleVelue = 0.3f;
    public float maxScaleVelue = 5;
    public float zoomSpeed = 1.5f;

    private float deltaMagnitude = 0;
    private float startDelta = 0;
    private float scaleFactor;
    // Use this for initialization
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 1)
        {
            scrollRect.enabled = false;
            if (startDelta == 0)
            {
                startDelta = Vector2.Distance(Input.touches[0].position, Input.touches[1].position);
            }
            else
            {
                scaleFactor = Vector2.Distance(Input.touches[0].position, Input.touches[1].position) / startDelta;
                Debug.Log(scaleFactor);
                scaledTransform.localScale *= scaleFactor;
            }
        }
        else
        {
            scrollRect.enabled = true;
            startDelta = 0;
        }
    }
}
