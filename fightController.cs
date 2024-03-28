using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class fightController : MonoBehaviour
{
    public GameObject monster;
    public GameObject startPosition;
    // Start is called before the first frame update
    void Start()
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
            Vector3.MoveTowards(this.gameObject, GameObject.monster, 5.0);
            Vector3.MoveTowards(this.gameObject, startPosition, 5.0);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

}
