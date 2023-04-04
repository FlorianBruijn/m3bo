using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class get_hit : MonoBehaviour
{
    public double hp = 100;
    public float max_hp = 100;
    public double damage = 0.05;
    public float slider_value;
    public GameObject parent;
    public ParticleSystem part;
    public List<ParticleCollisionEvent> collisionEvents;
    public Slider slider;
    public float fire_damage = 0.05f;
    public float fire_deplete = 2f;
    public float on_fire;
    public ParticleSystem fire;

    void Start()
    {
        hp = max_hp;
        collisionEvents = new List<ParticleCollisionEvent>();
    }
    [System.Obsolete]
    void Update()
    {
        var emission = fire.emission;
        emission.rateOverTime = on_fire * 2;

        if (on_fire > 0)
        {
            on_fire -= fire_deplete * Time.deltaTime;
            hp -= on_fire * Time.deltaTime;
        }
        slider.value = (float)hp / max_hp;
        if (hp < 0)
        {
            parent.active = false;
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        hp -= damage;
        if (on_fire < 10)
        {
            on_fire += fire_damage;
        }
    }
}
