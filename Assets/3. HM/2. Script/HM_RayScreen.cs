using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HM_RayScreen : MonoBehaviour
{
    public static HM_RayScreen instance;

    RaycastHit hit;

    public bool isRayOn = false;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        Debug.DrawLine(ray.origin, ray.direction * 100f, Color.red);

        Physics.Raycast(ray, out hit);

        if (hit.collider == null)
        {
            isRayOn = false;
            //GameScene_MGR.instance.isGamePasued = true;
            GameScene_MGR.instance.GamePasued();
        }
        else if (hit.collider.tag == "Stage")
        {
            isRayOn = true;
            //GameScene_MGR.instance.isGamePasued = false;
            GameScene_MGR.instance.GamePlay();
        }

    }
}
