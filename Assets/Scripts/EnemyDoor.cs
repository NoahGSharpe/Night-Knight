using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDoor : MonoBehaviour
{
    public List<GameObject> enemies;
    // Update is called once per frame
    void Update()
    {
         if (enemies.Exists(x => x.GetComponent<Animator>().GetBool("Death") == false))
        {
            gameObject.GetComponent<Animator>().SetBool("Open", false);
        }
         else
        {
            gameObject.GetComponent<Animator>().SetBool("Open", true);
        }

    }
}
