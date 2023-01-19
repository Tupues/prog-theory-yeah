using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animals : MonoBehaviour
{
    public int feedCycle { get; } = 10;
    /* public static int cleanCycle { get; } = 24;
     public static int playCycle { get; } = 10;
     public static int sleepCycle { get; } = 18;*/
    protected float m_maxFeed = 10.0f;
    protected GameManager gameManagerRef;
    //ENCAPSULATION - maxFeed cannot be below zero
    public float maxFeed
    {
        get { return m_maxFeed; }
        set
        {
            if (value < 0)
            {
                return;
            }
            else
            {
                m_maxFeed = value;
            }
        }
    }

    public void Start()
    {
        StartCoroutine("DiminishValues");
        gameManagerRef = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    public virtual void ReduceApetite()
    {
        m_maxFeed -= 1;
    }

    IEnumerator DiminishValues()
    {
        while (m_maxFeed > 0)
        {
            yield return new WaitForSeconds(3);
            ReduceApetite();
            print(gameObject.name + "apetite is " + m_maxFeed);
            gameManagerRef.UpdateLabels();
        }
        
    }
}
