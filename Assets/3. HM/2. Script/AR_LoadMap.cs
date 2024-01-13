using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARCore;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class AR_LoadMap : MonoBehaviour
{

    ARTrackedImageManager trackingImg;
    Dictionary<string, GameObject> spwanObj;

    public GameObject map_Prefeb;

    private void Awake()
    {
        trackingImg = this.GetComponent<ARTrackedImageManager>();

        spwanObj = new Dictionary<string, GameObject>();

        GameObject temp = Instantiate(map_Prefeb);
        temp.name = map_Prefeb.name;
        temp.SetActive(false);


        spwanObj.Add(temp.name, temp);
    }

    private void OnEnable()
    {
        trackingImg.trackedImagesChanged += OnTrackedImaged;
    }

    private void OnDisable()
    {
        trackingImg.trackedImagesChanged -= OnTrackedImaged;
    }

    void OnTrackedImaged(ARTrackedImagesChangedEventArgs args)
    {
        foreach (ARTrackedImage tracked_img in args.added)
        {
            UpdateObj(tracked_img);
        }

        foreach (ARTrackedImage tracked_img in args.updated)
        {
            //UpdateObj(tracked_img);
        }

        //foreach (ARTrackedImage tracked_img in args.added)
        //{
        //    UpdateObj(tracked_img);
        //}
    }

    void UpdateObj(ARTrackedImage img)
    {
        string loadname = img.referenceImage.name;
        spwanObj[loadname].SetActive(true);
        spwanObj[loadname].transform.position = img.transform.position;
        spwanObj[loadname].transform.rotation = img.transform.rotation;

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
