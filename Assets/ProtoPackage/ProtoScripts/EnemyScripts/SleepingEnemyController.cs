using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SpriteRenderer),typeof(Collider2D))]
public class SleepingEnemyController : MonoBehaviour
{
    SpriteRenderer _sr;
    [SerializeField] float _awakeTime;
    float _timer;
    bool _noizy = false;
    private void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
        _sr.color = Color.yellow;
    }
    private void Update()
    {
        if(_noizy)
        {
            Awakening();
        }
    }
    public void ActionMethod()
    {
        _sr.color = Color.blue;
    }
    void Awakening()
    {
        Debug.Log("Noizzy");
        _timer += Time.deltaTime;
        if(_timer >= _awakeTime)
        {
            _sr.color = Color.red;
            Debug.Log("Awaken!!");
            GameOver();
            _timer = 0;
        }
        
    }

    private void GameOver()
    {
        GameManager.isGameOver = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            _noizy = true;
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _noizy = false;
            _timer = 0;
        }
        
    }
}
