using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class FoodItem_Mono : MonoBehaviour
{
    [SerializeField] private float cookTime;
    [SerializeField] private SpriteRenderer image;
    [SerializeField] private GameObject burnPrefab;

    public bool isCooking;
    private float timeCooked;
    private bool hasBurned;

    public float cookRemaining;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isCooking)
        {
            Cook();
        }
    }
    private void Cook()
    {
        timeCooked += Time.deltaTime;
        cookRemaining = (cookTime - timeCooked) / cookTime;
        var currentColor = Color.white * cookRemaining;
        currentColor.a = 255;
        image.color = currentColor;

        if (cookRemaining < 0)
        {
            BurnUp();
        }
    }

    private void BurnUp()
    {
        if (!hasBurned)
        {
            hasBurned = true;
            GameObject burnAnim = Instantiate(burnPrefab, gameObject.transform.position, quaternion.identity);
            IEnumerator coroutine = WaitThenDestroy(burnAnim, 1f);
            StartCoroutine(coroutine);
            //Destroy(gameObject);
        }
    }

    private IEnumerator WaitThenDestroy(GameObject objectToDestroy, float delay)
    {
        yield return new WaitForSeconds(delay);
        Debug.Log("DestroyingObject");
        Destroy(objectToDestroy);
        Destroy(gameObject);
        
    }
}
