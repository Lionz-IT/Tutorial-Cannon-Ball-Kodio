using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public GameObject[] wallGroupPrefabs;
    public Transform wallGroupSpawnPosition;
    public int fallenBrickAmount, fallenBrickNeeded;

    public event Action setAmmo;

    public TextMeshProUGUI levelText;
    public static int level = 1;

    private void Start()
    {
        SpawnWallGroup(UnityEngine.Random.Range(0, wallGroupPrefabs.Length));
        levelText.text = "level: " + level;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            RestartGame();
        }
    }

    void SpawnWallGroup(int wallGroupIndex)
    {
        Instantiate(wallGroupPrefabs[wallGroupIndex], wallGroupSpawnPosition.position, Quaternion.identity);
    }


    public void BrickFall()
    {
        fallenBrickAmount++;
        if (fallenBrickAmount >= fallenBrickNeeded)
        {
            level++;
            RestartGame();
            print("You Win");
        }
    }

    public void SetAmmo()
    {
        setAmmo?.Invoke();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

