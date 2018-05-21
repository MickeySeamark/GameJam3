//------------------------------------------------------------------------------------------
// Filename:        ObjectPool.cs
//
// Description:     This Object Pool is used for handling the bullets it 
//                  firstly instantiates objects equal to the 'number to pool' 
//                  and then toggles their active state on and off.
//
// Author:          Mitchell Cattini-Schultz
// Editors:         Mitchell Cattini-Schultz
//------------------------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    // To access the object pool.
    public static ObjectPool m_SharedInstance;
    // The list of objects in the pool.
    private List<GameObject> m_lstPooledObjects;

    //------------------------------------------------------------------------------------------
    // Object to Pool
    //------------------------------------------------------------------------------------------
    [Tooltip("This stores the object that will be used by the object pool.")]
    public GameObject m_goObjectToPool;

    //------------------------------------------------------------------------------------------
    // Amount to Pool
    //------------------------------------------------------------------------------------------
    [Tooltip("An int to choose how many object you want in the pool.")]
    public int m_nAmountToPool;
    
    //------------------------------------------------------------------------------------------
    // Use this for initialization, called even if the script is disabled.
    //------------------------------------------------------------------------------------------
    void Awake()
    {
        // This is a singleton there can only be one, this is its accessor.
        m_SharedInstance = this;
    }

    //------------------------------------------------------------------------------------------
    // Use this for initialization, called when the script is first accessed.
    //------------------------------------------------------------------------------------------
    private void Start()
    {
        // A list of the passed in gameobjects (in the inspector) is created.
        m_lstPooledObjects = new List<GameObject>();

        // For loop instantiates the selected objects m_nAmountToPool amount of times into the list.
        for (int i = 0; i < m_nAmountToPool; i++)
        {
            // Creation of object.
            GameObject goObj = Instantiate(m_goObjectToPool);
            // Initially setting all the objects to false.
            goObj.SetActive(false);
            // Adding the object to the list.
            m_lstPooledObjects.Add(goObj);
        }
    }

    //------------------------------------------------------------------------------------------
    // Update is called once per frame.
    //------------------------------------------------------------------------------------------
    void Update()
    {

    }

    //------------------------------------------------------------------------------------------
    // Gets the pooled objects and checks each one, if the checked object is inactive in the
    // hierarchy it turns it to be active and returns that object.
    // 
    // 
    // Return:
    //      Returns the pooled object if it was inactive in the hierarchy.
    //------------------------------------------------------------------------------------------
    public GameObject GetPooledObject()
    {
        // For loop through all the pooled objects.
        for (int i = 0; i < m_lstPooledObjects.Count; i++)
        {
            // If the checked pooled object is inactive in the hierarchy, activate it.
            if (!m_lstPooledObjects[i].activeInHierarchy)
            {
                m_lstPooledObjects[i].SetActive(true);

                return m_lstPooledObjects[i];
            }
        }

        // If the pooled object is already turned on don't return it. 
        return null;
    }
}