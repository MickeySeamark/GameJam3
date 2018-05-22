using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrossHairMousePos : MonoBehaviour
{
    public Image crossHairImage;
    // Use this for initialization
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        crossHairImage.transform.position = Input.mousePosition;

    }
}
