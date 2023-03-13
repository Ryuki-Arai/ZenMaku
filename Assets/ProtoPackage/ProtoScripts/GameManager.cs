using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject [] _gameObjects;
    [SerializeField] GameObject _gameOverUIobject;
    [SerializeField] float _latetime = 1f;
    public static bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameOver)
        {
            Invoke(nameof(GameOver),_latetime);
        }
    }
    void GameOver()
    {
        isGameOver = false;
        foreach (var c in _gameObjects)
        {
            c.SetActive(false);
        }
        _gameOverUIobject.SetActive(true);
    }
}
