using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AmmoCount : MonoBehaviour
{

    public GameObject oPool;
    //public List<Image> images = new List<Image>();
    public List<GameObject> imagesGameObject = new List<GameObject>();
    //public GameObject[] bulletUIArray;

    public int bullets = 6;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        bullets = oPool.GetComponent<ObjectPool>().ObjectsAvailable();
        //print(bullets);
        switch (bullets)
        {
            default:
                imagesGameObject[0].SetActive(false);
                imagesGameObject[1].SetActive(false);
                imagesGameObject[2].SetActive(false);
                imagesGameObject[3].SetActive(false);
                imagesGameObject[4].SetActive(false);
                imagesGameObject[5].SetActive(false);
                break;
            case 6:
                for (int i = 0; i < 1; i++)
                {
                    imagesGameObject[i].SetActive(true);
                }
                imagesGameObject[1].SetActive(false);
                imagesGameObject[2].SetActive(false);
                imagesGameObject[3].SetActive(false);
                imagesGameObject[4].SetActive(false);
                imagesGameObject[5].SetActive(false);
                break;
            case 5:
                for (int i = 0; i < 2; i++)
                {
                    imagesGameObject[i].SetActive(true);
                }
                imagesGameObject[2].SetActive(false);
                imagesGameObject[3].SetActive(false);
                imagesGameObject[4].SetActive(false);
                imagesGameObject[5].SetActive(false);
                break;
            case 4:
                for (int i = 0; i < 3; i++)
                {
                    imagesGameObject[i].SetActive(true);
                }
                imagesGameObject[3].SetActive(false);
                imagesGameObject[4].SetActive(false);
                imagesGameObject[5].SetActive(false);
                break;
            case 3:
                for (int i = 0; i < 4; i++)
                {
                    imagesGameObject[i].SetActive(true);
                }
                imagesGameObject[4].SetActive(false);
                imagesGameObject[5].SetActive(false);
                break;
            case 2:
                for (int i = 0; i < 5; i++)
                {
                    imagesGameObject[i].SetActive(true);
                }
                imagesGameObject[5].SetActive(false);
                break;
            case 1:
                for (int i = 0; i < 6; i++)
                {
                    imagesGameObject[i].SetActive(true);
                }
                break;
        }
    }

}