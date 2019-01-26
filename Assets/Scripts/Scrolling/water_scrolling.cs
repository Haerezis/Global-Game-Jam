using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water_scrolling : MonoBehaviour
{

    public int preparationTime;
    public float waterSpeed;

    // Start is called before the first frame update
    void Start()
    {
        new WaitForSeconds(preparationTime);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 waterPosition = this.gameObject.transform.position;
        Vector3 playerPosition = GameObject.FindWithTag("Player").transform.position;

        float spatialDelay = playerPosition.y - waterPosition.y;

        if (spatialDelay > 100.0)
        {
            waterPosition.y += 3 * waterSpeed * Time.deltaTime;
        }
        else
        {
            waterPosition.y += (0.02f * spatialDelay + 1f) * waterSpeed * Time.deltaTime;
        }

        Debug.Log(spatialDelay);

        this.gameObject.transform.position = waterPosition;

    }
}
