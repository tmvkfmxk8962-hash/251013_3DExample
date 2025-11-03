using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    //▼적 체력
    int _enemyHp = 10;
    public int EnemyHp
    {
        get { return _enemyHp; }
        set { _enemyHp = value; }
    }
    //▼오브젝트 찾기
    GameObject _player;
    //▼좌표검색
    float _playerX;
    float _playerZ;
    float _enemyX;
    float _enemyZ;

    void Start()
    {
        //▼드론 오브젝트를 찾음
        _player = GameObject.Find("Drone");
    }
    void Update()
    {
        //▼현재 좌표 초기화
        _playerX = _player.transform.position.x;
        _playerZ = _player.transform.position.z;
        _enemyX = transform.position.x;
        _enemyZ = transform.position.z;

        //▼적 체력이 0이되면 드론에 적 처치 수를 하나 깍는다
        if (_enemyHp == 0)
        {
            _player.GetComponent<DroneMove>().EnemyDestroy -= 1;
            Destroy(gameObject);
        }
        
    }

    //▼트리거 형태로 부딪치면 플레이어 체력을 1깍는다
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<DroneMove>().PlayerHp -= 1;
        }
    }
    //▼충돌되었다면 플레이어를 적 객체로부터 조금씩 떨어지게 만듬
    private void OnTriggerStay(Collider other)
    {
        //▼상하좌우 계산표
        float XPosion = _enemyX - _playerX;
        float ZPosion = _enemyZ - _playerZ;
        if (ZPosion > 0 && (ZPosion > XPosion || ZPosion > -1 * XPosion))
        {
            other.gameObject.GetComponent<Transform>().Translate(0, 0, -0.2f);
        }
        if (ZPosion < 0 && (ZPosion > XPosion || ZPosion > -1 * XPosion))
        {
            other.gameObject.GetComponent<Transform>().Translate(0, 0, 0.2f);
        }
        if (XPosion > 0 && (XPosion > ZPosion || XPosion > -1 * ZPosion))
        {
            other.gameObject.GetComponent<Transform>().Translate(-0.2f, 0, 0);
        }
        if (XPosion < 0 && (XPosion > ZPosion || XPosion > -1 * ZPosion))
        {
            other.gameObject.GetComponent<Transform>().Translate(0.2f, 0, 0);
        }
    }

}
