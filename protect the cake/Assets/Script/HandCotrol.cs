using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCotrol : MonoBehaviour
{
    public float Speed;
    public Transform[] handpos;
    public GameObject Handleft, HandRight;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButtonDown("left"))
        {
            Handleft.GetComponent<Animator>().SetTrigger("left");
        }

        if (Input.GetButtonDown("up"))
        {
            Handleft.GetComponent<Animator>().SetTrigger("Up");
        }

        if (Input.GetButtonDown("right"))
        {
            HandRight.GetComponent<Animator>().SetTrigger("Right");
        }

        if (Input.GetButtonDown("down"))
        {
            HandRight.GetComponent<Animator>().SetTrigger("flint");
        }
    }
}
