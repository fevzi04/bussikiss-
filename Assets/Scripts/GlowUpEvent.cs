using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


public class GlowUpEvent : MonoBehaviour
{

    [SerializeField] private Camera cam;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject glowUpMenu;
    [SerializeField] private GameObject TimeManager;
    [SerializeField] private GameObject black;


    PostProcessVolume volume;
    PlayerMovement playerMove;
    TimeManager time;
    Stats stats;


    bool isBought = false;
    bool isBought2 = false;

     void Start()
    {
        stats = player.GetComponent<Stats>();
        volume = cam.GetComponent<PostProcessVolume>();
        playerMove = player.GetComponent<PlayerMovement>();
        time = TimeManager.GetComponent<TimeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        volume.enabled = !volume.enabled;
        glowUpMenu.SetActive(true);
        playerMove.disableMovement();
        time.timePaused = true;
    }

    public void buyGlowUp1(){
        if((stats.money >= stats.ticketPrice) && (isBought == false))
        {
            stats.money -= 50;
            stats.outfit = 2;
            isBought = true;
            stats.look = 66;
            time.addMinute(180);
            StartCoroutine(transition());
        }
        leave();
    }
    public void buyGlowUp2(){
        if((stats.money >= stats.ticketPrice) && (isBought2 == false))
        {
            stats.money -= 100;
            stats.outfit = 3;
            isBought2 = true;
            stats.look = 100;
            time.addMinute(240);
        
            StartCoroutine(transition());
        
        }
        leave();
    }

     public void leave(){
        volume.enabled = !volume.enabled;
        glowUpMenu.SetActive(false);
        playerMove.enableMovement();
        time.timePaused = false;
    }

    IEnumerator transition(){
        black.SetActive(true);
        yield return new WaitForSeconds(1);
        black.SetActive(false);
    }
}
