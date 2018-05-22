using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OuterCrosshairRing : MonoBehaviour
{
    //// how long it takes for the camera to travel from one point to the next.
    //public float fJumpDuration = 1.0f;

    //// if the camera is to jump to the next point.
    //private bool bJumpToNextPoint = false;

    //// the next point the camera is to jump to.
    //private int nNextPoint = 1;

    //// if there is a lerp happening, let it happen.
    //private bool bLerp = false;

    //// how long the lerp has been happening for.
    //private float fLerpCount = 0.0f;

    public float spinRate;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<RectTransform>().Rotate(new Vector3(0, 0, spinRate));
        
    }

    private void ResizeCrossHair()
    {
        gameObject.GetComponent<RectTransform>().sizeDelta =
            new Vector2(gameObject.GetComponent<RectTransform>().localScale.x * 1000,
            gameObject.GetComponent<RectTransform>().localScale.y * 1000);
    }
}
