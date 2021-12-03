using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, .75f);
    }

    void Update()
    {
        transform.localScale += new Vector3(.1f, .1f, .1f) * Time.deltaTime;
    }
}
