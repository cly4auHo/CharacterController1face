using System.Collections;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    private WanderingAI behavior;
    
    public void ReactToHit()
    {
        behavior = GetComponent<WanderingAI>();

        if (behavior)
        {
            behavior.SetIsAlive(false);
        }
        StartCoroutine(Die());
    }

    private IEnumerator Die()
    {       
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    } 
}
