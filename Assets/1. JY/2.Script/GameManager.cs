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

    //�����ư�� ������ �����ϴ� ����� ȣ���ϰ�ʹ�
    public void OnClickQuit()
    {
        print("OnClickQuit");
        Application.Quit();
    }
    //���۹�ư�� ������ ����
    public void OnClickStoryStart()
    {
        print("OnClickStoryStart");
        // ���� scene�� Load �ϰ�ʹ�
        SceneManager.LoadScene("StoryStart");
        Time.timeScale = 1;
    }


    //���۹�ư�� ������ ����
    public void OnClickARStart()
    {
        print("OnClickARStart");
        // ���� scene�� Load �ϰ�ʹ�
        SceneManager.LoadScene("AR_LoadScene");
        Time.timeScale = 1;
    }
    //���۹�ư�� ������ ����
    public void OnClickStoryEnd()
    {
        print("OnClickOutro");
        // ���� scene�� Load �ϰ�ʹ�
        SceneManager.LoadScene("Outro");
        Time.timeScale = 1;
    }
}
