using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    public float fHowLongUntilStart = 1;
    private float fCount = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        fCount += Time.deltaTime;

        if (fCount > fHowLongUntilStart)
            SceneManager.LoadScene(1);
    }
}
