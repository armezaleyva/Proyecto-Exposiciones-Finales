using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventHandler : MonoBehaviour
{
    [SerializeField]
    GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        panel.active = false;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
