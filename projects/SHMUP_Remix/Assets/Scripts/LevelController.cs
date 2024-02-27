using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static LevelController instance;
    
    private float numDestructibles = 0f;
    private bool startNextLevel = false;
    private float nextLevelTimer = 3;

    private string[] levels = { "Level1", "Level2"};

    private int currentLevel = 1;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startNextLevel)
        {
            if (nextLevelTimer <= 0)
            {
                currentLevel++;
                if (currentLevel <= levels.Length)
                {
                    string sceneName = levels[currentLevel - 1];
                    SceneManager.LoadSceneAsync(sceneName);
                }
                else
                {
                    Debug.Log("You Win!");
                }
                nextLevelTimer = 3;
                startNextLevel = false;
                
            }
            else
            {
                nextLevelTimer -= Time.deltaTime;
            }
        }
    }

    public void AddDestructable()
    {
        numDestructibles++;
    }

    public void RemoveDestructable()
    {
        numDestructibles--;

        if (numDestructibles == 0)
        {
            startNextLevel = true;
        }
    }
    
}
