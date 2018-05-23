using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Main Camera.
    [Tooltip("This is for the Main Camera. It allows for the mouse to interact with the screen for shooting where you click.")]
    public Camera MainCamera;

    // The layers that interact when clicked on.
    [Tooltip("This must be set to the setting everything. It means that the mouse can shoot anywhere.")]
    public LayerMask layerMask;

    // Empty GameObject that is where the bullets get shot from.
    [Tooltip("This is where the bullets shoot from. The empty game object positioned at the end of the gun.")]
    public GameObject shootSpot;

    // Empty GameObject that is where the bullets come back to when R is pressed.
    [Tooltip("This is where the bullets come back to when the magnet is used. It is best to use an empty game object for this.")]
    public Transform BulletsReloadSpot;

    // Shoot speed.
    [Tooltip("The speed that the bullets are fired at. Default is 75.")]
    public float shootSpeed = 75;

    // RELOAD
    // How long it takes the bullets to reload.
    [Tooltip("The amount of time in seconds that it takes for the bullets to disappear after magnet.")]
    public float reloadDuration = 1.0f;

    // Stores the bullets location for the magnet.
    private List<Transform> BulletsLocations;

    // The position to shoot the bullets at.
    private Vector3 shootLocation;

    private Vector3 mouseLocation;

    // Access to the shoot script.
    private GameObject shoot;

    // Whether the player is out of ammo or not.
    private bool outOfAmmo;

    // shotCount
    private int shotCount;

    // if the bullets are being pulled back
    private bool bBulletsLerp;

    // the count for bullets lerping back to the gun.
    private float fBulletsLerpCount;

    // Use this for initialization
    void Start()
    {
        bBulletsLerp = false;
        fBulletsLerpCount = 0.0f;
        layerMask = ~(LayerMask.NameToLayer("Enemy"));
        BulletsLocations = new List<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mouseLocation.z > (transform.position.z + 1))
        {
            Vector3 invalidPos;
            invalidPos = mouseLocation;
            invalidPos.y = 0.0f;

            gameObject.transform.LookAt(invalidPos);
        }
        // Checks amount of ammo to see whether
        // they have any ammo left to shoot.
        AmmoAmountCheck();

        // Raycast to screen
        RayCheck();

        // Shoot function
        Shoot();


        // Magnetic Pull(Reload)
        MagneticPull();
    }


    //--------------------------------------------
    // functions
    //--------------------------------------------

    /*
     *   Shoot, it shoots a bullet at the mouse's pos.
     */
    void Shoot()
    {

        // Rootin' Tootin' Shootin' 
        if (Input.GetKeyDown(KeyCode.Mouse0) && !outOfAmmo && ObjectPool.m_SharedInstance.ObjectsAvailable() <= ObjectPool.m_SharedInstance.m_nAmountToPool)
        {
            // Get access to the bullet in the object pool.
            GameObject copy = ObjectPool.m_SharedInstance.GetPooledObject();

            // Set the spawn point of the bullet at the players arm position.
            copy.transform.position = shootSpot.transform.position; /*+ shootSpot.transform.forward + shootSpot.transform.up;*/

            // Get the snowballs rigidbody
            Rigidbody rb = copy.GetComponent<Rigidbody>();

            copy.transform.LookAt(shootLocation);

            // Apply a 'shooting' force to the bullet.
            rb.AddForce(copy.transform.forward * shootSpeed, ForceMode.Impulse);

            //// Tell the animator the bullet is finished being shot.
            //m_Animator.SetBool("shooting", false);

            shotCount++;
            transform.GetChild(1).GetComponent<Animator>().SetBool("Shooting", true);
        }
        //
    }

    /* 
     *  Magnetic pull the bullets back to the player
     *   This is the same as reloading.
     */
    void MagneticPull()
    {
        // reload gun
        if (Input.GetKeyDown(KeyCode.R))
        {
            bBulletsLerp = true;

            // save the positions of the bullets, for lerping
            for (int i = 0; i < ObjectPool.m_SharedInstance.m_nAmountToPool; ++i)
            {
                BulletsLocations.Add(ObjectPool.m_SharedInstance.GetObject(i).transform);
            }
        }

        // whilst bullets reloading
        if (bBulletsLerp)
        {
            // increament the lerp count.
            fBulletsLerpCount += Time.deltaTime;

            // the bullets travelling from their positions to the gun
            for (int i = 0; i < ObjectPool.m_SharedInstance.m_nAmountToPool; ++i)
                ObjectPool.m_SharedInstance.GetObject(i).transform.position = Vector3.Lerp(BulletsLocations[i].position, BulletsReloadSpot.position, fBulletsLerpCount / reloadDuration);

        }
        // after the bullets are reloaded
        if (fBulletsLerpCount >= reloadDuration)
        {

            for (int i = 0; i < ObjectPool.m_SharedInstance.m_nAmountToPool; ++i)
            {
                ObjectPool.m_SharedInstance.GetObject(i).GetComponent<Rigidbody>().useGravity = false;
            }
            // delete all bullets
            ObjectPool.m_SharedInstance.DestroyAll();
            // reset these values, we need to reuse them.
            bBulletsLerp = false;
            fBulletsLerpCount = 0.0f;
            shotCount = 0;
        }
    }

    /*
     * Checks the ammo amount to see whether there are still bullets available.
     */
    void AmmoAmountCheck()
    {
        if (shotCount > 6)
        {
            outOfAmmo = true;
        }
    }

    /*
     * Mouse click to screen using a raycast. 
     * It shoots a raycast where clicked on the screen and shoots the 
     * bullet at the position that the ray hits somehthing.
     */
    void RayCheck()
    {
        RaycastHit hit; // Information on what a raycast hits
        Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition); // Ray to use when raycasting

        if (Physics.Raycast(ray, out hit, 1000.0f, layerMask)) // Sends raycast and checks if anything is hit
        {
            Transform objectHit = hit.transform; // Stores the hit object
            mouseLocation = hit.point;

            if (Input.GetKeyDown(KeyCode.Mouse0)) // Checks if left mouse button is pressed
            {
                //objectHit.GetComponent<Rigidbody>().AddForce(0, 0, 200.0f); // Applies a force to the object hit
                //hitTransform.position = hit.transform.position;

                shootLocation = hit.point;
            }
        }
        //Debug.Log(Input.mousePosition);
    }

    public float GetReloadDuration()
    {
        return reloadDuration;
    }


}
