using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class BusEventCheck : MonoBehaviour
{

    [SerializeField] private Camera cam;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject busMenu;
    [SerializeField] private GameObject TimeManager;
    [SerializeField] private GameObject black;
    
    PostProcessVolume volume;
    Stats stats;
    PlayerMovement playerMove;
    TimeManager time;
    // Start is called before the first frame update
    void Start()
    {  
        volume = cam.GetComponent<PostProcessVolume>();
        stats = player.GetComponent<Stats>();
        playerMove = player.GetComponent<PlayerMovement>();
        time = TimeManager.GetComponent<TimeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        volume.enabled = !volume.enabled;
        busMenu.SetActive(true);
        playerMove.disableMovement();
        time.timePaused = true;
    }

    public void buyBusTicket(){
        if(stats.money >= stats.ticketPrice)
        {
            stats.money -= stats.ticketPrice;
            stats.tickets++;
        }
        leave();
    }

    public void busCompany(){
        if(stats.tickets >= 1){
        player.transform.position = new Vector2(-20,-20);
        stats.tickets--;
        time.addMinute(45);
        StartCoroutine(transition());
        }
        leave();
    }

    public void busHome(){
        if(stats.tickets >= 1){
        player.transform.position = new Vector2(10.5f,1.5f);
        stats.tickets--;
        time.addMinute(45);
        StartCoroutine(transition());
        }
        leave();
    }

    public void busCity(){
        if(stats.tickets >= 1){
        player.transform.position = new Vector2(34f,-21f);
        stats.tickets--;
        time.addMinute(45);
        StartCoroutine(transition());
        }
        leave();
    }

    public void leave(){
        volume.enabled = !volume.enabled;
        busMenu.SetActive(false);
        playerMove.enableMovement();
        time.timePaused = false;
    }

    IEnumerator transition(){
        black.SetActive(true);
        yield return new WaitForSeconds(1);
        black.SetActive(false);
    }
}
