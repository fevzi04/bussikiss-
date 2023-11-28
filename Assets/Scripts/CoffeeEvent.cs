using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CoffeeEvent : MonoBehaviour
{

    [SerializeField] private Camera cam;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject coffeeMenu;
    [SerializeField] private GameObject TimeManager;
    
    PostProcessVolume volume;
    Stats stats;
    PlayerMovement playerMove;
    TimeManager time;

    void Start()
    {
        volume = cam.GetComponent<PostProcessVolume>();
        stats = player.GetComponent<Stats>();
        playerMove = player.GetComponent<PlayerMovement>();
        time = TimeManager.GetComponent<TimeManager>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        volume.enabled = !volume.enabled;
    }

    public void buyCoffee(){
        if(stats.money >= stats.ticketPrice)
        {
            stats.money -= stats.ticketPrice;
            stats.caffeine += 5;
        }
        leave();
    }

     public void leave(){
        volume.enabled = !volume.enabled;
        coffeeMenu.SetActive(false);
        playerMove.enableMovement();
        time.timePaused = false;
    }
}
