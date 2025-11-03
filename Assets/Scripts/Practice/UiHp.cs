using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiHp : MonoBehaviour
{
    float _player;

    void Update()
    {
        //▼플레이어 체력이 떨어지는걸 표현한 UI
        _player = GameObject.Find("Drone").GetComponent<DroneMove>().PlayerHp;
        gameObject.GetComponent<TextMeshProUGUI>().text = "Hp : " + _player;
        
    }
}
