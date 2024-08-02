using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScareTrigger : MonoBehaviour
{
    public AudioSource Scream;
    public GameObject FlashImg;
    public SanityManager sanityManager;
    public GameObject[] spawnPoints;
    private Rigidbody2D Gravity;

    private int hasTriggered = 1;
    private int previousSpawnIndex = -1;
    private bool isRespawning = false;
    private int GetArrayNumber = -1;
    private GameObject spawnedObject;
    public GameObject Coin_0;
    public GameObject Coin_1;
    public GameObject Coin_2;
    public GameObject Coin_3;
    public GameObject Coin_4;

    public DestinationForCoin destinationForCoin;
    public DestinationForCoin destinationForCoin1;
    public DestinationForCoin destinationForCoin2;
    public DestinationForCoin destinationForCoin3;
    public DestinationForCoin destinationForCoin4;

    void Start()
    {
        Gravity = GetComponent<Rigidbody2D>();
        StartCoroutine(NotTriggeredRespawnTimer());
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (hasTriggered == 1 && other.CompareTag("Player"))
        {
            hasTriggered += 1;

            Scream.Play();
            FlashImg.SetActive(true);
            StartCoroutine(EndJump());

            // ลดค่า sanity ลง 60 หน่วย
            sanityManager.ReduceSanity(120);
        if (destinationForCoin != null && Coin_0 != null && Coin_0.activeSelf)
        {
            destinationForCoin.runfunctionCoin();
        }

        if (destinationForCoin1 != null && Coin_1 != null && Coin_1.activeSelf)
        {
            destinationForCoin1.runfunctionCoin();
        }

        if (destinationForCoin2 != null && Coin_2 != null && Coin_2.activeSelf)
        {
            destinationForCoin2.runfunctionCoin();
        }

        if (destinationForCoin3 != null && Coin_3 != null && Coin_3.activeSelf)
        {
            destinationForCoin3.runfunctionCoin();
        }

        if (destinationForCoin4 != null && Coin_4 != null && Coin_4.activeSelf)
        {
            destinationForCoin4.runfunctionCoin();
        }

            
        }

    }

    IEnumerator EndJump()
    {
        isRespawning = true;
        yield return StartCoroutine(RespawnObject());
        isRespawning = false;

        turnOffJumpscare();
        FlashImg.SetActive(false);
        StartCoroutine(CloseFlashImg());

        // ตรวจสอบค่า previousSpawnIndex หลังจากกระบวนการ EndJump
        Debug.Log("After EndJump - previousSpawnIndex: " + previousSpawnIndex);
    }


    IEnumerator RespawnObject()
    {
        yield return new WaitForSeconds(2.1f);
        int selectedSpawnIndex = GetUniqueSpawnIndex();
        GetArrayNumber = selectedSpawnIndex;
        Debug.Log("SpawnPoint Respawn After jumped " + selectedSpawnIndex + ": " + spawnPoints[selectedSpawnIndex].transform.position);

        yield return StartCoroutine(SpawnObject(GetArrayNumber));
    }


    IEnumerator NotTriggeredRespawnTimer()
    {
        yield return new WaitForSeconds(8.0f);

        // Check if respawning is not in progress before starting a new respawn
        if (!isRespawning)
        {
            
            
            int selectedSpawnIndex = GetUniqueSpawnIndex();
            GetArrayNumber = selectedSpawnIndex;
            Debug.Log("SpawnPoint Not triger " + selectedSpawnIndex + ": " + spawnPoints[selectedSpawnIndex].transform.position);

            yield return StartCoroutine(SpawnObject(GetArrayNumber));
        }
    }
    int GetUniqueSpawnIndex()
    {
        int selectedSpawnIndex;
        
        do
        {
            selectedSpawnIndex = Random.Range(0, spawnPoints.Length);

            

        } while (selectedSpawnIndex == GetArrayNumber);


        Debug.Log("Get number" + selectedSpawnIndex + " Sending " + selectedSpawnIndex);
        return selectedSpawnIndex;
    }



    IEnumerator SpawnObject(int spawnIndex)
    {
        GameObject selectedSpawnPoint = spawnPoints[spawnIndex];
        Vector3 respawnPosition = selectedSpawnPoint.transform.position;

        // สร้าง Object ใหม่
        spawnedObject = Instantiate(this.gameObject, respawnPosition, Quaternion.identity);

        // รอให้ Unity ทำงานต่อจาก Instantiate
        yield return null;

        // กำหนดค่า GetArrayNumber ให้กับ Object ใหม่
        JumpScareTrigger newJumpScareTrigger = spawnedObject.GetComponent<JumpScareTrigger>();
        if (newJumpScareTrigger != null)
        {
            newJumpScareTrigger.GetArrayNumber = GetArrayNumber;
        }

        // ทำลาย Object เดิม
        Destroy(this.gameObject);
    }
    
    


    void turnOffJumpscare()
    {
        // FlashImg.SetActive(false); // ย้ายไปที่ EndJump() แล้ว
    }

    IEnumerator CloseFlashImg()
    {
        yield return new WaitForSeconds(0.01f); // ปรับเวลาตามความเหมาะสม
        FlashImg.SetActive(false);
    }



 
}
