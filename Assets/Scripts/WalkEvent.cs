using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class WalkEvent : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject walkMenu;
    [SerializeField] private GameObject TimeManager;
    [SerializeField] private GameObject black;


    PostProcessVolume volume;
    PlayerMovement playerMove;
    TimeManager time;

    void Start()
    {
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
        walkMenu.SetActive(true);
        playerMove.disableMovement();
        time.timePaused = true;
    }

    public void walkCompany(){
        player.transform.position = new Vector2(-22.5f,-20f);
        time.addMinute(90);
        StartCoroutine(transition());
        leave();
    }

    public void walkHome(){
        player.transform.position = new Vector2(14,1);
        time.addMinute(90);
        StartCoroutine(transition());
        leave();
    }

    public void walkCity(){
        player.transform.position = new Vector2(32,-21);
        time.addMinute(90);
        StartCoroutine(transition());
        leave();
    }

    public void leave(){
        volume.enabled = !volume.enabled;
        walkMenu.SetActive(false);
        playerMove.enableMovement();
        time.timePaused = false;
    }

    IEnumerator transition(){
        black.SetActive(true);
        yield return new WaitForSeconds(1);
        black.SetActive(false);
    }
}
