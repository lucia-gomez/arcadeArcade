using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextController : MonoBehaviour
{
    public int score = 0;
    private GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        text = GameObject.Find("restoredText");
        text.SetActive(false);
    }

    public void ActivateSelf() {
        text.SetActive(true);
    }
}
