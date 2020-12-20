using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flint : MonoBehaviour
{
    public GameManager manager;

    public void turnflint()
    {
        manager.turnOnCandle();
    }
}
