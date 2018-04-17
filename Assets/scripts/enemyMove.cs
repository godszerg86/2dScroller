using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMove : MonoBehaviour
{

    Transform tr;
    float direction;
    SpriteRenderer spr;
bool flipper =true;
    void Start()
    {

        tr = GetComponent<Transform>();
        direction = 0.015f;
        spr = GetComponent<SpriteRenderer>();

    }



    void FixedUpdate()
    {
        tr.Translate(direction, 0f, 0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("col"))
        {
            direction = direction * -1;
            flip();
        }
    }

 void flip(){
    spr.flipX = flipper;
    flipper = !flipper;
 }

}




