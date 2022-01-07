using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Creature : MonoBehaviour
{
    [SerializeField] private int _sample = 66;
    [SerializeField] private int _sample2 = 123;

    
    protected abstract void GetBombEffect();
}