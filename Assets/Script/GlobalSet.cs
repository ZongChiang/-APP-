using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSet : MonoBehaviour
{

    public static int score;
    public static int life = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
 
    public static void Beattack(int ap)
    {
        if (life - ap > 0)
            life = life - ap;
        else
        {
            GameObject.Find("mai char").GetComponent<CharControl>().enabled = false;
            GameObject.Find("mai char").GetComponent<Animator>().SetTrigger("die");
        }
    }
}
