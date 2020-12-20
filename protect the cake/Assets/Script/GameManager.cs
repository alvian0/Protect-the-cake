using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int Hp = 5;
    public GameObject candleLight, efek;
    public Transform efekPlay;
    public bool IsFireOn = false;
    public float FireTime = 10f, GameOverCoutdown = 3f;
    public GameObject[] Hpbar;
    public Color notActive;
    public SpriteRenderer cake;
    public Sprite CakeNormal, CakeDemage;
    public GameObject NotStart, HitEffect, cameras, Spawner;
    public Image PartyStartCounter;
    public float boomerangTimeInterval = 5f;
    public GameObject[] Boomerang;

    float fireRate;
    bool GameStart = false;
    bool IsPaused = false, OnGOcountdown = false;
    float GOcountdown, boomerangrate;

    void Start()
    {
        boomerangrate = boomerangTimeInterval;
        GOcountdown = GameOverCoutdown;
        cake.sprite = CakeNormal;
        fireRate = FireTime;
    }

    void Update()
    {
        if (GameStart)
        {
            PartyStartCounter.fillAmount -= Time.deltaTime / 60;

            NotStart.SetActive(false);

            if (boomerangrate <= 0)
            {
                int temps = temporary();

                if (temps == 2)
                {
                    Boomerang[Random.Range(0, Boomerang.Length)].SetActive(false);
                    Boomerang[Random.Range(0, Boomerang.Length)].SetActive(true);
                }

                boomerangrate = boomerangTimeInterval;
            }

            else
            {
                boomerangrate -= Time.deltaTime;
            }

            if (IsFireOn)
            {
                if (fireRate <= 0)
                {
                    candleLight.SetActive(false);
                    fireRate = FireTime;
                    Instantiate(efek, efekPlay.position, Quaternion.identity);
                    GOcountdown = GameOverCoutdown;
                    OnGOcountdown = true;
                    IsFireOn = false;
                }

                else
                {
                    fireRate -= Time.deltaTime;
                }
            }

            if (OnGOcountdown)
            {
                if (GOcountdown <= 0)
                {

                }
            }

            if (Hp <= 2)
            {
                cake.sprite = CakeDemage;
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (IsPaused)
                {
                    UnPaused();
                }

                else
                {
                    Paused();
                }    
            }
        }
    }

    int temporary()
    {
        int temps = Random.Range(1, 4);
        return temps;
    }

    public void turnOnCandle()
    {
        if (candleLight.activeInHierarchy)
        {
            HealthDecrease();
            candleLight.SetActive(false);
            IsFireOn = false;
        }

        else
        {
            candleLight.SetActive(true);
            IsFireOn = true;
            fireRate = FireTime;

            if (!GameStart)
            {
                Spawner.SetActive(true);
                GameStart = true;
            }
        }
    }

    public void GetJunk()
    {
        HealthDecrease();
        candleLight.SetActive(false);
        IsFireOn = false;
    }

    public void HealthDecrease()
    {
        if (Hp > 0)
        {
            Hp--;
            HitEffect.SetActive(false);
            HitEffect.SetActive(true);
            cameras.GetComponent<Animator>().SetTrigger("Shake");

            for (int i = Hpbar.Length; i > Hp; i--)
            {
                Hpbar[i - 1].GetComponent<Image>().color = notActive;
            }
        }
    }

    public void Paused()
    {
        Time.timeScale = 0f;
        IsPaused = true;
    }

    public void UnPaused()
    {
        Time.timeScale = 1f;
        IsPaused = false;
    }
}