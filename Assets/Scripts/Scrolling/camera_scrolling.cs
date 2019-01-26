using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_scrolling : MonoBehaviour
{
    public float cameraOffSet;

    private GameObject character;
    private float maxPlayerHigh;

    // Start is called before the first frame update
    void Start()
    {
        maxPlayerHigh = this.gameObject.transform.position.y;
        character = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float currentPlayerHigh = character.transform.position.y - cameraOffSet;
        if (currentPlayerHigh > maxPlayerHigh)
        {
            maxPlayerHigh = currentPlayerHigh;
        }

        // Trick allowing to modify current gameObject transform state
        Vector3 camPosCopy = this.gameObject.transform.position;
        camPosCopy.y = maxPlayerHigh;
        this.gameObject.transform.position = camPosCopy;

    }
}
