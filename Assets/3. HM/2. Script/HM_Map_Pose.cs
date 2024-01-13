using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HM_Map_Pose : MonoBehaviour
{
    public GameObject pose_ToMap;

    // Start is called before the first frame update
    void Start()
    {
        pose_ToMap = GameObject.Find("SavePose_Mgr");

        
    }

    // Update is called once per frame
    void Update()
    {

        SetMapPose();

    }

    void SetMapPose()
    {
        this.transform.position = pose_ToMap.transform.position;

        this.transform.rotation = pose_ToMap.transform.rotation;
    }
}
