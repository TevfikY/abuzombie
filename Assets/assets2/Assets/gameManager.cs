using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{

    [SerializeField] private Text goldText;
    private bool isTimeRunning = true;
    private static float gold;
    [SerializeField] private List<GameObject> case1Guns;
    [SerializeField] private GameObject market;
    private Transform PlayerTransform;
    private Vector3 playerRot;
    
    void Start()
    {
        gold = 300;
        goldText.text = gold.ToString();
        
        playerRot = new Vector3(0, 0, 0);

    }
    

    // Update is called once per frame
    void Update()
    {
        if (isTimeRunning)
        {
            Time.timeScale = 1;
            
        }
        else
        {
            Time.timeScale = 0;
        }
    }
    
    public void stopTime()
    {
        
        isTimeRunning = false;
        
    }

    public void resumeTime()
    {
        isTimeRunning = true;
        
    }

    public  void addGold(float newGold)
    {
        gold += newGold;
        goldText.text = gold.ToString();
    }

    public void case1()
    {
        
        if (gold >= 300)
        {
            
            GameObject player = GameObject.FindWithTag("Player");
            GameObject oldGun = GameObject.FindWithTag("Gun");
            GameObject selected = case1Guns[Random.Range(0, case1Guns.Count)];

            
            Destroy(oldGun);
            
            //Destroy(GameObject.FindWithTag("Gun"));
            Instantiate(selected,transform.position, player.transform.rotation);
            market.SetActive(false);
            resumeTime();
        }
    }
    
}
