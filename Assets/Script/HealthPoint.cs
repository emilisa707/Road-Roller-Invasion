using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPoint : MonoBehaviour
{
    public int startingHP = 100;
    public int currentHp;
    // Start is called before the first frame update
    void Start()
    {
        currentHp = startingHP;
    }
}
