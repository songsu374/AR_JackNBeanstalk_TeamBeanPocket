using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }


    void Start()
    {

    }

    void Update()
    {

    }

    //종료버튼을 누르면 종료하는 기능을 호출하고싶다
    public void OnClickQuit()
    {
        print("OnClickQuit");
        Application.Quit();
    }
    //시작버튼을 누르면 시작
    public void OnClickStoryStart()
    {
        print("OnClickStoryStart");
        // 다음 scene을 Load 하고싶다
        SceneManager.LoadScene("StoryStart");
        Time.timeScale = 1;
    }


    //시작버튼을 누르면 시작
    public void OnClickARStart()
    {
        print("OnClickARStart");
        // 다음 scene을 Load 하고싶다
        SceneManager.LoadScene("AR_LoadScene");
        Time.timeScale = 1;
    }
    //시작버튼을 누르면 시작
    public void OnClickStoryEnd()
    {
        print("OnClickOutro");
        // 다음 scene을 Load 하고싶다
        SceneManager.LoadScene("Outro");
        Time.timeScale = 1;
    }
}
