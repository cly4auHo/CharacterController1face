using System.Collections;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    private Camera camera;
    private Vector3 point;
    private Ray ray;
    private GameObject sphere;
    private GameObject hitObject;
    private ReactiveTarget target;

    private int size = 12;
    private float posX;
    private float posY;
 
    void Start()
    {
        camera = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !sphere)
        {
            point = new Vector3(camera.pixelWidth / 2, camera.pixelHeight / 2, 0); // center of the screen
            ray = camera.ScreenPointToRay(point);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                hitObject = hit.transform.gameObject;
                target = hitObject.GetComponent<ReactiveTarget>();

                if (target)
                {
                    target.ReactToHit();
                }
                else
                {
                    StartCoroutine(SphereIndicator(hit.point));
                }
            }
        }
    }

    private IEnumerator SphereIndicator(Vector3 pos)
    {
        sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;

        yield return new WaitForSeconds(0.3f);
        Destroy(sphere);
    }

    void OnGUI()
    {
        posX = camera.pixelWidth / 2 - size / 4;
        posY = camera.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "*"); // show a symbol on screen
    }
}
