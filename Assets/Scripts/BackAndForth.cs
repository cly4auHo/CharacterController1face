using UnityEngine;

public class BackAndForth : MonoBehaviour
{
    private float speed = 3.0f;
    private float maxZ = 10.0f;
    private float minZ = -10.0f;

    private int direction = 1;

    void Update() //ball with partickls
    {
        transform.Translate(0, 0, direction * speed * Time.deltaTime);

        if (transform.position.z > maxZ || transform.position.z < minZ)
        {
            direction = -direction;
        }
    }
}