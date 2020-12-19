using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCotrol : MonoBehaviour
{
    public float Speed;
    public Transform[] handpos;
    public GameObject Handleft, HandRight;

    Vector3 leftoriginalpos, rightoriginalpos;

    void Start()
    {
        leftoriginalpos = Handleft.transform.position;
        rightoriginalpos = HandRight.transform.position;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                MoveHand(Handleft.transform, 0);
            }

            else if (Input.GetKey(KeyCode.DownArrow))
            {
                MoveHand(Handleft.transform, 2);
            }

            else
            {
                MoveHand(Handleft.transform, 1);
            }
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            Handleft.transform.position = leftoriginalpos;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                MoveHand(HandRight.transform, 0, true);
            }

            else if (Input.GetKey(KeyCode.DownArrow))
            {
                MoveHand(HandRight.transform, 2, true);
            }

            else
            {
                MoveHand(HandRight.transform, 1, true);
            }
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            HandRight.transform.position = rightoriginalpos;
        }
    }

    void MoveHand(Transform hand, int index, bool right = false)
    {
        if (right)
        {
            hand.transform.position = Vector2.MoveTowards(hand.transform.localPosition, 
                new Vector2(-handpos[index].position.x, handpos[index].position.y), 
                Speed * Time.deltaTime);
        }

        else
        {
            hand.transform.position = Vector2.MoveTowards(hand.transform.localPosition, handpos[index].position, Speed * Time.deltaTime);
        }
    }
}
