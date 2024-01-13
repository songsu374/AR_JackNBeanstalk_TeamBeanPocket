using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerItem : MonoBehaviour
{
    // Start is called before the first frame update

    

    void Start()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");


    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        //키와 충돌했을때
        if (collision.gameObject.CompareTag("Key"))
        {
            Debug.Log("키와 충돌");
            ItemManager.instance.isKey = true;

            ItemManager.instance.BGM_Item.Play();

            collision.gameObject.SetActive(false);
            ItemManager.instance.DoorArrow.SetActive(true);
            ItemManager.instance.UI_Key.SetActive(true);
        }
        else if (collision.gameObject.CompareTag("Door"))
        {
            if (ItemManager.instance.isKey == true)
            {
                ItemManager.instance.UI_Key.SetActive(false);

                //키가 있는 상태에서 문이랑 충돌했을 때
                ItemManager.instance.isDoor = true;

                Debug.Log("문이랑 충돌");
                ItemManager.instance.BGM_Door.Play();
                ItemManager.instance.DoorArrow.SetActive(false);

                ItemManager.instance.Door.GetComponent<Animator>().SetTrigger("OpenDoor");
                ItemManager.instance.Door.GetComponent<Animator>().enabled = false;
                ItemManager.instance.Door.GetComponent<Transform>().position = new Vector3(-4.33f, 1.22f, 9.47f);
                ItemManager.instance.Door.transform.Rotate(0f, -117.666f, 0f);
               Debug.Log("OpenDoor");
                ItemManager.instance.OpenDoor.GetComponent<BoxCollider>().isTrigger = true;
                ItemManager.instance.OpenDoor.SetActive(false);
            }

        }
        else if (collision.gameObject.CompareTag("WoodPlank"))
        {
            Debug.Log("나무판자이랑 충돌");
            if (ItemManager.instance.isKey == true && ItemManager.instance.isDoor == true)
            {
                ItemManager.instance.isWoodPlank = true;
                ItemManager.instance.BGM_Item.Play();

                collision.gameObject.SetActive(false);
                ItemManager.instance.WoodPlankArrow.SetActive(true);
                ItemManager.instance.OpenDoor.SetActive(false);

                ItemManager.instance.UI_Wood.SetActive(true);

            }

        }
        else if (collision.gameObject.CompareTag("WoodPlankArea"))
        {

            if (ItemManager.instance.isWoodPlank == true)
            {
                if (ItemManager.instance.isWoodEFX == false)
                {
                    ItemManager.instance.BGM_Wood.Play();
                    ItemManager.instance.UI_Wood.SetActive(false);

                    ItemManager.instance.WoodPlankArrow.SetActive(false);
                    ItemManager.instance.WoodPlankPutOff.GetComponentInChildren<ParticleSystem>().Play();

                    ItemManager.instance.WoodPlankPutOff.SetActive(true);
                    ItemManager.instance.WoodPlankArea.GetComponent<BoxCollider>().isTrigger = true;
                    ItemManager.instance.isWoodEFX = true;
                }
                else if (ItemManager.instance.isWoodEFX == true)
                {
                    ItemManager.instance.WoodPlankPutOff.GetComponentInChildren<ParticleSystem>().Stop();
                }
            }
            
        }
        else if (collision.gameObject.CompareTag("Seed"))
        {
            Debug.Log("씨앗이랑 충돌");
            ItemManager.instance.isSeed = true;
            ItemManager.instance.BGM_Item.Play();

            collision.gameObject.SetActive(false);
            ItemManager.instance.TextSeed.SetActive(true);
            ItemManager.instance.TextCameraAround.SetActive(false);
            ItemManager.instance.UI_Seed.SetActive(true);


        }
        else if (collision.gameObject.CompareTag("BeanstalkArea"))
        {

            if (ItemManager.instance.isSeed == true)
            {
                ItemManager.instance.UI_Seed.SetActive(false);

                ItemManager.instance.BGM_Beanstalk.Play();
                ItemManager.instance.Beanstalk.SetActive(true);
                CameraShake.instacne.Shake();
                ItemManager.instance.BeanstalkArea.GetComponentInChildren<ParticleSystem>().Play();
                ItemManager.instance.Beanstalk.GetComponent<Animator>().SetTrigger("Beanstalk");

                Invoke("SceneLoad", 4f);
            }
        }
    }
    void SceneLoad()
    {
        SceneManager.LoadScene("StoryEnd");
    }

}
