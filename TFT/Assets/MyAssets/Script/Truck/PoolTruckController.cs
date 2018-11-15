using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolTruckController : MonoBehaviour {
    public PoolTruckControllerInstanciables m_instanciables;
    public Transform[] trucksPositions;
	// Use this for initialization
	void Awake () {
        trucksPositions[0] = GameObject.FindGameObjectWithTag("PointTruckRight").transform;
        trucksPositions[1] = GameObject.FindGameObjectWithTag("PointTruckCenter").transform;
        trucksPositions[2] = GameObject.FindGameObjectWithTag("PointTruckLeft").transform;
        Debug.Log("TRUCKS POSITIONS TRANSFORMS NO ESTA VACIO" + trucksPositions[0]);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void CreateFirstTruckController()
    {
        var TruckRight = Instantiate( m_instanciables.TruckControllerPrefab, trucksPositions[0].position, Quaternion.identity);
       // TruckRight.transform.parent = gameObject.transform;
        
    }


    [System.Serializable]
    public class PoolTruckControllerInstanciables
    {
        public GameObject TruckControllerPrefab;


    }
}
