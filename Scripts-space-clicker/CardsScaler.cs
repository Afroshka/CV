using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsScaler : MonoBehaviour
{
    public RectTransform panel;
    public RectTransform canvas;

    private void Start()
    {
        panel.sizeDelta = new Vector2(panel.sizeDelta.x, canvas.rect.height / 2);
    }
}
