using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIpanel : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    Vector2 position;
    public Snake snake;
    public void OnPointerDown(PointerEventData eventData)
    {
        position = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        float right = position.x - eventData.position.x; // вправо - right отрицат
        float up = position.y - eventData.position.y; 

        if (Math.Abs(right) - Math.Abs(up) < 0)
        {
            if (up < 0)
                snake.Up();
            else
                snake.Down();
        }
        else
        {
            if (right < 0)
                snake.Right();
            else
                snake.Left();
        }

    }
}
