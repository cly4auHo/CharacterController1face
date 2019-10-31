using UnityEngine;
using UnityEngine.UI;

public class TargetCreator : MonoBehaviour
{
    [SerializeField] private GameObject targtetPrefab;

    private float xLeft = -23f;
    private float xRight = 23f;
    private float zLeft = -23f;
    private float zRight = 23f;
    private float yHeight = 1;

    private GameObject currentTarget;
    private Vector3 currentPosition;

    [SerializeField] private Text scoreText;
    private int score = -1;

    void CreateTarget()
    {
        currentPosition = new Vector3(Random.Range(xLeft, xRight), yHeight, Random.Range(zLeft, zRight));
        currentTarget = Instantiate(targtetPrefab, currentPosition, Quaternion.identity);
    }

    void Update()
    {
        if (!currentTarget)
        {
            CreateTarget();
            score++;
        }

        scoreText.text = score.ToString();
    }

    public void SetScore(int score)
    {
        this.score = score;
    }
}
