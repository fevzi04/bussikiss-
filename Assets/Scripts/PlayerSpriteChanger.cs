using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteChanger : MonoBehaviour
{
    Animator animator;
    [SerializeField] private RuntimeAnimatorController anim1;
    [SerializeField] private RuntimeAnimatorController anim2;
    [SerializeField] private RuntimeAnimatorController anim3;
    Stats stats;
    void Start()
    {
     stats = GetComponent<Stats>();
     animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if(stats.outfit == 1){
             animator.runtimeAnimatorController = anim1 as RuntimeAnimatorController;       
        }

        if(stats.outfit == 2){
             animator.runtimeAnimatorController = anim2 as RuntimeAnimatorController;  
        }

        if(stats.outfit == 3){
             animator.runtimeAnimatorController = anim3 as RuntimeAnimatorController;  
        }
    }
}
