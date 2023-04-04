using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shooting : MonoBehaviour
{
    public float feul = 100f;
    public float max_feul = 100f;
    public float feul_rate = 1f;
    public AudioSource flames;
    private ParticleSystem particle_System;
    public Slider slider;
    void Start()
    {
        particle_System = GetComponent<ParticleSystem>();
    }


    void Update()
    {
        slider.value = feul / max_feul;
        if (Input.GetMouseButtonDown(0) && feul > 0)
        {
            flames.Play();
        }
        if (Input.GetMouseButton(0) && feul > 0)
        {
            var emission = particle_System.emission;
            emission.rateOverTime = 40;
            feul -= feul_rate;
        }
        else
        {
            var emission = particle_System.emission;
            emission.rateOverTime = 0;
            flames.Pause();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {

            feul = max_feul;
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            max_feul += 10;
        }
    }
}
