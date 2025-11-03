using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameEndText : MonoBehaviour
{
    public static string _endText;

    void Update()
    {
        //▼게임 엔드시 어떤 말이 나올지 결정
        gameObject.GetComponent<TextMeshProUGUI>().text = _endText;
    }
}
