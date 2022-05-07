using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneWall : MonoBehaviour
{
    public GameObject PrefabWall;

    float screenWidth = 0;
    float screenHeight = 0;
    void Start()
    {
        screenHeight = 30;
        screenWidth = Screen.width / (Screen.height / 30) - (3.2f / 2);

        // 30 юнитов высоты, 3.2f - длина квадрата
        // Как найти сколько в этих юнитах будет квадратов?
        int countHeight = Convert.ToInt32(screenHeight / 3.2f) - 1;
        int countWidth = Convert.ToInt32(screenWidth / 3.2f) -1 ;

        for (int i = 0; i <= countHeight; i++)
        {
            Instantiate(PrefabWall, new Vector3(-countWidth * 3.2f, i * 3.2f, 0), Quaternion.identity, transform);
            Instantiate(PrefabWall, new Vector3(-countWidth * 3.2f, i * -3.2f, 0), Quaternion.identity, transform);

            Instantiate(PrefabWall, new Vector3(countWidth * 3.2f, i * 3.2f, 0), Quaternion.identity, transform);
            Instantiate(PrefabWall, new Vector3(countWidth * 3.2f, i * -3.2f, 0), Quaternion.identity, transform);
            // i = 0:   i   = 0f
            // i = 1:   i   = 3.2f
            // i = 2:   i   = 6.4f
            // .....
        }
        for (int i = 0; i < countWidth; i++)
        {
            Instantiate(PrefabWall, new Vector3(i * 3.2f, -countHeight * 3.2f, 0), Quaternion.identity, transform);
            Instantiate(PrefabWall, new Vector3(i * -3.2f, -countHeight * 3.2f, 0), Quaternion.identity, transform);

            Instantiate(PrefabWall, new Vector3(i * 3.2f, countHeight * 3.2f, 0), Quaternion.identity, transform);
            Instantiate(PrefabWall, new Vector3(i * -3.2f, countHeight * 3.2f, 0), Quaternion.identity, transform);
        }
    }
}
