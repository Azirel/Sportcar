using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimeDelayedUnityEvent : MonoBehaviour
{
    public UnityEvent @event;
    public float delay;

    public void Invoke()
    {
        StartCoroutine(DelayedInvoke(delay));
    }

    IEnumerator DelayedInvoke(float delay)
    {
        yield return new WaitForSeconds(delay);
        @event.Invoke();
    }
}
