using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimuladorInput : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            gmm.SM_GoToVideo();

        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            gmm.SM_GoToPlaying();
        }

    }
    public  GameManagerMain gmm;
}
