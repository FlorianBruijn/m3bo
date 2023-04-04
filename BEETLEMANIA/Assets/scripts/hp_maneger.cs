using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hp_maneger : MonoBehaviour
{
    public float hp;
    public float max_hp = 100f;
    public Slider hp_bar;

    // Start is called before the first frame update
    void Start()
    {
        hp = max_hp;
    }

    // Update is called once per frame
    void Update()
    {
        hp_bar.value = hp / max_hp;
    }
}
