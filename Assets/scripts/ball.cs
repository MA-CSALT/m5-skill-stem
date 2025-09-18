using UnityEngine;

public class ball : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]Vector3 Velocity = new Vector3 (1f, 1f, 0f);
    [SerializeField] Vector3 acceleration = new Vector3(0f, -1f, 0f);

    Vector2 minScreen, maxScreen;
    void Start()
    {
        minScreen = Camera.main.ScreenToWorldPoint(Vector2.zero);
        maxScreen = Camera.main.ScreenToWorldPoint (new Vector2(Screen.width,Screen.height));
    }

    // Update is called once per frame
    void Update()
    {
        Velocity += acceleration * Time.deltaTime;
        transform.position += Velocity * Time.deltaTime;

        Vector3 temp = transform.position;

        if (temp.y > maxScreen.y)
        {
            Velocity.y = -Mathf.Abs(Velocity.y);
        }

        if (temp.x > maxScreen.x) 
        {
            Velocity.x = -Mathf.Abs(Velocity.x);
        }

        if (temp.y < minScreen.y)
        {
            Velocity.y = Mathf.Abs(Velocity.y);
        }

        if (temp.x < minScreen.x)
        {
            Velocity.x = Mathf.Abs(Velocity.x);
        }

    }
}
