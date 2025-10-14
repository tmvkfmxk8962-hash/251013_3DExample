using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    string[] Name = { "Awake", "OnEnable", "Start", "Update", "FixedUpdate", "LateUpdate", "OnDisable", "OnDestroy" };

    void Awake()
    {
        Debug.Log($"{Name[0]} 호출");
    }
    void OnEnable()
    {
        Debug.Log($"{Name[1]} 호출");
    }
    void Start()
    {
        Debug.Log($"{Name[2]} 호출");
    }
    void Update()
    {
        Debug.Log($"{Name[3]} 호출");
    }
    void FixedUpdate()
    {
        Debug.Log($"{Name[4]} 호출");
    }
    void LateUpdate()
    {
        Debug.Log($"{Name[5]} 호출");
    }
    void OnDisable()
    {
        Debug.Log($"{Name[6]} 호출");
    }
    void OnDestroy()
    {
        Debug.Log($"{Name[7]} 호출");
    }
}
