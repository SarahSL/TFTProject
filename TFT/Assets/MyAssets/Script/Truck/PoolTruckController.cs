using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoolTruckController : MonoBehaviour
{
    public PoolTruckControllerInstanciables m_instanciables;
    

    public GameObject[] nextTrucks;
    public Transform[] trucksPositions;

    private GameManagerPlaying gameManagerPlaying;
    private int trucksListInt;
    private TruckAgent truckAgentComponent;
    private Text wareLink;
    private int truckStatePos;

    // Use this for initialization
    void Awake()
    {
        trucksListInt = 8;
        truckStatePos = 0;
        nextTrucks = new GameObject[8];
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void CreateFirstTruckController()
    {
        gameManagerPlaying = FindObjectOfType<GameManagerPlaying>();
        CreateTruck(0).SetActive(true);
        CreateTruck(1).SetActive(true);
        CreateTruck(2).SetActive(true);
        CreateListTruck();
    }
    public void NewTruck(int oldPosition)
    {
        
        if (truckStatePos > 8)
        {
            truckStatePos = 0;
            CreateListTruck();
        }
        nextTrucks[truckStatePos].transform.position = trucksPositions[oldPosition].gameObject.transform.position;
        truckAgentComponent = nextTrucks[truckStatePos].GetComponent<TruckAgent>();
        truckAgentComponent.idTruck = oldPosition;
        nextTrucks[truckStatePos].SetActive(true);
        SetWareLinktText(truckStatePos);
        truckStatePos++;


    }
    private void CreateListTruck()
    {
        wareLink =  gameManagerPlaying.wareLinkText.GetComponentInChildren<Text>();

        for(int i = 0; i < trucksListInt; i++)
        {
            nextTrucks[i] = CreateTruck(1);
            nextTrucks[i].SetActive(false);
            if (i < 3)
            {
                truckAgentComponent = nextTrucks[i].GetComponent<TruckAgent>();
                wareLink.text += "LOAD: " + truckAgentComponent.load + "    TYPE: " 
                    + truckAgentComponent.typeLoadText.text +"\n";
            }
        }
    }
    private GameObject CreateTruck(int pos)
    {
        var truck = Instantiate(m_instanciables.TruckControllerPrefab, trucksPositions[pos].position, Quaternion.identity);
        truck.transform.parent = trucksPositions[pos].gameObject.transform;
        truck.transform.localScale = new Vector3(1f, 1F, 1F);


        truckAgentComponent = truck.GetComponent<TruckAgent>();
        truckAgentComponent.idTruck = pos;
        return truck;
    }
    
    private void SetWareLinktText( int truckStatePos)
    {
        if(truckStatePos < truckStatePos + 2)
        {
            truckAgentComponent = nextTrucks[truckStatePos + 1].GetComponent<TruckAgent>();
            wareLink.text = "LOAD: " + truckAgentComponent.load + "    TYPE: " + truckAgentComponent.typeLoadText.text + "\n";


            truckAgentComponent = nextTrucks[truckStatePos + 2].GetComponent<TruckAgent>();
            wareLink.text += "LOAD: " + truckAgentComponent.load + "    TYPE: " + truckAgentComponent.typeLoadText.text + "\n";
        }
    }




    [System.Serializable]
    public class PoolTruckControllerInstanciables
    {
        public GameObject TruckControllerPrefab;


    }
}
