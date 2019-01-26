using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_scrolling : MonoBehaviour
{
    public float playZone;

    private GameObject character;
    private float maxPlayerHigh;
    private float minPlayerHigh;

    // Start is called before the first frame update
    void Start()
    {
        maxPlayerHigh = this.gameObject.transform.position.y + playZone;
        minPlayerHigh = this.gameObject.transform.position.y - playZone;
        character = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float currentPlayerHigh = character.transform.position.y;
        float upperOffSet = currentPlayerHigh - maxPlayerHigh;
        float lowerOffSet = minPlayerHigh - currentPlayerHigh;

        Vector3 camPosCopy = this.gameObject.transform.position;
        if (upperOffSet > 0)
        {
            maxPlayerHigh += upperOffSet;
            camPosCopy.y += upperOffSet;
            minPlayerHigh += upperOffSet;
        }
        else if (lowerOffSet > 0)
        {
            minPlayerHigh -= lowerOffSet;
            camPosCopy.y -= lowerOffSet;
            maxPlayerHigh -= lowerOffSet;
        }
        this.gameObject.transform.position = camPosCopy;
    }
}
