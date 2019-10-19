using UnityEngine;

public class Fireball : MonoBehaviour
{
    private PlayerCharacter player;
    [SerializeField] private float speed = 15.0f;
    private int damage = 1;

    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        player = other.GetComponent<PlayerCharacter>();

        if (player)
        {          
            player.Hurt(damage);
        }
        Destroy(gameObject);
    }
}
