using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScene_MGR : MonoBehaviour
{
    public static GameScene_MGR instance;

    public GameObject gamePasueImg, gamePasueTxt;

    private void Awake()
    {
        instance = this;
    }

    public bool isGamePasued = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void GamePasued()
    {
            gamePasueImg.SetActive(true);
            gamePasueTxt.SetActive(true);

            Time.timeScale = 0;
    }

    public void GamePlay()
    {
        gamePasueImg.SetActive(false);
        gamePasueTxt.SetActive(false);

        Time.timeScale = 1;
    }
}
