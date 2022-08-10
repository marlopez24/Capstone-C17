using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    private GameObject[] characters;

    private int _charIndex;
    public int CharIndex
    {
        get { return _charIndex; }
        set { _charIndex = value; }
    }

    //this code below is making it so that when a game instance is not created
    //you can create one instance of it, otherwise if you already have a game instance
    //then you can destroy the duplicate, so that you only have one of the gameObject
    private void Awake()
    {
        // if null (no gameObject intiated) create one
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        // if already opened a gameObject, then destroy the duplicate
        else
        {
            Destroy(gameObject);
        }
            
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "Gameplay")
        {
            Instantiate(characters[CharIndex]);
        }
    }
} //class  
