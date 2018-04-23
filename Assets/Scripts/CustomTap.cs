using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CustomTap : MonoBehaviour//, IPointerUpHandler
{
    public UnityEvent onPointerUp;
    public UnityEvent onPointerDown;
    [Range(0,10)]public float timeLimit;

    private float counter = 0;

    private void OnMouseUp()
    {
        if (counter <= timeLimit)
        {
            onPointerUp.Invoke(); 
        }
    }

    private void OnMouseDown()
    {
        onPointerDown.Invoke();
        counter = 0;
    }

    private void Update()
    {
        counter += Time.deltaTime;
    }
}
