using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cows : Animals
{
    // Start is called before the first frame update
//POLYMORPHISM - call apetite reduce twice faster than other animals
    public override void ReduceApetite()
    {
        m_maxFeed -= 2;
    }
}
