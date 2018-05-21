using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AmmoCount : MonoBehaviour
{

    public GameObject oPool;
    public List<Image> images = new List<Image>();
    public int bullets = 6;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //int bullets = oPool.GetComponent<ObjectPool>().ObjectsAvailable();
        switch (bullets)
        {
            default:
                images[0].GetComponent<Image>().enabled = false;
                images[1].GetComponent<Image>().enabled = false;
                images[2].GetComponent<Image>().enabled = false;
                images[3].GetComponent<Image>().enabled = false;
                images[4].GetComponent<Image>().enabled = false;
                images[5].GetComponent<Image>().enabled = false;
                break;
            case 1:
                for (int i = 0; i < 1; i++)
                {
                    images[i].GetComponent<Image>().enabled = true;
                }
                images[1].GetComponent<Image>().enabled = false;
                images[2].GetComponent<Image>().enabled = false;
                images[3].GetComponent<Image>().enabled = false;
                images[4].GetComponent<Image>().enabled = false;
                images[5].GetComponent<Image>().enabled = false;
                break;
            case 2:
                for (int i = 0; i < 2; i++)
                {
                    images[i].GetComponent<Image>().enabled = true;
                }
                images[2].GetComponent<Image>().enabled = false;
                images[3].GetComponent<Image>().enabled = false;
                images[4].GetComponent<Image>().enabled = false;
                images[5].GetComponent<Image>().enabled = false;
                break;
            case 3:
                for (int i = 0; i < 3; i++)
                {
                    images[i].GetComponent<Image>().enabled = true;
                }
                images[3].GetComponent<Image>().enabled = false;
                images[4].GetComponent<Image>().enabled = false;
                images[5].GetComponent<Image>().enabled = false;
                break;
            case 4:
                for (int i = 0; i < 4; i++)
                {
                    images[i].GetComponent<Image>().enabled = true;
                }
                images[4].GetComponent<Image>().enabled = false;
                images[5].GetComponent<Image>().enabled = false;
                break;
            case 5:
                for (int i = 0; i < 5; i++)
                {
                    images[i].GetComponent<Image>().enabled = true;
                }
                images[5].GetComponent<Image>().enabled = false;
                break;
            case 6:
                for (int i = 0; i < 6; i++)
                {
                    images[i].GetComponent<Image>().enabled = true;
                }
                break;

        }

    }

}