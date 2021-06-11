using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tether : MonoBehaviour
{
    public GameObject humanCharacter;
    public GameObject ghostCharacter;

    public LineRenderer tether;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (humanCharacter != null && ghostCharacter != null)
        {
            tether.SetPosition(0, humanCharacter.transform.position);
            tether.SetPosition(1, ghostCharacter.transform.position);
        }
    }
}
