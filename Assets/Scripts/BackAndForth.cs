using UnityEngine;

public class BackAndForth : MonoBehaviour
{
    private float speed = 3.0f;
    private float maxZ = 10.0f;
    private float minZ = -10.0f;

    private int direction = 1;
    private bool bounced;

    void Update()
    {
        transform.Translate(0, 0, direction * speed * Time.deltaTime);

        bounced = false;

        if (transform.position.z > maxZ || transform.position.z < minZ)
        {
            direction = -direction;
            bounced = true;
        }

        if (bounced)
        {
            transform.Translate(0, 0, direction * speed * Time.deltaTime);
        }
    }
}