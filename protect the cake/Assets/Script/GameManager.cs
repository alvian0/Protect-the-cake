using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int Hp = 5;
    public GameObject candleLight, efek;
    public Transform efekPlay;
    public bool IsFireOn = false;
    public float FireTime = 10f;

    float fireRate;
    bool GameStart = false;
    void Start()
    {
        fireRate = FireTime;
    }

    void Update()
    {
        if (IsFireOn)
        {
            if (fireRate <= 0)
            {
                candleLight.SetActive(false);
                fireRate = FireTime;
                Instantiate(efek, efekPlay.position, Quaternion.identity);
                IsFireOn = false;
            }

            else
            {
                fireRate -= Time.deltaTime;
            }
        }
    }

    public void turnOnCandle()
    {
        if (candleLight.activeInHierarchy)
        {
            Hp--;
        }

        else
        {
            candleLight.SetActive(true);
            IsFireOn = true;

            if (!GameStart)
            {
                GameStart = true;
            }
        }
    }
}
