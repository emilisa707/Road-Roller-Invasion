using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Slider healthSlider;
    HealthPoint healthPoint;

    // Start is called before the first frame update
    void Start()
    {
        healthPoint = FindObjectOfType<HealthPoint>();
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = healthPoint.currentHp;
    }
}
