using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    

    void Start()
    {
        gameObject.GetComponent<CapsuleCollider>().isTrigger = true;
    }

    
    void Update()
    {
        //▼총알이 앞으로 이동
        gameObject.transform.Translate(0, 0, 0.03f);
    }

    private void OnTriggerEnter(Collider other)
    {
        //▼벽에 부딪치면 삭제한다.
        if (other.gameObject.tag == "Finish")
        {
            Destroy(gameObject);
        }
        //▼적에게 부딪치면 적의 체력을 1깍고 삭제한다.
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<Enemy>().EnemyHp -= 1;
            Destroy(gameObject);
        }
    }
}
