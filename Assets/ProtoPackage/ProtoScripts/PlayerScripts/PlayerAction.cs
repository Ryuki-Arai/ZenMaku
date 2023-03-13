using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// アクションてなんやねん…
/// とりあえずコライダーで相手の関数呼んで終わりでええんちゃう？
/// 相手側には色を変えるスクリプトを書いておく
/// testやし完全接着でええやろ
/// /// </summary>
[RequireComponent(typeof(Collider2D))]
public class PlayerAction : MonoBehaviour
{
    [SerializeField] float _latetime = 2f;
    SleepingEnemyController _eneCon;
    float _timer;
    private void Update()
    {
        if(Input.GetButton("Fire1") && _eneCon)
        {
            ActionStart();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag =="Enemy")
        {
            _eneCon = collision.gameObject.GetComponent<SleepingEnemyController>();
            Debug.Log("Enemy came In");
        }
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            _eneCon = null;
            Debug.Log("ActionCancell");
            _timer = 0;
        }
    }
    void ActionStart()
    {
        Debug.Log("OnGoing");
        _timer += Time.deltaTime;
        if(_timer >= _latetime)
        {
            _eneCon.ActionMethod();
            _eneCon.enabled = false;
            Debug.Log("Done it");
        }
    }
}
