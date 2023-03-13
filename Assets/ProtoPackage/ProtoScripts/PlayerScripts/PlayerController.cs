using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Playerの動きを制御するコンポーネント
/// スマホ移動に対応したやり方は知らんので学習がてら前のプロジェクトのスクリプトを参考にする
/// プレイヤーに必要な挙動はアクションと移動とされてるがアクションてなんやねん
/// 面倒だから別スクリプトでその機能は作るが凝ったものは作らん
/// これくらい動けばええやろ（適当）
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] FixedJoystick _joyStick;
    [SerializeField] float _moveSpeed;
    [SerializeField] Rigidbody2D _rb2D;
    float _h;
    float _v;
    private void Update()
    {
        _h = _joyStick.Horizontal;
        _v = _joyStick.Vertical;
    }
    private void FixedUpdate()
    {
        _rb2D.velocity = new Vector2(_h,_v).normalized * _moveSpeed;
    }
}
