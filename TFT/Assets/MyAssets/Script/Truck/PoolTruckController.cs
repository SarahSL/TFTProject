using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoolTruckController : MonoBehaviour
{
    public PoolTruckControllerInstanciables m_instanciables;
    

   // public GameObject[] nextTrucks;
    public Transform[] trucksPositions;

    private GameManagerPlaying gameManagerPlaying;
    private TruckAgent truckAgentComponent;
    private Text wareLink;
    private int id;
    private int idListaActual;


    private List<GameObject> nextTrucks;
    
    void Awake()
    {
        id = 0;
        idListaActual = 3;
        nextTrucks = new List<GameObject>();
    }
    public void Update()
    {
        if(id == idListaActual)
        {

            CreateListTruck();

            ControllerWareLink();
        }
    }
    public void CreateFirstTruckController()
    {
        gameManagerPlaying = FindObjectOfType<GameManagerPlaying>();

        wareLink = gameManagerPlaying.wareLinkText.GetComponentInChildren<Text>();
        CreateTruck(0).SetActive(true);
        CreateTruck(1).SetActive(true);
        CreateTruck(2).SetActive(true);
        CreateListTruck();
        ControllerWareLink();
    }
    private void CreateListTruck()
    {
        GameObject truck = CreateTruck(1);
        truck.SetActive(false);
        nextTrucks.Add(truck);

        GameObject truck2 = CreateTruck(1);
        truck2.SetActive(false);
        nextTrucks.Add(truck2);

        GameObject truck3 = CreateTruck(1);
        truck3.SetActive(false);
        nextTrucks.Add(truck3);
    }
    public void NewTruck(int oldPosition)
    {
        GameObject trucks = nextTrucks.Find(
            (x) => x.GetComponent<TruckAgent>().idTruck == idListaActual);
        trucks.transform.position = trucksPositions[oldPosition].position;
        truckAgentComponent = trucks.GetComponent<TruckAgent>();
        truckAgentComponent.positionTruck = oldPosition;

        trucks.SetActive(true);

        idListaActual++;

        ControllerWareLink();
    }
    private void ControllerWareLink()
    {
        wareLink.text = "";
        Debug.Log("CONTROLLER WARE LINKKKKKKKKK--------------");
        for (int i =idListaActual-3;i<nextTrucks.Count; i++)
        {
            Debug.Log("entra EN EL BUCLEEEEEEEEEEEEEEEEE");
            truckAgentComponent = nextTrucks[i].GetComponent<TruckAgent>();
            wareLink.text +="LOAD:  "+truckAgentComponent.load
                +" TYPE:  "+truckAgentComponent.typeLoadText.text+"\n";

            Debug.Log(wareLink.text);
        }
    }
    private GameObject CreateTruck(int pos)
    {
        var truck = Instantiate(m_instanciables.TruckControllerPrefab, trucksPositions[pos].position, Quaternion.identity);
        truck.transform.parent = trucksPositions[pos].gameObject.transform;
        truck.transform.localScale = new Vector3(1f, 1F, 1F);


        truckAgentComponent = truck.GetComponent<TruckAgent>();
        truckAgentComponent.positionTruck = pos;
        truckAgentComponent.idTruck = id;
        id++;
        return truck;
    }



    [System.Serializable]
    public class PoolTruckControllerInstanciables
    {
        public GameObject TruckControllerPrefab;


    }
}
