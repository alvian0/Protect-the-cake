using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Junk : MonoBehaviour
{
    public float Speed = 3;

    Vector3 target;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Cake").transform.position;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.localPosition,
            target, Speed * Time.deltaTime);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Hand")
        {
            Destroy(gameObject);
        }

        if (collision.tag == "Cake")
        {
            FindObjectOfType<GameManager>().Hp--;
            Destroy(gameObject);
        }
    }
}
