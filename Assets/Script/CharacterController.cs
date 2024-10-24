using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
    
{
    [SerializeField] private GameObject bulletWhite;
    [SerializeField] private GameObject bulletRed;
    /*[SerializeField] private ObjectPool bulletPool;*/
    

    // Start is called before the first frame update
    void Start()
    {
        ObjectPool.Instance.CreatePool(bulletWhite, 10); 
        ObjectPool.Instance.CreatePool(bulletRed, 10);


    }

    // Update is called once per frame
    void Update()
    {
        GameObject bullet = null;
        if (Input.GetKeyDown(KeyCode.A))
        {
            bullet = ObjectPool.Instance.getObject(bulletWhite);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            bullet = ObjectPool.Instance.getObject(bulletRed);
        }
        if (bullet != null)
        {
            bullet.transform.position = this.transform.position;
            bullet.SetActive(true);
        }
    }
}
