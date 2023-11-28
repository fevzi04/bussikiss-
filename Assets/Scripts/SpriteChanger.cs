using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteChanger : MonoBehaviour
{

    private Image currentSprite;
    [SerializeField] private Sprite Sprite;
    [SerializeField] private Sprite Sprite1;
    [SerializeField] private Sprite Sprite2;
    [SerializeField] private GameObject player;
    Stats stats;

   
    
    void Start()
    {
        stats = player.GetComponent<Stats>();
        currentSprite = GetComponent<Image>();


    }

    // Update is called once per frame
    void Update()
    {
        if(stats.outfit == 1){
            currentSprite.sprite = Sprite;
        }

        if(stats.outfit == 2){
            currentSprite.sprite = Sprite1;
        }

        if(stats.outfit == 3){
            currentSprite.sprite = Sprite2;
        }
    }



}
