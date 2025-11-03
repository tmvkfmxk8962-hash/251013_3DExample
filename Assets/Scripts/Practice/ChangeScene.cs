using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    //▼게임 시작 버튼
    public void GameStartButton()
    {
        SceneManager.LoadScene("Game");
    }

    //▼게임 종료창으로 가는 버튼
    public void GameEndButton()
    {
        GameEndText._endText = "게임을 종료하시겠습니까?";
        SceneManager.LoadScene("GameEnd");
    }

    //▼게임 진짜 종료 버튼
    public void GameRealEnd()
    {
        Application.Quit();
    }

    //▼게임 메뉴 버튼
    public void GameMenu()
    {
        SceneManager.LoadScene("GameMenu");
    }
}
