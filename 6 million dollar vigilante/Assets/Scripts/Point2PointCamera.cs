using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point2PointCamera : MonoBehaviour
{
    // list of locations that the camera will move to.
    public List<Transform> lstLocationPoints;
    // list of locations that the camera will look at.
    public List<Transform> lstLookAtPoints;

    // how long it takes for the camera to travel from one point to the next.
    public float fJumpDuration = 1.0f;

    // if the camera is to jump to the next point.
    private bool bJumpToNextPoint = false;

    // the next point the camera is to jump to.
    private int nNextPoint = 1;

    // if there is a lerp happening, let it happen.
    private bool bLerp = false;

    // how long the lerp has been happening for.
    private float fLerpCount = 0.0f;

    // Use this for initialization
    void Start()
    {
        // set the initial position of the camera
        transform.position = lstLocationPoints[0].position;

        // set where the camera looks at first
        transform.LookAt(lstLookAtPoints[0]);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
            bJumpToNextPoint = true;

        // if the camera jumps to the next point or not.
        if (bJumpToNextPoint)
        {
            // tell the lerp if check to lerp below
            bLerp = true;

            // set jump to next point to false so we can reuse it.
            bJumpToNextPoint = false;
        }

        // if going to lerp, continue it lerping.
        if (bLerp)
        {
            Debug.Log(fLerpCount / fJumpDuration);

            // increament the lerp count.
            fLerpCount += Time.deltaTime;

            // where the camera will jump next, over how long.
            transform.position = Vector3.Lerp(lstLocationPoints[nNextPoint - 1].position, lstLocationPoints[nNextPoint].position, fLerpCount / fJumpDuration);

            // where the camera will look next, over time.
            transform.LookAt(Vector3.Lerp(lstLookAtPoints[nNextPoint-1].position, lstLookAtPoints[nNextPoint].position, fLerpCount / fJumpDuration));
        }
        // when the lerp is finished.
        if (fLerpCount >= fJumpDuration)
        {
            // increment the next point counter.
            ++nNextPoint;

            // reset these values, we need to reuse them.
            bLerp = false;
            fLerpCount = 0.0f;
        }
    }
}

