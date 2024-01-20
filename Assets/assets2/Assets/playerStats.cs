using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStats : MonoBehaviour
{
    [SerializeField] private float Hp;
    [SerializeField] private GameObject gameOverPage;
    [SerializeField] private GameObject joystick;
    public Sprite deathImage;
    
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void getHit(float dmg)
    {
        Hp -= dmg;
        GameObject.FindWithTag("GameManager").GetComponent<gameManager>().setHp(Hp);
        if (Hp <= 0)
        {
            GetComponent<SpriteRenderer>().sprite = deathImage;
            gameOverPage.SetActive(true);
            joystick.SetActive(false);
            GameObject.FindWithTag("GameManager").GetComponent<gameManager>().stopTime();
        }
        //Debug.Log(Hp);
    }
}
