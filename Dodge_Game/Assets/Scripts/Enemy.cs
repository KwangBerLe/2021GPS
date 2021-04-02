using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int directionVector = 1;
    private int speed = 7;

    public void SetDirectionVector(int directionVector)
    {
        this.directionVector = directionVector;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += directionVector * speed * Time.deltaTime;
        transform.position = pos;

        if(pos.x < -10 || pos.x > 10)
        {
            gameObject.SetActive(false);
            //Destroy(gameObject);  
            //SetActive 가 계속 쌓이면 렉이 걸릴 수 있기 때문에, 적절한 상황에 SetActive와 Destroy 를 섞어가며 사용하자.
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
}
