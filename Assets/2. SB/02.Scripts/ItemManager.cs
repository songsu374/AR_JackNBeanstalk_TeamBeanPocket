using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    //1. 사다리를 타고 열쇠를 먹는다
    //2. 열쇠를 먹고 문을 연다
    //3. 문을 열고 나무판자를 집는다.
    //4. 나무판자를 잡고, 사다리를 타고 , 나무판자를 놓는다. => 잡고 움직이기
    //5. 나무판자를 타고 다리를 건너면 씨앗을 먹는다
    //6. 씨앗을 가지고 다시 내려와서 밭에 씨앗을 놓는다?
    //7. 씨앗을 밭에 놓으면 콩나무가 자라는 애니메이션? 연출이 일어난다.

    public static ItemManager instance;
    private void Awake()
    {
        instance = this;
    }

    public bool isKey;    //열쇠를 먹었는가
    public bool isSeed;   //씨앗을 먹었는가
    //public bool isLadder; //사다리
    public bool isWoodPlank; //나무판자를 잡았는가
    public bool isDoor;    //문을 열었는가

    [Header("아이템")]
    [SerializeField] GameObject Key;
    [SerializeField] GameObject Seed;
    //[SerializeField] GameObject Ladder;
    [SerializeField] GameObject WoodPlank;
    public GameObject Beanstalk; //콩나무
    public GameObject WoodPlankPutOff; //나중에 생기는 나무판자
    public GameObject Door;

    //다음 위치로 가라고 표시해주는 화살표
    public GameObject WoodPlankArrow;
    public GameObject DoorArrow;

    public GameObject BeanstalkArea;
    public GameObject OpenDoor;
    public GameObject WoodPlankArea;

    //새로운 나무판자길에 생기는 파티클효과
    public GameObject WoodPlankPutOffEFX;

    public bool isWoodEFX;

    [Header("UI")]
    public GameObject TextSeed;
    public GameObject TextCameraAround;
    public GameObject UI_Key;
    public GameObject UI_Wood;
    public GameObject UI_Seed;

    [Header("BGM")]
    public AudioSource BGM_Item;
    public AudioSource BGM_Beanstalk;
    public AudioSource BGM_Door;
    public AudioSource BGM_Wood;

    // Start is called before the first frame update
    void Start()
    {
        isKey = false;
        isSeed = false;
        //isLadder = false;
        isWoodPlank = false;
        isDoor = false;
        WoodPlankPutOff.SetActive(false);
        Beanstalk.SetActive(false);
        WoodPlankArrow.SetActive(false);
        TextSeed.SetActive(false);
        TextCameraAround.SetActive(true);
        UI_Key.SetActive(false);
        UI_Seed.SetActive(false);
        UI_Wood.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }

    //플레이어가 키를 먹었을 때
    public void OnKey()
    {
        isKey = true;
        StartCoroutine("IEOpenDoor");
    }
    //문에 충돌했을 때
    IEnumerator IEOpenDoor()
    {
        yield return new WaitForSeconds(0.5f);

        if (isKey == true)
        {
            //문이 열림

            isDoor = true;
        }
       
    }
    //나무판자와 충돌했을때
    public void OnWoodPlank()
    {
        if (isKey == true && isDoor == true)
        {
            isWoodPlank = true;
        }
    }

    //씨앗에 충돌했을 때
    public void OnSeed()
    {
        if (isWoodPlank == true)
        {
            isSeed = true;
        }
    }

    //밭에 씨앗 심기
    //콩나무 나오기
    IEnumerator IEOnPlant()
    {
        yield return new WaitForSeconds(0.5f);
        Beanstalk.SetActive(true);
    }

   


}
