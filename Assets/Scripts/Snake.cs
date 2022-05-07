using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public GameObject PrefabBody;
    public GameObject PrefabRotation1;
    public GameObject PrefabRotation2;

    float screenWidth = 0;
    float screenHeight = 0;

    int HeaderRotation = 0;
    public float speed = 2;

    // Start is called before the first frame update
    void Start()
    {
        screenHeight = 30;
        screenWidth = Screen.width / (Screen.height / 30) - (3.2f / 2);
        // 1920 1080
        // width = 1920
        // height = 1080
        // 30 - мера
        // в 1920/30 = 64
        // 1080 / 64 = 16,7
    }

    // Update is called once per frame
    float timer = 0;
    void Update()
    {
        //if (timer < 0)
        //{
        //    Move();
        //    timer = 1;
        //}
        //timer -= Time.deltaTime;

        if (timer * speed > 1)
        {
            Move();
            timer = 0;
        }
        timer += Time.deltaTime;
    }

    void MoveBody()
    {
        Body[] body = GetComponentsInChildren<Body>();
        Tail tail = GetComponentInChildren<Tail>();

        tail.transform.rotation = body[1].transform.rotation;
        tail.transform.position = body[0].transform.position;

        Destroy(body[0].gameObject);
    }

    void Move()
    {
        Had had = GetComponentInChildren<Had>();

        // ВПРАВО
        if (HeaderRotation == 0 &&  had.transform.position.x + 3.2f < screenWidth)  // ПОВОРОТ ГОЛОВЫ 0 - ВПРАВО, второе - чтобы змейка не заходила за экран
        {
            Instantiate(PrefabBody, had.transform.position, Quaternion.Euler(0, 0, HeaderRotation), transform); // Создание кусочка тела
            // Instantiate - создать объект на основе префаба
            // Параметры: 1. prefab, позиция спавна, поворот (identity - по умолчанию нет поворота), объект(или его часть) в котором создаем

            had.transform.position = new Vector3(
                had.transform.position.x + 3.2f,
                had.transform.position.y,
                had.transform.position.z);
            MoveBody();
           
        }

        // ВЛЕВО

        if (HeaderRotation == 180 && had.transform.position.x - 3.2f > -screenWidth)
        {
            Instantiate(PrefabBody, had.transform.position, Quaternion.Euler(0, 0, HeaderRotation), transform);

            had.transform.position = new Vector3(
                had.transform.position.x - 3.2f,
                had.transform.position.y,
                had.transform.position.z);
            MoveBody();
        }

        // ВВЕРХ
        if (HeaderRotation == 90 && had.transform.position.y + 3.2f < screenHeight)
        {
            Instantiate(PrefabBody, had.transform.position, Quaternion.Euler(0, 0, HeaderRotation), transform);

            had.transform.position = new Vector3(
                had.transform.position.x,
                had.transform.position.y + 3.2f,
                had.transform.position.z);
            MoveBody();
        }

        // ВНИЗ
        if (HeaderRotation == 270 && had.transform.position.y - 3.2f > -screenHeight)
        {
            Instantiate(PrefabBody, had.transform.position, Quaternion.Euler(0, 0, HeaderRotation), transform);

            had.transform.position = new Vector3(
                had.transform.position.x,
                had.transform.position.y - 3.2f,
                had.transform.position.z);
            MoveBody();
        }
    }

    public void Right()
    {
        timer = 0;
        if (HeaderRotation == 90 || HeaderRotation == 270)
        {
            Had had = GetComponentInChildren<Had>();
            had.transform.rotation = Quaternion.Euler(0, 0, 0);
            Instantiate(PrefabBody, had.transform.position, Quaternion.Euler(0, 0, HeaderRotation), transform);
            HeaderRotation = 0;
            had.transform.position = new Vector3(
                had.transform.position.x + 3.2f,
                had.transform.position.y,
                had.transform.position.z);
            MoveBody();
        }
    }
    public void Left()
    {
        timer = 0;
        if (HeaderRotation == 90 || HeaderRotation == 270)
        {
            Had had = GetComponentInChildren<Had>();
            had.transform.rotation = Quaternion.Euler(0, 0, 180);
            Instantiate(PrefabBody, had.transform.position, Quaternion.Euler(0, 0, HeaderRotation), transform);
            HeaderRotation = 180;
            had.transform.position = new Vector3(
                had.transform.position.x - 3.2f,
                had.transform.position.y,
                had.transform.position.z);
            MoveBody();
        }
    }
    public void Up()
    {
        timer = 0;
        if (HeaderRotation == 180 || HeaderRotation == 0)
        {
            Had had = GetComponentInChildren<Had>();
            had.transform.rotation = Quaternion.Euler(0, 0, 90);
            Instantiate(PrefabBody, had.transform.position, Quaternion.Euler(0, 0, HeaderRotation), transform);
            HeaderRotation = 90;
            had.transform.position = new Vector3(
                had.transform.position.x,
                had.transform.position.y + 3.2f,
                had.transform.position.z);
            MoveBody();
        }
    }
    public void Down()
    {
        timer = 0;
        if (HeaderRotation == 180 || HeaderRotation == 0)
        {
            Had had = GetComponentInChildren<Had>();
            had.transform.rotation = Quaternion.Euler(0, 0, 270);
            Instantiate(PrefabBody, had.transform.position, Quaternion.Euler(0, 0, HeaderRotation), transform);
            HeaderRotation = 270;
            had.transform.position = new Vector3(
                had.transform.position.x,
                had.transform.position.y - 3.2f,
                had.transform.position.z);
            MoveBody();
        }
    }
}
