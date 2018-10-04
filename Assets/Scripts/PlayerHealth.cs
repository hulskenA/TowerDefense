using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    [SerializeField] int healthPoint = 3;
    [SerializeField] Text healthText;

    void Start()
    {
        healthText.text = healthPoint.ToString();
    }

    public void HitPlayer()
    {
        healthPoint--;
        healthText.text = healthPoint.ToString();

        if (healthPoint <= 0)
            ProcessGameOver();
    }

    void ProcessGameOver()
    {
        Debug.Log("x_X");
    }
}
