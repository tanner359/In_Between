﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleBehaviour : MonoBehaviour
{
    public Light pointLight;
    public ParticleSystem particle;
    public float itemZ;

    private void Start()
    {
        itemZ = gameObject.transform.parent.transform.rotation.z;
        pointLight.color = particle.trails.colorOverTrail.color;
    }
    void Update()
    {       
        gameObject.transform.eulerAngles = new Vector3(Mathf.Abs(itemZ) + (-90), -90, 0);
    }           
}
