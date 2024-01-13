using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARCore;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.SceneManagement;

public class HM_AR_Mgr : MonoBehaviour
{

    ARTrackedImageManager tracingImg;
    Dictionary<string, GameObject> spwanObj;

    public GameObject Pose_ToMap;
    

    int limit_CallBack = 0;

    private void Awake()
    {
        tracingImg = this.GetComponent<ARTrackedImageManager>();

        spwanObj = new Dictionary<string, GameObject>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //SceneLoad();
    }

    // Update is called once per frame
    void Update()
    {
  
           

    }

    private void OnEnable()
    {
        tracingImg.trackedImagesChanged += OnTrackedImaged;
    }

    private void OnDisable()
    {
        tracingImg.trackedImagesChanged -= OnTrackedImaged;
    }

    void OnTrackedImaged(ARTrackedImagesChangedEventArgs args)
    {
        foreach (ARTrackedImage tracked_img in args.added)
        {
            SceneLoad();
            UpdateObj(tracked_img);
            
        }

        foreach (ARTrackedImage tracked_img in args.updated)
        {
            UpdateObj(tracked_img);
        }

        foreach (ARTrackedImage tracked_img in args.removed)
        {
            UpdateObj(tracked_img);
        }

    }

    void UpdateObj(ARTrackedImage image)
    {
        Pose_ToMap.transform.position = image.transform.position;
        Pose_ToMap.transform.rotation = image.transform.rotation;
    }

    void SceneLoad()
    {
        SceneManager.LoadScene(3, LoadSceneMode.Additive);

        DontDestroyOnLoad(Pose_ToMap);
    }

    void StopObj()
    {

        limit_CallBack++;
    }
}
