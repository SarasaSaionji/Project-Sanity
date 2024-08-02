using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UImanager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI txtCoins, txtVictoryCondition;
    [SerializeField] GameObject victoryCondition;
    private static UImanager instance;


    private void Awake()
    {
        if  (instance == null)
        {
            instance = this;
            
        }
        else
        {
            Destroy(gameObject);
        }


    }

    
    public static UImanager MyInstance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("UImanager instance is null. Make sure the UImanager is present in the scene.");
            }

            return instance;
        }
    }

    public void UpdateCoinUI(int _coins, int _victoryCondition)
    {
        txtCoins.text = "Item Collected : " + _coins + " / " + _victoryCondition;
    }

    public void  ShowVictoryCondition(int _coins, int _victoryCondition) 
    {


        victoryCondition.SetActive(true);

        if (_coins <= 0)
        {
            txtVictoryCondition.text = "Item for ritual? , But where is it?" ;
        }
        else
        {
            txtVictoryCondition.text = "Not Enought Item , I need more :(" ;
        }
        
        
    }

    public void  HideVictoryCondition() 
    {
        victoryCondition.SetActive(false);
    } 
    


}
