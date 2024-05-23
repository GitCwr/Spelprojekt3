using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farm : MonoBehaviour
{
    public int goldIncrease;

    public float timeBtwIncreases;
    private float nextIncreaseTime;

    private GameManager gm;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if(Time.time > nextIncreaseTime)
        {
            nextIncreaseTime = Time.time + timeBtwIncreases;
            gm.gold += goldIncrease;
        }
    }
}
