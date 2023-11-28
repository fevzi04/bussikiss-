using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI money;
    [SerializeField] private TextMeshProUGUI tickets;
    [SerializeField] private TextMeshProUGUI knowledge;
    [SerializeField] private TextMeshProUGUI look;

    private Stats stats;

    private void Start(){
        stats = GetComponent<Stats>();
    }

    public void Update(){
        money.text = stats.money.ToString();
        tickets.text = stats.tickets.ToString();
        knowledge.text = stats.knowledge.ToString();
        look.text = stats.look.ToString();
    }
}
