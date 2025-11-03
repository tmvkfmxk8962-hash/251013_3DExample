using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DroneMove : MonoBehaviour
{
    Transform rb;
    [SerializeField] GameObject _bulletPrefab;

    //▼이동 거리
    float _move = 0.02f;

    float _cooltime;
    //▼한 탄환이 작동하고 다음 탄환이 작동하는데 걸리는 시간

    float _cycle = 0.2f;

    //▼플레이어 체력
    int _playerHp = 5;
    public int PlayerHp
    {
        get { return _playerHp; }
        set { _playerHp = value; }
    }

    //▼적 처치 수
    int _enemyDestroy = 3;
    public int EnemyDestroy
    {
        get { return _enemyDestroy; }
        set { _enemyDestroy = value; }
    }

    void Start()
    {
        //▼해당 오브젝트의 위치정보를 가져옴
        rb = GetComponent<Transform>(); 
    }

    void Update()
    {
        //▼업데이트하고 다음 업데이트하기까지 걸리는 시간
        _cooltime += Time.deltaTime;

        //▼W가 눌렸을때 z방향(위로)작동
        if (Input.GetKey(KeyCode.W))
        {
            if (gameObject.transform.position.z <= 4.2)
            {
                rb.Translate(0, 0, _move);
            }
            
        }

        //▼S가 눌렸을때 -z방향(아래로)작동
        else if (Input.GetKey(KeyCode.S))
        {
            if (gameObject.transform.position.z >= -4.4)
            {
                 rb.Translate(0, 0, -_move);
            }
        }

        //▼A가 눌렸을때 -x방향(왼쪽으로)작동
        else if (Input.GetKey(KeyCode.A))
        {
            if (gameObject.transform.position.x >= -7.8)
            {
                rb.Translate(-_move, 0, 0);
            }
        }

        //▼D가 눌렸을때 x방향(오른쪽으로)작동
        else if (Input.GetKey(KeyCode.D))
        {
            if (gameObject.transform.position.x <= 7.84)
            {
                rb.Translate(_move, 0, 0);
            }
        }

        //▼Space를 눌렀을때 탄환 발사
        if (Input.GetKey(KeyCode.Space) && _cooltime > _cycle)
        {
            Instantiate(_bulletPrefab, transform.position 
                + new Vector3(0, 0, 0.5f), transform.rotation);
            _cooltime = 0;
        }

        //▼플레이어 체력이 0이되거나 적모두 삭제되면 게임엔드로 씬변경
        if (_playerHp == 0 || _enemyDestroy == 0)
        {
            if (_playerHp == 0)
            {
                GameEndText._endText = "Game Over";
            }
            if (_enemyDestroy == 0)
            {
                GameEndText._endText = "Game Clear";
            }
            SceneManager.LoadScene("GameEnd");
            
        }
        
    }

}

