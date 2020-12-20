using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomThings : MonoBehaviour
{
    public float Speed;
    GameObject Cake;
    void Start()
    {
        Cake = GameObject.FindGameObjectWithTag("Cake");
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.localPosition, Cake.transform.position, Speed * Time.deltaTime);
    }
}
