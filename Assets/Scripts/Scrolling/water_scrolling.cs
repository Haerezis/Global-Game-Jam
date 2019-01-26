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
        Vector3 waterScale = this.gameObject.transform.localScale;
        
        waterScale.y += waterSpeed * Time.deltaTime;
        waterPosition.y += 0.5f * waterSpeed * Time.deltaTime;
        this.gameObject.transform.position = waterPosition;
        this.gameObject.transform.localScale = waterScale;

    }
}
