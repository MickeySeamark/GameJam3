using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OuterCrosshairRing : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ResizeCrossHair();
        }
    }

    private void ResizeCrossHair()
    {
        gameObject.GetComponent<RectTransform>().sizeDelta = 
            new Vector2(gameObject.GetComponent<RectTransform>().localScale.x * 5, gameObject.GetComponent<RectTransform>().localScale.x * 5);
    }
}
