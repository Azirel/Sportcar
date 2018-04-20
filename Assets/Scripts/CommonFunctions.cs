using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommonFunctions : MonoBehaviour
{

    public void PushToLogger(string message)
    {
        Debug.Log(message);
    }

    public void RandomizeColor(Image sprite)
    {
        sprite.color = UnityEngine.Random.ColorHSV();
    }

    public void RandomizeColor(UIWidget widget)
    {
        widget.color = UnityEngine.Random.ColorHSV();
    }

}
