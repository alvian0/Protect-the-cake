using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int Hp = 5;
    public GameObject candleLight, efek;
    public Transform efekPlay;
    public bool IsFireOn = false;
    public float FireTime = 10f, GameOverCoutdown = 1f;
    public GameObject[] Hpbar;
    public Color notActive;
    public SpriteRenderer cake;
    public GameObject NotStart, HitEffect, cameras, Spawner, PausePanel, GameOverPanel, GameOverCounterImage, Cake;
    public Image PartyStartCounter, GameOverCounter;
    public float boomerangTimeInterval = 5f;
    public GameObject[] Boomerang;
    public Text Rank;
    public bool GameFinished = false;

    float fireRate;
    bool GameStart = false;
    bool IsPaused = false, OnGOcountdown = false;
    float boomerangrate;

    void Start()
    {
        Time.timeScale = 1f;

        boomerangrate = boomerangTimeInterval;
        GameOverCounter.fillAmount = GameOverCoutdown;
        fireRate = FireTime;
    }

    void Update()
    {
        if (GameStart && !GameFinished)
        {
            PartyStartCounter.fillAmount -= Time.deltaTime / 60;

            if (PartyStartCounter.fillAmount <= 0)
            {
                GameFinished = true;
            }

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
                GameOverCounterImage.SetActive(false);

                if (fireRate <= 0)
                {
                    candleLight.SetActive(false);
                    fireRate = FireTime;
                    Instantiate(efek, efekPlay.position, Quaternion.identity);
                    GameOverCounter.fillAmount = GameOverCoutdown;
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
                GameOverCounterImage.SetActive(true);

                if (GameOverCounter.fillAmount <= 0)
                {
                    GameFinished = true;
                }

                else
                {
                    GameOverCounter.fillAmount -= Time.deltaTime / 4;
                }
            }

            if (Hp <= 0)
            {
                GameFinished = true;
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

        if (GameFinished)
        {
            GameOverPanel.SetActive(true);
            Destroy(GameObject.FindGameObjectWithTag("Junk"));
            Spawner.SetActive(false);

            if (PartyStartCounter.fillAmount <= 0)
            {
                if (candleLight.activeSelf)
                {
                    if (Hp == 3)
                    {
                        Rank.text = "the party started\nYour rank : S";
                    }

                    else if (Hp == 2)
                    {
                        Rank.text = "the party started\nYour rank : A";
                    }

                    else if (Hp == 1)
                    {
                        Rank.text = "the party started\nYour rank : B";
                    }

                    else
                    {
                        Rank.text = "the party started\nYour rank : C";
                    }
                }

                else
                {
                    Rank.text = "the party not started you need burning candle to start party\nYour rank : F";
                }
            }

            else if (GameOverCounter.fillAmount <= 0)
            {
                Rank.text = "the party not started you need burning candle to start party\nYour rank : F";
            }

            else
            {
                Rank.text = "You failed protect your cake\nYour rank : F";
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
            OnGOcountdown = true;
        }

        else
        {
            candleLight.SetActive(true);
            IsFireOn = true;
            OnGOcountdown = false;
            GameOverCounter.fillAmount = GameOverCoutdown;
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
        OnGOcountdown = true;
    }

    public void HealthDecrease()
    {
        if (Hp > 0)
        {
            Hp--;
            HitEffect.SetActive(false);
            HitEffect.SetActive(true);
            Cake.GetComponent<Animator>().SetTrigger("Demage");
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
        PausePanel.SetActive(true);
    }

    public void UnPaused()
    {
        Time.timeScale = 1f;
        IsPaused = false;
        PausePanel.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}