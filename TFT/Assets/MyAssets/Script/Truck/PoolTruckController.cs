using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolTruckController : MonoBehaviour
{
    public PoolTruckControllerInstanciables m_instanciables;
    public Transform[] trucksPositions;
    // Use this for initialization
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void CreateFirstTruckController()
    {
        CreateTruck(0);
        CreateTruck(1);
        CreateTruck(2);

    }


    [System.Serializable]
    public class PoolTruckControllerInstanciables
    {
        public GameObject TruckControllerPrefab;


    }
    
    private void CreateTruck(int pos)
    {
        var truck = Instantiate(m_instanciables.TruckControllerPrefab, trucksPositions[pos].position, Quaternion.identity);
        truck.transform.parent = trucksPositions[pos].gameObject.transform;
        truck.transform.localScale = new Vector3(1f, 1F, 1F);
    }
}
