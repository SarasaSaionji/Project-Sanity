using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationForCoin : MonoBehaviour
{
    public GameObject MoveItemCoin;


    public GameObject[] spawnPointsForCoin;


    private int CurrentDestination = 0;



    public void runfunctionCoin()
    {
        MoveItemToRandomSpawnPoint();



    }


    

    public void MoveItemToRandomSpawnPoint()
    {
        // Get the index of a random spawn position
        int newDestination = NumberOfDestinationSpawnCoin();

        MoveItemCoin.transform.position = spawnPointsForCoin[newDestination].transform.position;  // Correct variable name

        CurrentDestination = newDestination;
    }

    int NumberOfDestinationSpawnCoin()
    {
        int selectedSpawnIndex;

        do
        {
            selectedSpawnIndex = Random.Range(0, spawnPointsForCoin.Length);  // Correct variable name
        } while (selectedSpawnIndex == CurrentDestination);

        Debug.Log("ได้หมายเลข: " + selectedSpawnIndex);
        return selectedSpawnIndex;
    }
}



