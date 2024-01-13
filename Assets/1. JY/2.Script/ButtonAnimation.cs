using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAnimation : MonoBehaviour
{
    float time;
    public GameObject jack;

    Animator anim;
    Image image;

    public static ButtonAnimation instance;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
        image = GetComponent<Image>();
        image.enabled = false;
        anim.enabled = false;
    }

    void Update()
    {
        Invoke("ChangeSize", 4f);

    }

    void ChangeSize()
    {
        image.enabled = true;
        anim.enabled = true;
        anim.Play("Button");
    }
}
