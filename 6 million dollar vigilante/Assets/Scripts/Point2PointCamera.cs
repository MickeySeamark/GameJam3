using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point2PointCamera : MonoBehaviour
{
    // the empty that contains all the camera loc points
    public GameObject goLocPoints = null;

    // the empty that contains all the camera look points
    public GameObject goLookPoints = null;

    // list of locations that the camera will move to.
    private List<Transform> lstLocationPoints;

    // list of locations that the camera will look at.
    private List<Transform> lstLookAtPoints;

    // how long it takes for the camera to travel from one point to the next.
    public float fJumpDuration = 1.0f;

    // the next point the camera is to jump to.
    private int nNextPoint = 1;

    // if there is a lerp happening, let it happen.
    private bool bLerp = false;

    // how long the lerp has been happening for.
    private float fLerpCount = 0.0f;
    

    // Use this for initialization
    void Start()
    {
        // creating a new list of location and look at points
        lstLocationPoints = new List<Transform>();
        lstLookAtPoints = new List<Transform>();

        // adding all the location points
        for (int i = 0; i < goLocPoints.transform.childCount; ++i)
            lstLocationPoints.Add(goLocPoints.transform.GetChild(i));

        // adding all the look points
        for (int i = 0; i < goLookPoints.transform.childCount; ++i)
            lstLookAtPoints.Add(goLookPoints.transform.GetChild(i));

        // set the initial position of the camera
        transform.position = lstLocationPoints[0].position;

        // set where the camera looks at first
        transform.LookAt(lstLookAtPoints[0]);
    }

    // Update is called once per frame
    void Update()
    {
        // if the camera jumps to the next point or not.
        if (RoundManager.bAllEnemiesDead)
        {
            // tell the lerp if check to lerp below
            bLerp = true;
        }

        // if going to lerp, continue it lerping.
        if (bLerp)
        {
            // increament the lerp count.
            fLerpCount += Time.deltaTime;

            if (nNextPoint < lstLocationPoints.Count)
            {
                // where the camera will jump next, over how long.
                transform.position = Vector3.Lerp(lstLocationPoints[nNextPoint - 1].position, lstLocationPoints[nNextPoint].position, fLerpCount / fJumpDuration);

                // where the camera will look next, over time.
                transform.LookAt(Vector3.Lerp(lstLookAtPoints[nNextPoint - 1].position, lstLookAtPoints[nNextPoint].position, fLerpCount / fJumpDuration));
            }
        }
        // when the lerp is finished.
        if (fLerpCount >= fJumpDuration)
        {
            // increment the next point counter.
            ++nNextPoint;

            // increment round count
            ++RoundManager.nCurrRound;

            // reset these values, we need to reuse them.
            bLerp = false;
            fLerpCount = 0.0f;

            RoundManager.bAllEnemiesDead = false;
            RoundManager.nHowManyDead = 0;
        }
    }
}

