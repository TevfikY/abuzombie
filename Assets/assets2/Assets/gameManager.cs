using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{

    [SerializeField] private Text goldText;
    [SerializeField] private Text ammoText;
    [SerializeField] private Text hpText;
    private bool isTimeRunning = true;
    private static float gold;
    private static float Ammo;
    private static int Hp;
    [SerializeField] private GameObject weapon1;
    [SerializeField] private GameObject weapon2;
    [SerializeField] private GameObject market;
    private Transform PlayerTransform;
    private Vector3 playerRot;
    
    void Start()
    {
        gold = 0;
        Hp = 100;
        goldText.text = gold.ToString();
        ammoText.text = Ammo.ToString();
        playerRot = new Vector3(0, 0, 0);
        hpText.text = Hp.ToString();

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

    public void weapon1Buy()
    {
        
        if (gold >= 100)
        {
            
            GameObject player = GameObject.FindWithTag("Player");
            GameObject oldGun = GameObject.FindWithTag("Gun");
            GameObject selected = weapon1;

            
            Destroy(oldGun);
            player.GetComponent<CircleCollider2D>().radius = 15;
            //Destroy(GameObject.FindWithTag("Gun"));
            Instantiate(selected,transform.position, player.transform.rotation);
            market.SetActive(false);
            resumeTime();
        }
    }
    
    public void weapon2Buy()
    {
        
        if (gold >= 200)
        {
            
            GameObject player = GameObject.FindWithTag("Player");
            GameObject oldGun = GameObject.FindWithTag("Gun");
            GameObject selected = weapon2;

            
            Destroy(oldGun);
            
            //Destroy(GameObject.FindWithTag("Gun"));
            player.GetComponent<CircleCollider2D>().radius = 15;
            Instantiate(selected,transform.position, player.transform.rotation);
            market.SetActive(false);
            resumeTime();
        }
    }

    public void setAmmo( string ammo)
    {

        ammoText.text = ammo;
    }

    public void setHp(float hp)
    {
        hpText.text = hp.ToString();
    }

    public void restartGame()
    {
       // SceneManager.LoadScene()
        SceneManager.LoadScene("LevelScene");
    }

    public void closeMarket()
    {
            Time.timeScale = 1f; 
            isTimeRunning = true;
            market.SetActive(false);
            
            
        
    }
}
