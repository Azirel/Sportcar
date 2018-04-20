using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FramesDelayedUnityEvent : MonoBehaviour
{
    public UnityEvent @event;
    public int delay;

    public void Invoke()
    {
        StartCoroutine(DelayedInvoke(delay));
    }

    IEnumerator DelayedInvoke(float delay)
    {
        yield return new WaitForFixedUpdate();
        @event.Invoke();
    }

}
