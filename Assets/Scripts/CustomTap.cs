using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CustomTap : MonoBehaviour, IPointerUpHandler
{
    public UnityEvent onPointerUp;
    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("!!!;");
    }

    private void OnMouseUp()
    {
        Debug.Log("OnMouseUp");
        onPointerUp.Invoke();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
