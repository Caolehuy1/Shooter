using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f; // Tốc độ di chuyển
    public float activeTime = 2f;
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
    private void OnEnable()
    {
        StartCoroutine(HideAfterTime(activeTime));
    }

    private IEnumerator HideAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        gameObject.SetActive(false);
    }
}
