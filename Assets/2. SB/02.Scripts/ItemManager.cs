using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    //1. ��ٸ��� Ÿ�� ���踦 �Դ´�
    //2. ���踦 �԰� ���� ����
    //3. ���� ���� �������ڸ� ���´�.
    //4. �������ڸ� ���, ��ٸ��� Ÿ�� , �������ڸ� ���´�. => ��� �����̱�
    //5. �������ڸ� Ÿ�� �ٸ��� �ǳʸ� ������ �Դ´�
    //6. ������ ������ �ٽ� �����ͼ� �翡 ������ ���´�?
    //7. ������ �翡 ������ �ᳪ���� �ڶ�� �ִϸ��̼�? ������ �Ͼ��.

    public static ItemManager instance;
    private void Awake()
    {
        instance = this;
    }

    public bool isKey;    //���踦 �Ծ��°�
    public bool isSeed;   //������ �Ծ��°�
    //public bool isLadder; //��ٸ�
    public bool isWoodPlank; //�������ڸ� ��Ҵ°�
    public bool isDoor;    //���� �����°�

    [Header("������")]
    [SerializeField] GameObject Key;
    [SerializeField] GameObject Seed;
    //[SerializeField] GameObject Ladder;
    [SerializeField] GameObject WoodPlank;
    public GameObject Beanstalk; //�ᳪ��
    public GameObject WoodPlankPutOff; //���߿� ����� ��������
    public GameObject Door;

    //���� ��ġ�� ����� ǥ�����ִ� ȭ��ǥ
    public GameObject WoodPlankArrow;
    public GameObject DoorArrow;

    public GameObject BeanstalkArea;
    public GameObject OpenDoor;
    public GameObject WoodPlankArea;

    //���ο� �������ڱ濡 ����� ��ƼŬȿ��
    public GameObject WoodPlankPutOffEFX;

    public bool isWoodEFX;

    [Header("UI")]
    public GameObject TextSeed;
    public GameObject TextCameraAround;

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
    }

    // Update is called once per frame
    void Update()
    {

    }

    //�÷��̾ Ű�� �Ծ��� ��
    public void OnKey()
    {
        isKey = true;
        StartCoroutine("IEOpenDoor");
    }
    //���� �浹���� ��
    IEnumerator IEOpenDoor()
    {
        yield return new WaitForSeconds(0.5f);

        if (isKey == true)
        {
            //���� ����

            isDoor = true;
        }
       
    }
    //�������ڿ� �浹������
    public void OnWoodPlank()
    {
        if (isKey == true && isDoor == true)
        {
            isWoodPlank = true;
        }
    }

    //���ѿ� �浹���� ��
    public void OnSeed()
    {
        if (isWoodPlank == true)
        {
            isSeed = true;
        }
    }

    //�翡 ���� �ɱ�
    //�ᳪ�� ������
    IEnumerator IEOnPlant()
    {
        yield return new WaitForSeconds(0.5f);
        Beanstalk.SetActive(true);
    }

   


}
